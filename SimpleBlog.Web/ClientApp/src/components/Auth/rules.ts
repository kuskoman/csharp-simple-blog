export const nameRules = [
  (name: string) => !!name || "Name is required",
  (name: string) => name.length >= 2 || "Name must be at least 2 characters",
  (name: string) => name.length <= 32 || "Name must be at most 32 characters",
];
export const emailRules = [
  (email: string) => !!email || "Email is required",
  (email: string) => /.+@.+\..+/.test(email) || "Email must be valid",
];
export const registerPasswordRules = [
  (password: string) => !!password || "Password is required",
  (password: string) => password.length >= 7 || "Password must be at least 7 characters",
  (password: string) => password.length <= 2048 || "Password must be at most 2048 characters",
];
