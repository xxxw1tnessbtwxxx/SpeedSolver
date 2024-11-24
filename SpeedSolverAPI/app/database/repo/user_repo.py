from app.schema.authorize import Authorize
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User


class UserRepository(AbstractRepository):
    model = User

    async def authorize(self, creds: Authorize):
        return await self.get_by_filter_one(login=creds.login, password=creds.password)