// Interceptors: https://github.com/nuxt/framework/discussions/5370
export default (req) =>
  $fetch(
    `https://1bb9-2003-ef-bf10-7d00-7c45-3087-f252-8c57.eu.ngrok.io${req.url}`
  );
