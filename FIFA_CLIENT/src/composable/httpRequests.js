// Pour que tout fonctionne :
// object : doit être une référence ref()
// url : url de là où on va chercher les données 
// actionWhenFetched : une fonction qui se lancera quand la valeur de la requête sera dans object
export async function getRequest(object, url, actionWhenFetched = null) {

    const response = await fetch(url, {
        method: "GET",
        mode: "cors"
    })

    object.value = await response.json()

    if (actionWhenFetched != null) {
        actionWhenFetched()
    }
}