<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

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
  <div>
    <h1>Liste des thèmes :</h1>
    <br>
    <ul v-for="theme in themes" :key="theme.themeId">
      <li>
        {{ theme.themeLibelle }} :
        <button class="btn btn-square btn-outline" @click="redirectToVotePage(theme.themeId)">
          Voter
        </button>
      </li>
    </ul>
    <br>
  </div>
</template>