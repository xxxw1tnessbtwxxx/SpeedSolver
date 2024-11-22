import datetime
from typing import List

import uuid

from sqlalchemy import Integer, String, Date, BigInteger
from sqlalchemy import ForeignKey
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship, mapped_column, Mapped, declarative_base

Base = declarative_base()

class User(Base):
    __tablename__ = "users"
    userId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    login: Mapped[str] = mapped_column(String(50), nullable=False, unique=True)
    password: Mapped[str] = mapped_column(String(255), nullable=False)
    email: Mapped[str] = mapped_column(String(255), nullable=False, unique=True)
    registered: Mapped[Date] = mapped_column(Date, default=datetime.date.today())

    profile: Mapped["UserProfile"] = relationship("UserProfile", back_populates="user")

class UserProfile(Base):
    __tablename__ = "profiles"
    userProfileId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    userId: Mapped[UUID] = mapped_column(ForeignKey("users.userId"), nullable=False)
    name: Mapped[str] = mapped_column(String(50), nullable=False)
    surname: Mapped[str] = mapped_column(String(50), nullable=False)
    patronymic: Mapped[str] = mapped_column(String(50), nullable=False)
    age: Mapped[int] = mapped_column(Integer)

    user: Mapped["User"] = relationship("User", back_populates="profile")



    