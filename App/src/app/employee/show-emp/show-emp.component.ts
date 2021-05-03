import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service'
@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service: SharedService) { }

  EmployeeList: any = [];

  ModalTitle: string;
  ActivateAddEditEmpComp: boolean = false;
  emp: any;

  ngOnInit(): void {
    this.refreshedEmpList();
  }

  addClick() {
    this.emp = {
      EmployeeId: 0,
      EmployeeName: "",
      Department:"",
      DateOfJoining:"",
      PhotoFileName:"anonymous.png"
    }
    this.ModalTitle = "Add Employee";
    this.ActivateAddEditEmpComp = true;
  }

  editClick(item) {
    this.emp = item;
    this.ModalTitle = "Edit Employee";
    this.ActivateAddEditEmpComp = true;
  }
  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.refreshedEmpList();
  }

  deleteClick(item){
    if(confirm('Are you sure?')){
      this.service.deleteEmployee(item).subscribe(data=>{
        alert(data.toString());
        this.refreshedEmpList();
      });
    }
  }
  refreshedEmpList() {
    //asyn
    this.service.getEmployeeList().subscribe(data => {
      this.EmployeeList = data;
    });
  }

}
