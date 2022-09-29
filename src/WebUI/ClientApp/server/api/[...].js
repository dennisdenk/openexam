// Interceptors: https://github.com/nuxt/framework/discussions/5370
export default (req) =>
  $fetch(
    `https://1ec2-2003-ef-bf10-7d00-ec6f-1641-736-8b50.eu.ngrok.io${req.url}`
  );
