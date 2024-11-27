from sqlalchemy.orm import Session
from ..abstract.abc_repo import AbstractRepository
from ..models.team import Team


class TeamRepository(AbstractRepository):

    def __init__(self, session: Session):
        self._session = session
