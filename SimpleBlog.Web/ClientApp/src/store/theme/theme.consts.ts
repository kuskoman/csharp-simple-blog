export const LOCAL_STORAGE_THEME_KEY = "THEME";
export const enum THEME_NAMES {
  DARK = "dark",
  LIGHT = "light",
}
export const THEMES = [THEME_NAMES.DARK, THEME_NAMES.LIGHT] as const;
export const THEME_STORE = "themes";
