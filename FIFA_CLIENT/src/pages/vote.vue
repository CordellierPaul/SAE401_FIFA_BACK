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
        const response = await fetch('https://apififa.azurewebsites.net/api/Vote/getbyid/${route.query.id}', {
            method: 'GET',
            mode: 'cors'
        });

        joueurs.value = await response.json();


        console.log(joueurs.value);



        } catch (error) {
        console.error('Erreur lors de la récupération des thèmes :', error);
        }
    }

    onMounted(fetchJoueurs);
</script>


<template> 
    <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Themes</a></li> 
</template>

<style scoped> 
</style>