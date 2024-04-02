<template>
    <RouterLink :to="{ name: 'blog', params: { id: blog.blogId } }">
        <div class="btn btn-block h-44">
            <div class="flex flex-col items-center justify-center">
                <p class="text-2xl m-3" v-if="blog">{{ blog.blogTitre}}</p>
                <p class="text-lg" v-if="blog">{{ blog.blogResume }}</p>
                <p class="text-xs m-5" v-if="blog">Cliquez pour regarder le blog</p>
            </div>
        </div>

    </RouterLink>
</template>

<script setup>
    import { defineProps } from 'vue';
    const props = defineProps({
        blog: Object
    });

</script>