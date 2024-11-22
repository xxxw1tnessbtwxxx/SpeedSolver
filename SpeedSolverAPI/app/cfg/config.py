from pydantic import Field
from pydantic_settings import BaseSettings
from yarl import URL
class Config(BaseSettings):
    POSTGRES_HOST: str
    POSTGRES_PORT: int
    POSTGRES_USER: str
    POSTGRES_PASSWORD: str
    POSTGRES_DB: str
    API_BASE_PORT: int

    class Config:
        env_file = ".env"

    @property
    def db_url(self):
        return URL.build (
            scheme="postgresql+psycopg2",
            host=self.POSTGRES_HOST,
            port=self.POSTGRES_PORT,
            user=self.POSTGRES_USER,
            password=self.POSTGRES_PASSWORD,
            path=f"/{self.POSTGRES_DB}"
        )
    
config: Config = Config()