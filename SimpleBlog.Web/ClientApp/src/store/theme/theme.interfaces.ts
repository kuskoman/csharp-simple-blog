import { THEMES } from "./theme.consts";

export type Theme = (typeof THEMES)[number];

export interface ThemeState {
  theme: Theme;
}
