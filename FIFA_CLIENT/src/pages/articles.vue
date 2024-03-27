<template>
    <div class="min-h-screen">
        <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

            <div class="text-sm breadcrumbs hidden lg:block">
                <ul>
                    <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                    <li>Articles</li>
                </ul>
            </div>
        </div>
        <p class="flex justify-center items-center m-12 text-3xl font-bold">Articles</p>
        <div class="m-5 *:my-8">

            <div class="collapse collapse-arrow bg-base-300">
                <input type="radio" name="my-accordion-2" /> 
                <div class="collapse-title text-xl font-medium">
                    <div class="badge badge-outline badge-sm">Article</div>
                    <div class="flex justify-between items-center"> 
                        
                        <div class="font-bold text-2xl selec">Kylian Mbappé : L'Étoile Montante du Football</div>
                        <p class="text-base">Écrit le: 26/03/2024</p>
                    </div>
                    <p class="font-semibold">Découvrez comment Kylian Mbappé, avec son talent inégalé et son charisme, a conquis le monde du football.</p>
                    <div class="divider"></div>
                    <p class="font-normal my-3">Kylian Mbappé est une force inarrêtable sur le terrain. À seulement 23 ans, il a déjà marqué l'histoire du football. Son mélange de vitesse, d'agilité, et de finition en fait un attaquant exceptionnel. Il a remporté la Coupe du Monde 2018 avec l'équipe nationale française et a conquis la Ligue 1 avec le Paris Saint-Germain. Mais ce qui le distingue encore plus, c'est son leadership et son humilité. Mbappé est un modèle pour les jeunes joueurs, incarnant l'esprit d'équipe et la passion pour le jeu. Avec un avenir prometteur devant lui, il est destiné à rester une légende du football.</p>
                </div>
                <div class="collapse-content *:my-3"> 
                    <RouterLink :to="{name: 'blog'}">
                    <div class="btn btn-block h-44">
                            <div class="flex flex-col items-center justify-center">
                                <p class="text-2xl m-3">Kylian Mbappé : Une Légende en Devenir</p>
                                <p class="text-lg">Cet article explore la carrière fulgurante de Kylian Mbappé, sa montée en puissance dans le monde du football et son rôle en tant que source d'inspiration pour la nouvelle génération. </p>
                                <p class="text-xs m-5">Cliquez pour regarder le blog</p>
                            </div>
                        </div>
                    </RouterLink>
                </div>
            </div>

        </div>
    </div>

</template>

<script setup>
    import { useRouter } from 'vue-router';

    const router = useRouter();
    function retour (){
        router.back()
    }
</script>