import { AuthApi } from "@/lib/sdk";
import { apiConfiguration } from "./configuration";

export const AuthClient = new AuthApi(apiConfiguration);
