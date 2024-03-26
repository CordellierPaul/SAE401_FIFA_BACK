<template>

    <form @submit.prevent action="" class="w-10/12">

        
        <p>COORDONNÉES</p>
        <label class="form-control w-full max-w-s">
            <div class="label ">
                <span class="label-text-alt"></span>
                <span class="label-text-alt flex gap-1">
                    <p>Already have an account?</p>
                    <p>Connexion</p>
                </span>
            </div>
            <input type="text" placeholder="Courriel *" class="input input-bordered w-full " />
            <div class="label ">
                <span class="label-text-alt text-red-500">Courriel is required.</span>
                <span class="label-text-alt ">
                </span>
            </div>
        </label>
        
        <p>ADRESSE DE LIVRAISON</p>
        
        <div class="*:my-2 w-full">
            <select class="select select-bordered w-full" placeholder="Pays *">
                <option >France</option>
                <option >Belgique</option>
                <option>Suisse</option>
                <option>Italie</option>
            </select>
            
            <input type="text" placeholder="Nom Complet *" class="input input-bordered w-full " />
            <input type="text" placeholder="Adresse 1 *" class="input input-bordered w-full " />
            <input type="text" placeholder="Appartement, suite, etc. (champ faculatatif)" class="input input-bordered w-full " />

            <div class="flex gap-2">
                <input type="text" placeholder="Code postal *" class="input input-bordered w-full " />
                <input type="text" placeholder="Ville *" class="input input-bordered w-full " />
            </div>

            <input type="text" placeholder="Téléphone *" class="input input-bordered w-full " />
        </div>

        <button class="btn btn-block btn-accent text-white">Suite</button>
    </form>

</template>


<script setup>
     const emits = defineEmits(["next"])
</script>