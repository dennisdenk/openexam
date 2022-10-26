<template>
    <div>
        <notifications position="top right" classes="my-custom-class" />
        <NuxtLayout>
            <NuxtPage></NuxtPage>
        </NuxtLayout>
    </div>
    <!-- <NuxtWelcome /> -->
</template>

<script setup>

    import Notifications from '@kyvg/vue3-notification'
    import { notify } from "@kyvg/vue3-notification";

    notify({
    title: "Authorization",
    text: "You have been logged in!",
    });





    // import Keycloak from 'keycloak-js';
    /* let initOptions = {
        url: 'http://127.0.0.1:8080/', realm: 'test', clientId: 'testclient', onLoad: 'login-required'
    }

let keycloak = new Keycloak(initOptions);

keycloak.init({ onLoad: initOptions.onLoad }).then((auth) => {
  if (!auth) {
    window.location.reload();
  } else {
    console.log("Authenticated");

    new Vue({
      el: '#app',
      render: h => h(App, { props: { keycloak: keycloak } })
    })
  }


//Token Refresh
  setInterval(() => {
    keycloak.updateToken(70).then((refreshed) => {
      if (refreshed) {
        console.log('Token refreshed' + refreshed);
      } else {
        console.log('Token not refreshed, valid for '
          + Math.round(keycloak.tokenParsed.exp + keycloak.timeSkew - new Date().getTime() / 1000) + ' seconds');
      }
    }).catch(() => {
        console.log('Failed to refresh token');
    });
  }, 6000)

}).catch(() => {
  console.log("Authenticated Failed");
});*/
</script>