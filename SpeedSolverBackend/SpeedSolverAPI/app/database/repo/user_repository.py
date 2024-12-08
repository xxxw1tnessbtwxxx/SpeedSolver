from sqlalchemy.orm import Session
from ..abstract.abc_repo import AbstractRepository
from ..models.user import User

from sqlalchemy import select, update, insert

class UserRepository(AbstractRepository):
    model = User