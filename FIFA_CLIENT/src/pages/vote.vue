<script setup>
    import { ref, onMounted } from 'vue';
    import { useRoute,useRouter } from 'vue-router';

    
    const router = useRouter();
    const route = useRoute();

    const props = defineProps({
    });

    
    function retour (){
        router.back()
    }

    const joueurs = ref([]);


    async function fetchJoueurs() {
        try {
        const responseTheme = await fetch('https://apififa.azurewebsites.net/api/Theme/GetJoueursByThemeId/${route.query.id}', {
            method: 'GET',
            mode: 'cors'
        });

        joueurs.value = await responseTheme.json();

        console.log(joueurs.value);

        } catch (error) {
        console.error('Erreur lors de la récupération des joueurs :', error);
        }
    }

    onMounted(fetchJoueurs);
</script>


<template> 
    <a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Revenir à Themes</a>

    <div>
      <h1>Liste des joueurs</h1>
        <br>
      <ul v-for="joueur in joueurs" :id="joueur.joueurId">
        <li >
          {{ joueur.joueurNom, joueur.joueurPrenom }}
          <button class="btn btn-primary text-white">
            Voter
          </button>
        </li>
      </ul>
      <br>
    </div>
</template>

<style scoped> 
</style>