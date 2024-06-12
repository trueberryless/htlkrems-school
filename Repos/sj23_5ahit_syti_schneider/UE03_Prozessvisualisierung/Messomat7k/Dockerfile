FROM node:20-alpine as angular
WORKDIR /home/app
COPY package*.json .
RUN npm ci
COPY . .
RUN npm run build --prod

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=angular /home/app/dist/messomat7-k/browser .
EXPOSE 80