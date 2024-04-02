<template>
    <div class="bg-base-200 m-4 p-3 h-96 w-96">
        <p class="text-xl">{{ blog.blogTitre }}</p>
        <div>
            <p>{{ blog.blogResume }}</p>
        </div>
    </div>
</template>

<script setup>

defineProps({
    blog: Object
})

</script>