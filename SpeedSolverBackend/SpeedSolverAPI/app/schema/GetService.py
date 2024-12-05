from pydantic import BaseModel

class GetService(BaseModel):
    email: str
    password: str