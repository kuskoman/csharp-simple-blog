<template>
  <div v-if="isUserAdmin">
    <v-btn icon color="info" class="new-blog-btn" size="large" elevation="2" fab @click="onClick">
      <v-icon>mdi-plus</v-icon>
    </v-btn>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import { computed } from "vue";
import { AUTH_ACTION_TYPES, AUTH_STORE } from "../../store/auth";

const router = useRouter();
const store = useStore();

const onClick = () => {
  router.push("/posts/new");
};

const userRoleGetter = `${AUTH_STORE}/${AUTH_ACTION_TYPES.GET_USER_ROLE}`;
const userRole = computed(() => store.getters[userRoleGetter]);

const isUserAdmin = userRole.value.toLowerCase() === "Admin".toLowerCase();
</script>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "NewBlogButton",
});
</script>

<style scoped lang="scss">
@import "@/styles/mixins/buttons.scss";

.new-blog-btn {
  @include fab;
}
</style>
