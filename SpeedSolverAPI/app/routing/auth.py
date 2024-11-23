from fastapi import APIRouter
from ..schema.authorize import Authorize

authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.post("/authorize")
async def authorze(data: Authorize):
    return {
        "auth": True
    }

@authRouter.get("/asdsda")
async def register():
    ...