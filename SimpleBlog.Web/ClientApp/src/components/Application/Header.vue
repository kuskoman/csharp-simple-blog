<template>
  <v-app-bar title="SimpleBlog" color="primary" prominent>
    <v-spacer></v-spacer>
    <v-btn :prepend-icon="themeIcon" @click="onClick"> Toggle Theme </v-btn>
  </v-app-bar>
</template>

<script setup lang="ts">
import {
  ACTION_TYPES,
  ThemeState,
  THEME_STORE,
  THEME_NAMES,
  Theme,
} from "@/store/theme";
import { computed } from "vue";

const store = useStore<ThemeState>(THEME_STORE);

const getThemeIcon = (theme: Theme) => {
  if (theme === THEME_NAMES.DARK) {
    return "mdi-weather-night";
  }

  return "mdi-weather-sunny";
};

const themeIcon = computed(() => getThemeIcon(store.state.theme));

const onClick = () => {
  store.commit(ACTION_TYPES.SWITCH_THEME);
};
</script>

<script lang="ts">
import { defineComponent } from "vue";
import { useStore } from "vuex";

export default defineComponent({
  name: "ApplicationHeader",
});
</script>
