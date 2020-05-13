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
  data: Array<any>;
  totalRecords: number;
  page = 0;
  sorting = 0;
  choise: string;
  sort: string;
  public selectedAlbum = 0;

  constructor( private cliService: ClientService, private http: HttpClient ) { }




  ngOnInit() {
  }


  GetAllAlbums() {


        return this.cliService.getAlbums()
        .subscribe(data => this.Albums$ = data);

  }


  GetAlbumsPaging(value: number) {

      console.log(this.page);
      switch (value) {
        case 0:
          this.page = 0;
          return this.cliService.getAlbumsPaging(this.page)
          .subscribe(data => this.Albums$ = data);
          break;
        case 1:
          this.page++;
          this.selectedAlbum += 10;
          return this.cliService.getAlbumsPaging(this.page)
          .subscribe(data => this.Albums$ = data);
          break;
        case 2:
          this.page--;
          this.selectedAlbum -= 10;
          /*
          if (this.page < 0 ) {
              this.page = 0;
          }
          */
          return this.cliService.getAlbumsPaging(this.page)
          .subscribe(data => this.Albums$ = data);
          break;
        case 3:
            this.sorting++;
            if (this.sorting % 2 === 0) {
              this.choise = 'asc';

            } else {
              this.choise = 'desc';
            }
            return this.cliService.getAlbumsSorting(this.sort = 'title', this.choise)
            .subscribe(data => this.Albums$ = data);
            break;
      }

    // https://localhost:5001/api/v1/albums?page=2&length=2
    // https://localhost:5001/api/v1/books?sort=title&dir=desc
  }


  PostAlbum(Btitle: string, Bgenre: string , Bartistid: number) {
      return this.cliService.postAlbum(Bgenre, Btitle, Bartistid);
    }


  DeleteAlbum(Bdelete: number) {
    return this.cliService.deleteAlbum(Bdelete);
  }

  UpdateAlbum(Btitle: string, Bgenre: string , Bartistid: number, BalbumId: number) {
    return this.cliService.updateAlbum(Bgenre, Btitle, Bartistid, BalbumId);
  }

  isNextValid() {
    if (this.selectedAlbum > this.Albums$.length) {
      return true;
    } else {
        return false;
    }
  }

  isPreviousValid() {
    if (this.selectedAlbum <= 0) {
        return true;
    } else if(this.selectedAlbum >= 10) {
        return false;
    }
}


}


