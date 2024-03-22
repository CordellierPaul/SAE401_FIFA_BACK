<template>
    
    <a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Retour</a>

</template>
    
<script setup>
    import { defineProps } from 'vue';
    import { useRoute,useRouter } from 'vue-router';

    const router = useRouter();

    const props = defineProps({
        
    });

    function retour (){
        router.back()
    }

</script>
    