<template>
  <v-card tag="article">
    <v-card-title tag="h2">{{ title }}</v-card-title>
    <v-card-text tag="p">{{ body }}</v-card-text>
    <blog-author v-if="author" :author="author.name"></blog-author>
    <v-divider></v-divider>
    <v-card-item class="comments" v-if="shouldDisplayComments()">
      <v-card-subtitle tag="h3" class="post-subtitle">Comments</v-card-subtitle>
      <post-comment
        v-for="comment in comments"
        :title="comment.author?.name"
        v-bind:key="comment.id"
        :body="comment.body"
      ></post-comment>
    </v-card-item>
  </v-card>
</template>

<script lang="ts">
import BlogAuthor from "./Author.vue";
import PostComment from "./Comment.vue";

import { Comment } from "@/lib/sdk";

import { defineComponent } from "vue";
import { useStore } from "vuex";
import { AUTH_STORE, AUTH_ACTION_TYPES } from "../../store/auth";

export default defineComponent({
  name: "BlogPost",
  props: {
    title: String,
    body: String,
    author: {
      required: false,
      type: Object,
    },
    comments: {
      required: false,
      type: Array<Comment>,
      default: () => [],
    },
  },
  components: {
    BlogAuthor,
    PostComment,
  },
  methods: {
    isLogged() {
      const store = useStore();
      const userLoginStatusGetter = `${AUTH_STORE}/${AUTH_ACTION_TYPES.GET_LOGIN_STATUS}`;
      return store.getters[userLoginStatusGetter];
    },
    shouldDisplayComments() {
      if (this.isLogged()) {
        return true;
      }
      const commentsExists = this.comments && this.comments.length > 0;
      return commentsExists;
    },
  },
});
</script>

<style scoped lang="scss">
@import "@/styles/mixins/card.scss";

article {
  @include square-card;

  .author-item {
    font: {
      size: 0.8em;
    }
  }
}

.post-subtitle {
  margin-top: 20px;
}
</style>
