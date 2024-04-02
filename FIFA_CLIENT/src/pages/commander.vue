<script setup>
    import CommanderProduitComponent from '@/components/commander/ProduitComponent.vue';
    import StepInscription from '@/components/commander/StepInscription.vue';
    import StepLivraison from '@/components/commander/StepLivraison.vue';
    import StepPaiement from '@/components/commander/StepPaiement.vue';
    import { ref, watchEffect } from 'vue';
    

    const step = ref('inscription')

    function scrollTop(){

        console.log("oui");
        
        window.scrollTo({
            top: 0,
            behavior: 'smooth' 
        });

    }

</script>

<template>

    
    <div class="flex w-full ">
        <!-- Partie gauche -->
        <div class="flex items-center  flex-col w-7/12 bg-base-200 p-2 mr-1" >
            
            <StepInscription  v-if="step === 'inscription'" @next="step = 'livraison'" ></StepInscription>
            <StepLivraison  v-if="step === 'livraison'" @next="step = 'paiement'" @previous="step = 'inscription'"></StepLivraison>
            <StepPaiement  v-if="step === 'paiement'"  @previous="step = 'livraison'"></StepPaiement>
        </div>

        <!-- Partie droite -->
        <div class="flex flex-col min-h-fit w-5/12 bg-base-200 p-2 ml-1" >
            
            <div class="flex flex-col gap-2 h-96 overflow-auto p-2">
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
            </div>
            
            <div class="">
                <div class="bg-base-200 p-5">
                    <p class="font-semibold">Utiliser un code promo</p>
                    <div class="my-2">
        
                        <p class="text-xs pb-1">Votre code:</p>
                        <div class="flex">
                            <input type="text" placeholder="Code promo" class="input input-bordered w-full max-w-xs mx-2" />
                            <input type="button" class="btn btn-accent text-white" value="Valider">
                        </div>
                    </div>
                </div>
                <div class="bg-base-200 p-5">
                    <div class="flex justify-between">
                        <div class="flex items-center">
                            <p>Sous-total</p>
                            <p class="mx-1 font-normal text-sm">(1)</p>
                        </div>
                        <p>1749 €</p>
                    </div>
                    <div class="divider"></div> 
                    <div>
                        <div class="flex justify-between">
                            <p>Livraison</p>
                            <p>Gratuit</p>
                        </div>
                    </div>
                    <div class="divider"></div> 
                    <div>
                        <div class="flex justify-between my-5 min-w-72">
                            <div class="flex justify-center items-end">
                                <p class="text-xl font-bold">TOTAL</p>
                                <p class="mx-1">(TVA incluse)</p>
                            </div>
                            <p class="text-2xl font-semibold">1749 €</p>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
    
</template>