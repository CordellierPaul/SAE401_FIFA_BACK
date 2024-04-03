<template>
    <div>

        <div v-if="blog && blog.blogId" class="">
            <div class="sticky top-20 z-[5] bg-secondary p-4 flex  items-center text-white min-h-20" >

                <div class="text-sm breadcrumbs hidden lg:block">
                    <ul>
                        <li><RouterLink :to="{name: 'index'}" class="hover:opacity-50 hover:cursor-pointer">FIFA</RouterLink></li> 
                        <li><a @click= "retour"  class="hover:opacity-50 hover:cursor-pointer">Articles</a></li>
                        <li>{{ article.articleTitre }}</li>
                        <li>Blog</li>
                        <!-- Titre de la page actuelle -->
                        <li>{{blog.blogTitre}}</li>
                    </ul>
                </div>
            </div>

            <div class="m-12">
                <div class="badge badge-outline badge-sm">Blog</div>
                <p>Publié le: {{ blog.blogDateHeure }}</p>
                <p class="text-4xl font-bold">{{blog.blogTitre}}</p>
                <div class="mt-5">
                    <p>Résumé:</p>
                    <p class="text-2xl">{{ blog.blogResume }}</p>
                </div>
                <div class="divider"></div>
                <div class="mt-5">
                    <p>Description:</p>
                    <p class="text-2xl">{{ blog.blogDescription }}</p>

                </div>
                <div class="divider"></div>
                <div class="mt-12">
                    <p class="text-xl">Autres blog de l'article:</p>
                    <div class="flex justify-center items-center p-12 overflow-x-auto whitespace-nowrap" v-if="blogsFiltre">
                        <AutreBlogComponent v-for="(autreBlog, index) in blogsFiltre" :key="index" :blog="autreBlog"></AutreBlogComponent>
                    </div>
                    
                </div>
                <div class="mt-12">
                    <p class="text-xl">Commentaires:</p>

                </div>
            </div>

        </div>
        <div v-else class="flex justify-center items-center h-screen">
            <span class="loading loading-spinner loading-lg"></span>
        </div>
    </div>

</template>

<script setup>
    import { useRouter, useRoute } from 'vue-router';
    import { onMounted, ref, watch } from 'vue';
    import { getRequest } from '../composable/httpRequests';

    import AutreBlogComponent from '../components/article/AutreBlogComponent.vue'
    
    const route = useRoute();
    const router = useRouter();
    function retour (){
        router.back()
    }
    const blogId = route.params.id;

    const blog = ref([]);
    const blogs = ref([]);
    const blogsFiltre = ref([]);
    const article = ref([]);

    async function fetchAll(){
        await getRequest(blog, 'https://apififa.azurewebsites.net/api/blog/getbyid/'+blogId)
        await getRequest(blogs, "https://apififa.azurewebsites.net/api/blog");
        await getRequest(article, 'https://apififa.azurewebsites.net/api/article/getbyid/'+blog.value.articleId)
        console.log(blog.value.articleId)

        blogsFiltre.value = blogs.value.filter(leBlog => leBlog.articleId === blog.value.articleId);
        blogsFiltre.value = blogsFiltre.value.filter(leBlog => leBlog.blogId !== blog.value.blogId);

    }

    onMounted(fetchAll)


    </script>