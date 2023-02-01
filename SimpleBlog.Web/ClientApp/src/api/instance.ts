import axios from "axios";
import { API_URL } from "./consts";

export const axiosInstance = axios.create({ baseURL: API_URL, timeout: 2000 });
