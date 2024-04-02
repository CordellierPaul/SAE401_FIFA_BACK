<template>
    <div class="collapse collapse-arrow bg-base-300">
        <input type="radio" name="my-accordion-2" /> 
        <div class="collapse-title text-xl font-medium">
            <div class="badge badge-outline badge-sm">Article</div>
            <div class="flex justify-between items-center"> 
                
                <div class="font-bold text-2xl selec" v-if="article">{{ article.articleTitre }}</div>
                <p class="text-base" v-if="article">Écrit le: {{ article.articleDateHeure }}</p>
            </div>
            <p class="font-semibold" v-if="article">{{ article.articleResume }}</p>
            <div class="divider"></div>
            <p class="font-normal my-3" v-if="article">{{ article.articleTexte }}</p>
        </div>
        <div class="collapse-content *:my-3" v-if="blogsFiltre"> 
            <BlogComponent v-for="(blog, index) in blogsFiltre" :blog="blog" :key="index"></BlogComponent>
        </div>
    </div>
</template>

<script setup>
    import { defineProps, watch, ref } from 'vue';
    import BlogComponent from './BlogComponent.vue'
    import { getRequest } from '../../composable/httpRequests.js'

    const props = defineProps({
        article: Object
    });

        const blogs = ref([]);
        const blogsFiltre = ref([]);
        getRequest(blogs, "https://apififa.azurewebsites.net/api/blog");
        watch(blogs, (newBlogs) => {
            blogsFiltre.value = newBlogs.filter(blog => blog.articleId === props.article.articleId);
        });
    
    


</script>