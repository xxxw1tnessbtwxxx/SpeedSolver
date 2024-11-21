from fastapi import APIRouter


authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.get("/login")
async def signin():
    return {
        "message": "signin"
    }

@authRouter.post("/register")
async def register():
    return {
        "message": "signup"
    }
