import datetime
from typing import List

import uuid

from sqlalchemy import Column, Integer, String, Boolean, Date, BigInteger
from sqlalchemy import ForeignKey
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship, mapped_column, Mapped, declarative_base

Base = declarative_base()
class User(Base):
    __tablename__ = "users"
    userId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    login: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    password: Mapped[str] = mapped_column(String(255), nullable=False)
    registered: Mapped[datetime.date] = mapped_column(Date, nullable=False, default=datetime.date.today())
    profile: Mapped["UserProfile"] = relationship("UserProfile", back_populates="user")
    teams: Mapped[List["Team"]] = relationship("Team", back_populates="creator")

class UserProfile(Base):
    __tablename__ = "profiles"
    userProfileId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    user_id: Mapped[int] = mapped_column(ForeignKey("users.userId"), nullable=False)
    user: Mapped[User] = relationship("User", back_populates="profile")
    

class Team(Base):
    __tablename__ = "teams"
    teamId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    teamName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    teamDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    createdAt: Mapped[Date] = mapped_column(Date, nullable=False, default=datetime.date.today())
    creatorId: Mapped[int] = mapped_column(ForeignKey("users.userId"), nullable=False)
    creator: Mapped["User"] = relationship("User", back_populates="teams")

    projects: Mapped["TeamProject"] = relationship("TeamProject")

class GeneralObjective(Base):
    __tablename__ = "general_objectives"
    generalObjectiveId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    generalObjectiveName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    generalObjectiveDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    underObjectives: Mapped[List["UnderObjective"]] = relationship("UnderObjective", back_populates="generalObjective")

class UnderObjective(Base):
    __tablename__ = "under_objectives"
    underObjectiveId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    underObjectiveName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    underObjectiveDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    generalObjectiveId: Mapped[int] = mapped_column(ForeignKey("general_objectives.generalObjectiveId"), nullable=False)
    generalObjective: Mapped["GeneralObjective"] = relationship("GeneralObjective", back_populates="underObjectives")

class Project(Base):
    __tablename__ = "projects"
    projectId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    projectTitle: Mapped[str] = mapped_column(String(50), unique=True)
    projectDescription: Mapped[str] = mapped_column()
    tasks: Mapped[List["ProjectTask"]] = relationship("ProjectTask", back_populates="project")
    
class ProjectTask(Base): 
    __tablename__ = "project_objectives"
    projectTaskId: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
    generalObjectiveId: Mapped[UUID] = mapped_column(ForeignKey("general_objectives.generalObjectiveId"))
    projectId: Mapped[UUID] = mapped_column(ForeignKey("projects.projectId"))
    project: Mapped["Project"] = relationship("Project", back_populates="tasks") 

class TeamProject(Base):
    __tablename__ = "team_projects"
    teamProjectid: Mapped[UUID] = mapped_column(primary_key=True, default=uuid.uuid4)
