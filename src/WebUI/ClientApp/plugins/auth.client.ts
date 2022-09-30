import Keycloak from 'keycloak-js'

var keycloak = new Keycloak(
  {
    url: 'https://login.sysadapt.com/auth',
    realm: 'openExam',
    clientId: 'testclient2',
}
);

keycloak.init({ onLoad: 'login-required', silentCheckSsoRedirectUri: 'http://localhost:3000/silent-check-sso',
pkceMethod: 'S256'
})
// flow: 'implicit'
// pkceMethod: 'S256' 


setInterval(() => {
  console.log("--> log: interval ");
  console.log("--> log: isAuthenticated ");
  console.log(keycloak.tokenParsed)
  keycloak.updateToken(500).then((refreshed) => {
    console.log(keycloak.tokenParsed)
    console.log("--- TOKEN: ----")
    console.log(keycloak.token)
    //console.log("--> log: isAuthenticated ", store.state.user.isAuthenticated);
    /* if (store.state.user.isAuthenticated != false ) {
      if (refreshed) {
        console.log("--> log: refreshed ");         
        let payloadRefreshedTokens = {
          idToken: keycloak.idToken,
          accessToken: keycloak.token
        }

        if ((keycloak.token && keycloak.idToken != '') && (keycloak.idToken != '')) {
          store.commit("login", payloadRefreshedTokens);
        }
        else {
          console.log("--> log: token refresh problems");  
          payloadRefreshedTokens = {
            idToken: "",
            accessToken: ""
          }
          store.commit("login", payloadRefreshedTokens);
          store.commit("logout");
        }
      }
    } else {
      console.log("--> log: logout isAuthenticated  =", store.state.user.isAuthenticated);
      
      var logoutOptions = { redirectUri : urls.cns };
      console.log("--> log: logoutOptions  ", logoutOptions  );
          
      keycloak.logout(logoutOptions).then((success) => {
            console.log("--> log: logout success ", success );
      }).catch((error) => {
            console.log("--> log: logout error ", error );
      });
      // store.commit("logout");
    } */
  }).catch(() => {
    console.log("--> log: catch interval");
  });
}, 10000)

export default defineNuxtPlugin(nuxtApp => {

    /* if(keycloak.loginRequired) {
        console.log("Login required")
        keycloak.login()
    }*/
  
    /*if(!keycloak.authenticated) {
      keycloak.login();
    } */
  return {
    provide: {
          keycloak: keycloak
      }
    }
  }
  // nuxtApp.provide('$http', (str: Object) => console.log('This is an example for $myInjectedFunction', str))
);