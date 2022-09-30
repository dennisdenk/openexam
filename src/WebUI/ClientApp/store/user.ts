import { defineStore } from "pinia";
import { watch } from "vue";

export interface User {
    token: string,
    fullname: string,
    userId: string
}

export interface UserState {
    user: User | undefined
}


const state = (): UserState => ({
    user: undefined,
})

// Not working in SSR environment -> Moved to persistedstate.ts plugin
/* if (window.localStorage.getItem("user") !== null) {
    state.user = JSON.parse(localStorage.getItem("user"));
}

watch (
    state, (stateChange) => {
        console.log("UserState changed!")
        console.log(stateChange)
        window.localStorage.setItem("user", JSON.stringify(stateChange))
        }, { deep: true }
    ) */

const getters = {
    get: (state: UserState) => () => {
        return state.user;
    }
};

const actions = {
    logout(){
        this.user = undefined;
    }
};

const persist = {
    beforeRestore: (ctx) => {
      console.log(`about to restore '${ctx.store.$id}'`)
    }
  };

export const useUserStore = defineStore('userStore', {
    state,
    getters,
    actions,
    persist,
})