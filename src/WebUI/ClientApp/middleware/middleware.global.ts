/** export default defineNuxtRouteMiddleware((to, from) => {
  if (to.params.id === '1') {
    return abortNavigation()
  }
  return navigateTo(to)
}) **/

// https://router.vuejs.org/guide/advanced/navigation-guards.html#optional-third-argument-next
// https://v3.nuxtjs.org/api/utils/define-nuxt-route-middleware/

export default defineNuxtRouteMiddleware((to, from) => {
  /** if(to.path !== from.path) {
    return abortNavigation()
  }
  return navigateTo(to.path)**/
}) 