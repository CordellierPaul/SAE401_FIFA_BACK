<script setup>
    import CommanderProduitComponent from '@/components/commander/ProduitComponent.vue';
</script>

<template>

    
    <div class="flex w-full">
        <!-- Partie gauche -->
        <div class="flex items-start flex-col w-7/12" >
            <div class="flex justify-center items-end">
                <p class="text-2xl font-bold">Votre panier</p><p class="mx-1">(1 produit)</p>
            </div>
            <div>
                <!-- Produits dans le panier -->
                <div class="bg-base-200 mx-5 ">

                </div>
            </div>
        </div>
        <!-- Partie droite -->

        <div class="flex flex-col ">
            
            <div class="flex flex-col gap-2 h-2/3/ overflow-auto ">
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                <CommanderProduitComponent :prz="'80,00'" :oldprz="'160,00'" :clr="'Multicolore'" :size="'M'" :qte="'1'" :title="'Maillot Football Domicile Comores Macron - hommes'" :img="'https://store.fifa.com/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0615%2F4456%2F2874%2Fproducts%2FFIFAMZ004803_1_b626dcf8-06c3-4a28-bb72-af7e424592a8.jpg%3Fv%3D1664464182&w=3840&q=85'"></CommanderProduitComponent>
                
            </div>
            <div class="">
                <div class="bg-base-200 p-5 my-5">
                    <p class="font-semibold">Utiliser un code promo</p>
                    <div class="my-2">
        
                        <p class="text-xs">Votre code:</p>
                        <div class="flex">
                            <input type="text" placeholder="Code promo" class="input input-bordered w-full max-w-xs mx-2" />
                            <input type="button" class="btn btn-accent" value="Valider">
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