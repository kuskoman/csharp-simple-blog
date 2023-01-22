<template>
  <v-card>
    <article>
      <h2>{{ title }}</h2>
      <p>{{ body }}</p>
      <span class="author">{{ author }}</span>
    </article>
  </v-card>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "BlogPost",
  props: {
    title: String,
    body: String,
    author: String,
  },
});
</script>

<style scoped lang="scss"></style>
