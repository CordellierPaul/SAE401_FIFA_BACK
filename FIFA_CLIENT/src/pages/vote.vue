<script setup>
    import { ref, onMounted } from 'vue';
    import { useRoute,useRouter } from 'vue-router';

    
    const router = useRouter();
    const route = useRoute();
    const joueurs = ref([]);
    
    const props = defineProps({
    });

    
    function retour (){
        router.back()
    }


    async function fetchJoueurs() {
        try {
        const responseTheme = await fetch(`https://apififa.azurewebsites.net/api/Theme/GetJoueursByThemeId/${route.query.id}`, {
            method: 'GET',
            mode: 'cors'
        });

        joueurs.value = await responseTheme.json();


        } catch (error) {
        console.error('Erreur lors de la récupération des joueurs :', error);
        }
    }

    onMounted(fetchJoueurs);




    async function voter() {
      const selectedPlayers = new Set();
  
      // Récupérer les joueurs sélectionnés à partir des sélecteurs nommés
      const joueur1Id = document.querySelector('select[name="joueur1"]').value;
      const joueur2Id = document.querySelector('select[name="joueur2"]').value;
      const joueur3Id = document.querySelector('select[name="joueur3"]').value;

      // Vérifier si les joueurs sont sélectionnés
      if (!joueur1Id || !joueur2Id || !joueur3Id) {
        alert('Veuillez sélectionner un joueur pour chaque option.');
        return;
      }

      // Vérifier si les joueurs sélectionnés sont différents
      if (joueur1Id === joueur2Id || joueur1Id === joueur3Id || joueur2Id === joueur3Id) {
        alert('Veuillez sélectionner des joueurs différents pour chaque option.');
        return;
      }

      // Ajouter les joueurs sélectionnés à l'ensemble
      selectedPlayers.add(joueur1Id);
      selectedPlayers.add(joueur2Id);
      selectedPlayers.add(joueur3Id);


      //const userId = /* ID de l'utilisateur connecté */; a faire quand connexion est fait
      const userId = 13;
      const themeId = route.query.id;
      /*const votes = [];*/


      /////////////////////////////debug/////////////////////////////
      let vote = ref({
        utilisateurId : null,
        themeId: null,
        joueurId: null,
        voteNote: null
      })

      vote.value.utilisateurId = userId;
      vote.value.themeId = parseInt(themeId,10);
      vote.value.joueurId = parseInt(joueur1Id,10);
      vote.value.voteNote = 1;
      ///////////////////////////fin debug/////////////////////////////

      /*
      votes.push({ UtilisateurId: userId, ThemeId: themeId, JoueurId: joueur1Id, VoteNote: 1 });
      votes.push({ UtilisateurId: userId, ThemeId: themeId, JoueurId: joueur2Id, VoteNote: 2 });
      votes.push({ UtilisateurId :userId, ThemeId: themeId, JoueurId: joueur3Id, VoteNote: 3 });
      */

      console.log(JSON.stringify(vote.value));

      try {
        const response = await fetch('https://apififa.azurewebsites.net/api/Vote', {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(vote.value)
        });

        if (!response.ok) {
          throw new Error('Erreur lors de la requête.');
        }
        alert('Votre vote a été enregistré avec succès.');
      } catch (error) {
        console.error('Erreur lors de la requête fetch :', error);
      }
  }

</script>


<template> 
    <a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Revenir à Themes</a>

    <div>
      <table>
        <tr>
          <td>
            <h1>Liste des joueurs</h1>
              <br>
            <ul v-for="joueur in joueurs" :id="joueur.joueurId">
              <li >
                {{ joueur.joueurNom, joueur.joueurPrenom }}
              </li>
              
            </ul>
          </td>
          <td>
                    <select name="joueur1" id="joueur1">
                        <option v-for="joueur in joueurs" :key="joueur.joueurId" :value="joueur.joueurId">
                            {{ joueur.joueurNom }}, {{ joueur.joueurPrenom }}
                        </option>
                    </select>
                </td>
                <td>
                    <select name="joueur2" id="joueur2">
                        <option v-for="joueur in joueurs" :key="joueur.joueurId" :value="joueur.joueurId">
                            {{ joueur.joueurNom }}, {{ joueur.joueurPrenom }}
                        </option>
                    </select>
                </td>
                <td>
                    <select name="joueur3" id="joueur3">
                        <option v-for="joueur in joueurs" :key="joueur.joueurId" :value="joueur.joueurId">
                            {{ joueur.joueurNom }}, {{ joueur.joueurPrenom }}
                        </option>
                    </select>
                </td>

        </tr>
      </table>
    
      <br>
      <br>
      <button class="btn btn-primary text-white" @click="voter">
        Voter pour 
      </button>
      
      <br>
      <br>
    </div>
</template>

<style scoped> 
</style>