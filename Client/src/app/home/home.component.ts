import { Component, OnInit } from '@angular/core';
import { ClientService, Album } from '../client.service';


import { FormsModule, ReactiveFormsModule, Validator, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public apiUrl = 'https://localhost:5001/api/v1/albums';
  Albums$: Album[];


  constructor( private cliService: ClientService, private http: HttpClient ) { }



  ngOnInit() {
  }


  GetAllAlbums() {

        return this.cliService.getAlbums()
        .subscribe(data => this.Albums$ = data);

  }

  PostAlbum(Btitle: string, Bgenre: string , Bartistid: number) {
      return this.cliService.postAlbum(Bgenre, Btitle, Bartistid);
    }
}
