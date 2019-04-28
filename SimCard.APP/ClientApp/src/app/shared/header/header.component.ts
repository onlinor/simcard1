import { Component, OnInit } from '@angular/core';
import { AuthService, SubscribeService } from '../../core/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn = false;

  constructor(
    private authService: AuthService,
    private subscribeService: SubscribeService,
    private router: Router
  ) {
    this.subscribeService.$subscribe('UserLoggedIn').subscribe(
      result => {
        this.isLoggedIn = result;
      },
      error => (this.isLoggedIn = false)
    );
  }

  ngOnInit() {}

  logout() {
    this.subscribeService.publish('UserLoggedOn', false);
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
