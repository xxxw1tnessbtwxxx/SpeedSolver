from fastapi import APIRouter, Depends, HTTPException

from app.database.repo.user_repository import UserRepository
from app.schema.GetService import GetService

import bcrypt


from ..database.database import get_session
from sqlalchemy.orm import Session

authRouter = APIRouter(prefix="/access", tags=["Auth"])

@authRouter.post("/register")
async def register(registerRequest: GetService, session: Session = Depends(get_session)):
    try:
        return await UserRepository(session).register(registerRequest)
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))


@authRouter.get("/authorize")
async def authorize(email: str, password: str, session: Session = Depends(get_session)):
    try:
        return await UserRepository(session).authorize(email, password)
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))
    