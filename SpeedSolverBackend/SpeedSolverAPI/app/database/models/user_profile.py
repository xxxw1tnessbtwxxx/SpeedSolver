from sqlalchemy.orm import declarative_base
import datetime
import uuid
from sqlalchemy import Date, ForeignKey
from sqlalchemy import Integer, String
from sqlalchemy.orm import (
    mapped_column,
    Mapped,
    relationship,
)

from sqlalchemy.dialects.postgresql import UUID, DATE
from .base import Base

class UserProfile(Base):
    __tablename__ = "user_profiles"
    userProfileId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    surname: Mapped[str] = mapped_column(nullable=True)
    name: Mapped[str] = mapped_column(nullable=True)
    patronymic: Mapped[str] = mapped_column(nullable=True)
    birthdate: Mapped[Date] = mapped_column(Date, nullable=True, default=datetime.date.today())
    userId: Mapped[UUID] = mapped_column(ForeignKey("users.userId"))

    user: Mapped["User"] = relationship("User", back_populates="profile") # type: ignore