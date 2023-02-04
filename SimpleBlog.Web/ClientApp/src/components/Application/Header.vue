<template>
  <v-app-bar title="SimpleBlog" color="primary" prominent>
    <v-spacer></v-spacer>
    <v-btn prepend-icon="mdi-account" @click="onAuthClick">Login</v-btn>
    <v-btn :prepend-icon="themeIcon" @click="onThemeSwitchClick">Theme</v-btn>
  </v-app-bar>
</template>

<script setup lang="ts">
import { THEME_ACTION_TYPES, ThemeState, THEME_STORE, THEME_NAMES, Theme } from "@/store/theme";
import { computed } from "vue";
import { useStore } from "vuex";

const store = useStore<ThemeState>();
const router = useRouter();

const getThemeIcon = (theme: Theme) => {
  if (theme === THEME_NAMES.DARK) {
    return "mdi-weather-night";
  }

  return "mdi-weather-sunny";
};

const themeIcon = computed(() => getThemeIcon(store.state.theme));

const onThemeSwitchClick = () => {
  const actionName = `${THEME_STORE}/${THEME_ACTION_TYPES.SWITCH_THEME}`;
  store.dispatch(actionName);
};

const onAuthClick = () => {
  router.push({ name: "auth" });
};
</script>

<script lang="ts">
import { defineComponent } from "vue";
import { useRouter } from "vue-router";

export default defineComponent({
  name: "ApplicationHeader",
});
</script>
