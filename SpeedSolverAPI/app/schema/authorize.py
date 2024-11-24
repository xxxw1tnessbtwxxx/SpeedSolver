from pydantic import BaseModel

class GetServiceRequest(BaseModel):
    login: str
    password: str
    email: str | None