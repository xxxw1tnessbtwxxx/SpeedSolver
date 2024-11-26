from app.cfg.config import config
from fastapi import FastAPI
from app.routing.main_router import mainRouter
from starlette.middleware.cors import CORSMiddleware


from alembic.config import Config
from alembic import command

api = FastAPI(
    title="SpeedSolverAPI",
    description="The API docs for SpeedSolver.",
    version="v1",
)

#rand#

api.add_middleware (
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"]
)

api.include_router(mainRouter)

if __name__ == "__main__":
    ...
