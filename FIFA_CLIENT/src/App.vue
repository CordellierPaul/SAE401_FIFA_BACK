<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue'
</script>

<template>
  <HeaderComponent></HeaderComponent>

  <div id="content">
    <RouterView />
  </div>
</template>

<style scoped>
#content {
  padding: 0 10vw;
}
</style>
