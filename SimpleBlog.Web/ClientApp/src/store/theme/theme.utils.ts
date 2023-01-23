import { LOCAL_STORAGE_THEME_KEY, THEMES, THEME_NAMES } from "./theme.consts";
import { Theme } from "./theme.interfaces";

export const checkBrowserDarkTheme = (): boolean => {
  return window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches;
};

export const getSavedTheme = () => {
  const savedTheme = localStorage.getItem(LOCAL_STORAGE_THEME_KEY);
  if (!savedTheme) {
    return null;
  }

  if (!isValidTheme(savedTheme)) {
    console.error(`Received theme ${savedTheme} that is not a valid theme`);
    return null;
  }

  return savedTheme;
};

export const saveTheme = (theme: Theme) => {
  localStorage.setItem(LOCAL_STORAGE_THEME_KEY, theme);
};

export const getInitialTheme = (): Theme => {
  const savedTheme = getSavedTheme();
  if (savedTheme) {
    return savedTheme;
  }

  const darkPreffered = checkBrowserDarkTheme();
  return darkPreffered ? THEME_NAMES.DARK : THEME_NAMES.LIGHT;
};

export const isValidTheme = (possibleTheme: string | Theme): possibleTheme is Theme => {
  const themesArr: string[] = [...THEMES];
  return themesArr.includes(possibleTheme);
};
