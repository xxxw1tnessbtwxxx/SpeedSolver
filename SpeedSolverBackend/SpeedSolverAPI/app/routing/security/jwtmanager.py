import jwt
from app.cfg.settings import settings
class JWTManager:
    
    def __init__(self):
        self.SECRET_KEY = settings.JWT_SECRET_KEY
        self.ALGORITHM = settings.JWT_ALGORITHM
        self.EXPIRES_AT = settings.JWT_EXPIRES_AT

    @classmethod
    def encode_token(self, payload: dict):
        exp = payload.copy().update({"exp": self.EXPIRES_AT * 60})
        return jwt.encode(payload, self.SECRET_KEY, algorithm=self.ALGORITHM)