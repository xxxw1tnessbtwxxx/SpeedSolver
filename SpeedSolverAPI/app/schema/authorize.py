from pydantic import BaseModel
from typing import Optional

class GetServiceRequest(BaseModel):
    login: str
    password: str
    email: Optional[str]