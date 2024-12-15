from app.cfg.settings import settings
from fastapi import FastAPI
from app.routing.main_router import main_router
from starlette.middleware.cors import CORSMiddleware


from alembic.config import Config
from alembic import command

api = FastAPI(
    title="SpeedSolverAPI",
    description="The API docs for SpeedSolver.",
    version="v1",
)

api.add_middleware (
    CORSMiddleware,
    allow_origins=[
        "https://speedsolver.ru"
        "http://speedsolver.ru"
    ],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"]
)

api.include_router(main_router)

if __name__ == "__main__":
    ...
