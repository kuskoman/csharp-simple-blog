import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import BlogView from "../views/Blog/BlogView.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "blog",
    component: BlogView,
  },
  {
    path: "/auth",
    name: "auth",
    component: () => import(/* webpackChunkName: "auth" */ "../views/Auth/AuthView.vue"),
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
  {
    path: "/profile",
    name: "profile",
    component: () => import(/* webpackChunkName: "profile" */ "../views/User/ProfileView.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
