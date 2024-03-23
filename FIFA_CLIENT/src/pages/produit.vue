<template>
    
    <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

        <!-- Liens entre les pages -->
        <div class="text-sm breadcrumbs hidden lg:block">
            <ul>
                <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Produits</a></li> 
                <!-- Titre de la page actuelle -->
                <li>ADIDAS ARGENTINA WINNERS HOME JERSEY - WOMEN'S</li>
            </ul>
        </div>
    </div>


    <div class="flex">
        <div  class="bg-base-300 hidden lg:block w-1/2 p-2">
            <div class="carousel carousel-center size-11/12 p-8 space-x-4 bg-neutral rounded-box">
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
    
        <div  class="w-1/2 bg-base-300 p-2">
            <p class="text-2xl font-bold">ADIDAS ARGENTINA WINNERS HOME JERSEY - WOMEN'S</p>
            <p class="text-2xl">90€</p>
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

            <button class="btn btn-block btn-accent my-5">AJOUTER AU PANIER</button>
            <div>
                <p class="font-semibold">Description</p>
                <p class="my-5">Un style indémodable pour les vainqueurs de la Coupe du Monde de la FIFA 2022™. Que les puristes se rassurent, on retrouve bien évidemment les mythiques bandes bleues et blanches, ainsi que le fameux emblème « Sol de Mayo », sur ce maillot domicile de l’Argentine. Les trois étoiles évoquent les titres mondiaux de l’Albiceleste, dont le sacre décroché au Qatar. Doté de la technologie absorbante AEROREADY et d’un écusson brodé, ce maillot permet d’exprimer votre passion dans un confort optimal en toute circonstance. Cet article est fabriqué à l’aide de matériaux 100% recyclés. Réutiliser d’anciens articles nous permet de diminuer les déchets, notre dépendance aux ressources limitées ainsi que l’empreinte carbone de nos produits.</p>
            </div>
        </div>

    </div>

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
    