import { ActionContext, Module, MutationTree } from "vuex";
import { THEME_ACTION_TYPES } from "./theme.action-types";
import { THEME_NAMES } from "./theme.consts";
import { ThemeState, Theme } from "./theme.interfaces";
import { getInitialTheme, saveTheme } from "./theme.utils";

const state = {
  theme: getInitialTheme(),
} satisfies ThemeState;

const getters = {
  theme: (): Theme => {
    return state.theme;
  },
};

const mutations: MutationTree<ThemeState> = {
  [THEME_ACTION_TYPES.SET_THEME]: (state: ThemeState, theme: Theme) => {
    state.theme = theme;
    saveTheme(state.theme);
  },
};

const actions = {
  [THEME_ACTION_TYPES.SWITCH_THEME]: ({ commit, state }: ActionContext<ThemeState, ThemeState>) => {
    const currentTheme = state.theme;
    const newTheme = currentTheme === THEME_NAMES.DARK ? THEME_NAMES.LIGHT : THEME_NAMES.DARK;
    commit(THEME_ACTION_TYPES.SET_THEME, newTheme);
    return newTheme;
  },
};

const themeStoreModule = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
} satisfies Module<ThemeState, ThemeState>;

export default themeStoreModule;
