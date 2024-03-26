<script setup>
    import {ref} from 'vue';

    const visible = ref("fixed")

    function hide(){
        visible.value = "hidden"
    }
</script>

<template>


<div :class="visible" role="alert" class="alert bottom-0 left-0 right-0 mb-4 mx-auto max-w-5xl bg-secondary text-sm text-base-content z-50">
  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="stroke-info shrink-0 w-6 h-6 mx-2"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
  <span class="ml-2 text-white">we use cookies for no reason.</span>
  <div class="mt-2 text-center">
    <button @click="hide" class="btn btn-sm">Deny</button>
    <button @click="hide" class="btn btn-sm btn-primary">Accept</button>
  </div>
</div>

</template>
