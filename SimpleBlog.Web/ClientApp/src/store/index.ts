import { createStore } from "vuex";

import theme, { ThemeState, THEME_STORE } from "./theme";

const store = createStore({
  modules: {
    [THEME_STORE]: theme,
  },
});

export interface StoreState {
  [THEME_STORE]: ThemeState;
}

export default store;
