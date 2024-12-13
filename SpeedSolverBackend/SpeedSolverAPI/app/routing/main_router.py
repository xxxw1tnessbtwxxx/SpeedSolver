from fastapi import APIRouter
from app.routing.access_router import auth_router
from app.routing.team_router import team_router
from app.routing.account_router import account_router
from app.routing.organization_router import organization_router

main_router = APIRouter (
   prefix = "/v1"
)

main_router.include_router(auth_router)
main_router.include_router(team_router)
main_router.include_router(account_router)
main_router.include_router(organization_router)
