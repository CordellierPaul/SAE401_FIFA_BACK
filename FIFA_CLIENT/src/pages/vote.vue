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

        console.log(joueurs.value);

        } catch (error) {
        console.error('Erreur lors de la récupération des joueurs :', error);
        }
    }

    onMounted(fetchJoueurs);

    function voter() {
        const selectedPlayers = [];
        const selects = document.querySelectorAll('select');
        
        for (let i = 0; i < selects.length; i++) {
            const joueurId = selects[i].value;
            if (!joueurId) {
                alert('Veuillez sélectionner un joueur pour chaque option.');
                return; 
            }

            if (selectedPlayers.includes(joueurId)) {
                alert('Veuillez sélectionner des joueurs différents pour chaque option.');
                return; 
            }

            selectedPlayers.push(joueurId);
        }

        //const userId = /* ID de l'utilisateur connecté */;
        const themeId = route.query.id;
        const votes = [];

        for (let i = 0; i < selects.length; i++) {
            const joueurId = selects[i].value;
            const selectNum = i + 1;
            votes.push({ userId, themeId, joueurId, selectNum });
        }

  //   try {
  //       const response = await fetch('https://apififa.azurewebsites.net/api/Vote', {
  //           method: 'POST',
  //           headers: {
  //               'Content-Type': 'application/json'
  //           },
  //           body: JSON.stringify(votes)
  //       });

  //       if (!response.ok) {
  //           throw new Error('Erreur lors de la requête.');
  //       }

  //       // Réussite - faire quelque chose en conséquence
  //   } catch (error) {
  //       console.error('Erreur lors de la requête fetch :', error);
  //       // Gérer l'erreur
  //   }
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
            <ul>
              <li >
                hehe (ceci est un joueur)
              </li>
            </ul>
            <br>
            <br>
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
    
      <button class="btn btn-primary text-white">
        Voter pour 
      </button>
    </div>
</template>

<style scoped> 
</style>