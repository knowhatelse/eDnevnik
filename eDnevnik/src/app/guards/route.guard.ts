import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { INavigationService } from '../interfaces/i-navigation.interface';
import { IStorageService } from '../interfaces/i-storage.interface';

@Injectable({
  providedIn: 'root'
})
export class RouteGuard implements CanActivate {
  expectedRoles: string[] = [];

  constructor(
    private navigationService: INavigationService,
    private storageService: IStorageService,
    private router: Router
  ) {
    console.log("Router guard :: constructor");
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      
      return this.checkLoginStatus(route);
  }

  checkLoginStatus(route: ActivatedRouteSnapshot): boolean {
    if (this.navigationService.getLoginStatus()) {
      if(!this.checkRolePermission(route)){
        this.router.navigate(['/information']);
      }
      return true;
    }
  
    return false;
  }

  checkRolePermission(route: ActivatedRouteSnapshot): boolean {
    
    this.expectedRoles = route.data['expectedRole'];
    const currentRole = this.storageService.getLoginInfo().role;

    if(this.expectedRoles.includes(currentRole)) {
      return true;
    }

    return false;
  }

}
