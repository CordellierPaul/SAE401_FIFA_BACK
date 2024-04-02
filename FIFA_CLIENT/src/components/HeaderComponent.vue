<script setup>

import useCompteStore from "../store/compte.js"
const compteStore = useCompteStore()

function deconnexion() {
  compteStore.disconnect()
}

</script>

<template>
  <div class="navbar bg-primary sticky top-0 z-50 min-h-20">
    <!-- Menu a droite avec titre + navigation quand petit ecran -->
    <div class="navbar-start">
      <!-- Menu navigation quand petit écran -->
      <div class="dropdown">
        <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="white"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h8m-8 6h16" /></svg>
        </div>
        <ul tabindex="0" class="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-300 rounded-box w-52 z-[2]">
          <li>
            <RouterLink :to="{name: 'produits'}">Produits</RouterLink>
            <ul id="dropDownCenter" class="p-2">
              <li><RouterLink :to="{name: 'produits'}">Maillots</RouterLink></li>
              <li><RouterLink  :to="{name: 'produits'}">Ballons</RouterLink></li>
            </ul>
          </li>
          <li><RouterLink :to="{name: 'contact'}">Contact</RouterLink></li>
          <li><RouterLink :to="{name: 'articles'}">Articles</RouterLink></li>
          <li><RouterLink :to="{name: 'clubs'}">Clubs</RouterLink></li>
          <li><RouterLink :to="{name: 'theme'}">Voter pour un theme</RouterLink></li>
        </ul>
      </div>
      <RouterLink :to="{name: 'index'}" class="btn btn-ghost text-3xl text-white">FIFA</RouterLink>
      
    </div>


    <!-- //Menu navigation quand grand écran -->
    <div class="navbar-center hidden lg:flex">
      <ul class="menu menu-horizontal px-1">
        
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'produits'}">Produits</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'contact'}">Contact</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'clubs'}">Clubs</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'articles'}">Articles</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'theme'}">Voter pour un theme</RouterLink></li>
      </ul>
    </div>


    <!-- //Partie droite du header-->
    <div class="navbar-end">
      <div class="flex">
        
        <!-- Barre de recherche -->
        <label class="input input-bordered flex items-center gap-2 bg-secondary">
          <input type="text" class="grow text-white" placeholder="Rechercher" />
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="white" class="w-4 h-4 opacity-70"><path fill-rule="evenodd" d="M9.965 11.026a5 5 0 1 1 1.06-1.06l2.755 2.754a.75.75 0 1 1-1.06 1.06l-2.755-2.754ZM10.5 7a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0Z" clip-rule="evenodd" /></svg>
        </label>

        <!-- SI L'UTILISATEUR EST CONNECTE -->
        <div v-if="compteStore.isConnected" class="dropdown dropdown-end ml-3">
          <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle avatar">
            <div class="w-10 rounded-full ">
              <div class="avatar placeholder">
                <div class="bg-accent text-neutral-content rounded-full w-8">
                  <span class="text-xs">M</span>
                </div>
              </div>
            </div>
          </div>

          <ul tabindex="0" class="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-300 rounded-box w-52">
            <li>
              <RouterLink class="justify-between" :to="{name: 'login'}">
                Profil<span class="badge badge-accent">Nouveau</span>
              </RouterLink>
            </li>
            <li>
              <RouterLink class="justify-between" :to="{name: 'parametres-compte'}">
                Paramètres
              </RouterLink>
            </li>
            <li><a @click="deconnexion()">Déconnexion</a></li>
          </ul>
        </div>

        <!-- SI L'UTILISATEUR EST LOGOUT : -->
        <div v-else class="dropdown dropdown-end ml-3">
          <RouterLink :to="{name: 'login'}">
            <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle flex justify-center items-center">
              <div class="w-10 rounded-full  flex justify-center items-center">
                <i class="fa-solid fa-user text-xl text-white"></i>
              </div>
            </div>
          </RouterLink>
        </div>

        <!-- Partie panier -->
        <div class="dropdown dropdown-end">
          <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle">
            <div class="indicator">
              <svg xmlns="http://www.w3.org/2000/svg" class="h-7 w-7" fill="none" viewBox="0 0 24 24" stroke="white"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z" /></svg>
              <span class="badge badge-sm badge-accent indicator-item">10</span>
            </div>
          </div>
          <div tabindex="0" class="mt-3 z-[1] card card-compact dropdown-content w-96 bg-base-200 shadow "> 
            <div class="card-body">
              <div class="flex justify-center flex-col items-center">
                <p class="font-bold text-lg">Votre panier</p>
                <p>10 articles</p>
              </div>

              <!-- PANIER VIDE -->
              <!-- <div class="h-96">
                <div class="h-full flex flex-col justify-center items-center">
                    <p class="flex items-center font-bold text-2xl">Votre panier est vide !</p>
                    <RouterLink :to="{name: 'produits'}" class="btn-block btn btn-primary">Visiter la boutique</RouterLink>
                </div>
                </div> -->

              <!-- PANIER PAS VIDE -->
              <div class="max-h-96 overflow-y-auto">
                <div v-for="index in 10" class="flex m-5">
                  <img class="w-32" src="https://store.fifa.com/_next/image?url=https%3A%2F%2Flegends.broadleafcloud.com%2Fapi%2Fasset%2Fcontent%2FARG%2520FRONT.png%3FcontextRequest%3D%257B%2522forceCatalogForFetch%2522%3Afalse%2C%2522applicationId%2522%3A%252201GPYEXET5B7Y61HW8TB4R0YWE%2522%2C%2522tenantId%2522%3A%2522FIFA%2522%257D&w=3840&q=85" alt="">
                  <div class="mx-3 flex flex-col justify-between">
                    <p>MAILLOT DOMICILE VAINQUEUR ARGENTINE ADIDAS – FEMME</p>
                    <div class="flex justify-between items-center">
                      <p class="text-base font-bold">100€</p>
                      <select class="bg-base-200 font-bold w-7">
                        <option v-for="index in 10">{{ index }}</option>
                      </select>
                      <i class="fa-solid fa-trash ml-2"></i>
                    </div>
                    
                  </div>
                </div>
              </div>
              <div class="card-actions">
                <RouterLink :to="{name: 'commander'}" class="btn-block btn btn-primary">Payer la commande</RouterLink>
              </div>

            </div>
          </div>
        </div>
        
      </div>
    </div>

  </div>
</template>