
from sqlalchemy.exc import IntegrityError
from app.database.repo.user_repository import UserRepository
from sqlalchemy.orm import Session
from app.schema.request.get_access import authorize, register
from app.utils.result import Result
from app.routing.security.cryptography import hash_password, verify_password
class UserService:

    def __init__(self, session: Session):
        self._repo: UserRepository = UserRepository(session)


    async def register(self, register_request: register.RegisterRequest) -> Result[None]:
        try:
            user = await self._repo.create(email=register_request.email, password=hash_password(register_request.password))
            return Result(success=True, value=user)
        except IntegrityError as e:
            return Result(success=False, error="User already exists")
        except Exception as e:
            return Result(success=False, error="Some error while attemping resource.")