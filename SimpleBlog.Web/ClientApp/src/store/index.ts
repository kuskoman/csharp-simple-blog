import { createStore } from "vuex";

import theme, { ThemeState, THEME_STORE } from "./theme";
import auth, { AuthState, AUTH_STORE } from "./auth";
import alert, { AlertState, ALERT_STORE } from "./alert";

// eslint-disable-next-line @typescript-eslint/no-explicit-any
const store = createStore<any>({
  modules: {
    [AUTH_STORE]: auth,
    [ALERT_STORE]: alert,
    [THEME_STORE]: theme,
  },
});

export interface StoreState {
  [THEME_STORE]: ThemeState;
  [ALERT_STORE]: AlertState;
  [AUTH_STORE]: AuthState;
}

export default store;
