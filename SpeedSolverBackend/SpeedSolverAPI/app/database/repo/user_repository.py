from sqlalchemy.orm import Session

from app.routing.security.hasher import verify_password
from app.utils.result import Result
from ..abstract.abc_repo import AbstractRepository
from app.database.models.models import User

from sqlalchemy import select, update, insert

class UserRepository(AbstractRepository):
    model = User

    async def authenticate_user(self, email: str, password: str) -> Result:
        user = await UserRepository(self._session).get_by_filter_one(email=email)
        if not user:
            return Result(success=False, error="User not found")
        if not verify_password(password, user.password):
            return Result(success=False, error="Invalid password")
        return Result(success=True, value=user)