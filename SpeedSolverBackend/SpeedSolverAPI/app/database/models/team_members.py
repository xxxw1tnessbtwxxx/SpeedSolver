from sqlalchemy import ForeignKey
from .base import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid



class TeamMember(Base):
    __tablename__ = "team_members"
    teamMemberId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    userId: Mapped[UUID] = mapped_column(ForeignKey("users.userId"))
    teamId: Mapped[UUID] = mapped_column(ForeignKey("teams.teamId"))

    team: Mapped["Team"] = relationship("Team", back_populates="members") # type: ignore
    user: Mapped["User"] = relationship("User", back_populates="teams") # type: ignore