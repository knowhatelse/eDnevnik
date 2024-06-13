export interface Grade {
    id: number,
    gradeValue: number,
    gradeNote: string,
    dateOfAssessment: Date,
    studentId: number,
    subjectId: number
    subject: string
}