<script setup>
    import ProduitComponent from '@/components/ProduitComponent.vue';
    import FiltreComponent from '@/components/FiltreComponent.vue';
        
    import { onMounted, ref } from 'vue'
    import { getRequest } from '../composable/httpRequests.js'

    const produits = ref()

    const tailles = ref()
    const taillesLibelle = ref([])

    const genres = ref()
    const genresNom = ref([])

    const coloris = ref()
    const colorisNom = ref([])

    getRequest(produits, "https://apififa.azurewebsites.net/api/produit")


    async function fetchObjects() {
        // pour avoir les tailles
        const tailleResponse = await fetch("https://apififa.azurewebsites.net/api/taille", {
            method: "GET",
            mode: "cors"
        })

        tailles.value = await tailleResponse.json()
        
        tailles.value.forEach(taille => {
            taillesLibelle.value.push(taille.tailleLibelle);
        });

        // pour avoir les genre
        const genreResponse = await fetch("https://apififa.azurewebsites.net/api/genre", {
            method: "GET",
            mode: "cors"
        })

        genres.value = await genreResponse.json()

        genres.value.forEach(genre => {
            genresNom.value.push(genre.genreNom);
        });

        // pour avoir les coloris
        const colorisResponse = await fetch("https://apififa.azurewebsites.net/api/coloris", {
            method: "GET",
            mode: "cors"
        })

        coloris.value = await colorisResponse.json()

        coloris.value.forEach(coloris => {
            colorisNom.value.push(coloris.colorisNom);
        });

    }

    onMounted(fetchObjects)


    const optionsTaillesChecked = ref([])
    const optionsGenresChecked = ref([])
    const optionsColorisChecked = ref([])


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
                <p class="flex justify-center text-xl m-5"  >Filtres</p>
                
                <FiltreComponent v-model:optionsChecked="optionsTaillesChecked" v-if="taillesLibelle" :filtreData="{ titre: 'Taille', options: taillesLibelle }" />
                <FiltreComponent v-model:optionsChecked="optionsGenresChecked" v-if="genresNom" :filtreData="{ titre: 'Genre', options: genresNom }" />
                <FiltreComponent v-model:optionsChecked="optionsColorisChecked" v-if="colorisNom" :filtreData="{ titre: 'Coloris', options: colorisNom }" />


            </div>
            <div id="right_part" class="w-full bg-base-200">
                <div class="m-5">
                    <p v-if="produits">{{ produits.length }} résultats</p>
                    {{ optionsTaillesChecked }}
                    {{ optionsGenresChecked }}
                    {{ optionsColorisChecked }}
                    

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