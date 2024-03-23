<template>
    
    <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white" >

        <div class="text-sm breadcrumbs">
            <ul>
                <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Produits</a></li> 
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
            <p class="text-2xl">ADIDAS ARGENTINA WINNERS HOME JERSEY - WOMEN'S</p>
            <p class="text-2xl">90€</p>
            <div class="flex justify-between">
                <p>SIZE</p>
                <p>SIZE GUIDE</p>
            </div>
            <div class="flex gap-1">
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

            <button class="btn btn-block">ADD TO CART</button>
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
    