import { ActionContext, ActionTree, Module } from "vuex";
import { ApiClient } from "../../api/ApiClient";
import { AUTH_ACTION_TYPES } from "./auth.action-types";
import { AuthState, RegisterParams } from "./auth.interfaces";

const state: AuthState = {
  dummyField: undefined,
};

const getters = {};

const mutations = {};

const actions: ActionTree<AuthState, AuthState> = {
  [AUTH_ACTION_TYPES.REGISTER]: async (
    { commit, state }: ActionContext<AuthState, AuthState>,
    registerParams: RegisterParams
  ) => {
    const authResponse = await ApiClient.postAuthSignup({
      body: registerParams,
    });
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
