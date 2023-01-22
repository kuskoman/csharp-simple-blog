<template>
  <v-card tag="article">
    <v-card-title tag="h2">{{ title }}</v-card-title>
    <v-card-text tag="p">{{ body }}</v-card-text>
    <blog-author :author="author"></blog-author>
  </v-card>
</template>

<script lang="ts">
import BlogAuthor from "./Author.vue";

import { defineComponent } from "vue";

export default defineComponent({
  name: "BlogPost",
  props: {
    title: String,
    body: String,
    author: String,
  },
  components: {
    BlogAuthor,
  },
});
</script>

<style scoped lang="scss">
article {
  padding: {
    top: 20px;
    bottom: 20px;
    left: 40px;
    right: 40px;
  }
  margin: {
    top: 20px;
    bottom: 20px;
  }
  border: {
    radius: 0;
  }

  .author-item {
    font: {
      size: 0.8em;
    }
  }
}
</style>
