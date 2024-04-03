import { defineStore } from "pinia";
import { useStorage } from '@vueuse/core'


const usePanierStore = defineStore("panier", {
    state: () => ({
        nombreProduits: 0,
        produits: [],
        variantes: [],
        stocks: [],
        quantites: [],
    }),
    actions: {
        add(produit, variante, stk) {
            if(this.stocks.includes(stk))
                return this.augmenteQuantite(stk)
            this.nombreProduits++
            this.produits.push(produit)
            this.variantes.push(variante)
            this.stocks.push(stk)
            this.quantites.push(1)
        },
        augmenteQuantite(stk){
            let index = this.stocks.indexOf(stk)
            this.nombreProduits++
            this.quantites[index]++
        },
        baisseQuantite(stk) {
            let index = this.stocks.indexOf(stk)
            if(this.quantites[index] == 1)
                return this.supprimeProduit(stk)
            this.nombreProduits--
            this.quantites[index]--
        },
        supprimeProduit(stk) {            
            let index = this.stocks.indexOf(stk)
            this.nombreProduits-= this.quantites[index]
            this.produits.splice(index, 1)
            this.variantes.splice(index, 1)
            this.quantites.splice(index, 1)
            this.stocks.splice(index, 1)
        },
        augmentationPossible(stk){
            let index = this.stocks.indexOf(stk)
            if(this.quantites[index] == stk.quantiteStockee)
                return false
            return true;
        }
    },
    getters: {
        count: (state) => state.nombreProduits,
        getProduits: (state) => state.produits,
        getVariantes: (state) => state.variantes,
        getQuantites: (state) => state.quantites,
        getStocks: (state) => state.stocks,
    }
})

export default usePanierStore