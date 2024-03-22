<template>
  <div class="navbar bg-primary">
    <!-- Menu a droite avec titre + navigation quand petit ecran -->
    <div class="navbar-start">
      <!-- Menu navigation quand petit écran -->
      <div class="dropdown">
        <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="white"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h8m-8 6h16" /></svg>
        </div>
        <ul tabindex="0" class="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-300 rounded-box w-52">
          <li><RouterLink  :to="{name: 'apropos'}">A Propos</RouterLink></li>
          <li>
            <RouterLink :to="{name: 'produits'}">Produits</RouterLink>
            <ul id="dropDownCenter" class="p-2">
              <li><RouterLink  :to="{name: 'produits'}">Maillots</RouterLink></li>
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
        
        <li><RouterLink class="text-white" :to="{name: 'apropos'}">A Propos</RouterLink></li>
        <li><RouterLink class="text-white" :to="{name: 'produits'}">Produits</RouterLink></li>
        <li><RouterLink class="text-white" :to="{name: 'contact'}">Contact</RouterLink></li>
      </ul>
    </div>


    <!-- //Partie droite du header-->
    <div class="navbar-end">
      <div class="flex">

        <!-- Partie panier -->
        <div class="dropdown dropdown-end ">
          <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle">
            <div class="indicator">
              <svg xmlns="http://www.w3.org/2000/svg" class="h-7 w-7" fill="none" viewBox="0 0 24 24" stroke="white"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z" /></svg>
              <span class="badge badge-sm indicator-item">8</span>
            </div>
          </div>
          <div tabindex="0" class="mt-3 z-[1] card card-compact dropdown-content w-52 bg-base-200 shadow">
            <div class="card-body">
              <span class="font-bold text-lg">0 Articles</span>
              <span class="text-info">Total: 0,00€</span>
              <div class="card-actions">
                <button class="btn btn-primary btn-block">Voir le panier</button>
              </div>
            </div>
          </div>
        </div>

        <!-- Partie utilisateur -->
        <div class="dropdown dropdown-end">
          <div tabindex="0" role="button" class="btn btn-primary hover:opacity-70 btn-circle avatar">
            <div class="w-10 rounded-full">
              <img alt="Photo de profil utilisateur" src="https://freesvg.org/img/abstract-user-flat-4.png" />
            </div>
          </div>
          <ul tabindex="0" class="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-300 rounded-box w-52">
            <li>
              <a class="justify-between">
                Profil
                <span class="badge">Nouveau</span>
              </a>
            </li>
            <li><a>Paramètres</a></li>
            <li><a>Déconnexion</a></li>
          </ul>
        </div>
      </div>
    </div>

    
  </div>
</template>

<script setup>
  import { ref } from 'vue';
  const open = ref(false);
</script>