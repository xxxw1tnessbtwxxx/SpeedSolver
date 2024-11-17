from fastapi import APIRouter
from .auth import authRouter

mainRouter = APIRouter (
   prefix = "/v1"
)

mainRouter.include_router(authRouter)