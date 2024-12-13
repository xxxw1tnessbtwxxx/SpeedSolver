from fastapi import APIRouter, Depends, Form, HTTPException
from fastapi.security import OAuth2PasswordRequestForm

from app.database.models.models import User
from app.schema.response.AccessToken import AccessToken
from app.services.user_service import UserService

from app.schema.request.get_access.register import RegisterRequest

from app.utils.result import Result
from app.utils.logger.logger import logger
from app.database.database import get_session



from app.routing.security.jwtmanager import JWTManager, oauth2_scheme

from sqlalchemy.orm import Session

auth_router = APIRouter(prefix="/access", tags=["System Access"])

@auth_router.post("/register")
async def register(registerRequest: RegisterRequest, session: Session = Depends(get_session)):
    registered: Result = await UserService(session).register(registerRequest)
    if not registered.success:
        raise HTTPException(status_code=400, detail=registered.error)
    
    logger.info(f"User {registered.value.email} registered")
    return {
        "register": "User registered successfully"        
    }


@auth_router.post("/authorize")
async def authorize(username: str = Form(), password: str = Form(), session: Session = Depends(get_session)):
    authorized: Result = await UserService(session).authorize(username, password)
    if not authorized.success:
        raise HTTPException(status_code=400, detail=authorized.error)

    return AccessToken(
        access_token=authorized.value,
        token_type="Bearer"
    )

    