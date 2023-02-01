#! /usr/bin/env node

import { codegen } from "swagger-axios-codegen";
import { join, dirname } from "path";
import { fileURLToPath } from "url";
import { resolveRefs } from "json-refs";

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);

const OUTPUT_PATH = join(__dirname, "..", "src", "lib", "sdk");

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

const dereferenceSwaggerFile = async (file) => {
  const { resolved: resolvedFile } = await resolveRefs(file);
  return resolvedFile;
};

const main = async () => {
  const url = getSwaggerUrl();
  const swaggerFile = await fetchSwaggerFile(url);
  const fixedFile = await dereferenceSwaggerFile(swaggerFile);
  await codegen({
    source: fixedFile,
    outputDir: OUTPUT_PATH,
    methodNameMode: "operationId",
    useStaticMethod: true,
    modelMode: "class",
  });
};

main();
