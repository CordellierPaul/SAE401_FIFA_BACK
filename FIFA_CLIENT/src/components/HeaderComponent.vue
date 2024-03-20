<template>
  <header class="h-28 bg-cyan-800 flex items-center justify-around ">
    <RouterLinkComponent :to="'/'" :text="'FIFA'"/>

    <nav class="">
      <RouterLinkComponent :to="'/about'" :text="'A propos'"/>
      <RouterLinkComponent :to="'/products'" :text="'Produits'"/>
      <RouterLinkComponent :to="'/user'" :text="'<i class=\'fa-regular fa-user\'></i>'"/>
    </nav>
  </header>
  
</template>

<script setup>
  import RouterLinkComponent from './RouterLinkComponent.vue'

</script>

<style scoped>

</style>