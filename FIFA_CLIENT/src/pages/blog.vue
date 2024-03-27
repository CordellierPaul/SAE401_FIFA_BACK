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
                <p class="text-2xl">Kylian Mbappé, véritable phénomène du football, ne cesse d'éblouir par son jeu spectaculaire et son influence transcendante sur le terrain. À seulement 23 ans, son parcours époustouflant est tissé d'exploits sportifs et de moments de génie qui ont marqué l'histoire du sport. Doté d'une vitesse fulgurante, d'une agilité hors norme et d'une finition chirurgicale, il incarne l'avenir du football mondial.

Mais au-delà de ses prouesses techniques, c'est sa détermination inébranlable et son éthique de travail exemplaire qui fascinent. De ses débuts précoces à l'AS Monaco jusqu'à son ascension vertigineuse au Paris Saint-Germain et en équipe nationale française, Mbappé a su défier les attentes et repousser les limites du possible.

Son impact dépasse largement les terrains de jeu. Mbappé représente bien plus qu'un simple joueur de football ; il est devenu une icône mondiale, un symbole d'espoir et d'inspiration pour des millions de fans à travers le globe. Son charisme, sa modestie et son engagement en font un modèle pour la jeunesse, tandis que son style de jeu flamboyant captive les foules et transcende les frontières.

Cet article captivant plonge dans l'univers fascinant de Kylian Mbappé, explorant en profondeur son parcours exceptionnel, son impact culturel et son héritage grandissant dans le monde du sport. Que vous soyez un passionné de football ou simplement admiratif du talent brut, plongez-vous dans cette saga envoûtante qui célèbre l'ascension d'une légende en devenir. #Mbappé #FootballLegend 🌟⚽</p>

            </div>
            <div class="divider"></div>
            <div class="mt-12">
                <p>Autres blog de l'article:</p>
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