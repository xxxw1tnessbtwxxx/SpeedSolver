from fastapi import APIRouter


authRouter = APIRouter(prefix="/auth", tags=["Auth"])

@authRouter.get("/signin")
async def signin():
    return {
        "message": "signin"
    }

@authRouter.post("/signup")
async def register():
    return {
        "message": "signup"
    }
