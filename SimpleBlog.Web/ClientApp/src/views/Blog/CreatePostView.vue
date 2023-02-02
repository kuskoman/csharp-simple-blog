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
import { useStore } from "vuex";
import { AlertState, ALERT_STORE, ALERT_ACTION_TYPES } from "../../store/alert";

const initialState = {
  valid: true,
  title: "",
  body: "",
};

const state = reactive({ ...initialState });

const store = useStore<AlertState>();

const submit = () => {
  const alertActionName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.ADD_ALERT}`;
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
