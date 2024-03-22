<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue'
import FooterComponent from './components/FooterComponent.vue'
</script>

<template>
  <div>
    
    <HeaderComponent></HeaderComponent>
    
    <div id="content">
      <RouterView />
    </div>
    
    <FooterComponent></FooterComponent>
  </div>

</template>

<style scoped>
</style>
