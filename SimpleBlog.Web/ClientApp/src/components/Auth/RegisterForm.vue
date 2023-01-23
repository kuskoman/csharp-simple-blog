<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-text-field v-model="name" :counter="10" :rules="nameRules" label="Name" required></v-text-field>
  </v-form>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "RegisterForm",
  data: () => ({
    valid: true,
    name: "",
    nameRules: [],
  }),
});
</script>

<style scoped lang="scss"></style>
