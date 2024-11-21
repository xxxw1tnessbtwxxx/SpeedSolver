from pydantic_settings import BaseSettings

class ApiConfig(BaseSettings):
    API_BASE_PORT: int