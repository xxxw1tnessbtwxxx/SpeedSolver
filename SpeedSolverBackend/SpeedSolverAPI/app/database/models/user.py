from typing import List
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
    email: Mapped[str] = mapped_column(nullable=True)
    password: Mapped[str] = mapped_column()
    registered: Mapped[DATE] = mapped_column(DATE, default=datetime.date.today(), nullable=True)

    profile: Mapped["UserProfile"] = relationship("UserProfile", back_populates="user") # type: ignore
    teams: Mapped[List["Team"]] = relationship("Team", back_populates="user") # type: ignore