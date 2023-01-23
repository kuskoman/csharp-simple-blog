export const ALERT_STORE = "alerts";
export enum ALERT_TYPE {
  SUCCESS = "success",
  INFO = "info",
  WARNING = "warning",
  ERROR = "error",
}
export const ALERTS_ARRAY = [ALERT_TYPE.SUCCESS, ALERT_TYPE.INFO, ALERT_TYPE.WARNING, ALERT_TYPE.ERROR] as const;
