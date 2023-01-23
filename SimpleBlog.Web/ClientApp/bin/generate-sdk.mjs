#! /usr/bin/env node

import { CodeGen } from "swagger-typescript-codegen";
import { writeFile } from "fs/promises";
import { join, dirname } from "path";
import { fileURLToPath } from "url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);

const OUTPUT_PATH = join(
  __dirname,
  "..",
  "src",
  "lib",
  "sdk",
  "SimpleBlog.Api.Sdk.ts"
);

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

const main = async () => {
  const url = getSwaggerUrl();
  const swaggerFile = await fetchSwaggerFile(url);

  const tsSourceCode = CodeGen.getTypescriptCode({
    className: "SimpleBlogApiSdk",
    swagger: swaggerFile,
  });

  const header = `/* eslint-disable */
/* THIS FILE IS GENERATED AUTOMATICALLY, DON'T EDIT IT BY HAND
INSTEAD PROCEED TO bin/generate-sdk.mjs */`;

  const fileToWrite = `${header}${tsSourceCode}`;

  await writeFile(OUTPUT_PATH, fileToWrite, "utf-8");
};

main();
