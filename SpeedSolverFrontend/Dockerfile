FROM node:apline AS build
WORKDIR /app/web

COPY . .
RUN npm install
RUN npm run build

COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 3000
EXPOSE 80