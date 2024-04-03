<template>
    <h1>Club: {{ club }}</h1>
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