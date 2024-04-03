<script setup>
import { ref } from "vue"
import { formatEmailEstBon, emailEstDansLaBaseDeDonnees } from "./register.vue"
import { encrypter } from "../composable/hashageMdp"
import { useRouter } from "vue-router"
import useCompteStore from "../store/compte.js"

const compteStore = useCompteStore()

const router = useRouter()

// Textes des classes conditions pour que les champs soient correct
const styleConditionFormatEmail = ref("")
const styleConditionMdpRempli = ref("")
const styleMessageChargement = ref("")
const styleConditionMauvaisMdp = ref("")
const styleConditionMauvaisEMail = ref("")

function reinitialiserStyles() {
    styleConditionFormatEmail.value = "hidden"
    styleConditionMdpRempli.value = "hidden"
    styleMessageChargement.value = "hidden"
    styleConditionMauvaisMdp.value = "hidden"
    styleConditionMauvaisEMail.value = "hidden"
}

reinitialiserStyles()

const styleConditionPasRespectee = "list-image-[url(/images/icon/bulle-condition-pas-respectee.png)]"
const styteInformation = "list-image-[url(/images/icon/bulle-condition-info.png)]"

const compte = ref({
    CompteEmail: "",
    CompteMdp: ""
})

async function boutonConnexionCompte() {

    let formatChampsSontCorrects = true

    if (formatEmailEstBon(compte.value.CompteEmail)) {
        styleConditionFormatEmail.value = "hidden"
    } else {
        styleConditionFormatEmail.value = styleConditionPasRespectee
        formatChampsSontCorrects = false
    }

    if (compte.value.CompteMdp != "") {
        styleConditionMdpRempli.value = "hidden"
    } else {
        styleConditionMdpRempli.value = styleConditionPasRespectee
        formatChampsSontCorrects = false
    }

    if (!formatChampsSontCorrects) {
        return
    }

    // La version hahsée du mot de passe doit être cachée à l'utilisateur
    
    let compteAvecMDPHashe = {
        CompteEmail: compte.value.CompteEmail,
        CompteMdp: encrypter(compte.value.CompteMdp)
    }
    
    compte.value.CompteMdp = ""

    styleMessageChargement.value = styteInformation

    // let emailEstDansLaBaseDeDonnee = await emailEstDansLaBaseDeDonnees()

    // console.log(emailEstDansLaBaseDeDonnee);

    // if (!emailEstDansLaBaseDeDonnee) {
    //     reinitialiserStyles()
    //     styleConditionMauvaisEMail.value = styleConditionPasRespectee
    //     return
    // }
    
    const response = await fetch("https://apififa.azurewebsites.net/api/accescompte/connexion", {
        method: "POST",
        mode: "cors",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(compteAvecMDPHashe)
    })

    if (response.status == 401) {
        reinitialiserStyles()
        styleConditionMauvaisMdp.value = styleConditionPasRespectee
    } else if (response.status == 200) {
        
        // On enregistre les données retournées, l'id du compte et le token pour lire les
        // données, dans compteStore
        let data = await response.json()

        compteStore.connect(data.userDetails.compteId, data.token)

        router.push({ "name" : "index" })   // on va à la page d'accueil
        
    } else {
        console.warn("réponse non gérée " + response.status + "\n" + response)
    }

    styleMessageChargement.value = "hidden"
}

</script>

<template>
    <div class="flex items-center justify-center flex-col">
        <h1 class="font-bold text-4xl my-20">Connexion</h1>
        <div class="*:m-2">
            <label class="input input-bordered flex items-center gap-2">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70">
                    <path d="M2.5 3A1.5 1.5 0 0 0 1 4.5v.793c.026.009.051.02.076.032L7.674 8.51c.206.1.446.1.652 0l6.598-3.185A.755.755 0 0 1 15 5.293V4.5A1.5 1.5 0 0 0 13.5 3h-11Z" />
                    <path d="M15 6.954 8.978 9.86a2.25 2.25 0 0 1-1.956 0L1 6.954V11.5A1.5 1.5 0 0 0 2.5 13h11a1.5 1.5 0 0 0 1.5-1.5V6.954Z" />
                </svg>
                <input type="text" class="grow" placeholder="Email" v-model="compte.CompteEmail" />
            </label>
            <label class="input input-bordered flex items-center gap-2">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70">
                    <path fill-rule="evenodd"
                        d="M14 6a4 4 0 0 1-4.899 3.899l-1.955 1.955a.5.5 0 0 1-.353.146H5v1.5a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1-.5-.5v-2.293a.5.5 0 0 1 .146-.353l3.955-3.955A4 4 0 1 1 14 6Zm-4-2a.75.75 0 0 0 0 1.5.5.5 0 0 1 .5.5.75.75 0 0 0 1.5 0 2 2 0 0 0-2-2Z"
                        clip-rule="evenodd" />
                </svg>
                <input type="password" class="grow" value="" placeholder="Mot de passe" v-model="compte.CompteMdp" />
            </label>
        </div>

        <ul>
            <li :class="styleConditionFormatEmail">Le format de l'e-mail n'est pas correct</li>
            <li :class="styleConditionMdpRempli">Le mot de passe doit être spécifié</li>
            <li :class="styleMessageChargement">Chargement...</li>
            <li :class="styleConditionMauvaisMdp">Il y a un compte à cette e-mail mais le mot de passe est incorrect</li>
            <li :class="styleConditionMauvaisEMail">Il n'y a pas de compte à cette e-mail</li>
        </ul>

        <button class="btn btn-accent m-5" @click="boutonConnexionCompte">SE CONNECTER</button>
        <p>Mot de passe oublié ?</p>
        <div class="m-28 flex items-center justify-center flex-col *:m-3">
            <p>Vous n'avez pas de compte ?</p>
            <RouterLink :to="{name: 'register'}" class="btn btn-secondary">CRÉER UN COMPTE</RouterLink>
        </div>
    </div>
</template>