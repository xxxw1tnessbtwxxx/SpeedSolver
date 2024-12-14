from datetime import timedelta
import datetime
from fastapi import Depends, HTTPException
from fastapi.security import OAuth2PasswordBearer

from jwt import encode, decode


from sqlalchemy.orm import Session

from app.cfg.settings import settings
from app.database.repo.user_repository import UserRepository
from app.database.database import get_session

from app.utils.result import Result, err, success
from app.utils.logger.logger import logger

from app.routing.security.hasher import verify_password
from app.routing.security.jwttype import JWTType

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="/v1/access/authorize")

class JWTManager:

    def __init__(self):
        self.SECRET_KEY = settings.JWT_SECRET_KEY
        self.ALGORITHM = settings.JWT_ALGORITHM
        self.ACCESS_TOKEN_LIFETIME = settings.JWT_ACCESS_TOKEN_LIFETIME_MINUTES
        self.REFRESH_TOKEN_LIFETIME = settings.JWT_REFRESH_TOKEN_LIFETIME_HOURS

    def encode_token(self, payload, token_type: JWTType = JWTType.ACCESS):
        jwt_payload = payload.copy()

        current_time = datetime.datetime.utcnow()
        expire = timedelta(minutes=self.ACCESS_TOKEN_LIFETIME) if token_type == JWTType.ACCESS else timedelta(hours=self.REFRESH_TOKEN_LIFETIME)
        jwt_payload.update({"exp": current_time + expire})
        return encode(jwt_payload, self.SECRET_KEY, algorithm=self.ALGORITHM)
    
    def decode_token(self, token: str) -> Result[dict]:
        try:
            return success(decode(token, self.SECRET_KEY, algorithms=[self.ALGORITHM]))
        except:
            return err("Invalid token")
    
    async def get_current_user(self, token: str, session: Session):
        
        payload = self.decode_token(token)
        username: str = payload.get("userId")
        if username is None:
            raise HTTPException(
            status_code=401,
            detail="Could not validate credentials",
            headers={"WWW-Authenticate": "Bearer"},
        )
        
        user = await UserRepository(session).get_by_filter_one(userId=username)
        if user is None:
            raise HTTPException(
                status_code=401,
                detail="User not found",
                headers={"WWW-Authenticate": "Bearer"},
            )
        return user