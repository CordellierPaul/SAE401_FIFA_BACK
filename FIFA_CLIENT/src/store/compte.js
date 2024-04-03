import { defineStore } from "pinia";
import { useStorage } from '@vueuse/core'

// Avec useStorage, les éléments du store ne sont pas réinitialisés avec un rafraichissemet de la pahe

const useCompteStore = defineStore("compte", {
    state: () => ({
        compteId: useStorage("compteId", null),
        token: useStorage("token", ""),
        isConnected: useStorage("isConnected", false) 
    }),
    actions: {
        connect(compteId, token) {
            this.compteId = compteId
            this.token = token
            this.isConnected = true
        },
        disconnect() {
            this.compteId = null
            this.token = ""
            this.isConnected = false
        }
    },
    getters: {
    }
})

export default useCompteStore