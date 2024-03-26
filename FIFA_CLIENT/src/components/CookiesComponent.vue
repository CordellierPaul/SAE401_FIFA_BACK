<script setup>
    import {ref} from 'vue';

    const visible = ref("fixed")

    function hide(){
        visible.value = "hidden"
    }
</script>

<template>


<div :class="visible" role="alert" class="alert border-none bottom-0 left-0 right-0 mb-4 mx-auto max-w-5xl bg-secondary text-sm text-base-content z-50">
  <i class="fa-solid fa-cookie text-white text-3xl"></i>
  <span class="ml-2 text-white">On utilise des cookies mais pour aucune raison valable. :)</span>
  <div class="mt-2 text-center *:m-1">
    <button @click="hide" class="btn btn-sm">Deny</button>
    <button @click="hide" class="btn btn-sm btn-primary">Accept</button>
  </div>
</div>

</template>
