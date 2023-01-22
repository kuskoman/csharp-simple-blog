<template>
  <v-app :theme="theme">
    <v-app-bar title="SimpleBlog" color="primary" prominent>
      <v-spacer></v-spacer>
      <v-btn :prepend-icon="getThemeIcon()" @click="onClick">
        Toggle Theme
      </v-btn>
    </v-app-bar>
    <v-main>
      <v-container>
        <router-view />
      </v-container>
    </v-main>
    <application-footer></application-footer>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from "vue";

const theme = ref("dark");

const onClick = () => {
  theme.value = theme.value === "light" ? "dark" : "light";
};

const getThemeIcon = () => {
  return theme.value === "light" ? "mdi-weather-sunny" : "mdi-weather-night";
};
</script>

<script lang="ts">
import ApplicationFooter from "@/components/Application/Footer.vue";

export default {
  data: () => ({
    drawer: false,
    group: null,
    items: [
      { title: "Home", value: "home" },
      { title: "About", value: "about" },
    ],
  }),
  components: {
    ApplicationFooter,
  },
};
</script>

<style lang="scss">
@import "./styles/index.scss";
</style>
