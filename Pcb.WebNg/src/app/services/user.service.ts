import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagedResult } from '@models/common.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private defaultHeader = new HttpHeaders()
    .set('Content-Type', 'application/json;odata=verbose')
    .set('Accept', 'application/json;odata=verbose');
  private apiURL = environment.apiUrl + environment.apiVersion;

  constructor(private httpClient: HttpClient) {}

  // *
  // User Items - split out?
  // *
  // TODO add the query filters
  public getUsers(queryString: string | null): Observable<Array<User>> {
    return this.httpClient.get<Array<User>>(this.apiURL + 'admin/users' + queryString, { headers: this.defaultHeader });
  }
  public createUser(user: User): Observable<User> {
    return this.httpClient.post<User>(this.apiURL + 'admin/users/save', user, { headers: this.defaultHeader });
  }

  // TODO does this need its own end point and update process?
  public updateUser(userID: string, update: any): Observable<User> {
    return this.httpClient.put<User>(this.apiURL + 'admin/users/save' + userID, update, {
      headers: this.defaultHeader
    });
  }

  // TODO implement the API
  public deleteUser(userID: string): Observable<User> {
    return this.httpClient.delete<User>(this.apiURL + 'admin/users/' + userID, { headers: this.defaultHeader });
  }

  // TODO implement the API
  public getUserByEmail(emailString: string): Observable<PagedResult<User>> {
    return this.httpClient.get<PagedResult<User>>(this.apiURL + `user?filter=email%3D${emailString}`, {
      headers: this.defaultHeader
    });
  }

  public getUserById(userID: string): Observable<User> {
    return this.httpClient.get<User>(this.apiURL + 'admin/users/' + userID, { headers: this.defaultHeader });
  }
}
