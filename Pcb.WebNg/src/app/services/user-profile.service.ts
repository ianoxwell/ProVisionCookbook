import { Injectable } from '@angular/core';
import { AdminRights, IdTitlePair } from '@models/common.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { User, UserRole } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  private userProfile$: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);
  private isLoggedIn$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  getUserProfile(): Observable<User | null> {
    return this.userProfile$.asObservable();
  }

  getIsLoggedIn(): Observable<boolean> {
    return this.isLoggedIn$.asObservable();
  }

  setUserProfile(userProfile: User | null) {
    this.userProfile$.next(userProfile);
  }

  setLoggedIn(isLoggedIn: boolean) {
    this.isLoggedIn$.next(isLoggedIn);
  }

  checkAdminRights(user: User): AdminRights {
    const schoolAdmin: IdTitlePair[] = [];
    let globalAdmin = false;
    user.userRole?.forEach((roleItem: UserRole) => {
      if (roleItem.role.isAdmin && roleItem.isCountryWide) {
        globalAdmin = true;
      } else if (roleItem.role.isAdmin && !!roleItem.schoolId && !!roleItem.school) {
        schoolAdmin.push({ id: roleItem.schoolId, title: roleItem.school.title });
      }
    });
    return {
      globalAdmin,
      schoolAdmin
    };
  }
}
