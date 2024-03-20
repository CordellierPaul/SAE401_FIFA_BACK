<template>
  <header>
    <RouterLink to="/" id="coteGauche"><h1>FIFA</h1></RouterLink> 

    <nav>
      <RouterLink to="/about">A propos</RouterLink>
      <RouterLink to="/products">Produits</RouterLink>
      <RouterLink to="/user"><i class="fa-regular fa-user"></i></RouterLink>
    </nav>
  </header>
  
</template>

<script setup>

</script>

<style scoped>
header {
    height: 100px;
    background-color: rgba(4,86,148);
    padding: 0 10vw;
    align-items: center;
    display: flex;
    justify-content: space-between;
}

header a {
    padding: 10px 15px;
    text-decoration: none;
    color: white;
}

header nav {
    display: flex;
    align-items: center;
    position: relative;
}

header nav a {
    font-size: 1.5em;
}
</style>