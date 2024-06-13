export interface Absence {
    id: number
    lecture: string
    absenceDate: string
    absenceNote: string
    justified: boolean
    studentId: number
    teacherId: number
    teacher: string
}