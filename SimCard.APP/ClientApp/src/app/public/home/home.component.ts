import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  selectedDonVi: String = '';
  LoaiDonVi = [
    { label: 'Shop 1', value: 'CN1' },
    { label: 'Shop 2', value: 'CN2' },
    { label: 'Shop 3', value: 'CN3' },
    { label: 'Shop 4', value: 'CN4' }
  ];
  constructor() {}

  ngOnInit() {}
}
