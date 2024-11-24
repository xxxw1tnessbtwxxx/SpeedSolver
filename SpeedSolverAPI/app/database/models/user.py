from sqlalchemy.orm import declarative_base
import datetime
import uuid
from sqlalchemy import ForeignKey
from sqlalchemy import Integer, String
from sqlalchemy.orm import (
    mapped_column,
    Mapped,
    relationship,
)

from sqlalchemy.dialects.postgresql import UUID, DATE
from .base import Base

class User(Base):
    __tablename__ = "users"
    userId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    login: Mapped[str] = mapped_column()
    password: Mapped[str] = mapped_column()
    email: Mapped[str] = mapped_column(nullable=True)
    registered: Mapped[DATE] = mapped_column(DATE, default=datetime.date.today(), nullable=True)