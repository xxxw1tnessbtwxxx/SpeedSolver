from sqlalchemy.orm import Session
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User

from app.schema.get_access import register, authorize

from sqlalchemy import select, update, insert

class UserRepository(AbstractRepository):
    model = User

    def __init__(self, session: Session):
        self._session = session

    async def register(self, register: register.RegisterRequest):
        query = (
            select(self.model)
            .where(self.model.email == register.email)
        )

        result = self._session.execute(query)
        user = result.scalars().first()

        if user:
            raise Exception("User already exists")

        return await self.create(email=register.email, password=register.password)
    
    async def authorize(self, authorize: authorize.AuthorizeRequest):
        query = (
            select(self.model)
            .where(self.model.email == authorize.email)
            .where(self.model.password == authorize.password)
        )

        result = self._session.execute(query)
        user = result.scalars().first()
        return user