<script setup>
    import { ref, onMounted } from 'vue';
    import { useRoute,useRouter } from 'vue-router';
    import useCompteStore from "../store/compte.js";


    const compteStore = useCompteStore();

    
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


      const userId = parseInt(compteStore.compteId,10);
      //const userId = 17;
      const themeId = route.query.id;
      const votes = [];


      /////////////////////////////debug/////////////////////////////
      let vote1 = {
          utilisateurId: userId,
          themeId: parseInt(themeId, 10),
          joueurId: parseInt(joueur1Id, 10),
          voteNote: 1
      };
      votes.push(vote1);

      // Deuxième itération
      let vote2 = {
          utilisateurId: userId,
          themeId: parseInt(themeId, 10),
          joueurId: parseInt(joueur2Id, 10),
          voteNote: 2
      };
      votes.push(vote2);

      // Troisième itération
      let vote3 = {
          utilisateurId: userId,
          themeId: parseInt(themeId, 10),
          joueurId: parseInt(joueur3Id, 10),
          voteNote: 3
      };
      votes.push(vote3);
      ///////////////////////////fin debug/////////////////////////////


      console.log(JSON.stringify(votes));

      for (let vote of votes) {
        console.log(vote);
        try {
          const response = await fetch('https://apififa.azurewebsites.net/api/Vote', {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(vote)
          });

          if (!response.ok) {
            throw new Error('Erreur lors de la requête.');
          }
          alert('Votre vote a été enregistré avec succès.');
        } catch (error) {
          console.error('Erreur lors de la requête fetch :', error);
        }
    }
  }

</script>

<template>
<template v-if="compteStore.isConnected">
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
  <template v-else>
    <!-- Utilisateur non connecté -->
    <p>Connectez-vous pour voter</p>
  </template>
  </template>

<style scoped> 
</style>