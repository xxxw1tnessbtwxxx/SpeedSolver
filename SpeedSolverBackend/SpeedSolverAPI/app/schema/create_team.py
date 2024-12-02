from pydantic import BaseModel
from typing import Optional, List
from uuid import UUID

class CreateTeam(BaseModel):
    name: str
    description: str
    leaderId: UUID