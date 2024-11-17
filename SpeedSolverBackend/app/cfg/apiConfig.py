from pydantic_settings import BaseSettings

class ApiConfig(BaseSettings):
    API_BASE_PORT: int
    API_BASE_PATH: str