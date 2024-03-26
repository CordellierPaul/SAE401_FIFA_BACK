<template>
    <h1>contact</h1>
    <div class="mt-3 z-[1] card card-compact dropdown-content w-96 bg-base-200 shadow"> 
            <div class="card-body">
              <span class="font-bold text-lg">Votre panier</span>
              <div class="max-h-96 overflow-y-auto">

                <div v-for="index in 10" class="flex">
                  <div class="divider"></div> 
                  <img class="w-32" src="https://store.fifa.com/_next/image?url=https%3A%2F%2Flegends.broadleafcloud.com%2Fapi%2Fasset%2Fcontent%2FARG%2520FRONT.png%3FcontextRequest%3D%257B%2522forceCatalogForFetch%2522%3Afalse%2C%2522applicationId%2522%3A%252201GPYEXET5B7Y61HW8TB4R0YWE%2522%2C%2522tenantId%2522%3A%2522FIFA%2522%257D&w=3840&q=85" alt="">
                  <div>
                    <p>MAILLOT DOMICILE VAINQUEUR ARGENTINE ADIDAS – FEMME</p>
                  </div>
                </div>
              </div>
              <div class="card-actions">
                <RouterLink :to="{name: 'commander'}" class="btn-block btn btn-primary">Payer la commande</RouterLink>
              </div>
            </div>
          </div>
</template>