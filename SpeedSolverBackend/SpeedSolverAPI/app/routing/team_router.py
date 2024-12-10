from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session


from app.database.database import get_session
from app.services.team_service import TeamService
from app.routing.security.jwtmanager import oauth2_scheme
team_router = APIRouter(prefix="/team", tags=["Team"])


@team_router.get("/create")
async def create_team(token: str = Depends(oauth2_scheme), session: Session = Depends(get_session)):
    ...