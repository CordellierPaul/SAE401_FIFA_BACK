<script setup>
    import ProduitComponent from '@/components/ProduitComponent.vue';
    import FiltreComponent from '@/components/FiltreComponent.vue';
        
    import { onMounted, ref } from 'vue'
    import { getRequest } from '../composable/httpRequests.js'

    const produits = ref()

    const produitsFiltre = ref([])

    const tailles = ref()
    const taillesLibelle = ref([])

    const genres = ref()
    const genresNom = ref([])

    const coloris = ref()
    const colorisNom = ref([])

    const categories = ref()
    const categoriesNom = ref([])

    const pays = ref()
    const paysNom = ref([])

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

        // pour avoir les categories
        const categorisResponse = await fetch("https://apififa.azurewebsites.net/api/categorie", {
            method: "GET",
            mode: "cors"
        })

        categories.value = await categorisResponse.json()

        categories.value.forEach(categorie => {
            categoriesNom.value.push(categorie.categorieNom);
        });

        // pour avoir les pays
        const paysResponse = await fetch("https://apififa.azurewebsites.net/api/pays", {
            method: "GET",
            mode: "cors"
        })

        pays.value = await paysResponse.json()

        pays.value.forEach(pays => {
            paysNom.value.push(pays.paysNom);
        });

    }

    onMounted(fetchObjects)


    const optionsTaillesChecked = ref([])
    const optionsGenresChecked = ref([])
    const optionsColorisChecked = ref([])
    const optionsCategoriesChecked = ref([])
    const optionsPaysChecked = ref([])

    function emptyList(){
        optionsTaillesChecked.value = [];
        optionsGenresChecked.value = [];
        optionsColorisChecked.value = [];
        optionsCategoriesChecked.value = [];
        optionsPaysChecked.value = [];
    }

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
                <FiltreComponent v-model:optionsChecked="optionsCategoriesChecked" v-if="categoriesNom" :filtreData="{ titre: 'Categorie', options: categoriesNom }" />
                <FiltreComponent v-model:optionsChecked="optionsPaysChecked" v-if="paysNom" :filtreData="{ titre: 'Pays', options: paysNom }" />


            </div>
            <div id="right_part" class="w-full bg-base-200">
                <div class="flex m-5 gap-2">
                    <div class=" whitespace-nowrap" v-if="produits">
                        <div class="flex gap-2">
                            {{ produits.length }} résultats
                            <div class="flex gap-2" v-if="optionsTaillesChecked.length != 0 || optionsGenresChecked.length != 0 || optionsColorisChecked.length != 0 || optionsCategoriesChecked.length != 0 || optionsPaysChecked.length != 0">
                                pour
                                <div class=" flex gap-2 flex-wrap *:badge *:badge-neutral *:flex *:gap-2">
                                    <div v-if="optionsTaillesChecked" v-for="(taille, index) in optionsTaillesChecked" :key="taille"><div @click="optionsTaillesChecked.splice(index,1)"><i class="fa-solid fa-xmark hover:cursor-pointer"></i></div>{{ taille }}</div>
                                    <div v-if="optionsGenresChecked" v-for="(genre, index) in optionsGenresChecked" :key="genre"><div @click="optionsGenresChecked.splice(index,1)"><i class="fa-solid fa-xmark hover:cursor-pointer"></i></div>{{ genre }}</div>
                                    <div v-if="optionsColorisChecked" v-for="(coloris, index) in optionsColorisChecked" :key="coloris"><div @click="optionsColorisChecked.splice(index,1)"><i class="fa-solid fa-xmark hover:cursor-pointer"></i></div>{{ coloris }}</div>
                                    <div v-if="optionsCategoriesChecked" v-for="(categorie, index) in optionsCategoriesChecked" :key="categorie"><div  @click="optionsCategoriesChecked.splice(index,1)"><i class="fa-solid fa-xmark hover:cursor-pointer"></i></div>{{ categorie }}</div>
                                    <div v-if="optionsPaysChecked" v-for="(pays, index) in optionsPaysChecked" :key="pays"><div  @click="optionsPaysChecked.splice(index,1)"><i class="fa-solid fa-xmark hover:cursor-pointer"></i></div>{{ pays }}</div>
                                    <div class="hover:cursor-pointer" @click="emptyList"> Supprimer tous les filtres </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div id="container" class="flex flex-wrap items-center justify-center gap-10 p-2">
                    <!-- <p v-if="produits" v-for="produit in produits" :id="produit.produitId" :nom="produit.produitNom"> {{ produit.variantesProduit[0] }} </p> -->
                    <div v-if="produitsFiltre.length != 0">non</div>
                    <ProduitComponent v-else-if="produits" v-for="produit in produits" :id="produit.produitId" :nom="produit.produitNom" />
                    <div v-else v-for="i in 5" >
                        <div class="flex flex-col gap-4 w-52">
                            <div class="skeleton h-32 w-full"></div>
                            <div class="skeleton h-4 w-28"></div>
                            <div class="skeleton h-4 w-full"></div>
                            <div class="skeleton h-4 w-full"></div>
                        </div>
                    </div>
                </div>
                <div class="m-10 flex items-center justify-center">
                    <button class="btn btn-primary text-white">Voir plus</button>
                </div>
            </div>
        </div>
    </div>
</template>