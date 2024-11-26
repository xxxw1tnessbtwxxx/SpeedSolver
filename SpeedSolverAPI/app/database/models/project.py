from sqlalchemy.orm import declarative_base
import datetime
import uuid
from sqlalchemy import ForeignKey
from sqlalchemy import Integer, String
from sqlalchemy.orm import (
    mapped_column,
    Mapped,
    relationship,
)

from sqlalchemy.dialects.postgresql import UUID, DATE
from .base import Base

class Project(Base):
    __tablename__ = "projects"

    projectId: Mapped[UUID] = mapped_column(UUID, primary_key=True, default=uuid.uuid4)
    projectName: Mapped[str] = mapped_column(nullable=False)
    projectDescription: Mapped[str] = mapped_column(nullable=True)