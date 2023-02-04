<template>
  <v-btn icon color="info" class="new-blog-btn" size="large" elevation="2" fab @click="onClick">
    <v-icon>mdi-plus</v-icon>
  </v-btn>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
const router = useRouter();

const onClick = () => {
  router.push("/posts/new");
};
</script>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "NewBlogButton",
});
</script>

<style scoped lang="scss">
@import "@/styles/mixins/buttons.scss";

.new-blog-btn {
  @include fab;
}
</style>
