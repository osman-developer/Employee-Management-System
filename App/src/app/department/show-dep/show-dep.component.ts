import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service'
@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service: SharedService) { }

  DepartmentList: any = [];

  ModalTitle: string;
  ActivateAddEditDepComp: boolean = false;
  dep: any;

  DepartmentIDfilter: string = "";
  DepartmentNameFilter: string = "";
  DepartmentListWithoutFilter: any = [];
  ngOnInit(): void {
    this.refreshedDepList();
  }

  addClick() {
    this.dep = {
      DepartmentID: -1,
      DepartmentName: ""
    }
    this.ModalTitle = "Add Department";
    this.ActivateAddEditDepComp = true;
  }

  editClick(item) {
    this.dep = item;
    this.ModalTitle = "Edit Department";
    this.ActivateAddEditDepComp = true;
  }
  closeClick() {
    this.ActivateAddEditDepComp = false;
    this.refreshedDepList();
  }

  deleteClick(item) {
    if (confirm('Are you sure?')) {
      this.service.deleteDepartment(item).subscribe(data => {
        alert(data.toString());
        this.refreshedDepList();
      });
    }
  }
  refreshedDepList() {
    //asyn
    this.service.getDepartmentList().subscribe(data => {
      this.DepartmentList = data;
      this.DepartmentListWithoutFilter = data;
    });
  }

  FilterFn() {
    //not recommended to add logic in interface
    // var DepartmentIdfilter = this.DepartmentIDfilter;
    // var DepartmentNameFilter = this.DepartmentNameFilter;
    // this.DepartmentList=this.DepartmentListWithoutFilter.filter(function(el){
    //   return el.DepartmentId.toString().toLowerCase().includes(
    //     DepartmentIdfilter.toString().trim().toLowerCase()
    //   )&&
    //   el.DepartmentName.toString().toLowerCase().includes(
    //     DepartmentNameFilter.toString().trim().toLowerCase()
    //   )
    // })

    //filtering by going to the server and calling the api
    var val = {
      DepartmentId: this.DepartmentIDfilter,
      DepartmentName: this.DepartmentNameFilter
    }
    this.service.getDepartmentsByWhere(val).subscribe(data => {this.DepartmentList=data });
  }
  sortResult(prop, asc) {
    this.DepartmentList = this.DepartmentListWithoutFilter.sort(function (a, b) {
      if (asc) {
        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
      } else {
        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    })
  }
}
