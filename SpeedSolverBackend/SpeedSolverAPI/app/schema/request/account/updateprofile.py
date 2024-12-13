from datetime import datetime
from pydantic import BaseModel
from typing import Optional

class UpdateProfile(BaseModel):
    surname: Optional[str]
    name: Optional[str]
    patronymic: Optional[str]
    birthdate: Optional[datetime]