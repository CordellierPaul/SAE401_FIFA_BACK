<template>
    
  <div class="">
    <div class="divider mx-10"></div> 
      <div class="ml-5">
        <p class="text-lg mb-4">{{ titre }}</p>
        <div v-for="option in options" :key="option" class="flex items-center">
          <input @click="toggleOption(option)" type="checkbox" class="checkbox checkbox-accent checkbox-sm "/>
          <span class="ml-4">{{ option }}</span>
        </div>
      </div>
    </div>

    <button @click="addNb(1)">+</button>
    <slot name="count" :count="count">{{ count }}</slot>
</template>
  
  <script setup>
  import { defineProps, ref } from 'vue';
  
  const props = defineProps({
    filtreData: {
      type: Object,
      required: true
    }
  });
  
  const titre = props.filtreData.titre;
  const options = props.filtreData.options;

  const optionsCheck = []

  function toggleOption(option){

    if (optionsCheck.includes(option)) {
      optionsCheck.splice(optionsCheck.indexOf(option),1)
    }
    else{
      optionsCheck.push(option) 
    }

    console.log(optionsCheck);

  }
  
  const emit = defineEmits(['next','previous'])

  function btPreviousClick() {
      emit('previous')
  }

  const count = defineModel("count",{default: 0})

  function addNb(number){
        count.value = count.value + number;
    }

  </script>
  