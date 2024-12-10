
from sqlalchemy.exc import IntegrityError
from app.database.repo.user_repository import UserRepository
from sqlalchemy.orm import Session
from app.schema.request.get_access import authorize, register
from app.utils.result import Result
from app.routing.security.hasher import hash_password, verify_password
from app.routing.security.jwtmanager import JWTManager
from app.utils.logger.logger import logger, log_info_with_separator

class UserService:

    def __init__(self, session: Session):
        self._repo: UserRepository = UserRepository(session)


    async def register(self, register_request: register.RegisterRequest) -> Result[None]:
        try:
            user = await self._repo.create(email=register_request.email, password=hash_password(register_request.password))
            return Result(success=True, value=user)
        except IntegrityError:
            return Result(success=False, error="User already exists")
        except Exception as e: 
            log_info_with_separator(str(e))
            return Result(success=False, error="Some error while attemping resource.")
        
    async def authorize(self, session: Session, email: str, password: str) -> Result[None]:
        authenticated: Result = await UserRepository(session).authenticate_user(email, password)
        if authenticated.error:
            return Result(success=False, error=authenticated.error)
        
        payload: dict = {
            "userId": str(authenticated.value.userId),
            "email": authenticated.value.email
        }

        token = JWTManager().encode_token(payload)
        return Result(success=True, value=token)
