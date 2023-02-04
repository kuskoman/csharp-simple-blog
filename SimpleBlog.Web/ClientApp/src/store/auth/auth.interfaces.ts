import { UserCreateDto, UserLoginDto } from "@/lib/sdk";

interface UserState {
  username: string;
}

export interface AuthState {
  user: UserState | null;
}

export type RegisterParams = UserCreateDto;

export type LoginParams = UserLoginDto;
