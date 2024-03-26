<script setup>

defineProps({
    id: Number,
    nom: String
});

</script>

<template>
  <div class="card w-96 bg-neutral-400 shadow-xl overflow-hidden">
    <RouterLink  :to="{name: 'produit'}">
      <figure class="relative">
        <img src="https://store.fifa.com/_next/image?url=https%3A%2F%2Flegends.broadleafcloud.com%2Fapi%2Fasset%2Fcontent%2FARG%2520Front.png%3FcontextRequest%3D%257B%2522forceCatalogForFetch%2522%3Afalse%2C%2522applicationId%2522%3A%252201GPYEXET5B7Y61HW8TB4R0YWE%2522%2C%2522tenantId%2522%3A%2522FIFA%2522%257D&w=828&q=50" alt="Shoes" class="hover:grayscale hover:brightness-50" />
        <div class="cursor-pointer absolute top-0 left-0 w-full h-full bg-black bg-opacity-50 flex justify-center items-center opacity-0 transition-opacity hover:opacity-100">
          <p class="text-white text-lg ">Voir plus</p>
        </div>
      </figure>
        <div class="card-body">
          <p class="badge badge-accent text-white">NOUVEAU</p>
          <h2 class="card-title text-white">{{ nom }}</h2>
          <div class="flex">
            <span class="text-white font-medium">100,00€</span>
            <span class="ml-5 line-through text-white font-light">140,00€</span>
          </div>
        </div>
      
    </RouterLink>
  </div>
</template>
