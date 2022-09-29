/**
 * AUTO_GENERATED Do not change this file directly, use config.ts file instead
 *
 * @version 6
 */

export type BaseEvent = { [x in string | number]: any };

export interface CalendarSystem {
  /**
   *
   * - Format: int32
   */
  maxYear: number;
  /**
   *
   * - Format: int32
   */
  minYear: number;
  eras?: Era[];
  id?: string;
  name?: string;
}

export interface CreateTodoItemCommand {
  /**
   *
   * - Format: int32
   */
  listId: number;
  title?: string;
}

export interface CreateTodoListCommand {
  title?: string;
}

export interface DeleteExamQueryParams {
  Id?: string;
}

export interface Era {
  name?: string;
}

export interface Exam {
  /**
   *
   * - Format: date-time
   */
  created: string;
  endTime: LocalDateTime;
  examFile: FileUpload;
  /**
   *
   * - Format: uuid
   */
  examId: string;
  /**
   *
   * - Format: int32
   */
  id: number;
  latestSubmissionTime: LocalDateTime;
  startTime: LocalDateTime;
  createdBy?: string;
  description?: string;
  domainEvents?: BaseEvent[];
  examinees?: Examinee[];
  examiner?: UserAccount[];
  fileName?: string;
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  submissions?: Submission[];
  title?: string;
}

export interface Examinee {
  /**
   *
   * - Format: date-time
   */
  created: string;
  exam: Exam;
  /**
   *
   * - Format: uuid
   */
  examineeId: string;
  examineeType: ExamineeType;
  /**
   *
   * - Format: int32
   */
  id: number;
  user: UserAccount;
  code?: string;
  createdBy?: string;
  domainEvents?: BaseEvent[];
  email?: string;
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  submissions?: Submission[];
}

/**
 *
 * - Format: int32
 */

export enum ExamineeType {
  0 = 0,
  1 = 1,
  2 = 2,
  3 = 3,
}

export interface FileUpload {
  /**
   *
   * - Format: date-time
   */
  created: string;
  /**
   *
   * - Format: uuid
   */
  fileId: string;
  /**
   *
   * - Format: int32
   */
  id: number;
  uploadedAt: LocalDateTime;
  checksum?: string;
  comment?: string;
  createdBy?: string;
  domainEvents?: BaseEvent[];
  fileName?: string;
  filePath?: string;
  fileType?: string;
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  uploadedBy?: string;
}

export interface GetSubmissionQueryParams {
  ExamId?: string;
}

export interface GetTodoItemsQueryParams {
  /**
   *
   * - Format: int32
   */
  ListId?: number;
  /**
   *
   * - Format: int32
   */
  PageNumber?: number;
  /**
   *
   * - Format: int32
   */
  PageSize?: number;
}

export type IntPtr = { [x in string | number]: any };

/**
 *
 * - Format: int32
 */

export enum IsoDayOfWeek {
  0 = 0,
  1 = 1,
  2 = 2,
  3 = 3,
  4 = 4,
  5 = 5,
  6 = 6,
  7 = 7,
}

export interface LocalDate {
  calendar: CalendarSystem;
  /**
   *
   * - Format: int32
   */
  day: number;
  dayOfWeek: IsoDayOfWeek;
  /**
   *
   * - Format: int32
   */
  dayOfYear: number;
  era: Era;
  /**
   *
   * - Format: int32
   */
  month: number;
  /**
   *
   * - Format: int32
   */
  year: number;
  /**
   *
   * - Format: int32
   */
  yearOfEra: number;
}

export interface LocalDateTime {
  calendar: CalendarSystem;
  /**
   *
   * - Format: int32
   */
  clockHourOfHalfDay: number;
  date: LocalDate;
  /**
   *
   * - Format: int32
   */
  day: number;
  dayOfWeek: IsoDayOfWeek;
  /**
   *
   * - Format: int32
   */
  dayOfYear: number;
  era: Era;
  /**
   *
   * - Format: int32
   */
  hour: number;
  /**
   *
   * - Format: int32
   */
  millisecond: number;
  /**
   *
   * - Format: int32
   */
  minute: number;
  /**
   *
   * - Format: int32
   */
  month: number;
  /**
   *
   * - Format: int64
   */
  nanosecondOfDay: number;
  /**
   *
   * - Format: int32
   */
  nanosecondOfSecond: number;
  /**
   *
   * - Format: int32
   */
  second: number;
  /**
   *
   * - Format: int64
   */
  tickOfDay: number;
  /**
   *
   * - Format: int32
   */
  tickOfSecond: number;
  timeOfDay: LocalTime;
  /**
   *
   * - Format: int32
   */
  year: number;
  /**
   *
   * - Format: int32
   */
  yearOfEra: number;
}

export interface LocalTime {
  /**
   *
   * - Format: int32
   */
  clockHourOfHalfDay: number;
  /**
   *
   * - Format: int32
   */
  hour: number;
  /**
   *
   * - Format: int32
   */
  millisecond: number;
  /**
   *
   * - Format: int32
   */
  minute: number;
  /**
   *
   * - Format: int64
   */
  nanosecondOfDay: number;
  /**
   *
   * - Format: int32
   */
  nanosecondOfSecond: number;
  /**
   *
   * - Format: int32
   */
  second: number;
  /**
   *
   * - Format: int64
   */
  tickOfDay: number;
  /**
   *
   * - Format: int32
   */
  tickOfSecond: number;
}

export interface PostChatQueryParams {
  message?: string;
}

export interface PostExamQueryParams {
  Description?: string;
  /**
   *
   * - Format: date-time
   */
  EndTime?: string;
  ExamFilePath?: string;
  /**
   *
   * - Format: date-time
   */
  LatestSubmissionTime?: string;
  /**
   *
   * - Format: date-time
   */
  StartTime?: string;
  Title?: string;
}

export interface PostFileQueryParams {
  BucketName?: string;
  Comment?: string;
  FileName?: string;
  FilePath?: string;
  FileType?: string;
}

export interface PostFileUploadFileStreamQueryParams {
  BucketName?: string;
  Comment?: string;
  FileName?: string;
  FilePath?: string;
  "FileStream.CanRead"?: boolean;
  "FileStream.CanSeek"?: boolean;
  "FileStream.CanTimeout"?: boolean;
  "FileStream.CanWrite"?: boolean;
  "FileStream.Handle"?: IntPtr;
  "FileStream.IsAsync"?: boolean;
  /**
   *
   * - Format: int64
   */
  "FileStream.Length"?: number;
  "FileStream.Name"?: string;
  /**
   *
   * - Format: int64
   */
  "FileStream.Position"?: number;
  /**
   *
   * - Format: int32
   */
  "FileStream.ReadTimeout"?: number;
  "FileStream.SafeFileHandle.IsAsync"?: boolean;
  "FileStream.SafeFileHandle.IsClosed"?: boolean;
  "FileStream.SafeFileHandle.IsInvalid"?: boolean;
  /**
   *
   * - Format: int32
   */
  "FileStream.WriteTimeout"?: number;
  FileType?: string;
  /**
   *
   * - Format: int64
   */
  "Reader.BodyLengthLimit"?: number;
  /**
   *
   * - Format: int32
   */
  "Reader.HeadersCountLimit"?: number;
  /**
   *
   * - Format: int32
   */
  "Reader.HeadersLengthLimit"?: number;
  /**
   *
   * - Format: int64
   */
  "Section.BaseStreamOffset"?: number;
  "Section.Body.CanRead"?: boolean;
  "Section.Body.CanSeek"?: boolean;
  "Section.Body.CanTimeout"?: boolean;
  "Section.Body.CanWrite"?: boolean;
  /**
   *
   * - Format: int64
   */
  "Section.Body.Length"?: number;
  /**
   *
   * - Format: int64
   */
  "Section.Body.Position"?: number;
  /**
   *
   * - Format: int32
   */
  "Section.Body.ReadTimeout"?: number;
  /**
   *
   * - Format: int32
   */
  "Section.Body.WriteTimeout"?: number;
  "Section.ContentDisposition"?: string;
  "Section.ContentType"?: string;
  "Section.Headers"?: { [x: string]: string[] };
}

/**
 *
 * - Format: int32
 */

export enum PriorityLevel {
  0 = 0,
  1 = 1,
  2 = 2,
  3 = 3,
}

export interface PriorityLevelDto {
  /**
   *
   * - Format: int32
   */
  value: number;
  name?: string;
}

export interface PutExamQueryParams {
  Description?: string;
  EndTime?: LocalDateTime;
  ExamFilePath?: string;
  Id?: string;
  LatestSubmissionTime?: LocalDateTime;
  StartTime?: LocalDateTime;
  Title?: string;
}

export interface PutTodoItemsUpdateItemDetailsQueryParams {
  /**
   *
   * - Format: int32
   */
  id?: number;
}

export interface Submission {
  /**
   *
   * - Format: date-time
   */
  created: string;
  exam: Exam;
  file: FileUpload;
  /**
   *
   * - Format: double
   */
  grade: number;
  graded: boolean;
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: uuid
   */
  submissionId: string;
  submittedAt: LocalDateTime;
  submitter: Examinee;
  correctorComment?: string;
  correctors?: UserAccount[];
  createdBy?: string;
  domainEvents?: BaseEvent[];
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  note?: string;
}

export interface TodoItemBriefDto {
  done: boolean;
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: int32
   */
  listId: number;
  title?: string;
}

export interface TodoItemBriefDtoPaginatedList {
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  /**
   *
   * - Format: int32
   */
  pageNumber: number;
  /**
   *
   * - Format: int32
   */
  totalCount: number;
  /**
   *
   * - Format: int32
   */
  totalPages: number;
  items?: TodoItemBriefDto[];
}

export interface TodoItemDto {
  done: boolean;
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: int32
   */
  listId: number;
  /**
   *
   * - Format: int32
   */
  priority: number;
  note?: string;
  title?: string;
}

export interface TodoListDto {
  /**
   *
   * - Format: int32
   */
  id: number;
  colour?: string;
  items?: TodoItemDto[];
  title?: string;
}

export interface TodosVm {
  lists?: TodoListDto[];
  priorityLevels?: PriorityLevelDto[];
}

export type Unit = { [x in string | number]: any };

export interface UpdateTodoItemCommand {
  done: boolean;
  /**
   *
   * - Format: int32
   */
  id: number;
  title?: string;
}

export interface UpdateTodoItemDetailCommand {
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: int32
   */
  listId: number;
  priority: PriorityLevel;
  note?: string;
}

export interface UpdateTodoListCommand {
  /**
   *
   * - Format: int32
   */
  id: number;
  title?: string;
}

export interface UserAccount {
  /**
   *
   * - Format: date-time
   */
  created: string;
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: uuid
   */
  userId: string;
  createdBy?: string;
  domainEvents?: BaseEvent[];
  exams?: Examinee[];
  examsToGrade?: Submission[];
  identityServiceId?: string;
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  roles?: UserRole[];
}

export interface UserRole {
  /**
   *
   * - Format: date-time
   */
  created: string;
  /**
   *
   * - Format: int32
   */
  id: number;
  /**
   *
   * - Format: uuid
   */
  roleId: string;
  createdBy?: string;
  domainEvents?: BaseEvent[];
  /**
   *
   * - Format: date-time
   */
  lastModified?: string;
  lastModifiedBy?: string;
  roleName?: string;
}

export interface WeatherForecast {
  /**
   *
   * - Format: date-time
   */
  date: string;
  /**
   *
   * - Format: int32
   */
  temperatureC: number;
  /**
   *
   * - Format: int32
   */
  temperatureF: number;
  summary?: string;
}
