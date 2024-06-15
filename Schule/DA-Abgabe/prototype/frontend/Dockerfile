FROM node:20-alpine as build
WORKDIR /home/app

ARG CONFIGURATION=production

COPY . .
RUN npm ci
RUN npm i -g @angular/cli
RUN ng run networkanalysis:build:${CONFIGURATION}

FROM nginx:alpine
# COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /home/app/dist/networkanalysis/browser /usr/share/nginx/html
EXPOSE 80