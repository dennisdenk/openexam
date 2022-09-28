<template>
    <div>
        <nav class="w-full flex justify-evenly mx-5 my-5">
            <NuxtLink class="" to="/">Home</NuxtLink>
            <NuxtLink class="col-2" to="/exam/exams">Prüfungen</NuxtLink>
            <NuxtLink class="col-2" to="/exam/submission/my-submissions">Einreichungen</NuxtLink>
        </nav>
        <main class="px-10">
            <slot />
        </main>
    <!-- 
    <main>
        <div>
            Hallo
        </div>
        <slot />
    </main> -->
</div>
</template>