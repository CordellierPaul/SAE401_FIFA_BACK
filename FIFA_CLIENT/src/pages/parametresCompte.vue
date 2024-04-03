<script setup>
import { ref, onMounted } from 'vue'; 
import useCompteStore from "../store/compte.js"

const compteStore = useCompteStore()
const donneesCompte = ref()

const deleteButtonClass = "bg-red-500 text-white hover:bg-white hover:text-black border border-red-500 rounded-lg py-2 px-4 duration-75"

// Ce code ne fonctionnera qu'avec le version non-sécurisée de l'api

async function fetchCompteData() {

    console.log(compteStore.token);

    const response = await fetch("https://apififa.azurewebsites.net/api/compte/getbyid/" + compteStore.compteId, {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${compteStore.token}`,
            "Content-Type": "application/json",
        }
    })

    donneesCompte.value = await response.json()

    console.log(donneesCompte.value)
}

onMounted(fetchCompteData)

function supprimerCompte() {
    // TODO ajouter la suppression du compte ici
}
</script>

<template>
<!-- Le code HTML est provisoire, puisqu'on va devoir ajouter une modification des champs -->

<p class="flex justify-center items-center m-12 text-3xl font-bold">Paramètres du compte</p>

<div v-if="donneesCompte" class="container sm:mx-auto px-5 py-2">
    <p class="text-2xl font-semibold">Informations générales :</p>
    
    <p>Nom d'utilisateur (login) : {{ donneesCompte.comptelogin }}</p>
    <p>Email : {{ donneesCompte.compteEmail }}</p>
    <p>Nom : {{ donneesCompte.utilisateurCompte.utilisateurNomAcheteur }}</p>
    <p>Prénom : {{ donneesCompte.utilisateurCompte.prenomUtilisateur }}</p>

    <button :class="deleteButtonClass" @click="supprimerCompte">Supprimer le compte</button>
</div>

</template>