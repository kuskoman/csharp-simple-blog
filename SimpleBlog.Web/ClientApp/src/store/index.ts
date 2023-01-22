import { createStore } from "vuex";

import theme, { THEME_STORE } from "./theme";

export default createStore({
  modules: {
    [THEME_STORE]: theme,
  },
});
