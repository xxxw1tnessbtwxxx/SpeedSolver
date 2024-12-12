from pydantic import BaseModel
from typing import Optional


class UpdateTeam(BaseModel):
    teamId: str
    new_name: str
    new_description: str | None
    new_leader_id: str | None