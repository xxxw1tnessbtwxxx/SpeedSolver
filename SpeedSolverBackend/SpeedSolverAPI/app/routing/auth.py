from fastapi import APIRouter, Depends, HTTPException

from app.services.user_service import UserService

from app.schema.request.get_access.register import RegisterRequest

from app.utils.result import Result
from app.utils.logger.logger import logger
from app.database.database import get_session

from app.routing.security.jwtmanager import JWTManager

from sqlalchemy.orm import Session

authRouter = APIRouter(prefix="/access", tags=["Auth"])

@authRouter.post("/register")
async def register(registerRequest: RegisterRequest, session: Session = Depends(get_session)):
    registered: Result = await UserService(session).register(registerRequest)
    if not registered.success:
        raise HTTPException(status_code=400, detail=registered.error)
    
    logger.info(f"User {registered.value.email} registered")
    return {
        "register": "User registered successfully"        
    }


@authRouter.post("/authorize")
async def authorize(authorizeRequest: RegisterRequest, session: Session = Depends(get_session)):
    authorized: Result = await UserService(session).authorize(authorizeRequest)
    if not authorized.success:
        raise HTTPException(status_code=400, detail=authorized.error)
    
    logger.info(f"User {authorized.value.email} authorized")
    return {
        "authorize": "User authorized successfully"        
    }