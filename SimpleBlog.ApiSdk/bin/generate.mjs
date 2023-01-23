#! /usr/bin/env node

import { CodeGen } from "swagger-typescript-codegen";
import { writeFile } from "fs/promises";

const OUTPUT_PATH = "src/api.ts";

const getSwaggerUrl = () => {
  const host = process.env.SWAGGER_HOST || "http://localhost";
  const port = process.env.SWAGGER_PORT || "5000";
  const path = process.env.SWAGGER_PATH || "swagger/v1/swagger.json";

  const url = `${host}:${port}/${path}`;
  return url;
};

const fetchSwaggerFile = async (url) => {
  console.debug(`Sending request to ${url}`);
  const swaggerResponse = await fetch(url);
  const swaggerFile = await swaggerResponse.json();
  return swaggerFile;
};

const url = getSwaggerUrl();
const swaggerFile = await fetchSwaggerFile(url);

const tsSourceCode = CodeGen.getTypescriptCode({
  className: "SimpleBlogApiSdk",
  swagger: swaggerFile,
});

await writeFile(OUTPUT_PATH, tsSourceCode, "utf-8");
