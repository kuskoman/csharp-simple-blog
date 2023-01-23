<template>
  <v-app-bar title="SimpleBlog" color="primary" prominent>
    <v-spacer></v-spacer>
    <v-btn :prepend-icon="themeIcon" @click="onClick"> Toggle Theme </v-btn>
  </v-app-bar>
</template>

<script setup lang="ts">
import {
  THEME_ACTION_TYPES,
  ThemeState,
  THEME_STORE,
  THEME_NAMES,
  Theme,
} from "@/store/theme";
import { computed } from "vue";
import { useStore } from "vuex";

const store = useStore<ThemeState>();

const getThemeIcon = (theme: Theme) => {
  if (theme === THEME_NAMES.DARK) {
    return "mdi-weather-night";
  }

  return "mdi-weather-sunny";
};

const themeIcon = computed(() => getThemeIcon(store.state.theme));

const onClick = () => {
  const actionName = `${THEME_STORE}/${THEME_ACTION_TYPES.SWITCH_THEME}`;
  store.dispatch(actionName);
};
</script>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ApplicationHeader",
});
</script>
