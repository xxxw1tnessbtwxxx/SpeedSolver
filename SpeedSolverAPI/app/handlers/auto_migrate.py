from alembic.config import Config
from alembic import command

def migrate():
    command.upgrade(Config("alembic.ini"), "head")