<template>
  <div class="d-flex align-center flex-column">
    <v-card width="800" variant="tonal" class="register-card">
      <v-card-title>Register</v-card-title>
      <v-card-subtitle class="register-subtitle">Create an account</v-card-subtitle>
      <register-form></register-form>
    </v-card>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import RegisterForm from "../components/Auth/RegisterForm.vue";

export default defineComponent({
  name: "RegisterView",
  components: {
    RegisterForm,
  },
});
</script>

<style lang="scss" scoped>
@import "@/styles/mixins/card.scss";

.register-card {
  @include square-card;
}

.register-subtitle {
  margin-bottom: 15px;
}
</style>
