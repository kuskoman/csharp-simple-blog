import { ActionContext, ActionTree, Module } from "vuex";
import { AuthClient } from "@/api";
import { ALERT_ACTION_TYPES, ALERT_STORE, ALERT_TYPE, ApplicationAlertInput } from "../alert";
import { AUTH_ACTION_TYPES } from "./auth.action-types";
import { AuthState, LoginParams, RegisterParams } from "./auth.interfaces";
import { AxiosError } from "axios";
import { RegisterErrorResponseDto, UserResponseDto } from "@/lib/sdk";
import router from "../../router";
import { UsersClient } from "../../api/UsersClient";
import { AUTH_USER_LOCAL_STORAGE_KEY } from "./auth.consts";

const addAlertAction = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

const state: AuthState = {
  user: localStorage.getItem(AUTH_USER_LOCAL_STORAGE_KEY)
    ? JSON.parse(localStorage.getItem(AUTH_USER_LOCAL_STORAGE_KEY) || "")
    : null,
};

const getters = {
  [AUTH_ACTION_TYPES.GET_LOGIN_STATUS]: (state: AuthState): boolean => !!state.user?.name,
  [AUTH_ACTION_TYPES.GET_USER_NAME]: (state: AuthState) => state.user?.name || "Guest",
  [AUTH_ACTION_TYPES.GET_USER_ROLE]: () => "admin", //state.user?.role || "guest",
};

const mutations = {
  [AUTH_ACTION_TYPES.SET_LOGGED_USER_DATA]: (state: AuthState, user: UserResponseDto) => {
    state.user = user;
    localStorage.setItem(AUTH_USER_LOCAL_STORAGE_KEY, JSON.stringify(state.user));
  },
};

const actions: ActionTree<AuthState, AuthState> = {
  [AUTH_ACTION_TYPES.REGISTER]: async (ctx: ActionContext<AuthState, AuthState>, registerParams: RegisterParams) => {
    const { dispatch } = ctx;

    try {
      await AuthClient.authSignupPost(registerParams);
      const registerSuccessfulAlert: ApplicationAlertInput = {
        type: ALERT_TYPE.SUCCESS,
        title: "Welcome!",
        body: "Successfully created an account",
      };
      await dispatch(AUTH_ACTION_TYPES.FETCH_USER_DATA);
      await dispatch(addAlertAction, registerSuccessfulAlert, { root: true });
    } catch (e: unknown) {
      const axiosError = e as AxiosError<RegisterErrorResponseDto>;
      const responseErrors = Object.entries(axiosError.response?.data.errors || {});
      const errors = responseErrors.flatMap(([, err]) => err);
      const failureAlert: ApplicationAlertInput = {
        type: ALERT_TYPE.ERROR,
        title: "Registration failed",
        body: errors,
      };
      await dispatch(addAlertAction, failureAlert, { root: true });
      return;
    }

    await router.push("/");
  },

  [AUTH_ACTION_TYPES.LOGIN]: async (ctx: ActionContext<AuthState, AuthState>, loginParams: LoginParams) => {
    const { dispatch } = ctx;

    try {
      await AuthClient.authLoginPost(loginParams);
      await dispatch(AUTH_ACTION_TYPES.FETCH_USER_DATA);
      const loginSuccessfulAlert: ApplicationAlertInput = {
        type: ALERT_TYPE.SUCCESS,
        title: "Welcome back!",
        body: "Successfully logged in",
      };
      await dispatch(addAlertAction, loginSuccessfulAlert, { root: true });
    } catch (e: unknown) {
      const axiosError = e as AxiosError<RegisterErrorResponseDto>;
      const responseErrors = Object.entries(axiosError.response?.data.errors || {});
      const errors = responseErrors.flatMap(([, err]) => err);
      const failureAlert: ApplicationAlertInput = {
        type: ALERT_TYPE.ERROR,
        title: "Login failed",
        body: errors,
      };
      await dispatch(addAlertAction, failureAlert, { root: true });
      return;
    }

    await router.push("/");
  },

  [AUTH_ACTION_TYPES.FETCH_USER_DATA]: async (ctx: ActionContext<AuthState, AuthState>) => {
    const { commit, dispatch } = ctx;
    let user: UserResponseDto;
    try {
      const responseData = await UsersClient.usersMeGet();
      user = responseData.data;
    } catch (e) {
      const alert: ApplicationAlertInput = {
        type: ALERT_TYPE.ERROR,
        title: "Failed to fetch user data",
        body: "Please try again later",
      };
      await dispatch(addAlertAction, alert, { root: true });
      return;
    }

    commit(AUTH_ACTION_TYPES.SET_LOGGED_USER_DATA, user);
  },
};

const AuthStoreModule = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
} satisfies Module<AuthState, AuthState>;

export default AuthStoreModule;
