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
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
