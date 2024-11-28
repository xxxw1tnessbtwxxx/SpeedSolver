from fastapi import APIRouter
from app.routing.auth import authRouter
from app.routing.team_router import team_router
mainRouter = APIRouter (
   prefix = "/v1"
)

mainRouter.include_router(authRouter)
mainRouter.include_router(team_router)

