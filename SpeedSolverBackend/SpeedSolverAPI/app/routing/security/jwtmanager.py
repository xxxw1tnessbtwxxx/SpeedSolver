from datetime import timedelta
import datetime
from fastapi import Depends, HTTPException
from fastapi.security import OAuth2PasswordBearer

import jwt

from sqlalchemy.orm import Session

from app.cfg.settings import settings
from app.database.repo.user_repository import UserRepository
from app.database.database import get_session
from app.utils.result import Result
from app.utils.logger.logger import logger
from app.routing.security.hasher import verify_password

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="/v1/access/authorize")

class JWTManager:

    def __init__(self):
        self.SECRET_KEY = settings.JWT_SECRET_KEY
        self.ALGORITHM = settings.JWT_ALGORITHM
        self.EXPIRES_AT = settings.JWT_EXPIRES_AT

    def encode_token(self, payload):
        jwt_payload = payload.copy()
        print(jwt_payload)
        jwt_payload.update({"exp": datetime.datetime.utcnow() + timedelta(hours=self.EXPIRES_AT)})
        return jwt.encode(jwt_payload, self.SECRET_KEY, algorithm=self.ALGORITHM)
    
    
    def decode_token(self, token: str) -> dict:
        return jwt.decode(token, settings.JWT_SECRET_KEY, algorithms=[settings.JWT_ALGORITHM])
    
    async def get_current_user(self, token: str = Depends(oauth2_scheme), session: Session = Depends(get_session)):
        logger.info("asjkaskjdasjk")
        credentials_exception = HTTPException(
            status_code=401,
            detail="Could not validate credentials",
            headers={"WWW-Authenticate": "Bearer"},
        )
        
        payload = self.decode_token(token)
        logger.info(payload)
        username: str = payload.get("userId")
        logger.info(username)
        if username is None:
            logger.warning("user is none")
            raise credentials_exception
        
        user = await UserRepository(session).get_by_filter_one(userId=username)
        if user is None:
            logger.info("user is none")
            raise credentials_exception
        return user