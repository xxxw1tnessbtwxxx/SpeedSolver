from pydantic import BaseModel

class AuthorizeRequest(BaseModel):
    email: str
    password: str
