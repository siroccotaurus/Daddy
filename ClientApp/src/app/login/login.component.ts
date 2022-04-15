import { Component, OnInit, Inject } from '@angular/core';
import { IUser, IUserResponse } from '../interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SimpleQuestion, User } from '../classes';
import { Router } from '@angular/router';

declare function initAs(page): any;

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Component({
  selector: 'app-counter-component',
  templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit {
  protected http: HttpClient;
  private baseUrl: string;
  private router: Router;

  constructor(protected h: HttpClient, @Inject("BASE_URL") bURL: string, private r: Router) {
    this.http = h;
    this.baseUrl = bURL;
    this.router = r;
    
    this.SetSession("", "");
  }

  ngOnInit(): void {
    initAs("login");
  }

  Login(email: string, password: string) {
    this.http.post<SimpleQuestion>(this.baseUrl + "MainController/Sha256",
      {
        'text': password,
      }, httpOptions).subscribe(
        res256 => {
          if (res256.text == "") console.error("Encryption failed.");
          else {
            this.http.post<IUserResponse>(this.baseUrl + "UserController/Login",
              {
                'email': email,
                'password': res256.text,
              }, httpOptions).subscribe(result => { if (!result.success) console.error(result.message); else this.SetSession(email, res256.text); }, error => console.error(error));
          }
        }, error => console.error(error));
  }

  SetSession(email: string, password: string) {
    this.http.post<User>(this.baseUrl + "MainController/Login",
      {
        'email': email,
        'password': password,
      }, httpOptions).subscribe(result => { if (result == null) console.warn("Web has no session active"); else if (email == "") this.router.navigate(['/user']); else this.router.navigate(['/']); }, error => console.error(error));
  }
}
