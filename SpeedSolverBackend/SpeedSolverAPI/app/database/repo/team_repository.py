from app.database.abstract.abc_repo import AbstractRepository
from app.database.models.models import Team
from sqlalchemy import select, update, delete, insert, and_, or_

from app.utils.result import Result
class TeamRepository(AbstractRepository):
    model: Team = Team


    async def create_team(self, title, description, leaderId, organizationId) -> Result[Team]:

        query = (
            select(self.model)
            .where(
                and_(
                    self.model.title == title,
                    self.model.leaderId == leaderId
                )
            )
        )

        result = self._session.execute(query)
        team = result.scalars().first()

        if team:
            return Result(success=False, error="Team already exists")
        

        return Result(success=True, value = await self.create(title=title, description=description, leaderId=leaderId, organizationId=organizationId))