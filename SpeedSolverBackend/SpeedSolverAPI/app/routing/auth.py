from fastapi import APIRouter, Depends

from ..schema.authorize import GetServiceRequest
from ..schema.response.UserRegister import UserRegisterfrom
from ..database.database import get_session
from sqlalchemy.orm import Session

authRouter = APIRouter(prefix="/auth", tags=["Auth"])

