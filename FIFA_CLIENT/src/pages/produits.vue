<script setup>
    import ProduitComponent from '@/components/ProduitComponent.vue';
    import FiltreComponent from '@/components/FiltreComponent.vue';
        
    import { onMounted, ref } from 'vue'
    import { getRequest } from '../composable/httpRequests.js'

    const produits = ref()

    getRequest(produits, "https://apififa.azurewebsites.net/api/produit")
</script>

<template>
    <div>
        <div class="sticky top-20 z-[5] bg-secondary p-4 flex justify-between items-center min-h-20 " id="right_part">
            <div class="text-sm breadcrumbs text-white start hidden lg:block">
            <ul>
                <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Produits</a></li>
            </ul>
        </div>
            <select class="select select-primary w-full max-w-xs lg:hidden">
                <option selected>Filtrer par</option>
            </select>
            <select class="select select-primary w-full max-w-xs bg-secondary text-white border-white">
                <option selected>Classer par défaut</option>
                <option>Prix: Par ordre croissant</option>
                <option>Prix: Par ordre décroissant</option>
            </select>
        </div>
        
        <div class="flex">
            <div id="left_part" class="bg-base-300 hidden lg:block w-72">
                <p class="flex justify-center text-xl m-5">Filtres</p>
                
                <FiltreComponent :filtreData="{ titre: 'Taille', options: ['S', 'M', 'L', 'XL'] }" />
                <FiltreComponent :filtreData="{ titre: 'Genre', options: ['Homme', 'Femme', 'Jeune'] }" />
                <FiltreComponent :filtreData="{ titre: 'Coloris', options: ['Bleu', 'Rouge', 'Vert', 'Orange', 'Noir', 'Blanc', 'Gris', 'Rose'] }" />


            </div>
            <div id="right_part" class="w-full bg-base-200">
                <div class="m-5">
                    <p>30 résultats</p>

                </div>
                <div id="container" class="flex flex-wrap items-center justify-center gap-10 p-2">
                    <!-- <p v-if="produits" v-for="produit in produits" :id="produit.produitId" :nom="produit.produitNom"> {{ produit.produitId }} et {{ produit.produitNom }} </p> -->
                    <ProduitComponent v-if="produits" v-for="produit in produits" :id="produit.produitId" :nom="produit.produitNom" />
                </div>
                <div class="m-10 flex items-center justify-center">
                    <button class="btn btn-primary text-white">Voir plus</button>
                </div>
            </div>
        </div>
    </div>
</template>