<template>
    <!-- <data-table :rows="data2" :columns="{examId: 'Id', title: 'Titel', startTime: 'Start'}">

    </data-table> -->
    <div>
        <table class="mx-5">
            <tr>
                <th>Beschreibung</th>
                <th>Start</th>
                <th>Ende</th>
                <th>Prüfungsdatei</th>
            </tr>
            <tr v-for="exam in data2" :key="exam.examId">
                <td><NuxtLink class="" :to="exam.examId">{{exam.title}}</NuxtLink></td>
                <td>{{exam.startTime}}</td>
                <td>{{exam.endTime}}</td>
                <!-- <td>{{exam.examFile}}</td> -->
                <td><a v-if="exam.examFile != null" @click="getFile(exam.examFile.fileName)">Download</a>
                    <span></span></td>
            </tr>
        </table>
        <div class="ml-5 mt-5 mb-5">
            <NuxtLink to="new">
                Neue Prüfung anlegen
            </NuxtLink>
            <router-link to="new" tag="button" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Neue Prüfung anlegen</router-link>
        </div>
    </div>
    <!-- <div class="text-blue-700">
        {{data2[0]}}
    </div> -->
</template>

<script setup>
    import { DataTable } from '@jobinsjp/vue3-datatable';
    import { LocalDateTime } from '@js-joda/core';
    const data = ref([]);
    var data2 = ref([]);
    data.value = await useFetch('/api/Exam')
    const { $http, $datecreate, $keycloak } = useNuxtApp();

    onMounted(() => {
        console.log(data)
        /* data.value.map((exam) => {
            exam.startTime = new LocalDateTime(exam.startTime)
            })  */

        
        $http.get('/api/Exam').then((response) => {
            console.log("AXIOS")
            data2.value = response.data;
            console.log(response)

            data2.value.map((exam) => {
                console.log(exam.startTime);
                exam.startTime = $datecreate(exam.startTime);
                exam.endTime = $datecreate(exam.endTime);
            }) 
        });
        console.log(data2.value);

        console.log("Token keycloak");
        console.log($keycloak.tokenParsed);
    })

    /* function getFile() {
        console.log("Get File")
        $http.get('/api/Exam/GetFile').then((response) => {
            console.log(response)
        })
    } */ 

    function getFile(title) {
        $http.get('/api/File/GetFileFromBucket?BucketName=general&FileName=' + title).then((response) => {
            console.log(response)
            this.forceFileDownload(response, title)
        }).catch(e => {
            console.log(e)
        })
    }

    function forceFileDownload(response, title) {
      // console.log(title)
      const url = window.URL.createObjectURL(new Blob([response.data]))
      const link = document.createElement('a')
      link.href = url
      link.setAttribute('download', title)
      document.body.appendChild(link)
      link.click()
    }

    components: {
        DataTable
    }
</script>