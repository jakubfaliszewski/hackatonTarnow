import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup,FormBuilder, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { HttpClient } from '@angular/common/http';
import { signalRService } from '../services/signal-r.service';

export class MyErrorStateMatcher implements ErrorStateMatcher {

  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private signalRService: signalRService = new signalRService();

  emailFormControl = new FormControl('', [
      Validators.required,
      Validators.email,
    ]);
  PasswordFormControl = new FormControl('', [
      Validators.required
    ]);

  matcher = new MyErrorStateMatcher();
  
  public user = {};
  constructor(private http: HttpClient) {
      
  }

  public login() {
    this.http.post("https://localhost:5001/api/login", this.user, {responseType: "text"}).subscribe(resp => {
      console.log(resp);
    });
  }

  ngOnInit() {

  }

}
