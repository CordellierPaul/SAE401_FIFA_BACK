<script setup>
import ProduitComponent from '@/components/ProduitComponent.vue'

</script>

<template>
    <div class="flex">
        <div id="left_part" class="bg-base-300 hidden lg:block w-72">
            <div>
                <p>Pays</p>
                <ul>
                    <li>France</li>
                    <li>France</li>
                    <li>France</li>
                    <li>France</li>
                    <li>France</li>
                </ul>
            </div>
        </div>
        <div id="right_part" class="flex flex-wrap p-10 w-full gap-10 items-center justify-center">
            <ProduitComponent v-for="index in 30" :key="index" />
        </div>
    </div>
</template>






<style scoped>

</style>