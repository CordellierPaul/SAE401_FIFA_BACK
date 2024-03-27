<template>
    <div>
        <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >
            <div class="text-sm breadcrumbs hidden lg:block">
                <ul>
                    <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                    <li>Contact</li>
                </ul>
            </div>
        </div>

        <div class="m-5">
            <p class="text-2xl font-bold">Comment nous contacter</p>
            <div class="divider"></div>
            <div class="mt-5">
                <p class="font-bold">Téléphoner:</p>
                <li>France: +33 0 00 00 00 00</li>
            </div>
            <div class="mt-5">
                <p class="font-bold">Formulaire de contact</p>
                <div class="flex items-center justify-center flex-col">
                    <div class="*:m-2 min-w-96">
                        <div>

                            <label for="email">Email</label>
                            <label class="input input-bordered flex items-center gap-2 w-full">
                                <input type="text" id="email" class="grow" placeholder="exemple@fifa.fr" />
                            </label>
                        </div>
                        <div>

                            <label for="message">Message</label>
                            <textarea class="textarea textarea-bordered w-full h-80" id="message" placeholder="Message"></textarea>
                        </div>
                    </div>
                    <button class="btn btn-accent m-5">ENVOYER</button>
                </div>
            </div>
        </div>

    </div>

</template>