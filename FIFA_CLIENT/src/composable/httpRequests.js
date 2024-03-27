import { isProxy, toRaw, onMounted } from 'vue'

// Pour que tout fonctionne :
// object : doit être une référence ref()
// url : url de là où on va chercher les données 
// actionWhenFetched : une fonction qui se lancera quand la valeur de la requête sera dans object
export function getRequest(object, url, actionWhenFetched = null) {

    async function fetchObjects() {
        const response = await fetch(url, {
            method: "GET",
            mode: "cors"
        })

        object.value = await response.json()

        // À ce moment du code, produits.value est peut-être un élément Proxy. 
        // code suivant s'assure que la valeur est un Object :
        if (isProxy(object.value)) {
            object.value = toRaw(object.value)
        }

        // console.log(object.value);

        if (actionWhenFetched != null) {
            actionWhenFetched()
        }
    }

    onMounted(fetchObjects)
}