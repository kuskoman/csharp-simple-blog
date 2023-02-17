<template>
  <v-card>
    <v-card-title tag="h2">{{ title }}</v-card-title>
    <v-card-text tag="p">{{ body }}</v-card-text>
    <blog-author v-if="author" :author="author.name"></blog-author>
  </v-card>
</template>

<script lang="ts">
import BlogAuthor from "./Author.vue";

import { defineComponent } from "vue";

export default defineComponent({
  name: "BlogComment",
  props: {
    title: String,
    body: String,
    author: {
      required: false,
      type: Object,
    },
  },
  components: {
    BlogAuthor,
  },
});
</script>

<style scoped lang="scss"></style>
