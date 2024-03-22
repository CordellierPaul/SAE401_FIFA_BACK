<template>
    
  <div class="">
    <div class="divider mx-10"></div> 
      <div class="ml-5">
        <p class="text-lg mb-4">{{ titre }}</p>
        <div v-for="option in options" :key="option" class="flex items-center">
          <input type="checkbox" class="checkbox checkbox-accent checkbox-sm "/>
          <span class="ml-4">{{ option }}</span>
        </div>
      </div>
    </div>
</template>
  
  <script setup>
  import { defineProps } from 'vue';
  
  const props = defineProps({
    filtreData: {
      type: Object,
      required: true
    }
  });
  
  const titre = props.filtreData.titre;
  const options = props.filtreData.options;
  </script>
  