<script setup>
import ProduitComponent from '@/components/ProduitComponent.vue'

</script>

<template>
    <div class="flex">
        <div id="left_part" class="bg-base-300 hidden lg:block w-72">
            <p class="flex justify-center text-xl">Filtres</p>
            <div class="divider"></div> 
            <div class="bg-base-100">
                <div class="ml-5">
                    <p class="text-lg">Pays</p>
                    <ul class="">
                        <div class="flex items-center"><input type="checkbox" class="checkbox checkbox-sm"/><span class="ml-4">France</span></div>
                    </ul>
                </div>
            </div>
        </div>
        <div id="right_part" class="w-full">
            <div class="bg-base-200 p-10">
                <p>dezbjfrbi</p>
            </div>
            <div id="container" class="flex flex-wrap items-center justify-center gap-10">
                <ProduitComponent v-for="index in 30" :key="index" />

            </div>
        </div>
    </div>
</template>






<style scoped>

</style>