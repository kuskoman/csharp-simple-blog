import { serviceOptions } from "@/lib/sdk";
import { axiosInstance } from "./instance";

serviceOptions.axios = axiosInstance;
