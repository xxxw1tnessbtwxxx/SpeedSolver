from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session


from app.database.database import get_session
team_router = APIRouter(prefix="/team", tags=["Team"])
