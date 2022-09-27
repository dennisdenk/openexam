<template>
    <data-table :rows="data2" :columns="{examId: 'Id', title: 'Titel', startTime: 'Start'}">

    </data-table>
    <!-- <div>
        <div v-for="exam in data2" :key="examId" >
            <div>{{exam}}</div>
        </div>
    </div> -->
</template>

<script setup>
    import { DataTable } from '@jobinsjp/vue3-datatable';
    import { LocalDateTime } from '@js-joda/core';
    const data = ref([]);
    var data2 = ref([]);
    data.value = await useFetch('/api/Exam')
    const { $http, $datecreate } = useNuxtApp();

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
                console.log(exam.startTime)
                exam.startTime = $datecreate(exam.startTime)
            }) 
        })
        console.log(data2.value)
    })

    components: {
        DataTable
    }
</script>