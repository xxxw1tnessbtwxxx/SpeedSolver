from sqlalchemy import ForeignKey
from .base import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid


class Objective(Base):
    __tablename__ = "objectives"

    objectiveId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    title: Mapped[str] = mapped_column()
    description: Mapped[str] = mapped_column(nullable=True)

    parent_objective: Mapped["Objective"] = relationship("Objective", back_populates="child_objectives", remote_side=[objectiveId])
    child_objectives: Mapped[list["Objective"]] = relationship("Objective", back_populates="parent_objective")