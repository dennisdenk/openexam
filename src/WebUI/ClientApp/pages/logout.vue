<template>
    <div>
        <h2>Logout</h2>
        <p>Logout erfolgreich</p>
    </div>
</template>


<script setup>
    import { useUserStore } from '~~/store/user';
    const userStore = useUserStore();
    const { $keycloak } = useNuxtApp();

    onMounted(() => {
        console.log("logged out");
        $keycloak.logout();
        userStore.logout();
    })
</script>