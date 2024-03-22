<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue'
import FooterComponent from './components/FooterComponent.vue'
import CookieComponent from './components/CookiesComponent.vue'
</script>

<template>
  <div>
    
    <HeaderComponent></HeaderComponent>

    <CookieComponent></CookieComponent>
    
    <div id="content">
      <RouterView />
    </div>
    
    <FooterComponent></FooterComponent>
  </div>

</template>

<style scoped>
</style>
