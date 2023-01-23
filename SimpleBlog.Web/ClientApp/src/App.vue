<template>
  <v-app :theme="theme">
    <application-header></application-header>
    <v-main>
      <v-container>
        <alert-box></alert-box>
        <router-view />
      </v-container>
    </v-main>
    <application-footer></application-footer>
  </v-app>
</template>

<script setup lang="ts">
import { useStore } from "vuex";

const store = useStore<StoreState>();

const theme = computed(() => store.state.themes.theme); //todo: use getter
</script>

<script lang="ts">
import ApplicationFooter from "@/components/Application/Footer.vue";
import ApplicationHeader from "@/components/Application/Header.vue";

import AlertBox from "./components/Alerts/AlertBox.vue";

import { computed } from "vue";
import { RouterView } from "vue-router";
import { StoreState } from "./store";

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
    ApplicationHeader,
    AlertBox,
  },
};
</script>

<style lang="scss">
@import "./styles/index.scss";
</style>
