<script setup>
import { onMounted, ref } from "vue"

const props = defineProps({
  id: Number,
  nom: String
});

const image = ref("")

async function fetchProductImagePath() {

  let response;

  response = await fetch("https://apififa.azurewebsites.net/api/produit/getanimageofproduitbyid/" + props.id, {
      method: "GET",
      mode: "cors"
  })

  if (response.status === 404) {
    console.log("erreur 404")
    image.value = "/images/image_pas_trouvee.jpg"
    return
  }

  image.value = await response.text()
}

onMounted(fetchProductImagePath)

</script>

<template>
  <div class="card w-96 bg-neutral-400 shadow-xl overflow-hidden">
    <RouterLink  :to="{
                name: 'produit', 
                query:{
                    id: id
                }}">
      <figure class="relative">
        <img v-if="image" :src="image" alt="Image du produit" class="hover:grayscale hover:brightness-50" />
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
