<script setup>
import { ref } from "vue"
import { encrypter } from "../composable/hashageMdp";
import { useRouter } from "vue-router";

const router = useRouter()

const compte = ref({
    comptelogin: "",
    compteNom: "",
    comptePrenom: "",
    dateDeNaissance: "",
    paysDeNaissanceId: 0,
    compteEmail: "",
    compteMdp: ""
})

const classesPourListeCondition = {
    "infomation": "list-image-[url(/images/icon/bulle-condition-info.png)]",
    "respectee": "list-image-[url(/images/icon/bulle-condition-reussie.png)]",
    "pasRespectee": "list-image-[url(/images/icon/bulle-condition-pas-respectee.png)]",
    "cachee": "hidden"
}

// Textes des classes conditions pour que l'e-mail soit correct
const styleConditionEmailUnique = ref(classesPourListeCondition["cachee"])
const styleConditionFormatEmail = ref(classesPourListeCondition["cachee"])

// Textes des classes conditions pour que le mot de passe soit correct
const styleConditionMajuscule = ref(classesPourListeCondition["infomation"])
const styleConditionMinuscule = ref(classesPourListeCondition["infomation"])
const styleConditionCaractereSpecial = ref(classesPourListeCondition["infomation"])
const styleConditionChiffre = ref(classesPourListeCondition["infomation"])
const styleCondition12Caracteres = ref(classesPourListeCondition["infomation"])

var idTimeoutVerificationMdp = null

function onPasswordTyped() {
    if (idTimeoutVerificationMdp != null) {
        clearTimeout(idTimeoutVerificationMdp)
    }
    idTimeoutVerificationMdp = setTimeout(() => {
        motDePasseVerifierConditions(compte.value.compteMdp)
    }, 500)
}

// cette fonction met la couleur des puces de la liste des conditions
function motDePasseVerifierConditions(motDePasse) {   

    if (motDePasse == "") {
        styleConditionMajuscule.value = classesPourListeCondition["infomation"]
        styleConditionMinuscule.value = classesPourListeCondition["infomation"]
        styleConditionCaractereSpecial.value = classesPourListeCondition["infomation"]
        styleConditionChiffre.value = classesPourListeCondition["infomation"]
        styleCondition12Caracteres.value = classesPourListeCondition["infomation"]
        return false
    }
    
    let motDePasseEstBon = true
    
    if (motDePasse == motDePasse.toLowerCase()) {
        motDePasseEstBon = false
        styleConditionMajuscule.value = classesPourListeCondition["pasRespectee"]
    } else {
        styleConditionMajuscule.value = classesPourListeCondition["respectee"]
    }
    
    if (motDePasse == motDePasse.toUpperCase()) {
        motDePasseEstBon = false
        styleConditionMinuscule.value = classesPourListeCondition["pasRespectee"]
    } else {
        styleConditionMinuscule.value = classesPourListeCondition["respectee"]
    }
    
    if (!motDePasse.match(/[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/)) {
        motDePasseEstBon = false
        styleConditionCaractereSpecial.value = classesPourListeCondition["pasRespectee"]
    } else {
        styleConditionCaractereSpecial.value = classesPourListeCondition["respectee"]
    }
    
    if (!motDePasse.match(/[0-9]+/)) {
        motDePasseEstBon = false
        styleConditionChiffre.value = classesPourListeCondition["pasRespectee"]
    } else {
        styleConditionChiffre.value = classesPourListeCondition["respectee"]
    }
    
    if (motDePasse.length < 12) {
        motDePasseEstBon = false
        styleCondition12Caracteres.value = classesPourListeCondition["pasRespectee"]
    } else {
        styleCondition12Caracteres.value = classesPourListeCondition["respectee"]
    }
    
    idTimeoutVerificationMdp = null

    return motDePasseEstBon
}

async function boutonCreationCompte() {
    
    let toutesLesConditionsSontRemplies = true

    motDePasseVerifierConditions(compte.value.compteMdp)

    if (!conditionsSontVerifieesPourMotDePasse(compte.value.compteMdp)) {
        toutesLesConditionsSontRemplies = false
    }

    if (formatEmailEstBon(compte.value.compteEmail)) {
        styleConditionFormatEmail.value = classesPourListeCondition["cachee"]
    } else {
        styleConditionFormatEmail.value = classesPourListeCondition["pasRespectee"]
        toutesLesConditionsSontRemplies = false
    }

    if (await emailEstUnique(compte.value.compteEmail)) {
        styleConditionEmailUnique.value = classesPourListeCondition["cachee"]
    } else {
        styleConditionEmailUnique.value = classesPourListeCondition["pasRespectee"]
        toutesLesConditionsSontRemplies = false
    }

    if (!toutesLesConditionsSontRemplies) {
        return
    }

    // La version hahsée du mot de passe doit être cachée à l'utilisateur

    let compteAvecMDPHashe = {
        compteEmail: compte.value.compteEmail,
        comptelogin: compte.value.comptelogin,
        compteMdp: encrypter(compte.value.compteMdp),
        utilisateurCompte: {
            utilisateurNomAcheteur: compte.value.compteNom,
            prenomUtilisateur: compte.value.comptePrenom,
            utilisateurDateNaissance: compte.value.dateDeNaissance,
            paysNaissanceId: compte.value.paysDeNaissanceId
        }
    }

    compte.value.compteMdp = ""

    console.log(JSON.stringify(compteAvecMDPHashe))

    const response = await fetch("https://apififa.azurewebsites.net/api/accescompte/inscription", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(compteAvecMDPHashe)
    })

    if (response.status == 200) {
        router.push({ "name" : "index" })
    } else {
        console.warn("réponse non gérée " + response.status + "\n" + response)
    }
}
</script>

<script>
// Cette fonction retourne true si le mot de passe est valide est false sinon
// Une fonction de vérification de mot de passe est fait deux fois pour les tests
export function conditionsSontVerifieesPourMotDePasse(motDePasse) {   

    if (motDePasse == "") {
        return false
    }

    if (motDePasse == motDePasse.toLowerCase()) {
        return false
    }

    if (motDePasse == motDePasse.toUpperCase()) {
        return false
    }

    if (!motDePasse.match(/[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/)) {
        return false
    }

    if (!motDePasse.match(/[0-9]+/)) {
        return false
    }

    if (motDePasse.length < 12) {
        return false
    }

    return true
}

export function formatEmailEstBon(email) {
    const regexEmail = /^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$/

    if (email.match(regexEmail)) {
        return true
    }

    return false
}

export async function emailEstUnique(email) {

    // On recherche l'e-mail dans la base de données
    const response = await fetch("https://apififa.azurewebsites.net/api/compte/getbyemail/" + email, {
        method: "GET",
        mode: "cors"
    })

    if (response.status == 204) {
        // La réponse 204 signifie qu'il n'y a pas de contenu à la recherche par email, donc aucun mail
        // n'a été trouvé dans la base de données. L'e-mail est bien unique.
        return true
    } else if (response.status == 200) {
        // La réponse 200 signifie qu'un e-mail a été trouvé dans la base de données, donc l'e-mail entrée
        // par l'utilisateur n'est pas unique
        return false
    } else {
        console.warn("réponse non gérée " + response.status + "\n" + response)
        return false
    }
}
</script>

<template>
    <div class="flex items-center justify-center flex-col mb-20">
        <h1 class="font-bold text-4xl my-20">Inscription</h1>
        <div class="flex">

            <!-- PARTIE GAUCHE -->
            <div class="*:m-2">
                <p>Prénom</p>
                <label class="input input-bordered flex items-center gap-2">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70"><path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6ZM12.735 14c.618 0 1.093-.561.872-1.139a6.002 6.002 0 0 0-11.215 0c-.22.578.254 1.139.872 1.139h9.47Z" /></svg>
                    <input type="text" class="grow" placeholder="Prénom" v-model="compte.comptePrenom" />
                </label>
                <p>Nom de famille</p>
                <label class="input input-bordered flex items-center gap-2">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70"><path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6ZM12.735 14c.618 0 1.093-.561.872-1.139a6.002 6.002 0 0 0-11.215 0c-.22.578.254 1.139.872 1.139h9.47Z" /></svg>
                    <input type="text" class="grow" placeholder="Nom de famille" v-model="compte.compteNom" />
                </label>
                <p>Date de naissance</p>
                <label class="input input-bordered flex items-center gap-2">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70">
                        <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6ZM12.735 14c.618 0 1.093-.561.872-1.139a6.002 6.002 0 0 0-11.215 0c-.22.578.254 1.139.872 1.139h9.47Z" />
                    </svg>
                    <input type="date" class="grow" placeholder="Date de naissance" v-model="compte.dateDeNaissance" />
                </label>
                <p>Pays de naissance</p>
                <label class="input input-bordered flex items-center gap-2">
       
                    <select class="w-full select-none" v-model="compte.paysDeNaissanceId">
                        <option disabled selected>Pays de naissance</option>
                        <option value="1">France</option>
                        <option value="2">Italie</option>
                    </select>
                </label>
            </div>

            <!-- PARTIE DROITE -->
            <div class="*:m-2">
                <p>Nom d'utilisateur</p>
                <label class="input input-bordered flex items-center gap-2">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70"><path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6ZM12.735 14c.618 0 1.093-.561.872-1.139a6.002 6.002 0 0 0-11.215 0c-.22.578.254 1.139.872 1.139h9.47Z" /></svg>
                    <input type="text" class="grow" placeholder="Nom d'utilisateur (login)" v-model="compte.comptelogin" />
                </label>
                <p>Email</p>
                <label class="input input-bordered flex items-center gap-2">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70">
                        <path
                            d="M2.5 3A1.5 1.5 0 0 0 1 4.5v.793c.026.009.051.02.076.032L7.674 8.51c.206.1.446.1.652 0l6.598-3.185A.755.755 0 0 1 15 5.293V4.5A1.5 1.5 0 0 0 13.5 3h-11Z" />
                        <path
                            d="M15 6.954 8.978 9.86a2.25 2.25 0 0 1-1.956 0L1 6.954V11.5A1.5 1.5 0 0 0 2.5 13h11a1.5 1.5 0 0 0 1.5-1.5V6.954Z" />
                    </svg>
                    <input type="text" class="grow" placeholder="Email" v-model="compte.compteEmail" />
                </label>
                <p>Mot de passe</p>
                <label class="input input-bordered flex items-center gap-2">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="currentColor" class="w-4 h-4 opacity-70">
                            <path fill-rule="evenodd"
                                d="M14 6a4 4 0 0 1-4.899 3.899l-1.955 1.955a.5.5 0 0 1-.353.146H5v1.5a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1-.5-.5v-2.293a.5.5 0 0 1 .146-.353l3.955-3.955A4 4 0 1 1 14 6Zm-4-2a.75.75 0 0 0 0 1.5.5.5 0 0 1 .5.5.75.75 0 0 0 1.5 0 2 2 0 0 0-2-2Z"
                                clip-rule="evenodd" />
                        </svg>
                        <input type="password" class="grow" value="" placeholder="Mot de passe" @input="onPasswordTyped" v-model="compte.compteMdp"/>
                </label>
            </div>
        </div>

        <ul>
            <li :class="styleConditionEmailUnique">Un compte est déjà enregistré à cet e-mail</li>
            <li :class="styleConditionFormatEmail">Le format de l'e-mail n'est pas correct</li>
            <li :class="styleConditionMajuscule">Le mot de passe avoir au moins une majuscule</li>
            <li :class="styleConditionMinuscule">Le mot de passe avoir au moins une minuscule</li>
            <li :class="styleConditionCaractereSpecial">Le mot de passe avoir au moins un caractère spécial</li>
            <li :class="styleConditionChiffre">Le mot de passe avoir au moins un chiffre</li>
            <li :class="styleCondition12Caracteres">Le mot de passe avoir au minimum 12 caractères</li>
        </ul>

        <button class="btn btn-accent m-5" @click="boutonCreationCompte">CRÉER LE COMPTE</button>
        <div class="m-5 flex items-center justify-center flex-col *:m-3">
            <p>Vous avez déjà un compte ?</p>
            <RouterLink :to="{name: 'login'}" class="btn btn-secondary">SE CONNECTER</RouterLink>
        </div>
    </div>
</template>