from sqlalchemy.orm import Session
from sqlalchemy.engine import create_engine
from ..cfg.config import config

async def get_session() -> Session:
    return Session(bind=create_engine(str(config.db_url)))