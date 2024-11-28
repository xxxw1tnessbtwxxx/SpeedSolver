from sqlalchemy.orm import Session
from ..abstract.abc_repo import AbstractRepository
from ..models.team import Team
from app.schema.create_team import CreateTeam

class TeamRepository(AbstractRepository):

    def __init__(self, session: Session):
        self._session = session

    model = Team

    async def create_team(self, team: CreateTeam):
        return await self.create(teamName=team.name, teamDescription=team.description, leaderId=team.leaderId)