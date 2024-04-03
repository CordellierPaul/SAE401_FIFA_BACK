<template>
    <div>
        <div v-if="club && club.clubId">
            {{ club }}
            <p class="text-2xl font-bold">{{ club.clubNom }}</p>
            <p>{{ club.clubInitiales }}</p>
        </div>
        <div v-else class="flex justify-center items-center h-screen">
            <span class="loading loading-spinner loading-lg"></span>
        </div>
    </div>
</template>

<script setup>
    import { useRouter, useRoute } from 'vue-router';
    import { onMounted, ref } from 'vue';
    import { getRequest } from '../composable/httpRequests';

    const route = useRoute();
    const router = useRouter();
    function retour (){
        router.back()
    }
    const clubId = route.params.id;

    const club = ref([]);


    async function fetchAll(){
        await getRequest(club, 'https://apififa.azurewebsites.net/api/club/getbyid/'+clubId)

    }

    onMounted(fetchAll)


    </script>