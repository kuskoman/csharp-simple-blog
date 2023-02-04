<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-textarea
      v-model="comment"
      :rules="rules"
      label="Comment"
      class="comment-body"
      placeholder="Enter your comment here..."
      required
    ></v-textarea>
    <v-btn color="primary" class="submit-btm" :disabled="!valid" @click="submitComment">Submit</v-btn>
  </v-form>
</template>

<style lang="scss">
@import "@/styles/mixins/text-area.scss";

.comment-body {
  @include big-text-area;
  margin-bottom: 0;
}

.submit-btn {
  width: 100%;
  margin-top: 0;
}
</style>

<script lang="ts">
import { defineComponent } from "vue";
import { ref } from "vue";
import { CommentsClient } from "@/api/CommentsClient";
import { ALERT_STORE, ALERT_ACTION_TYPES } from "../../store/alert";
import { useStore } from "vuex";

const rules = [
  (comment: string) => !!comment || "Comment is required",
  (comment: string) => comment.length >= 2 || "Comment must be at least 3 characters",
];

const comment = ref("");
const valid = ref(false);

export default defineComponent({
  name: "NewComment",
  props: {
    postId: {
      type: Number,
      required: true,
    },
  },
  data: () => ({
    rules,
    comment,
    valid,
  }),
  methods: {
    async submitComment() {
      if (!valid.value) {
        // create a new alert
        const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;
        const store = useStore();
        return store.dispatch(alertActionName, {
          body: "Please enter a valid comment",
          title: "Error",
          type: "error",
        });
      }

      const store = useStore();
      const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

      try {
        await CommentsClient.apiCommentsPostIdPost(this.postId, {
          body: comment.value,
        });
      } catch (e: unknown) {
        await store.dispatch(alertActionName, {
          body: "An error occurred while creating the comment",
          title: "Error",
          type: "error",
        });
        return;
      }

      await store.dispatch(alertActionName, {
        body: "Comment created successfully!",
        title: "Success",
        type: "success",
      });
    },
  },
});
</script>
