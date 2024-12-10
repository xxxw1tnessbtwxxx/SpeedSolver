from fastapi import APIRouter, Depends, HTTPException
from fastapi.security import OAuth2PasswordRequestForm

from app.database.models.models import User
from app.schema.response.AccessToken import AccessToken
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
async def authorize(authRequest: OAuth2PasswordRequestForm = Depends(), session: Session = Depends(get_session)):
    authorized: Result = await UserService(session).authorize(session, authRequest.username, authRequest.password)
    if not authorized.success:
        raise HTTPException(status_code=400, detail=authorized.error)

    return AccessToken(
        access_token=authorized.value,
        token_type="Bearer"
    )
@authRouter.post("/test")
async def test(user: User = Depends(JWTManager().get_current_user)):
    return user
    