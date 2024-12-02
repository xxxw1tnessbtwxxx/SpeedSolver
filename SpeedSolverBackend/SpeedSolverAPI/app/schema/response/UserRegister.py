from pydantic import BaseModel

class UserRegister(BaseModel):
    userId: str
    login: str
    email: str