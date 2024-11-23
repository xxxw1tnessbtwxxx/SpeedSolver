# Этап сборки проекта
FROM node:14-alpine AS build-stage

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем package.json и package-lock.json
COPY package*.json ./

# Устанавливаем зависимости
RUN npm install

# Копируем остальные файлы проекта
COPY . .

# Сборка проекта
RUN npm run build

# Проверяем, что директория dist существует и содержит файлы
RUN ls -la dist

# Этап копирования собранных файлов
FROM alpine:latest

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем собранные файлы из предыдущего этапа сборки
COPY --from=build-stage /app/dist /app/dist
