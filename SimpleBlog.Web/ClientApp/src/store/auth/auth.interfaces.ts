import { UserCreateDto, UserLoginDto, UserResponseDto } from "@/lib/sdk";

type UserState = UserResponseDto;

export interface AuthState {
  user: UserState | null;
}

export type RegisterParams = UserCreateDto;

export type LoginParams = UserLoginDto;
