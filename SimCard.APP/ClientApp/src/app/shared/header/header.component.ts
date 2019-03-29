import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean;
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isLoggedIn = this.authService.currentUserValue != null ? true : false;
  }

}
