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

class ProjectObjectives(Base):
    __tablename__ = "projects_objectives"
    projectObjectiveId: Mapped[UUID] = mapped_column(UUID, nullable=False, default=uuid.uuid4)
    projectId: Mapped[UUID] = mapped_column(UUID, nullable=False)
    objectiveId: Mapped[UUID] = mapped_column(UUID, nullable=False)