run:
	docker-compose --env-file .env -f docker/docker-compose.yml --project-directory . up --build

dev:
	poetry run uvicorn main:api --reload --port 8000

rev:
	poetry run alembic revision --autogenerate

mig:
	poetry run alembic upgrade head

