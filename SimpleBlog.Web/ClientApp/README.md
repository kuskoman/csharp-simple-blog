# SimpleBlog.Web

## Project setup

```sh
yarn install --frozen-lockfile
```

### Compiles and hot-reloads for development

```sh
yarn serve
```

### Compiles and minifies for production

```sh
yarn build
```

## API Client Generation

This project utilizes OpenAPI Generator to generate API clients for the backend API. The API client is generated using the following command:

```sh
yarn sdk
```

The command will update SDK files stored under [src/lib/sdk directory](./src/lib/sdk).
Most of the files are generated automatically, but some of them are manually modified to add custom logic.

## Build Docker Image

```sh
docker build -t simpleblog-client-app .
```
