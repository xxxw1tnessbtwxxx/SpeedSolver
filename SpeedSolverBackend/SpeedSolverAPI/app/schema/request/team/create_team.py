from pydantic import BaseModel
from typing import Optional
import uuid

class CreateTeam(BaseModel):
    name: str
    description: Optional[str]
    organizationId: Optional[uuid.UUID]