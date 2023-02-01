import { ActionContext, ActionTree, Module } from "vuex";
import { AuthClient } from "@/api";
import { ALERT_ACTION_TYPES, ALERT_STORE, ALERT_TYPE, ApplicationAlert } from "../alert";
import { AUTH_ACTION_TYPES } from "./auth.action-types";
import { AuthState, RegisterParams } from "./auth.interfaces";

const state: AuthState = {
  dummyField: undefined,
};

const getters = {};

const mutations = {};

const actions: ActionTree<AuthState, AuthState> = {
  [AUTH_ACTION_TYPES.REGISTER]: async (ctx: ActionContext<AuthState, AuthState>, registerParams: RegisterParams) => {
    const { dispatch } = ctx;
    const authResponse = await AuthClient.authSignupPost(registerParams);

    const addAlertAction = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

    if (authResponse.status !== 201) {
      const failureAlert: ApplicationAlert = {
        type: ALERT_TYPE.ERROR,
        title: "Login failed",
        body: (authResponse.data.errors || []).map((e) => e.description).join("\n"),
      };
      await dispatch(addAlertAction, failureAlert, { root: true });
      return;
    }

    const registerSuccessfulAlert: ApplicationAlert = {
      type: ALERT_TYPE.SUCCESS,
      title: "Welcome!",
      body: "Successfully created an account",
    };
    await dispatch(addAlertAction, registerSuccessfulAlert, { root: true });
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
