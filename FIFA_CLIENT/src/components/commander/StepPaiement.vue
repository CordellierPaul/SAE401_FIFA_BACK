<template>
    <ul class="steps steps-vertical lg:steps-horizontal">
        <li class="step step-primary">Inscritpion</li>
        <li class="step step-primary">Livrasion</li>
        <li class="step step-primary">Paiement</li>
    </ul>

    <form @submit.prevent action="" class="w-10/12 *:my-2">


        <p class="text-xl">Paiement</p>
        <p>Toutes les transactions sont chiffrées et sécurisées.</p>

        <div class="bg-base-300 p-3 *:my-1 rounded-lg w-full">
            <div class="flex justify-between ">
                <p class="font-bold text-lg">Carte de crédit</p>
                <div class="flex gap-2">
                    <img class="h-6" src="https://images.ctfassets.net/ei8z56ft9sxn/3e8qIIXqJukjUnSpu0VxGX/b211c732ee077291fab058fbbc05fc73/visa-logo.svg " alt="">
                    <p>MasterCard</p>
                    <p>|</p>
                    <p>Discover</p>
                    <p>|</p>
                    <p>American Express</p>
                </div>
            </div>

            <input type="text" placeholder="Numéro de carte" class="input input-bordered w-full " />
            <input type="text" required placeholder="Nom Complet" class="input input-bordered w-full " />

            <div class="flex gap-2">     
                <input type="text" placeholder="Numéro de sécurité (cvv)" class="input input-bordered w-full " />
                <input type="text" required placeholder="Date d'expiration (MM/AA)" class="input input-bordered w-full " />
            </div>

        </div>

        <div class="flex gap-2 justify-between mt-2">
            <button @click="btPreviousClick" class="btn w-1/12 bg-secondary text-white"><i class="fa-solid fa-chevron-left"></i></button>
            <button class="btn w-10/12 btn-accent text-white">Payer Maintenant</button>

        </div>

    </form>

</template>

<script setup>
const emit = defineEmits(['next','previous'])

function btPreviousClick() {
    emit('previous')
}
</script>