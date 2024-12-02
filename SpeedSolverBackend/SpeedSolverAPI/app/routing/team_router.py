from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session


from app.database.database import get_session
from app.schema.create_team import CreateTeam
team_router = APIRouter(prefix="/team", tags=["Team"])