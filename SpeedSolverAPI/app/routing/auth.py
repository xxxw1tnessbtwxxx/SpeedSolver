from fastapi import APIRouter, Depends
from ..schema.authorize import GetServiceRequest
from ..database.repo.user_repo import UserRepository
from ..database.database import get_session
from sqlalchemy.orm import Session
authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.post("/authorize")
async def authorize(authRequest: GetServiceRequest, session: Session = Depends(get_session)):
    return await UserRepository(session).authorize(authRequest)

@authRouter.post("/register")
async def register(regRequest: GetServiceRequest, session: Session = Depends(get_session)):
    return await UserRepository(session).register(regRequest)

@authRouter.get("/arinaLoshara")
async def test(login: str, session: Session = Depends(get_session)):
    return await UserRepository(session).get_by_login(login)