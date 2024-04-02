<template>
    
    <ul class="steps steps-vertical lg:steps-horizontal">
        <li class="step step-primary">Inscritpion</li>
        <li class="step step-primary">Livrasion</li>
        <li class="step">Paiement</li>
    </ul>
    

    <form @submit.prevent action="" class="w-10/12 *:my-2" >


        <p class="text-xl font-medium">LIVRAISON</p>

        <div class="*:my-2 *:flex *:w-full *:justify-between">

            <div >
                <div class="flex gap-2">
                    <input type="radio" name="radio-1" id="radio_std" class="radio" checked />
                    <label for="radio_std">Standard (Jusqu'à 4 jours ouvrables)</label>
                </div>
                <p>14,00€</p>
            </div>
            <div class="divider"></div> 
            <div >
                <div class="flex gap-2">
                    <input type="radio" name="radio-1" id="radio_xpr" class="radio" />
                    <label for="radio_xpr">Express (Jusqu'à 3 jours ouvrables)</label>
                </div>
                <p>22,00€</p>
            </div>
        </div>

        <div class="flex gap-2 justify-between ">
            <button @click="btPreviousClick" class="btn w-1/12 bg-secondary text-white"><i class="fa-solid fa-chevron-left"></i></button>
            <button @click="btNextClick" class="btn w-10/12 btn-accent text-white">Suite</button>

        </div>
        

    </form>

</template>


<script setup>

    const emit = defineEmits(['next','previous'])

    function btPreviousClick() {
        emit('previous')
    }

    function btNextClick() {
        emit('next')
    }

</script>