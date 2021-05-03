import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:5000/api"
  readonly PhotoUrl = "http://localhost:5000/Photos/"

  constructor(private http: HttpClient) { }

  getDepartmentList(): Observable<any[]> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.get<any>(this.APIUrl + '/Department/GetDepartments', options);
  }

  addDepartment(val: any) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Department/EditDepartment', JSON.stringify(val), options);
  }

  updateDepartment(val: any) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Department/EditDepartment', JSON.stringify(val), options);
  }

  getDepartmentsByWhere(val:any){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Department/GetDepartmentsByWhere', JSON.stringify(val), options);
  }

  deleteDepartment(val: any) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Department/DeleteDepartment', JSON.stringify(val), options);
  }
  //------------

  getEmployeeList(): Observable<any[]> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.get<any>(this.APIUrl + '/Employee/GetEmployee', options);
  }

  addEmployee(val: any) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Employee/EditEmployee', JSON.stringify(val), options);
  }

  updateEmployee(val: any) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Employee/EditEmployee', JSON.stringify(val), options);
  }

  deleteEmployee(val: any) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };
    return this.http.post(this.APIUrl + '/Employee/DeleteEmployee', JSON.stringify(val), options);
  }

  UploadPhoto(val: any) {
    return this.http.post(this.APIUrl + '/Employee/SaveFile', val);
  }

  getAllDepartmentNames(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Employee/GetAllDepartmentName');
  }
}

export class Department {
  DepartmentID?: number;
  DepartmentName: string;
}