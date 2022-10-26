import { notify } from "@kyvg/vue3-notification";

export default defineNuxtPlugin(nuxtApp => {
  return {
    provide: {
          notify: notify
      }
    }
  }
);