from pydantic import BaseModel

class Authorize(BaseModel):
    login: str
    password: str