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
        <div  class=" bg-base-200 hidden lg:block w-1/2 p-2 mr-1">
            <div class="carousel carousel-center w-11/12 p-8 space-x-4 bg-neutral rounded-box scrollbar" >
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Flegends.broadleafcloud.com%2Fapi%2Fasset%2Fcontent%2FARG%2520FRONT.png%3FcontextRequest%3D%257B%2522forceCatalogForFetch%2522%3Afalse%2C%2522applicationId%2522%3A%252201GPYEXET5B7Y61HW8TB4R0YWE%2522%2C%2522tenantId%2522%3A%2522FIFA%2522%257D&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FIB3596_3_APPAREL_Photography_BackCenterView_white.jpg%3Fv%3D1674806837&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FIB3596_5_APPAREL_Photography_DetailView2_white.jpg%3Fv%3D1674806838&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FIB3596_4_APPAREL_Photography_DetailView1_white.jpg%3Fv%3D1674806838&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FIB3596_6_APPAREL_Photography_DetailView3_white.jpg%3Fv%3D1674806838&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
                <div class="carousel-item w-fit">
                    <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FIB3596_10_APPAREL_OnModel_WalkingView_white.jpg%3Fv%3D1674806838&w=3840&q=85" class="rounded-box" alt="Tailwind CSS Carousel component" />
                </div> 
            </div>
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
                <p>COLOR:</p>
                <p>BLUE</p>
            </div>
            <div class="size-8 bg-blue-500 border-solid border-black border-2">

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
                    <ul class="list-disc pl-4">
                        <li>Coupe droite</li>
                        <li>Col rond côtelé</li>
                        <li>Maille double 100% polyester recyclé</li>
                        <li>AEROREADY</li>
                        <li>Empiècements en mesh sous les bras</li>
                        <li>Manches côtelées</li>
                        <li>Coupe plus longue à l’arrière</li>
                        <li>Écusson brodé de l’Argentine</li>
                    </ul>
                    <p class="my-5">Un style indémodable pour les vainqueurs de la Coupe du Monde de la FIFA 2022™. Que les puristes se rassurent, on retrouve bien évidemment les mythiques bandes bleues et blanches, ainsi que le fameux emblème « Sol de Mayo », sur ce maillot domicile de l’Argentine. Les trois étoiles évoquent les titres mondiaux de l’Albiceleste, dont le sacre décroché au Qatar. Doté de la technologie absorbante AEROREADY et d’un écusson brodé, ce maillot permet d’exprimer votre passion dans un confort optimal en toute circonstance. Cet article est fabriqué à l’aide de matériaux 100% recyclés. Réutiliser d’anciens articles nous permet de diminuer les déchets, notre dépendance aux ressources limitées ainsi que l’empreinte carbone de nos produits.</p>
                </div>

            </div>
            
                
        </div>    
    </div>
    
    <div class="p-2 w-full bg-base-200 mt-2">
        <p class="text-2xl font-bold">Produits associés</p>
        <div id="container" class="flex overflow-x-auto w-full gap-10 p-2">
            <ProduitComponent class="min-w-96" v-for="index in 21" :key="index" />
        </div>
    </div>
    
</template>
    
<script setup>
    import { defineProps, ref, onMounted } from 'vue';
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
        console.log("caca");
        if (classChevron.value == 'fa-solid fa-chevron-down'){
            classChevron.value = 'fa-solid fa-chevron-up'
        }else{
            classChevron.value = 'fa-solid fa-chevron-down'
        }
    }

    const produit = ref([])

    const variantesProduit = ref([])

    const varianteProduitPrix = ref()
    const varianteProduitPromo = ref()
    const variantProduitPrixAvecPromo = ref()


    async function fetchProduit() {
        const response = await fetch(`https://apififa.azurewebsites.net/api/produit/getbyid/${route.query.id}`, {
            method: "GET",
            mode: "cors"
        })

        produit.value = await response.json()
        variantesProduit.value = produit.value.variantesProduit
        varianteProduitPromo.value = variantesProduit.value.$values[0].varianteProduitPromo
        varianteProduitPrix.value = variantesProduit.value.$values[0].varianteProduitPrix

        // calcul du prix avec promo
        if (varianteProduitPrix.value) {
            variantProduitPrixAvecPromo.value = (varianteProduitPrix.value - (varianteProduitPrix.value * varianteProduitPromo.value)).toFixed(2);
        }

        


    }

    onMounted(fetchProduit)


</script>

<style scoped>
</style>
    