from typing import List
from sqlalchemy import ForeignKey
from .base import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid

class Organization(Base):
    __tablename__ = "organizations"
    organizationId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    title: Mapped[str] = mapped_column()
    description: Mapped[str] = mapped_column(nullable=True)

    teams: Mapped[List["Team"]] = relationship("Team", back_populates="organization") # type: ignore