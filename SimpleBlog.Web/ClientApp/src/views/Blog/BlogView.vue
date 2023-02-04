<template>
  <div v-for="post in posts" :key="post.id">
    <post :body="post.content" :author="post.author" :title="post.title"></post>
  </div>
  <new-blog-button></new-blog-button>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Post from "@/components/Blog/Post.vue";
import NewBlogButton from "@/components/Blog/NewPostButton.vue";
import { PostsClient } from "@/api/PostsClient";

const postsResponse = await PostsClient.postsGet();
const posts = postsResponse.data;

export default defineComponent({
  name: "BlogView",
  components: {
    Post,
    NewBlogButton,
  },
  data: () => ({ posts }),
});
</script>
