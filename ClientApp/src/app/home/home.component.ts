import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ICharacter, ICharacterResponse } from '../interfaces';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  protected http: HttpClient;
  private baseUrl: string;
  public cities: ICharacter[];

  constructor(protected h: HttpClient, @Inject("BASE_URL") bURL: string) {
    this.http = h;
    this.baseUrl = bURL;

    this.http.post<ICharacterResponse>(this.baseUrl + "CityController/GetMatchings",
      {
        'match': 'barc',
      }, httpOptions).subscribe(result => { if (!result.success) console.error(result.message); else this.cities = result.data as ICharacter[]; }, error => console.warn(error));


    //this.http.post<ICityResponse>(this.baseUrl + "CityController/GetMatchings",
    //  {
    //    'username': 'eloiaro5',
    //    'password': 'hammer',
    //  }, httpOptions).subscribe(result => { if (!result.success) console.error(result.message); else this.cities = result.data as ICity[]; }, error => console.warn(error));
  }
}
