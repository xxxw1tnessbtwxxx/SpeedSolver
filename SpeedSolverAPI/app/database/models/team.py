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

class Team(Base):
    __tablename__ = "teams"

    teamId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    teamMame: Mapped[str] = mapped_column(nullable=True)
    teamDescription: Mapped[str] = mapped_column(nullable=True)
    createdAt: Mapped[Date] = mapped_column(Date, nullable=True, default=datetime.date.today())
