from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session

from app.database.repo.team_repository import TeamRepository

from app.database.database import get_session
from app.schema.create_team import CreateTeam
team_router = APIRouter(prefix="/team", tags=["Team"])

@team_router.post("/createTeam")
async def create_team(team: CreateTeam, session: Session = Depends(get_session)):
    return await TeamRepository(session).create_team(team)