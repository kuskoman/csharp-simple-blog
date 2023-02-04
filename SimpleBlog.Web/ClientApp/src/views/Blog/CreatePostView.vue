<template>
  <div class="d-flex align-center flex-column">
    <v-card width="1200" variant="tonal" class="post-create-card">
      <v-card-title class="text-h5" tag="h2">Create new post</v-card-title>
      <v-card-subtitle class="text-h6" tag="h3">Enter the title and body of your post</v-card-subtitle>
      <new-post-form class="new-post-form"></new-post-form>
    </v-card>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import NewPostForm from "@/components/Blog/NewPostForm.vue";

export default defineComponent({
  name: "CreatePostView",
  components: {
    NewPostForm,
  },
});
</script>

<style lang="scss" scoped>
@import "@/styles/mixins/card.scss";
@import "@/styles/mixins/text-area.scss";

.post-create-card {
  @include square-card;
}

.new-post-form {
  margin-top: 30px;
}
</style>
