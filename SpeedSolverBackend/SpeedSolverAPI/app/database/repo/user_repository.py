from sqlalchemy.orm import Session
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User

<<<<<<< HEAD
from sqlalchemy import select, update, insert

class UserRepository(AbstractRepository):
    model = User
=======
from app.routing.security.cryptography import hash_password

from app.schema.get_access.register import RegisterRequest

from sqlalchemy import and_, select, update, insert

class UserRepository(AbstractRepository):
    model = User

    def __init__(self, session: Session):
        self._session = session

    async def register(self, register: RegisterRequest):
        query = (
            select(self.model)
            .where(self.model.email == register.email)
        )

        result = self._session.execute(query)
        user = result.scalars().first()

        if user:
            raise Exception("User already exists")

        registered = await self.create(email=register.email, password=hash_password(register.password))
        return registered.userId

    async def authorize(self, login: str, password: str) -> str:
        query = (
            select(self.model)
            .where(and_(
                self.model.email == login,
                self.model.password == hash_password(password)
                ))
        )

        result = self._session.execute(query)
        user = result.scalars().first()
        if not user:
            raise Exception("Wrong credentialls")

        
>>>>>>> e03ca8dc984babbd26e3731a014912049581482f
