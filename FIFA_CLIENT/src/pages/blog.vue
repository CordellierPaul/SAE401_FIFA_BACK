<template>
    <div class="">
        <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

            <div class="text-sm breadcrumbs hidden lg:block">
                <ul>
                    <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                    <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Articles</a></li> 
                    <!-- Titre de la page actuelle -->
                    <li>Kylian Mbappé : Une Légende en Devenir</li>
                </ul>
            </div>
        </div>
        <div class="m-12">
            <p class="text-4xl font-bold">Kylian Mbappé : Une Légende en Devenir</p>
            <div class="mt-5">
                <p>Résumé:</p>
                <p class="text-2xl">Cet article explore la carrière fulgurante de Kylian Mbappé, sa montée en puissance dans le monde du football et son rôle en tant que source d'inspiration pour la nouvelle génération. </p>
            </div>
            <div class="divider"></div>
            <div class="mt-5">
                <p>Description:</p>
                <p class="text-2xl">Kylian Mbappé, une force inarrêtable sur le terrain, incarne l'avenir du football. Son parcours est un exemple de détermination et de talent. Découvrez comment il a conquis le monde du sport et inspire des millions de fans à travers le globe. Un article incontournable pour tous les passionnés de football. ⚽🌟 #Mbappé #FootballLegend</p>
            </div>
            <div class="divider"></div>
            <div class="mt-12">
                <p>Autres blog de l'article</p>
                <div class="flex justify-center items-center p-12">
                    <p class="text-xl">Aucun autre blog n'a été rencesé dans cet article.</p>
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