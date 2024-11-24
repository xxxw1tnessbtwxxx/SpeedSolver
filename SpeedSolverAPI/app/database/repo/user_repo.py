from app.schema.authorize import GetServiceRequest
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User


class UserRepository(AbstractRepository):
    model = User

    async def authorize(self, creds: GetServiceRequest):
        return await self.get_by_filter_one(login=creds.login, password=creds.password)
    
    async def register(self, creds: GetServiceRequest):
        return await self.create(login=creds.login, password=creds.password, email=creds.email)