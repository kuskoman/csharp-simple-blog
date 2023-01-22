<template>
  <v-app>
    <v-app-bar title="Application"></v-app-bar>

    <v-navigation-drawer
      ><router-link to="/">Home</router-link>
      <router-link to="/about">About</router-link></v-navigation-drawer
    >

    <v-main><router-view /></v-main>
  </v-app>
</template>

<style lang="scss">
@import "./styles/index.scss";
</style>
