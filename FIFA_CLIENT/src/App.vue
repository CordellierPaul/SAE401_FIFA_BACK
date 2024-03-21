<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue'
</script>

<template>
  <div>
    
    <HeaderComponent></HeaderComponent>
    
    <div id="content">
      <RouterView />
    </div>
    
  </div>

</template>

<style scoped>
</style>
