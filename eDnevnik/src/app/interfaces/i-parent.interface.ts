import { Observable } from "rxjs";
import { Parent } from "../models/response/parent.response.model";

export abstract class IParentService {
    abstract getParentById(parentId: number): Observable<Parent>;
}