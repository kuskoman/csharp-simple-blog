<template>
  <v-app :theme="theme">
    <v-app-bar title="SimpleBlog" color="primary" prominent>
      <v-spacer></v-spacer>
      <v-btn :prepend-icon="getThemeIcon()" @click="onClick">
        Toggle Theme
      </v-btn>
    </v-app-bar>
    <v-main>
      <v-card>
        <router-view />
      </v-card>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from "vue";

const theme = ref("light");

const onClick = () => {
  theme.value = theme.value === "light" ? "dark" : "light";
};

const getThemeIcon = () => {
  return theme.value === "light" ? "mdi-weather-sunny" : "mdi-weather-night";
};
</script>

<script lang="ts">
export default {
  data: () => ({
    drawer: false,
    group: null,
    items: [
      { title: "Home", value: "home" },
      { title: "About", value: "about" },
    ],
  }),
};
</script>

<style lang="scss">
@import "./styles/index.scss";
</style>
