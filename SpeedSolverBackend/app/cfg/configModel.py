from .db_config import DatabaseConfig
from .apiConfig import ApiConfig
from pydantic_settings import BaseSettings

class ConfigModel(BaseSettings):

    database: DatabaseConfig = DatabaseConfig()
    api: ApiConfig = ApiConfig()

configModel = ConfigModel()