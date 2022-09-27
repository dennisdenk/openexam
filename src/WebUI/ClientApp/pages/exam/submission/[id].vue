<script setup>
    const exam = await useFetch('/api/Exam')
</script>


<template>
    <div>
        <h2>
        {{exam.description}}
        </h2>
    </div>
</template>