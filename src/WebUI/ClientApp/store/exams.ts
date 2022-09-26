import { defineStore } from "pinia";

export interface Exam {
    examId: string,
    title: string,
    fileName: string
}

export interface ExamState {
    exams: Exam[] | undefined
}


const state = (): ExamState => ({
    exams: [],
})

const getters = {
    getById: (state: ExamState) => (id: string) => {
        return state.exams.find(itm => itm.examId == id);
    },
    getAll: (state: ExamState) => () => {
        return state.exams;
    }
};

const actions = {};

export const useExamStore = defineStore('examStore', {
    state,
    getters,
    actions
})