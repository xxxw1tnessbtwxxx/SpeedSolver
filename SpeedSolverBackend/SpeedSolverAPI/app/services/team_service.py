
from sqlalchemy.orm import Session

from app.database.repo.team_repository import TeamRepository

class TeamService:
    def __init__(self, session: Session):
        self._repo = TeamRepository(session)

    async def create_team(self, title, description, leaderId, organizationId = None):
        return await self._repo.create_team(title, description, leaderId, organizationId)