<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <div class="form-box">
      <v-text-field v-model="name" :rules="nameRules" label="Name" placeholder=" Jan" required></v-text-field>
      <v-text-field
        v-model="email"
        :rules="emailRules"
        label="Register"
        placeholder=" jannowak@example.com"
        required
      ></v-text-field>
      <v-text-field v-model="password" :rules="passwordRules" label="Password" placeholder=" *******"></v-text-field>
      <v-btn color="success" class="me-4 submit-btn" @click="submit">Submit</v-btn>
    </div>
  </v-form>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { emailRules, nameRules, registerPasswordRules } from "./rules";

export default defineComponent({
  name: "RegisterForm",
  data: () => ({
    valid: true,
    name: "",
    email: "",
    password: "",
    nameRules,
    emailRules,
    passwordRules: registerPasswordRules,
    submit: () => {
      alert("albert");
    },
  }),
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
