import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import BlogView from "../views/Blog/BlogView.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "blog",
    component: BlogView,
  },
  {
    path: "/register",
    name: "register",
    component: () => import(/* webpackChunkName: "register" */ "../views/Auth/RegisterView.vue"),
  },
  {
    path: "/login",
    name: "login",
    component: () => import(/* webpackChunkName: "login" */ "../views/Auth/LoginView.vue"),
  },
  {
    path: "/posts/new",
    name: "createPost",
    component: () => import(/* webpackChunkName: "createPost" */ "../views/Blog/CreatePostView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
