<template>
  <v-form ref="form" v-model="state.valid" lazy-validation>
    <div class="form-box">
      <v-text-field v-model="state.name" :rules="rules.name" label="Name" placeholder=" Jan" required></v-text-field>
      <v-text-field
        v-model="state.email"
        :rules="rules.email"
        label="Register"
        placeholder=" jannowak@example.com"
        required
      ></v-text-field>
      <v-text-field
        v-model="state.password"
        :rules="rules.password"
        label="Password"
        placeholder=" *******"
      ></v-text-field>
      <v-btn color="success" class="me-4 submit-btn" @click="submit">Submit</v-btn>
    </div>
  </v-form>
</template>

<script lang="ts">
import { defineComponent, reactive } from "vue";
import { useStore } from "vuex";
import { AuthState, AUTH_ACTION_TYPES, AUTH_STORE, RegisterParams } from "../../store/auth";
import { emailRules, nameRules, registerPasswordRules } from "./rules";

export default defineComponent({
  name: "RegisterForm",
  setup() {
    const initialState = {
      valid: true,
      name: "",
      email: "",
      password: "",
    };

    const state = reactive({ ...initialState });

    const rules = {
      name: nameRules,
      email: emailRules,
      password: registerPasswordRules,
    };

    const store = useStore<AuthState>();

    const submit = () => {
      const action = `${AUTH_STORE}/${AUTH_ACTION_TYPES.REGISTER}`;
      state satisfies RegisterParams;
      store.dispatch(action, state);
    };

    return { state, rules, submit };
  },
});
</script>

<style scoped lang="scss">
@use "@/styles/partials/auth_forms";
</style>
