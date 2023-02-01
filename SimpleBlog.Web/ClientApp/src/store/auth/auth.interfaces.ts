import { UserCreateDto, UserLoginDto } from "@/lib/sdk";

export interface AuthState {
  dummyField?: undefined;
}

export type RegisterParams = UserCreateDto;

export type LoginParams = UserLoginDto;
