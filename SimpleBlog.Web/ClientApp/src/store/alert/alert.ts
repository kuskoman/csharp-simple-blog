import { ActionContext, Module } from "vuex";
import { ALERT_ACTION_TYPES } from "./alert.action-types";
import { AlertGetters, AlertState, AlertWithId, ApplicationAlertInput } from "./alert.interfaces";
import { v4 as uuidv4 } from "uuid";

const state: AlertState = {
  alerts: [],
};

const getters: AlertGetters = {
  [ALERT_ACTION_TYPES.GET_ALERTS]: (state) => state.alerts,
};

const mutations = {
  [ALERT_ACTION_TYPES.PUSH_ALERT]: (state: AlertState, alert: AlertWithId) => {
    state.alerts.push(alert);
  },
  [ALERT_ACTION_TYPES.REMOVE_ALERT]: (state: AlertState, alertId: string) => {
    state.alerts = state.alerts.filter((alert) => alert.id !== alertId);
  },
};

const actions = {
  [ALERT_ACTION_TYPES.ADD_ALERT]: ({ commit }: ActionContext<AlertState, AlertState>, alert: ApplicationAlertInput) => {
    const body = typeof alert.body === "string" ? [alert.body] : alert.body;
    const alertWithId: AlertWithId = { ...alert, id: uuidv4(), body };
    commit(ALERT_ACTION_TYPES.PUSH_ALERT, alertWithId);
  },
};

const AlertStoreModule = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
} satisfies Module<AlertState, AlertState>;

export default AlertStoreModule;
