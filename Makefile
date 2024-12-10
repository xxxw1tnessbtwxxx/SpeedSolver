build-backend:
	docker-compose --env-file SpeedSolverBackend/SpeedSolverAPI/.env -f SpeedSolverBackend/SpeedSolverAPI/docker/docker-compose.backend.yml --project-directory . up --build

build-frontend:
	docker-compose -f docker/docker-compose.frontend.yml --project-directory . up --build