<template>
    <h1>Club: {{ club }}</h1>
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


    async function fetchAll(){
        await getRequest(blog, 'https://apififa.azurewebsites.net/api/blog/getbyid/'+blogId)
        await getRequest(blogs, "https://apififa.azurewebsites.net/api/blog");

        blogsFiltre.value = blogs.value.filter(leBlog => leBlog.articleId === blog.value.articleId);
        blogsFiltre.value = blogsFiltre.value.filter(leBlog => leBlog.blogId !== blog.value.blogId);

    }

    onMounted(fetchAll)


    </script>