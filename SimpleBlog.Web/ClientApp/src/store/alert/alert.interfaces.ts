import { GetterTree } from "vuex";
import { ALERT_ACTION_TYPES } from "./alert.action-types";
import { ALERT_TYPE } from "./alert.consts";

export interface ApplicationAlert {
  type: ALERT_TYPE;
  title: string;
  body: string;
}

export interface AlertWithId extends ApplicationAlert {
  id: string;
}

export interface AlertState {
  alerts: Array<AlertWithId>;
}

export interface AlertGetters extends GetterTree<AlertState, AlertState> {
  [ALERT_ACTION_TYPES.GET_ALERTS]: (state: AlertState) => AlertState["alerts"];
}
