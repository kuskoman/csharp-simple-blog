<template>
  <v-alert
    :type="type"
    :icon="`$${type}`"
    :title="title"
    v-model="alert"
    closable
  >
    {{ body }}
  </v-alert>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { PropType } from "vue";
import {
  ALERT_TYPE,
  ALERTS_ARRAY,
  ALERT_ACTION_TYPES,
  ALERT_STORE,
} from "@/store/alert";
import store from "@/store";

const dispatchAlertRemoveName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.REMOVE_ALERT}`;

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
  data: () => ({
    alert: true,
  }),
  watch: {
    async alert(val: boolean) {
      if (!val) {
        const alertId = this.$props.id;
        store.commit(dispatchAlertRemoveName, alertId);
      }
    },
  },
});
</script>

<style scoped lang="scss"></style>
