<template>
    <div>
        <div v-if="clubs && clubs.length > 0" class="flex justify-center items-center flex-col">
            <p class="mt-10 text-2xl font-bold">Les clubs</p>

            <label class="input input-bordered flex items-center gap-2 bg-secondary m-10 w-9/12">
                <input type="text" class="grow text-white" v-model="searchQuery" placeholder="Rechercher un club" />
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="white" class="w-4 h-4 opacity-70"><path fill-rule="evenodd" d="M9.965 11.026a5 5 0 1 1 1.06-1.06l2.755 2.754a.75.75 0 1 1-1.06 1.06l-2.755-2.754ZM10.5 7a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0Z" clip-rule="evenodd" /></svg>
            </label>
            <div v-if="filteredClubs.length > 0" class="m-10 min-h-screen">
                <ul class="flex gap-5 flex-wrap items-center justify-center" >
                    <li v-for="(club, index) in filteredClubs" :key="index" class="w-72 ">
                        <p class="w-fit hover:cursor-pointer  hover:border-black hover:border-2 p-2 border-2 border-white ">({{ club.clubInitiales }}) {{ club.clubNom }}</p>
                    </li>
                </ul>
            </div>
            <div v-else class="h-screen flex items-center justify-center">
                <p class="text-xl">Aucun résultat.</p>
            </div>
        </div>
        <div v-else class="flex justify-center items-center h-screen">
            <span class="loading loading-spinner loading-lg"></span>
        </div>
    </div>
</template>

<script setup>
    import { onMounted, ref, computed } from 'vue'
    import { getRequest } from '../composable/httpRequests';

    const clubs = ref([])
    const searchQuery = ref('');

    

    async function fetchAll(){
        await getRequest(clubs, "https://apififa.azurewebsites.net/api/club");
    }

    onMounted(fetchAll);

    const filteredClubs = computed(() => {
        if (!searchQuery.value) {
            return clubs.value;
        } else {
            const query = searchQuery.value.toLowerCase();
            return clubs.value.filter(club => club.clubInitiales.toLowerCase().includes(query) || club.clubNom.toLowerCase().includes(query));
        }
    });
</script>
