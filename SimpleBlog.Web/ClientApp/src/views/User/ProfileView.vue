<template>
  <div class="d-flex align-center flex-column">
    <v-card width="800" variant="tonal" class="profile-card">
      <v-card-title class="auth-card-title">
        {{ user.name }}
      </v-card-title>
      <v-card-subtitle class="profile-subtitle">Your profile</v-card-subtitle>
      <v-spacer></v-spacer>
      <div class="profile-data">
        <p class="profile-paragraph">
          <v-icon size="small">mdi-badge-account</v-icon>
          <span class="profile-field-name">Id: </span>
          {{ user.id }}
        </p>
        <p class="profile-paragraph">
          <v-icon size="small">mdi-account</v-icon>
          <span class="profile-field-name">Name: </span>
          {{ user.name }}
        </p>
        <p class="profile-paragraph">
          <v-icon size="small">mdi-email</v-icon>
          <span class="profile-field-name">Email: </span>
          {{ user.email }}
        </p>
        <p class="profile-paragraph" v-if="user.roles?.length > 0">
          <v-icon size="small">mdi-account-key</v-icon>
          <span class="profile-field-name">Roles: </span>
          {{ user.roles.join(", ") }}
        </p>
      </div>
    </v-card>
  </div>
</template>

<script lang="ts" setup>
import { useStore } from "vuex";
import { AUTH_STORE, AUTH_ACTION_TYPES } from "../../store/auth";

const store = useStore();

const refreshUserActionName = `${AUTH_STORE}/${AUTH_ACTION_TYPES.FETCH_USER_DATA}`;
store.dispatch(refreshUserActionName);

const { user } = store.state.auth;
</script>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ProfileView",
});
</script>

<style lang="scss">
@import "@/styles/mixins/card.scss";

.profile-card {
  @include square-card;
}

.profile-data {
  margin-top: 30px;
}

.profile-field-name {
  font-weight: bold;
  margin: {
    left: 0.3em;
  }
}

.profile-paragraph {
  margin: {
    top: 0.35em;
    bottom: 0.35em;
  }
}
</style>
