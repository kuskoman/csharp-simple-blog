<template>
  <div class="d-flex align-center flex-column">
    <v-card width="800" variant="tonal" class="register-card"> Test </v-card>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "RegisterView",
});
</script>

<style lang="scss" scoped>
@import "@/styles/mixins/card.scss";

.register-card {
  @include square-card;
}
</style>
