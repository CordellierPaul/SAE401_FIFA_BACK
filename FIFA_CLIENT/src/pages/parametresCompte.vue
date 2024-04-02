<script setup>
import { ref, onMounted } from 'vue'; 
import useCompteStore from "../store/compte.js"

const compteStore = useCompteStore()
const donneesCompte = ref()

// Ce code ne fonctionnera qu'avec le version non-sécurisée de l'api

async function fetchCompteData() {
    const response = await fetch("https://apififa.azurewebsites.net/api/compte/getbyid/" + compteStore.compteId, {
        method: "GET",
        mode: "cors"
    })

    donneesCompte.value = await response.json()

    console.log(donneesCompte)
}

onMounted(fetchCompteData)
</script>

<template>
<!-- Le code HTML est provisoire, puisqu'on va devoir ajouter une modification des champs -->

<p class="flex justify-center items-center m-12 text-3xl font-bold">Paramètres du compte</p>

<div v-if="donneesCompte" class="container sm:mx-auto px-5 py-2">
    <p class="text-2xl font-semibold">Informations générales :</p>
    
    <p>Nom d'utilisateur (login) : </p>
    <p>Email : </p>
</div>

</template>