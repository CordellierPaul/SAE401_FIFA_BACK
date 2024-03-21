<template>
    
    <RouterLink class="btn btn-ghost text-xl" :to="{name: name}" v-html="text"></RouterLink>

</template>

<script setup>
   import { defineProps } from 'vue';

    const props = defineProps({
        text: String,
        to: String, 
        name: String
    });
</script>

<style scoped>




</style>