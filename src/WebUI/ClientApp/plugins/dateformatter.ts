import { LocalDateTime } from "@js-joda/core";

type NodaTimeDateTime = {
    calendar: Object;
    year: number;
    month: number;
    day: number;
    hour: number;
    minute: number;
    second: number;
    nanoSecond: number;
    monthValue: number;
    timeOfDay: TimeOfDay;
    date: DateType;
}

type TimeOfDay = {
    hour: number;
    minute: number;
    second: number;
    millisecond: number;
}

type DateType = {
    year: number;
    month: number;
    day: number;
}

export default defineNuxtPlugin(nuxtApp => {
    
    const dateFromApi: ( date: NodaTimeDateTime) => LocalDateTime = function (date){   
        // year: number, month: Month | number, dayOfMonth: number, hour?: number, minute?: number, second?: number, nanoSecond?: number
        return LocalDateTime.of(date.year, date.month, date.day, date.hour, date.minute, date.second, date.nanoSecond);
    }
    // Add $myInjectedFunction(context) in Vue, context and nuxtApp
    // nuxtApp.provide('$date.create()', (str: Object) => console.log('This is an example for $myInjectedFunction', str))
    return {
        provide: {
            datecreate: dateFromApi
    }
    }
    // nuxtApp.provide('$date.create', dateFromApi);
});