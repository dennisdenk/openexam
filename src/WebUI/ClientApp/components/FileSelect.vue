<template>
    <div class="flex justify-center items-center w-full">
        <label for="dropzone-file" class="flex flex-col justify-center items-center w-full h-64 bg-gray-50 rounded-lg border-2 border-gray-300 border-dashed cursor-pointer dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600">
            <div class="flex flex-col justify-center items-center pt-5 pb-6">
                <svg aria-hidden="true" class="mb-3 w-10 h-10 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"></path></svg>
                <p class="mb-2 text-sm text-gray-500 dark:text-gray-400"><span class="font-semibold">Klicken für Upload </span> oder Datei hier fallen lassen</p>
                <p v-if="upload" class="text-md text-gray-500 dark:text-gray-400">{{upload.name}}</p>
                <p class="text-xs text-gray-500 dark:text-gray-400">PDF, PNG, JPG</p>
            </div>
            <input id="dropzone-file" type="file" class="hidden" @change="handleFileChange" />
        </label>
    </div> 
</template>


<script setup>
    const emit = defineEmits(['input'])
    var upload = ref(null)
    
    function handleFileChange(e) {
        emit('input', e.target.files[0])
        console.log(e)
        upload.value = e.target.files[0]
    }
    
</script>