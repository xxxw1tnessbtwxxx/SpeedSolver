from sqlalchemy import ForeignKey
from .base import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid


class Team(Base):
    __tablename__ = "teams"
    teamId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    title: Mapped[str] = mapped_column()
    description: Mapped[str] = mapped_column(nullable=True)
    organizationId: Mapped[UUID] = mapped_column(ForeignKey("organizations.organizationId"), nullable=True)

    organization: Mapped["Organization"] = relationship("Organization", back_populates="teams") # type: ignore
    members: Mapped[list["TeamMember"]] = relationship("TeamMember", back_populates="team") # type: ignore
    projects: Mapped[list["TeamProject"]] = relationship("TeamProject", back_populates="team") # type: ignore
