import axios from "axios";

export default defineNuxtPlugin(nuxtApp => {

    // Add $myInjectedFunction(context) in Vue, context and nuxtApp
    const apiClient = axios.create({
        baseURL: "https://1bb9-2003-ef-bf10-7d00-7c45-3087-f252-8c57.eu.ngrok.io",
        withCredentials: false,
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
        }
    });

    return {
        provide: {
            http: apiClient
        }
    }
    // nuxtApp.provide('$http', (str: Object) => console.log('This is an example for $myInjectedFunction', str))
});