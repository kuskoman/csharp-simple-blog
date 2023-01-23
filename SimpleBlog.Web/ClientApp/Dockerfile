FROM node:18.12.1-alpine AS build

WORKDIR /build

COPY package.json .
COPY yarn.lock .

RUN yarn --frozen-lockfile --production=false

COPY . .
RUN yarn build


FROM httpd:2.4-alpine

COPY --from=build /build/dist /usr/local/apache2/htdocs/
