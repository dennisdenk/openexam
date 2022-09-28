<template>
    <div>
        <div class="text-xl">Neue Prüfung anlegen</div>
        <div>


        </div>
        <div style="width: 50%;">
            <FileSelect @input="handleNewFile"></FileSelect>
            <div v-if="examFile">{{examFile.name}}</div>
        </div>
        <button @click="saveNewExam"  class="mt-4 bg-green-600 py-3 px-3 text-light-100 rounded-md">
            Speichern
        </button>
    </div>
</template>

<script setup>
    var examFile = ref();

// var upload = ref(null)

    function handleNewFile(file) {
        console.log(file)
        examFile.value = file;
    }

    async function saveNewExam() {
        console.log(examFile.value)
        await uploadFile();
    }

    async function uploadFile() {
        const formData = new FormData();
        formData.append('file', examFile.value);
        const response = await fetch('https://localhost:5001/api/File', {
            method: 'POST',
            body: formData
        });
        console.log(response)
    }



</script>