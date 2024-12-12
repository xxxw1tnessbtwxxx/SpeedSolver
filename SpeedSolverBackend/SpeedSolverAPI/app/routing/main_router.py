from fastapi import APIRouter
from app.routing.access import authRouter
from app.routing.team_router import team_router
from app.routing.account import account_router
mainRouter = APIRouter (
   prefix = "/v1"
)

mainRouter.include_router(authRouter)
mainRouter.include_router(team_router)
mainRouter.include_router(account_router)

