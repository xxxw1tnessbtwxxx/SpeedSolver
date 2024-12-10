from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session


from app.database.database import get_session
from app.services.team_service import TeamService
team_router = APIRouter(prefix="/team", tags=["Team"])


@team_router.get("/create")
async def create_team(session: Session = Depends(get_session)):
    creating = TeamService(session).create_team()