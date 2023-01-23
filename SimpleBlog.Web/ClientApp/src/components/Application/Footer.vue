<template>
  <v-footer color="primary" class="application-footer">
    <span class-name="footer-text">Created by Jakub Surdej for zaliczenie przedmiotu</span>
  </v-footer>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ApplicationFooter",
});
</script>

<style scoped lang="scss">
.application-footer {
  padding: 20px;
}
</style>
