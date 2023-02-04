<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <div class="comment-box">
      <v-textarea
        v-model="comment"
        :rules="rules"
        label="Type your comment here"
        class="comment-body"
        placeholder="Enter your comment here..."
        required
      ></v-textarea>
    </div>
    <div class="submit-wrapper">
      <v-btn color="primary" class="me-4 submit-btn" @click="submitComment">Create</v-btn>
    </div>
  </v-form>
</template>

<style lang="scss">
@import "@/styles/mixins/text-area.scss";

.comment-body {
  height: 40px;
  max-height: 40px;
  padding: auto;
  overflow: none;
}

.submit-wrapper {
  margin-top: 30px;
}

.comment-box {
  display: block;
}

.submit-btn {
  width: 100%;
  display: block;
}
</style>

<script lang="ts">
import { defineComponent } from "vue";
import { ref } from "vue";
import { CommentsClient } from "@/api/CommentsClient";
import { ALERT_STORE, ALERT_ACTION_TYPES } from "../../store/alert";
import { Store, useStore } from "vuex";

const rules = [
  (comment: string) => !!comment || "Comment is required",
  (comment: string) => comment.length >= 2 || "Comment must be at least 3 characters",
];

let store: Store<unknown> | null = null;
const getStore = () => {
  if (!store) {
    throw new Error("Store not initialized");
  }

  return store;
};

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
    comment: ref(""),
    valid: ref(false),
  }),
  setup() {
    store = useStore();
  },
  methods: {
    async submitComment() {
      if (!this.valid) {
        const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;
        return getStore().dispatch(alertActionName, {
          body: "Please enter a valid comment",
          title: "Error",
          type: "error",
        });
      }

      const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

      try {
        await CommentsClient.apiCommentsPostIdPost(this.postId, {
          body: this.comment,
        });
      } catch (e: unknown) {
        await getStore().dispatch(alertActionName, {
          body: "An error occurred while creating the comment",
          title: "Error",
          type: "error",
        });
        return;
      }

      await getStore().dispatch(alertActionName, {
        body: "Comment created successfully!",
        title: "Success",
        type: "success",
      });
    },
  },
});
</script>
