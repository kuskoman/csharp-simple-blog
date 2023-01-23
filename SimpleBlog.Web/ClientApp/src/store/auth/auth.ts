import { ActionContext, Module } from "vuex";
import { ApiSdk } from "../../lib/ApiSdk";
import { AUTH_ACTION_TYPES } from "./auth.action-types";
import { AuthState, RegisterParams } from "./auth.interfaces";

const state: AuthState = {
  dummyField: undefined,
};

const getters = {};

const mutations = {};

const actions = {
  [AUTH_ACTION_TYPES.REGISTER]: async (
    { commit, state }: ActionContext<AuthState, AuthState>,
    registerParams: RegisterParams
  ) => {
    const authResponse = await ApiSdk.postAuthSignup({ body: registerParams });
  },
};

const AuthStoreModule = {
  namespaced: true,
  state,
  getters: getters,
  actions,
  mutations: mutations,
} satisfies Module<AuthState, AuthState>;

export default AuthStoreModule;
