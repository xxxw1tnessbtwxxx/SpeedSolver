
from app.database.repo.user_repository import UserRepository
from sqlalchemy.orm import Session
from app.schema.request.get_access import authorize, register
class UserService:

    def __init__(self, session: Session):
        self._repo: UserRepository = UserRepository(session)


    async def register(self, register_request: register.RegisterRequest):
        user = await self._repo.get_by_filter_one(email=register_request.email)