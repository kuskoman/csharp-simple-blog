<template>
  <div class="d-flex align-center flex-column">
    <v-card width="1200" variant="tonal" class="login-card">
      <v-form ref="form" v-model="state.valid" lazy-validation>
        <div class="form-box">
          <v-text-field v-model="state.title" label="Title" placeholder=" Awesome Post Title!" required></v-text-field>
          <v-textarea
            v-model="state.body"
            label="Body"
            type="text-area"
            placeholder=" Lorem Ipsum"
            required
            class="post-body"
          ></v-textarea>
          <v-btn color="success" class="me-4 submit-btn" @click="submit">Create</v-btn>
        </div>
      </v-form>
    </v-card>
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";
import store from "@/store";
import { ALERT_STORE, ALERT_ACTION_TYPES, ApplicationAlertInput, ALERT_TYPE } from "../../store/alert";
import { PostsClient } from "@/api/PostsClient";
import { AxiosError } from "axios";
import router from "../../router";

const initialState = {
  valid: true,
  title: "",
  body: "",
};

const state = reactive({ ...initialState });

const submit = async () => {
  const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;

  try {
    await PostsClient.postsPost({
      title: state.title,
      content: state.body,
    });

    const postCreationSuccessfulAlert: ApplicationAlertInput = {
      body: "Post created successfully!",
      title: "Success",
      type: ALERT_TYPE.SUCCESS,
    };
    await store.dispatch(alertActionName, postCreationSuccessfulAlert);
    await router.push("/");
  } catch (e: unknown) {
    const error = e as AxiosError;
    const postCreationFailedAlert: ApplicationAlertInput = {
      body: error.response?.data?.message ?? "Post creation failed!",
      title: "Error",
      type: ALERT_TYPE.ERROR,
    };
    await store.dispatch(alertActionName, postCreationFailedAlert);
  }
};

export default defineComponent({
  name: "CreatePostView",
  data: () => ({
    state,
  }),
  methods: {
    submit,
  },
});
</script>

<style lang="scss" scoped>
@import "@/styles/mixins/card.scss";
@import "@/styles/mixins/text-area.scss";

.login-card {
  @include square-card;
}

.post-body {
  @include big-text-area;
  margin-bottom: 0;
}
</style>
