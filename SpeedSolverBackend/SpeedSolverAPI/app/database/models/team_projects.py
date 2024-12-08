from sqlalchemy import ForeignKey
from .base import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid


class TeamProject(Base):
    __tablename__ = "team_projects"

    teamProjectId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    teamId: Mapped[UUID] = mapped_column(ForeignKey("teams.teamId"))
    projectId: Mapped[UUID] = mapped_column(ForeignKey("projects.projectId"))
    team: Mapped["Team"] = relationship("Team", back_populates="projects") # type: ignore
    project: Mapped["Project"] = relationship("Project", back_populates="teams") # type: ignore
    