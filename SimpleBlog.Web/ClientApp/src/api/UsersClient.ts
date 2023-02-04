import { UsersApi } from "@/lib/sdk";
import { apiConfiguration } from "./configuration";

export const UsersClient = new UsersApi(apiConfiguration);
