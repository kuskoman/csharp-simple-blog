<template>
  <v-card-item class="author-item">
    <span class="author-label">Author: </span>
    <span class="author-name">{{ author }}</span>
  </v-card-item>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "BlogAuthor",
  props: {
    author: String,
  },
});
</script>

<style scoped lang="scss">
.author-item {
  font: {
    size: 0.8em;
  }
}
</style>
