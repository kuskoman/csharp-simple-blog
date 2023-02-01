import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import BlogView from "../views/BlogView.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "blog",
    component: BlogView,
  },
  {
    path: "/register",
    name: "register",
    component: () => import(/* webpackChunkName: "register" */ "../views/RegisterView.vue"),
  },
  {
    path: "/login",
    name: "login",
    component: () => import(/* webpackChunkName: "login" */ "../views/LoginView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
