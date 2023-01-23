<template>
  <div v-for="alert in alerts" :key="alert.id">
    <single-alert :type="alert.type" :body="alert.body" :title="alert.title" :id="alert.id"></single-alert>
  </div>
</template>

<script lang="ts" setup>
import { useStore } from "vuex";
import { Ref } from "vue";
import { AlertState, AlertWithId, ALERT_ACTION_TYPES, ALERT_STORE } from "../../store/alert";

const store = useStore<AlertState>();
const getterName = `${ALERT_STORE}/${ALERT_ACTION_TYPES.GET_ALERTS}`;
const alerts: Ref<AlertWithId[]> = store.getters[getterName];
</script>

<script lang="ts">
import { defineComponent } from "vue";
import SingleAlert from "./SingleAlert.vue";

export default defineComponent({
  name: "AlertBox",
  components: {
    SingleAlert,
  },
});
</script>

<style scoped lang="scss"></style>
