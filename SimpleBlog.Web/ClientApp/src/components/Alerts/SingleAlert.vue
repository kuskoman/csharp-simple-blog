<template>
  <v-alert :type="type" :icon="`$${type}`" :title="title">
    {{ body }}
  </v-alert>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { PropType } from "vue";
import { ALERT_TYPE, ALERTS_ARRAY } from "@/store/alert";

export default defineComponent({
  name: "SingleAlert",
  props: {
    title: String,
    body: String,
    type: {
      type: String as PropType<ALERT_TYPE>,
      validator: (prop: ALERT_TYPE) => ALERTS_ARRAY.includes(prop),
      required: true,
    },
    id: String,
  },
});
</script>

<style scoped lang="scss"></style>
