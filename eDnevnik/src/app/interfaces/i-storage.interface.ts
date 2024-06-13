export abstract class IStorageService {
    abstract setLoginInfo(userId: number, role: string, token: string): void;
    abstract setUserInfo(userId: any, role: string): void;
    abstract getLoginInfo(): any;
    abstract getUserInfo(): any;
    abstract removeLoginInfo(): void;
    abstract removeUserInfo(): void;
}