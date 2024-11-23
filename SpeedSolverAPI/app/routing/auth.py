from fastapi import APIRouter
from ..schema.authorize import Authorize

authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.get("/authorize")
async def authorze(data: Authorize):
    return {
        "auth": True
    }
