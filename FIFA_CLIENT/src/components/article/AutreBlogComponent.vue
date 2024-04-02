<template>
    <div class="bg-base-200 m-4 p-3 min-h-64 w-96">
        <p class="text-xl">{{ blog.blogTitre }}</p>
        <div class="h-36 overflow-hidden text-ellipsis">
            <p>{{ blog.blogResume }}</p>
        </div>
    </div>
</template>

<script setup>

defineProps({
    blog: Object
})

</script>