<template>
  <!-- A simple card with two buttons: register and login -->
  <v-card class="mx-auto" max-width="800">
    <v-card-title class="auth-card-title" tag="h2">Register or login</v-card-title>
    <v-card-text class="text-center auth-btn-box">
      <v-btn color="success" class="auth-btn" @click="onRegisterClick">Register</v-btn>
      <v-btn color="info" class="auth-btn" @click="onLoginClick">Login</v-btn>
      <v-btn color="error" class="auth-btn" @click="$router.go(-1)">Cancel</v-btn>
    </v-card-text>
  </v-card>
</template>

<style scoped lang="scss">
@use "@/styles/partials/auth_forms";
</style>

<script lang="ts">
import { defineComponent } from "vue";
import { useRouter } from "vue-router";

export default defineComponent({
  name: "AuthView",
  setup() {
    const router = useRouter();

    const onRegisterClick = () => {
      router.push({ name: "register" });
    };

    const onLoginClick = () => {
      router.push({ name: "login" });
    };

    return { onRegisterClick, onLoginClick };
  },
});
</script>
