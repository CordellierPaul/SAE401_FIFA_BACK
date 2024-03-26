
<script setup>
    import { ref, onMounted } from 'vue';

    const themes = ref([]);

    async function fetchThemes() {
        try {
        const response = await fetch('https://apififa.azurewebsites.net/api/Theme', {
            method: 'GET',
            mode: 'cors'
        });

        const data = await response.json();

        themes.value = data;

        console.log(themes.value, "hehe");
        //proxy??
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
      <ul>
        <li v-for="theme in themes" :key="theme.themeId">
          {{ theme.themeLibelle }}
          3
        </li>
      </ul>
      <br>
    </div>
  </template>
  

