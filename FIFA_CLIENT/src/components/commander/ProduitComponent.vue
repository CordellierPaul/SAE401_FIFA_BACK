<template>

    <div class="flex h-fit items-center  gap-2   ">
        <img class="h-32" :src="img" alt="">

        <div class="flex gap-2 bg-neutral-400 justify-between">

            <div class="w-3/5  flex flex-col gap-2">
                <p class="text-xl">{{ title }}</p>
                <p><strong>Qté:</strong> {{ qte }}</p>
                <p><strong>Taille:</strong> {{ size }}</p>
                <p><strong>Couleur:</strong> {{ clr }}</p>
            </div>
            <p>{{ prz }}€</p>
            <p class="line-through font-light">{{ oldprz }}€</p>
        </div>
    </div>

</template>
  
<script setup>
    import { ref } from 'vue';
    
    defineProps({
        img: String,
        title: String,
        qte: String,
        size: String,
        clr: String,
        prz: String,
        oldprz: String,
    })

</script>