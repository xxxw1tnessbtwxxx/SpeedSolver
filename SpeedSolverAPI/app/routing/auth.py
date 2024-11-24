from fastapi import APIRouter
from ..schema.authorize import Authorize
from ..database.repo.user_repo import UserRepository

authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.post("/authorize")
async def authorze(data: Authorize):
    return await UserRepository().authorize(data)
