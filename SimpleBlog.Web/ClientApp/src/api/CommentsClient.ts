import { CommentsApi } from "@/lib/sdk";
import { apiConfiguration } from "./configuration";

export const CommentsClient = new CommentsApi(apiConfiguration);
