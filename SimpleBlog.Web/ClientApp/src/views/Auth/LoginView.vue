<template>
  <div class="d-flex align-center flex-column">
    <v-card width="800" variant="tonal" class="login-card">
      <v-card-title class="auth-card-title">Login</v-card-title>
      <v-card-subtitle class="login-subtitle">Sign in to your account</v-card-subtitle>
      <login-form></login-form>
    </v-card>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import LoginForm from "../../components/Auth/LoginForm.vue";

export default defineComponent({
  name: "LoginView",
  components: {
    LoginForm,
  },
});
</script>

<style lang="scss" scoped>
@use "@/styles/partials/auth_forms";

@import "@/styles/mixins/card.scss";

.login-card {
  @include square-card;
}
</style>
