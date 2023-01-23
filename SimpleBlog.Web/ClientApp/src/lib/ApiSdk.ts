import { SimpleBlogApiSdk } from "simple-blog-api-sdk";

export const ApiSdk = new SimpleBlogApiSdk(process.env.VUE_APP_API_URL);
