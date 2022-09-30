<template>
    <div>
        <h2>Login</h2>
        <p>Weiterleiten zum Login ...</p>
        <div><button @click="userfuellen">User füllen</button></div>
    </div>
</template>


<script setup>
    import { useUserStore } from '~~/store/user';
    const userStore = useUserStore();

    onMounted(() => {
        console.log("logging in");
        // userStore.user = 
    });

    function userfuellen() {
        userStore.user = {"token" : "asdf", "fullname": "Hans Wurst"};
    }

</script>