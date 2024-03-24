<template>

    <!-- SI PANIER VIDE -->
    <!-- <div class="mx-20">
        <p class="text-2xl font-bold">Votre panier</p>
        <div class="bg-base-200 p-10 flex justify-center items-center flex-col *:my-2">
            <p>Votre panier est vide !</p>
            <p>N'hésitez pas à visiter les produits:</p>
            <button class="btn btn-accent">LES PRODUITS</button>
        </div>
    </div> -->

    <!-- SI PANIER CONTIENT OBJET -->
    <div class="flex items-center justify-center">
        <!-- Partie gauche -->
        <div class="flex items-start flex-col">
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
        <div>
            <p class="text-3xl font-bold my-5">Récapitulatif</p>

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
                        <p>Panier</p>
                        <p class="mx-1 font-normal text-sm">(1)</p>
                    </div>
                    <p>1749 €</p>
                </div>
                <div class="divider"></div> 
                <div>
                    <div class="flex justify-between">
                        <p>Retrait en magasin</p>
                        <p>Gratuit</p>
                    </div>
                    <div class="flex justify-between">
                        <p>Frais de livraison</p>
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
                    <button class="btn  btn-block btn-accent">
                        <RouterLink :to="{name: 'commander'}" class="hover:opacity-50 hover:cursor-pointer">
                            COMMANDER
                        </RouterLink>
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>