<template>
    <div class="produit">
        <div class="img_container">
            <img src="https://one-football.com/wp-content/uploads/2023/04/Maillot-Femme-Japon-Exterieur-2023-2024.jpg" alt="">
        </div>
        <div>
            <h3>Nom produit ..........</h3>
            <h4>1000,00 €</h4>
        </div>
    </div>
</template>


<script setup>

</script>


<style scoped>
.produit{
    position: relative;
    border: solid 0.5px black;
    width: 25%;
    height: auto;
}
.img_container{
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 0.5rem;
}
img{
    width: 100%;
}
</style>