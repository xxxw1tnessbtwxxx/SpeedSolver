from logging.config import fileConfig

from sqlalchemy import engine_from_config
from sqlalchemy import pool

from alembic import context
from app.database.models.base import Base
from app.cfg.config import config as cfg

# User:
from app.database.models.user import User
from app.database.models.user_profile import UserProfile

# Team:
from app.database.models.team import Team
from app.database.models.team_project import TeamProject
from app.database.models.team_member import TeamMember

# Project:
from app.database.models.project import Project
from app.database.models.project_objectives import ProjectObjectives

# Objective
from app.database.models.underobjectve import UnderObjective
from app.database.models.objectve import Objective
config = context.config
config.set_main_option("sqlalchemy.url", f"{cfg.db_url}")
if config.config_file_name is not None:
    fileConfig(config.config_file_name)

target_metadata = Base.metadata

def run_migrations_offline() -> None:
    url = config.get_main_option("sqlalchemy.url")
    context.configure(
        url=url,
        target_metadata=target_metadata,
        literal_binds=True,
        dialect_opts={"paramstyle": "named"},
    )

    with context.begin_transaction():
        context.run_migrations()


def run_migrations_online() -> None:

    connectable = engine_from_config(
        config.get_section(config.config_ini_section, {}),
        prefix="sqlalchemy.",
        poolclass=pool.NullPool,
    )

    with connectable.connect() as connection:
        context.configure(
            connection=connection, target_metadata=target_metadata
        )

        with context.begin_transaction():
            context.run_migrations()


if context.is_offline_mode():
    run_migrations_offline()
else:
    run_migrations_online()