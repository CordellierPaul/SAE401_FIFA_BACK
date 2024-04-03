<template>
    <div>
        <div v-if="clubs">
            <div class="bg-base-300 m-10">
                <div >
                    <div  class="bg-red-500" v-for="(club, index) in clubs" :key="index">
                        <p>({{ club.clubInitiales }}) {{ club.clubNom }}</p>
                    </div>
                </div>
            </div>
        </div>
        <div v-else class="flex justify-center items-center h-screen">
            <span class="loading loading-spinner loading-lg"></span>
        </div>
    </div>
</template>

<script setup>
    import { onMounted, ref } from 'vue'
    import { getRequest } from '../composable/httpRequests';

    const clubs = ref([])
    
    async function fetchAll(){
        await getRequest(clubs, "https://apififa.azurewebsites.net/api/club");
    }


    onMounted(fetchAll)
</script>