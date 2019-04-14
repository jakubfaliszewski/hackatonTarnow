import { Component } from '@angular/core';
import {
  Router,
  RouterEvent,
  NavigationStart,
  NavigationEnd,
  NavigationCancel,
  NavigationError
} from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'hackhaton';
  loading = false;
  menuVisible = false;
  toggleMenu() {
    this.menuVisible = !this.menuVisible;
  }

  closeMenu() {
    this.menuVisible = false;
  }

  constructor(private router: Router) {
    router.events.subscribe((event: RouterEvent) => {
      this.navigationInterceptor(event)
    });
    console.info("App is running, yay!");
    console.info("%cHave a nice day, human (ಠ‿↼)", "font-weight: bold");
  }

  //navigation
  navigationInterceptor(event: RouterEvent): void {
    //this.token = localStorage.getItem("token");
    //this.role = localStorage.getItem("role");
    //if (this.token == null)
    //  this.logged = false;
    //else
    //  this.logged = true;

    if (event instanceof NavigationStart) {
      this.loading = true
      console.info('Loading component...');
    }
    if (event instanceof NavigationEnd) {
      setTimeout(() => {
        this.loading = false;
      }, 200);
      this.menuVisible = false;
      console.info('Component loaded.');
    }

    if (event instanceof NavigationCancel) {
      this.loading = false;
      this.menuVisible = false;

      console.info('canceled');
    }
    if (event instanceof NavigationError) {
      this.loading = false;
      this.menuVisible = false;

      console.info('error');
    }
  }

}
