/**
 * AUTO_GENERATED Do not change this file directly, use config.ts file instead
 *
 * @version 6
 */

import { AxiosRequestConfig } from "axios";
import { SwaggerResponse } from "./config";
import { Http } from "./httpRequest";
//@ts-ignore
import qs from "qs";
import {
  PostChatQueryParams,
  PostExamQueryParams,
  PutExamQueryParams,
  DeleteExamQueryParams,
  PostFileQueryParams,
  PostFileUploadFileStreamQueryParams,
  GetSubmissionQueryParams,
  GetTodoItemsQueryParams,
  PutTodoItemsUpdateItemDetailsQueryParams,
  CreateTodoItemCommand,
  CreateTodoListCommand,
  Exam,
  Submission,
  TodoItemBriefDtoPaginatedList,
  TodosVm,
  Unit,
  UpdateTodoItemCommand,
  UpdateTodoItemDetailCommand,
  UpdateTodoListCommand,
  WeatherForecast,
} from "./types";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const __DEV__ = process.env.NODE_ENV !== "production";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
function overrideConfig(
  config?: AxiosRequestConfig,
  configOverride?: AxiosRequestConfig
): AxiosRequestConfig {
  return {
    ...config,
    ...configOverride,
    headers: {
      ...config?.headers,
      ...configOverride?.headers,
    },
  };
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
export function template(path: string, obj: { [x: string]: any } = {}) {
  Object.keys(obj).forEach((key) => {
    const re = new RegExp(`{${key}}`, "i");
    path = path.replace(re, obj[key]);
  });

  return path;
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
function objToForm(requestBody: object) {
  const formData = new FormData();

  Object.entries(requestBody).forEach(([key, value]) => {
    value && formData.append(key, value);
  });

  return formData;
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
function objToUrlencoded(requestBody: object) {
  return qs.stringify(requestBody);
}

export const deleteExam = (
  queryParams?: DeleteExamQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<Unit>> => {
  return Http.deleteRequest(
    deleteExam.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
deleteExam.key = "/api/Exam";

export const deleteTodoItemsId = (
  id: number,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.deleteRequest(
    template(deleteTodoItemsId.key, { id }),
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
deleteTodoItemsId.key = "/api/TodoItems/{id}";

export const deleteTodoListsId = (
  id: number,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.deleteRequest(
    template(deleteTodoListsId.key, { id }),
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
deleteTodoListsId.key = "/api/TodoLists/{id}";

export const getExam = (
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<Exam[]>> => {
  return Http.getRequest(
    getExam.key,
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
getExam.key = "/api/Exam";

export const getSubmission = (
  queryParams?: GetSubmissionQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<Submission[]>> => {
  return Http.getRequest(
    getSubmission.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
getSubmission.key = "/api/Submission";

export const getTodoItems = (
  queryParams?: GetTodoItemsQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<TodoItemBriefDtoPaginatedList>> => {
  return Http.getRequest(
    getTodoItems.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
getTodoItems.key = "/api/TodoItems";

export const getTodoLists = (
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<TodosVm>> => {
  return Http.getRequest(
    getTodoLists.key,
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
getTodoLists.key = "/api/TodoLists";

export const getTodoListsId = (
  id: number,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.getRequest(
    template(getTodoListsId.key, { id }),
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
getTodoListsId.key = "/api/TodoLists/{id}";

export const getWeatherForecast = (
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<WeatherForecast[]>> => {
  return Http.getRequest(
    getWeatherForecast.key,
    undefined,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
getWeatherForecast.key = "/api/WeatherForecast";

export const postChat = (
  queryParams?: PostChatQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.postRequest(
    postChat.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
postChat.key = "/api/Chat";

export const postExam = (
  queryParams?: PostExamQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<Exam>> => {
  return Http.postRequest(
    postExam.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
postExam.key = "/api/Exam";

export const postFile = (
  requestBody: {
    /**
     *
     * - Format: binary
     */
    File: string;
  },
  queryParams?: PostFileQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<string>> => {
  return Http.postRequest(
    postFile.key,
    queryParams,
    objToForm(requestBody),
    undefined,
    overrideConfig(_CONSTANT2, configOverride)
  );
};

/** Key is end point string without base url */
postFile.key = "/api/File";

export const postFileUploadFileStream = (
  queryParams?: PostFileUploadFileStreamQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<string>> => {
  return Http.postRequest(
    postFileUploadFileStream.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
postFileUploadFileStream.key = "/api/File/UploadFileStream";

export const postTodoItems = (
  requestBody: CreateTodoItemCommand,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<number>> => {
  return Http.postRequest(
    postTodoItems.key,
    undefined,
    requestBody,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
postTodoItems.key = "/api/TodoItems";

export const postTodoLists = (
  requestBody: CreateTodoListCommand,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<number>> => {
  return Http.postRequest(
    postTodoLists.key,
    undefined,
    requestBody,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
postTodoLists.key = "/api/TodoLists";

export const putExam = (
  queryParams?: PutExamQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<Unit>> => {
  return Http.putRequest(
    putExam.key,
    queryParams,
    undefined,
    undefined,
    overrideConfig(_CONSTANT1, configOverride)
  );
};

/** Key is end point string without base url */
putExam.key = "/api/Exam";

export const putTodoItemsId = (
  id: number,
  requestBody: UpdateTodoItemCommand,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.putRequest(
    template(putTodoItemsId.key, { id }),
    undefined,
    requestBody,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
putTodoItemsId.key = "/api/TodoItems/{id}";

export const putTodoItemsUpdateItemDetails = (
  requestBody: UpdateTodoItemDetailCommand,
  queryParams?: PutTodoItemsUpdateItemDetailsQueryParams,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.putRequest(
    putTodoItemsUpdateItemDetails.key,
    queryParams,
    requestBody,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
putTodoItemsUpdateItemDetails.key = "/api/TodoItems/UpdateItemDetails";

export const putTodoListsId = (
  id: number,
  requestBody: UpdateTodoListCommand,
  configOverride?: AxiosRequestConfig
): Promise<SwaggerResponse<any>> => {
  return Http.putRequest(
    template(putTodoListsId.key, { id }),
    undefined,
    requestBody,
    undefined,
    overrideConfig(_CONSTANT0, configOverride)
  );
};

/** Key is end point string without base url */
putTodoListsId.key = "/api/TodoLists/{id}";
export const _CONSTANT0 = {
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
};
export const _CONSTANT1 = {
  headers: {
    "Content-Type": "application/json",
    Accept: "text/plain",
  },
};
export const _CONSTANT2 = {
  headers: {
    "Content-Type": "multipart/form-data",
    Accept: "text/plain",
  },
};
