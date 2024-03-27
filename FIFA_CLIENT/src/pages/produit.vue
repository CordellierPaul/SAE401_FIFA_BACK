<template>
    
    <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

        <!-- Liens entre les pages -->
        <div class="text-sm breadcrumbs hidden lg:block">
            <ul>
                <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Produits</a></li> 
                <!-- Titre de la page actuelle -->
                <li>MAILLOT DOMICILE VAINQUEUR ARGENTINE ADIDAS – FEMME</li>
            </ul>
        </div>
    </div>


    <div class="flex ">
        <div  class=" flex justify-center items-center bg-base-200  lg:block w-1/2 p-2 mr-1">
  
            <img v-if="image" :src="image" alt="">

        </div>

        

        <div  class="bg-base-200 w-1/2  p-2 ml-1" >
            <p class="text-2xl font-bold" v-if="produit">{{produit.produitNom}}</p>
            <div class="flex gap-2">
                <p class="text-xl" v-if="varianteProduitPrix && varianteProduitPromo && variantProduitPrixAvecPromo"  >{{ variantProduitPrixAvecPromo}}€</p>
                <p class="text-xl font-light line-through" v-if="varianteProduitPrix">{{varianteProduitPrix}}€</p>
            </div>
            <div class="flex justify-between my-3">
                <p>Taille</p>
                <p>Guide des tailles</p>
            </div>
            <div class="flex gap-1 py-5">
                <button class="btn btn-square btn-outline btn-disabled">2XS</button>
                <button class="btn btn-square btn-outline">XS</button>
                <button class="btn btn-square btn-outline">S</button>
                <button class="btn btn-square btn-outline">M</button>
                <button class="btn btn-square btn-outline btn-disabled">L</button>
                <button class="btn btn-square btn-outline">XL</button>
                <button class="btn btn-square btn-outline">2XL</button>
            </div>
            <div class="flex gap-1">
                <p class="font-bold">COULEUR :</p>
                <p>{{ colorisNom }}</p>
            </div>
            <div v-if="colorisHexa" :class="colorisHexa" class="size-8 border-solid border-black border-2">

            </div>

            <button class="btn btn-block btn-accent text-white my-5">AJOUTER AU PANIER</button>
            <div @click="toggleChevronDescription" class="collapse bg-base-200 ">
                <input type="checkbox" /> 
                <div   class="collapse-title text-xl font-medium ">
                    <div  class="flex justify-between ">
                        <p class="font-semibold">Description</p>
                        <i :class="classChevron"></i>
                    </div>
                </div>
                <div class="collapse-content"> 
                    <p class="my-5" v-if="produit">{{ produit.produitDescription }}</p>
                </div>

            </div>
            
                
        </div>    
    </div>
    
    <div class="p-2 w-full bg-base-200 mt-2">
        <p class="text-2xl font-bold">Produits associés</p>
        <div id="container" class="flex overflow-x-auto w-full gap-10 p-2" v-if="listIdProduitsSimilaire">
            <ProduitComponent class="min-w-96" v-for="id in listIdProduitsSimilaire" :id="id" :key="id" />
        </div>
        <div v-else v-for="i in 5" >
            <div class="flex flex-col gap-4 w-52">
                <div class="skeleton h-32 w-full"></div>
                <div class="skeleton h-4 w-28"></div>
                <div class="skeleton h-4 w-full"></div>
                <div class="skeleton h-4 w-full"></div>
            </div>
        </div>
    </div>
    
</template>
    
<script setup>
    import { defineProps, ref, onMounted, watch, watchEffect } from 'vue';
    import { useRoute,useRouter } from 'vue-router';
    import ProduitComponent from '@/components/ProduitComponent.vue';
    import { isProxy, toRaw } from 'vue';

    const router = useRouter();
    const route = useRoute();

    const props = defineProps({
        
    });

    // Pour retourner à la page précédente

    function retour (){
        router.back()
    }

    // Pour changer le le sans du chevron de la déscription
    const classChevron = ref('fa-solid fa-chevron-down')

    function toggleChevronDescription() {
        if (classChevron.value == 'fa-solid fa-chevron-down'){
            classChevron.value = 'fa-solid fa-chevron-up'
        }else{
            classChevron.value = 'fa-solid fa-chevron-down'
        }
    }


    // Pour le data

    const produit = ref([])

    const variantesProduit = ref([])

    const varianteProduitPrix = ref()
    const varianteProduitPromo = ref()
    const variantProduitPrixAvecPromo = ref()

    const produitsSimilaire = ref()
    const listIdProduitsSimilaire = ref([])

    const coloris = ref()

    const colorisNom = ref()

    const colorisHexa = ref()

    const image = ref()

    watchEffect(()=>{
        fetchProduit()
        window.scrollTo({
            top: 0,
            behavior: 'smooth' // Pour un défilement fluide, utilisez 'smooth'
        });
    },{
        deep: true
    });

    async function fetchProduit() {
        const firstResponse = await fetch(`https://apififa.azurewebsites.net/api/produit/getbyid/${route.query.id}`, {
            method: "GET",
            mode: "cors"
        })

        produit.value = await firstResponse.json()
        variantesProduit.value = produit.value.variantesProduit
        varianteProduitPromo.value = variantesProduit.value[0].varianteProduitPromo
        varianteProduitPrix.value = variantesProduit.value[0].varianteProduitPrix

        // calcul du prix avec promo
        if (varianteProduitPrix.value) {
            variantProduitPrixAvecPromo.value = (varianteProduitPrix.value - (varianteProduitPrix.value * varianteProduitPromo.value)).toFixed(2);
        }   

        // pour avoir les produits similaires

        if (produit.value.produitSimilaireLienUn.length != 0) {
            produitsSimilaire.value = produit.value.produitSimilaireLienUn 
            produitsSimilaire.value.forEach(produit => {
    
                listIdProduitsSimilaire.value.push(produit.produitDeuxId)
            });
            
        }else{
            produitsSimilaire.value = produit.value.produitSimilaireLienDeux 
            produitsSimilaire.value.forEach(produit => {
                
                listIdProduitsSimilaire.value.push(produit.produitUnId)
            });
        }
        
        

        // pour avoir les coloris 
        const secondResponse = await fetch(`https://apififa.azurewebsites.net/api/coloris/getbyid/${variantesProduit.value[0].colorisId }`, {
            method: "GET",
            mode: "cors"
        })

        coloris.value = await secondResponse.json()
        colorisNom.value = coloris.value.colorisNom 

        if (coloris.value.colorisNom == 1) {
            colorisHexa.value = "bg-orange-200"
        }
        else if (coloris.value.colorisId == 2){
            colorisHexa.value = "bg-black"
        }
        else if (coloris.value.colorisId == 3){
            colorisHexa.value = "bg-blue-500"
        }
        else if (coloris.value.colorisId == 4){
            colorisHexa.value = "bg-green-500"
        }
        else if (coloris.value.colorisId == 5){
            colorisHexa.value = "bg-gray-500"
        }
        else if (coloris.value.colorisId == 6){
            colorisHexa.value = "bg-gradient-to-bl from-violet-600 via-yellow-400 to-green-600"
        }
        else if (coloris.value.colorisId == 7){
            colorisHexa.value = "bg-blue-800"
        }
        else if (coloris.value.colorisId == 8){
            colorisHexa.value = "bg-orange-500"
        }
        else if (coloris.value.colorisId == 9){
            colorisHexa.value = "bg-pink-500"
        }
        else if (coloris.value.colorisId == 10){
            colorisHexa.value = "bg-red-500"
        }
        else if (coloris.value.colorisId == 11){
            colorisHexa.value = "bg-white"
        }
        else if (coloris.value.colorisId == 12){
            colorisHexa.value = "bg-yellow-500"
        }
        else if (coloris.value.colorisId == 13){
            colorisHexa.value = "bg-purple-500"
        }

        // pour avoir l'image 
        const thirdResponse = await fetch(`https://apififa.azurewebsites.net/api/produit/getanimageofproduitbyid/${route.query.id}`, {
            method: "GET",
            mode: "cors"
        })

        if (thirdResponse.status === 404) {
            image.value = "/images/image_pas_trouvee.jpg"   
        }else{
            image.value = await thirdResponse.text()
        }

    }



</script>

<style scoped>
</style>
    