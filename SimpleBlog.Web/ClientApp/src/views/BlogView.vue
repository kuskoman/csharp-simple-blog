<template>
  <div v-for="post in posts" :key="post.id">
    <post :body="post.body" :author="post.author" :title="post.title"></post>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Post from "@/components/Blog/Post.vue";

const articleMock = {
  title: "Title",
  body: "lorem ipsum",
  author: "Sakub Jurdej",
};
const articlesMock: Array<typeof articleMock & { id: number }> = [];
for (let i = 0; i < 20; i++) {
  articlesMock.push({ ...articleMock, id: i });
}

export default defineComponent({
  name: "BlogView",
  components: {
    Post,
  },
  data: () => ({ posts: articlesMock }),
});
</script>
