import { PostsApi } from "@/lib/sdk";
import { apiConfiguration } from "./configuration";

export const PostsClient = new PostsApi(apiConfiguration);
