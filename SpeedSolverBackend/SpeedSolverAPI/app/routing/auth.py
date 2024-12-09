from fastapi import APIRouter, Depends, HTTPException

from app.services.user_service import UserService

from app.schema.request.get_access.register import RegisterRequest
from app.utils.result import Result


from ..database.database import get_session
from sqlalchemy.orm import Session

authRouter = APIRouter(prefix="/access", tags=["Auth"])

@authRouter.post("/register")
async def register(registerRequest: RegisterRequest, session: Session = Depends(get_session)):
    registered: Result = await UserService(session).register(registerRequest)
    if not registered.success:
        raise HTTPException(status_code=400, detail=registered.error)
    
    return registered.value
