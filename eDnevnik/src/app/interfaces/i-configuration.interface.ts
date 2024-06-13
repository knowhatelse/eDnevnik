import { HttpHeaders } from "@angular/common/http";

export abstract class IConfigurationService{
    abstract  getBaseUrl(): string;
    abstract  getHeaders(): HttpHeaders;
}