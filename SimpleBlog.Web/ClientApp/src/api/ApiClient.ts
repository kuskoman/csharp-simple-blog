import { SimpleBlogApiSdk } from "@/lib/sdk";

export const ApiClient = new SimpleBlogApiSdk(process.env.VUE_APP_API_URL);
