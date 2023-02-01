<template>
  <v-form ref="form" v-model="state.valid" lazy-validation>
    <div class="form-box">
      <v-text-field
        v-model="state.email"
        :rules="rules.email"
        label="Email"
        placeholder=" jannowak@example.com"
        required
      ></v-text-field>
      <v-text-field v-model="state.password" label="Password" placeholder=" *******"></v-text-field>
      <v-btn color="success" class="me-4 submit-btn" @click="submit">Login</v-btn>
    </div>
  </v-form>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";
import { useStore } from "vuex";
import { AuthState, AUTH_ACTION_TYPES, AUTH_STORE, LoginParams } from "../../store/auth";
import { emailRules } from "./rules";

export default defineComponent({
  name: "LoginForm",
  setup() {
    const initialState = {
      valid: true,
      email: "",
      password: "",
    };

    const state = reactive({ ...initialState });

    const rules = {
      email: emailRules,
    };

    const store = useStore<AuthState>();

    const submit = () => {
      const action = `${AUTH_STORE}/${AUTH_ACTION_TYPES.LOGIN}`;
      state satisfies LoginParams;
      store.dispatch(action, state);
    };

    return { state, rules, submit };
  },
});
</script>

<style scoped lang="scss">
.form-box {
  margin {
    top: 30px;
  }
}

.submit-btn {
  margin: {
    top: 5px;
  }
}
</style>
