<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import useCompteStore from "../store/compte.js";


const compteStore = useCompteStore();

const themes = ref([]);
const router = useRouter();

async function fetchThemes() {
  try {
    const response = await fetch('https://apififa.azurewebsites.net/api/Theme', {
      method: 'GET',
      mode: 'cors'
    });

    themes.value = await response.json();
  } catch (error) {
    console.error('Erreur lors de la récupération des thèmes :', error);
  }
}

function redirectToVotePage(themeId) {
  router.push({ name: 'vote', query: { id: themeId } });
}

onMounted(fetchThemes);
</script>


<template>
    
    <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

        <!-- Liens entre les pages -->
        <div class="text-sm breadcrumbs hidden lg:block">
            <ul>
                <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Thèmes</a></li>
            </ul>
        </div>
    </div>
  <div>
    <h1 class="flex justify-center items-center m-12 text-3xl font-bold">Liste des thèmes :</h1>
    <br>
    <div class="grid grid-cols-3 gap-4 place-content-stretch ">
      <div v-for="theme in themes" :key="theme.themeId" class="collapse collapse-arrow bg-base-300 p-5">
        <p class="flex justify-center font-bold p-12"> {{ theme.themeLibelle }} </p>
        <template v-if="compteStore.isConnected">
          <!-- Utilisateur connecté -->
          <button class="btn btn-outline btn-primary" @click="redirectToVotePage(theme.themeId)">
            Voter
          </button>
        </template>
        <template v-else>
          <!-- Utilisateur non connecté -->
          <button class="btn">Connectez-vous pour voter</button>
        </template>
      </div>
    </div>
    <br>
  </div>
</template>