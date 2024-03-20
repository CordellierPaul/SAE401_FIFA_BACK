<template>
    <div id="container">
        <div id="left_part">
            <h3>Filtres</h3>
            <h4>Pays</h4>
            <ul>
                <li><input type="checkbox" id="france"><label for="france">France</label></li>
                <li><input type="checkbox" id="espagne"><label for="espagne">Espagne</label></li>
                <li><input type="checkbox" id="belgique"><label for="belgique">Belgique</label></li>
                <li><input type="checkbox" id="allemagne"><label for="allemagne">Allemagne</label></li>
                <li><input type="checkbox" id="italie"><label for="italie">Italie</label></li>
            </ul>
            <h4>Taille</h4>
            <ul>
                <li><input type="checkbox" id="xs"><label for="xs">XS</label></li>
                <li><input type="checkbox" id="s"><label for="s">S</label></li>
                <li><input type="checkbox" id="m"><label for="m">M</label></li>
                <li><input type="checkbox" id="l"><label for="l">L</label></li>
                <li><input type="checkbox" id="xl"><label for="xl">XL</label></li>
            </ul>
            <h4>Coloris</h4>
            <ul>
                <li><input type="checkbox" id="rouge"><label for="rouge">Rouge</label></li>
                <li><input type="checkbox" id="bleu"><label for="bleu">Bleu</label></li>
                <li><input type="checkbox" id="vert"><label for="vert">Vert</label></li>
                <li><input type="checkbox" id="jaune"><label for="jaune">Jaune</label></li>
                <li><input type="checkbox" id="orange"><label for="orange">Orange</label></li>
            </ul>
        </div>
        <div id="right_part"></div>
    </div>
</template>
<script setup></script>
<style scoped>
#container{
    display: flex;
    width: 100vw;
}
#left_part{
    background-color: red;
    width: 17%;
    height: 100vh;
}
#right_part{
    background-color: blue;
    width: 100%;
    height: 100vh;
}
</style>