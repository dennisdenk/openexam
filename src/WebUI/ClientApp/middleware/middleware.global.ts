/** export default defineNuxtRouteMiddleware((to, from) => {
  if (to.params.id === '1') {
    return abortNavigation()
  }
  return navigateTo(to)
}) **/

import { useUserStore } from "~~/store/user"

// https://router.vuejs.org/guide/advanced/navigation-guards.html#optional-third-argument-next
// https://v3.nuxtjs.org/api/utils/define-nuxt-route-middleware/

export default defineNuxtRouteMiddleware((to, from) => {
  console.log("Routechange! :")
  console.log(to)
  console.log(from)
  console.log("UserItem")
  const userStore = useUserStore()
  console.log(userStore.get())

  // TODO: Nur wenn Route erforder authentifizierung
  /* if(!keycloak.authenticated){
    // keycloak.
  }*/

  // TODO: Loginstuff
  /* if(userStore.get() == undefined && to.path != "/login"){
    return navigateTo('/login')
  } */

  // if (this.localStorage.getItem('token') !== null) {

  // } else {
  //   navigateTo('/login')
  // }

  /** if(to.path !== from.path) {
    return abortNavigation()
  }
  return navigateTo(to.path)**/
}) 