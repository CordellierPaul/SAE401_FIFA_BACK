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
          <li><RouterLink  :to="{name: 'apropos'}">A Propos</RouterLink></li>
          <li>
            <RouterLink :to="{name: 'produits'}">Produits</RouterLink>
            <ul id="dropDownCenter" class="p-2">
              <li><RouterLink :to="{name: 'produits'}">Maillots</RouterLink></li>
              <li><RouterLink  :to="{name: 'produits'}">Ballons</RouterLink></li>
            </ul>
          </li>
          <li><RouterLink :to="{name: 'contact'}">Contact</RouterLink></li>
        </ul>
      </div>
      <RouterLink :to="{name: 'index'}" class="btn btn-ghost text-3xl text-white">FIFA</RouterLink>
      
    </div>


    <!-- //Menu navigation quand grand écran -->
    <div class="navbar-center hidden lg:flex">
      <ul class="menu menu-horizontal px-1">
        
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'apropos'}">A Propos</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'produits'}">Produits</RouterLink></li>
        <li><RouterLink class="text-white btn btn-primary" :to="{name: 'contact'}">Contact</RouterLink></li>
      </ul>
    </div>


    <!-- //Partie droite du header-->
    <div class="navbar-end">
      <div class="flex">
        
        <!-- Barre de recherche -->
        <label class="input input-bordered flex items-center gap-2 bg-secondary">
          <input type="text" class="grow text-white" placeholder="Search" />
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" fill="white" class="w-4 h-4 opacity-70"><path fill-rule="evenodd" d="M9.965 11.026a5 5 0 1 1 1.06-1.06l2.755 2.754a.75.75 0 1 1-1.06 1.06l-2.755-2.754ZM10.5 7a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0Z" clip-rule="evenodd" /></svg>
        </label>

        <!-- Partie panier -->
        <div class="dropdown dropdown-end ">
          <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle">
            <div class="indicator">
              <svg xmlns="http://www.w3.org/2000/svg" class="h-7 w-7" fill="none" viewBox="0 0 24 24" stroke="white"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z" /></svg>
              <span class="badge badge-sm badge-accent indicator-item">8</span>
            </div>
          </div>
          <div tabindex="0" class="mt-3 z-[1] card card-compact dropdown-content w-52 bg-base-200 shadow">
            <div class="card-body">
              <span class="font-bold text-lg">0 Articles</span>
              <span class="text-info">Total: 0,00€</span>
              <div class="card-actions">
                <RouterLink :to="{name: 'panier'}"><button class="btn btn-primary btn-block">Voir le panier</button></RouterLink>
                
              </div>
            </div>
          </div>
        </div>

        <!-- Partie utilisateur -->
        <div class="dropdown dropdown-end">

          
          <!-- SI UTILISATEUR CONNECTE -->
          <!-- <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle avatar">
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
            <li><a>Paramètres</a></li>
            <li><a>Déconnexion</a></li>
          </ul> -->


          <!-- SI UTILISATEUR LOGOUT -->
          <RouterLink :to="{name: 'login'}">
            <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle avatar">
              <div class="w-10 rounded-full ">
                <img alt="Photo de profil utilisateur" class="bg-accent" src="https://static.thenounproject.com/png/363640-200.png" />
              </div>
            </div>
          </RouterLink>
          
        </div>
        
      </div>
    </div>

    
  </div>
</template>

<script setup>
  import { ref } from 'vue';
  const open = ref(false);
</script>