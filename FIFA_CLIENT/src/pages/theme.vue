<script setup>
  import { ref, onMounted } from 'vue';

    const themes = ref([]);


    async function fetchThemes() {
        try {
        const response = await fetch('https://apififa.azurewebsites.net/api/Theme', {
            method: 'GET',
            mode: 'cors'
        });

        themes.value = await response.json();


        console.log(themes.value);



        } catch (error) {
        console.error('Erreur lors de la récupération des thèmes :', error);
        }
    }

    onMounted(fetchThemes);
</script>

<template>
    <div>
      <h1>Liste des thèmes</h1>
        <br>
      <ul v-for="theme in themes" :id="theme.themeId">
        <li >
          {{ theme.themeLibelle }}
          <button class="btn btn-primary text-white">
            Voter
          </button>
        </li>
      </ul>
      <br>
    </div>
  </template>
  

