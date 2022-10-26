# build stage
FROM node:18.7-alpine as build-stage
WORKDIR /app
COPY package*.json ./
RUN yarn
COPY . .
RUN yarn build
# CMD ["node", ".output/server/index.mjs"]


# production stage
# FROM nginx:stable-alpine as production-stage
FROM node:18.7-alpine as production-stage
# COPY --from=build-stage /app/.output/server /usr/share/nginx/html
COPY --from=build-stage /app/.output/server /app
EXPOSE 3000
CMD ["node", "/app/index.mjs"]
# CMD ["nginx", "-g", "daemon off;"]