build-backend:
	docker-compose --env-file .env -f docker/docker-compose.backend.yml --project-directory . up --build

build-frontend:
	docker-compose -f docker/docker-compose.frontend.yml --project-directory . up --build