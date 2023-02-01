import { ActionContext, ActionTree, Module } from "vuex";
import { AuthClient } from "@/api";
import { ALERT_ACTION_TYPES, ALERT_STORE, ALERT_TYPE, ApplicationAlertInput } from "../alert";
import { AUTH_ACTION_TYPES } from "./auth.action-types";
import { AuthState, RegisterParams } from "./auth.interfaces";
import { AxiosError } from "axios";
import { RegisterErrorResponseDto } from "@/lib/sdk";

const state: AuthState = {
  dummyField: undefined,
};

const getters = {};

const mutations = {};

const actions: ActionTree<AuthState, AuthState> = {
  [AUTH_ACTION_TYPES.REGISTER]: async (ctx: ActionContext<AuthState, AuthState>, registerParams: RegisterParams) => {
    const { dispatch } = ctx;
    const addAlertAction = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

    try {
      await AuthClient.authSignupPost(registerParams);
      const registerSuccessfulAlert: ApplicationAlertInput = {
        type: ALERT_TYPE.SUCCESS,
        title: "Welcome!",
        body: "Successfully created an account",
      };
      await dispatch(addAlertAction, registerSuccessfulAlert, { root: true });
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
