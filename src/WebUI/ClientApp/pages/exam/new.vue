<template>
    <div>
        <div class="text-xl">Neue Prüfung anlegen</div>
        <div>
            <span>Name</span>
            <input v-model="title" />
            <span>Beschreibung</span>
            <input v-model="beschreibung"  />

            <div>
                <Datepicker v-model="date"></Datepicker>
            </div>
        </div>
        <div style="width: 50%;">
            <FileSelect @input="handleNewFile"></FileSelect>
            <div v-if="examFile">{{examFile.name}}</div>
        </div>
        <button @click="createExam" class="mt-4 bg-green-600 py-3 px-3 text-light-100 rounded-md">
            Speichern
        </button>
    </div>
</template>

<script setup>
    import { postExam, postFile } from '~/server/services';
    import Datepicker from '@vuepic/vue-datepicker';
    import '@vuepic/vue-datepicker/dist/main.css'
    import Notifications from '@kyvg/vue3-notification'
    const { $http, $notify } = useNuxtApp();


    var examFile = ref();
    var title = ref();
    var beschreibung = ref();
    var date = ref();

// var upload = ref(null)

    function handleNewFile(file) {
        console.log(file)
        examFile.value = file;
    }

    async function saveNewExam() {
        console.log(examFile.value)
        await uploadFile();
    }

    async function createExam() {
        const fileRespon = await uploadFileButton();
        
        const exam = {
            title: title.value,
            description: beschreibung.value,
            startTime: Date.now(),
            endTime: new Date(),
            examFile: fileRespon.examId
        }
        const examRespon = await postExam(exam);

        examRespon.status === 200 ? $notify({
            title: "Prüfung erfolgreich angelegt",
            type: "success"
            // text: "You have been logged in!",
        }) : $notify({
            title: "Fehler beim Anlegen der Prüfung",
            type: "error",
            text: examRespon.statusText
        })
    }

    onMounted(() => {
        console.log("Mounted")
        // var axio = getAxiosInstance();
        /* var resp = uploadFile().then(resp => {
            console.log(resp)
        }); */
    })
    

    async function uploadFileButton() {
        const formData = new FormData();
        formData.append('file', examFile.value);
        console.log(formData)

       // const response = await postFile(formData);
        // TODO: Auf Auto-generierten Axios client umbauen
        /* $http.post({
            url: '/api/File',
            
        }) */ 

        const fileResponse = await fetch('https://localhost:5001/api/File', {
            method: 'POST',
            body: formData
        }).catch(e => {
            console.log(e)
            $notify.error("Fehler beim Hochladen der Datei")
        });
        console.log("RESPONSE:")
        $notify({
        title: "Datei erfolgreich hochgeladen",
        type: "success"
        // text: "You have been logged in!",
        })
        return fileResponse
    }
</script>