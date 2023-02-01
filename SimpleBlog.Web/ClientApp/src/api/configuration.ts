import { Configuration } from "@/lib/sdk";

export const apiConfiguration = new Configuration({ basePath: process.env.VUE_APP_API_URL });
