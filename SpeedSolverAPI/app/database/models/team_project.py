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

class TeamProject(Base):
    __tablename__ = "teams_projects"
    teamProjectId: Mapped[UUID] = mapped_column(UUID, primary_key=True, nullable=False, default=uuid.uuid4)
    teamId: Mapped[UUID] = mapped_column(ForeignKey("teams.teamId"))
    projectId: Mapped[UUID] = mapped_column(ForeignKey("projects.projectId"))