<template>
    
  <div class="">
    <div class="divider mx-10"></div> 
      <div class="ml-5">
        <div @click="toggleChevronDescription" class="collapse ">
          <input type="checkbox" /> 
          <div class="collapse-title  ">
            <div  class="flex justify-between items-center">
                  <p class="text-lg ">{{ titre }}</p>
                  <i :class="classChevron"></i>
                </div>
            </div>
            <div class="collapse-content">
              <div v-for="option in options" :key="option" class="flex items-center">
                <input @click="toggleOption(option)" type="checkbox" class="checkbox checkbox-accent checkbox-sm "/>
                <span class="ml-4">{{ option }}</span>
              </div>
            </div>
          </div>
      </div>
    </div>
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

  const optionsChecked = defineModel("optionsChecked",{default: []})

  function toggleOption(option){

    if (optionsChecked.value.includes(option)) {
      optionsChecked.value.splice(optionsChecked.value.indexOf(option),1)
    }
    else{
      optionsChecked.value.push(option) 
    }

    console.log(optionsChecked.value);

  }

  //  Pour changer le le sans du chevron 
  const classChevron = ref('fa-solid fa-chevron-down')

    function toggleChevronDescription() {
        if (classChevron.value == 'fa-solid fa-chevron-down'){
            classChevron.value = 'fa-solid fa-chevron-up'
        }else{
            classChevron.value = 'fa-solid fa-chevron-down'
        }
    }

  </script>
  