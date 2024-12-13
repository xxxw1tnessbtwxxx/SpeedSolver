from typing import Optional
from pydantic import BaseModel


class CreateOrganization(BaseModel):
    name: str
    description: Optional[str]