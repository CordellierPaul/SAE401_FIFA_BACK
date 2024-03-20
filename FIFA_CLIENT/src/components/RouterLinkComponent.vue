<template>
    
    <RouterLink class="px-2 py-1 text-white text-2xl" :to="to" v-html="text"></RouterLink>

</template>

<script setup>
   import { defineProps } from 'vue';

    const props = defineProps({
        text: String,
        to: String, 
    });
</script>

<style scoped>




</style>