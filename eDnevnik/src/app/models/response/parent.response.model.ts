import { Student } from "./student.response.model";

export interface Parent {
    students?: Student[],
    id: number
    firstName: string
    lastName: string
    username: string
    role: string
    birthDate: string
    enabled2FA: boolean
    schoolId: number
}