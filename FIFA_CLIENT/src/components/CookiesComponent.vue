<script setup>
    import {ref} from 'vue';

    const visible = ref("block")

    function hide(){
        visible.value = "hidden"
    }
</script>

<template>

<div :class="visible" class="card w-96 bg-neutral text-neutral-content fixed z-50 top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2">
  <div class="card-body items-center text-center">
    <h2 class="card-title">Cookies!</h2>
    <p>We are using cookies for no reason.</p>
    <div class="card-actions justify-end">
      <button @click="hide" class="btn btn-primary">Accept</button>
      <button @click="hide" class="btn btn-ghost">Deny</button>
    </div>
  </div>
</div>

</template>
