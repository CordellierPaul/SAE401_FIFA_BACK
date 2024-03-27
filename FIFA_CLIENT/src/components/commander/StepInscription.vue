<template>

    <ul class="steps steps-vertical lg:steps-horizontal">
        <li class="step step-primary">Inscritpion</li>
        <li class="step">Livrasion</li>
        <li class="step">Paiement</li>
    </ul>

    <form @submit.prevent action="" class="w-10/12 *:my-2" >


        
        <p class="text-xl font-medium">COORDONNÉES</p>
        <label class="form-control w-full max-w-s">
            <div class="label ">
                <span class="label-text-alt"></span>
                <span class="label-text-alt flex gap-1">
                    <p>Already have an account?</p>
                    <RouterLink :to="{name: 'login'}" class="font-bold hover:underline">Connexion</RouterLink>
                </span>
            </div>
            <input type="text" placeholder="Courriel *" class="input input-bordered w-full " />
            <div class="label ">
                <span class="label-text-alt text-red-500">Courriel is required.</span>
                <span class="label-text-alt ">
                </span>
            </div>
        </label>
        
        <p class="text-xl font-medium">ADRESSE DE LIVRAISON</p>
        
        <div class="*:my-2 w-full">
            <select class="select select-bordered w-full" placeholder="Pays">
                <option >France</option>
                <option >Belgique</option>
                <option>Suisse</option>
                <option>Italie</option>
            </select>
            
            <input type="text" required placeholder="Nom Complet" class="input input-bordered w-full " />
            <input type="text" required placeholder="Adresse 1" class="input input-bordered w-full " />
            <input type="text" placeholder="Appartement, suite, etc. (champ faculatatif)" class="input input-bordered w-full " />

            <div class="flex gap-2">
                <input type="text" required placeholder="Code postal" class="input input-bordered w-full " />
                <input type="text" required placeholder="Ville" class="input input-bordered w-full " />
            </div>

            <input type="text" required  placeholder="Téléphone" class="input input-bordered w-full " />
        </div>

        <button @click="btClick" class="btn btn-block btn-accent text-white">Suite</button>
    </form>

</template>


<script setup>
     const emit = defineEmits(['next'])

    function btClick() {
        emit('next')
    }
</script>