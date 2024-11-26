from app.schema.authorize import GetServiceRequest
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User
from sqlalchemy import select, update, insert, delete
from ..models.user_profile import UserProfile
class UserRepository(AbstractRepository):
    model = User

    async def authorize(self, creds: GetServiceRequest):
        return await self.get_by_filter_one(login=creds.login, password=creds.password)
    
    async def register(self, creds: GetServiceRequest):
        return await self.create(login=creds.login, password=creds.password, email=creds.email)
    
    async def get_by_login(self, login: str):
        result = self._session.execute(
            select(self.model)
            .join(UserProfile, self.model.userId == UserProfile.userId)
            .where(self.model.login == login)
            )
        return result.scalars().all()