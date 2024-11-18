import datetime
from typing import List
from sqlalchemy import Column, Integer, String, Boolean, Date
from sqlalchemy import ForeignKey
from sqlalchemy.orm import relationship, mapped_column, Mapped, declarative_base

Base = declarative_base()
class User(Base):
    __tablename__ = "users"
    userId: Mapped[int] = mapped_column(primary_key=True)
    login: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    password: Mapped[str] = mapped_column(String(255), nullable=False)
    registered: Mapped[datetime.date] = mapped_column(Date, nullable=False, default=datetime.date.today())
    profile: Mapped["UserProfile"] = relationship("UserProfile", back_populates="user")
    teams: Mapped[List["Team"]] = relationship("Team", back_populates="creator")

class UserProfile(Base):
    __tablename__ = "profiles"
    userProfileId: Mapped[int] = mapped_column(primary_key=True)
    user_id: Mapped[int] = mapped_column(ForeignKey("users.userId"), nullable=False)
    user: Mapped[User] = relationship("User", back_populates="profile")
    

class Team(Base):
    __tablename__ = "teams"
    teamId: Mapped[int] = mapped_column(primary_key=True)
    teamName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    teamDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    createdAt: Mapped[Date] = mapped_column(Date, nullable=False, default=datetime.date.today())
    creatorId: Mapped[int] = mapped_column(ForeignKey("users.userId"), nullable=False)
    creator: Mapped["User"] = relationship("User", back_populates="team")

class GeneralObjective(Base):
    __tablename__ = "general_objectives"
    generalObjectiveId: Mapped[int] = mapped_column(primary_key=True)
    generalObjectiveName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    generalObjectiveDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    underObjectives: Mapped[List["UnderObjective"]] = relationship("UnderObjective", back_populates="generalObjective")

class UnderObjective(Base):
    __tablename__ = "under_objectives"
    underObjectiveId: Mapped[int] = mapped_column(primary_key=True)
    underObjectiveName: Mapped[str] = mapped_column(String(50), unique=True, nullable=False)
    underObjectiveDescription: Mapped[str] = mapped_column(String(255), nullable=False)
    generalObjectiveId: Mapped[int] = mapped_column(ForeignKey("general_objectives.generalObjectiveId"), nullable=False)
    generalObjective: Mapped["GeneralObjective"] = relationship("GeneralObjective", back_populates="underObjectives")

class TeamObjective(Base):
    __tablename__ = "team_objectives"
    teamObjectiveId: Mapped[int] = mapped_column(primary_key=True)
    generalObjectiveId: Mapped[int] = mapped_column(ForeignKey("general_objectives.generalObjectiveId"), nullable=False)
    generalObjective: Mapped["GeneralObjective"] = relationship("GeneralObjective")
