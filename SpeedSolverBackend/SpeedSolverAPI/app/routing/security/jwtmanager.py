from fastapi import Depends, HTTPException
from fastapi.security import OAuth2PasswordBearer
import jwt
from app.cfg.settings import settings
from app.database.repo.user_repository import UserRepository
from app.database.database import get_session
from app.utils.result import Result
from app.routing.security.hasher import verify_password

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")

class JWTManager:
    
    def __init__(self):
        self.SECRET_KEY = settings.JWT_SECRET_KEY
        self.ALGORITHM = settings.JWT_ALGORITHM
        self.EXPIRES_AT = settings.JWT_EXPIRES_AT

    @classmethod
    def encode_token(self, payload: dict):
        jwt_payload = payload.copy().update({"exp": self.EXPIRES_AT * 60})
        return jwt.encode(jwt_payload, self.SECRET_KEY, algorithm=self.ALGORITHM)
    
    
    @classmethod
    def decode_token(token: str) -> dict:
        return jwt.decode(token, settings.JWT_SECRET_KEY, algorithms=[settings.JWT_ALGORITHM])
    
    @classmethod
    async def get_current_user(self, token: str = Depends(oauth2_scheme)):
        credentials_exception = HTTPException(
            status_code=401,
            detail="Could not validate credentials",
            headers={"WWW-Authenticate": "Bearer"},
        )
        try:
            payload = jwt.decode(token, self.SECRET_KEY, algorithms=[self.ALGORITHM])
            username: str = payload.get("sub")
            if username is None:
                raise credentials_exception
            token_data = TokenData(username=username)
        except JWTError:
            raise credentials_exception
        user = get_user(fake_users_db, username=token_data.username)
        if user is None:
            raise credentials_exception
        return user