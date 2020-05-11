import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Http, Response } from '@angular/http';
import { Observable, of, throwError, pipe } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ClientService {
  public apiUrl = 'https://localhost:5001/api/v1/';


  constructor( private httpclnt: HttpClient) { }




  getAllAlbums() {
    return this.httpclnt.get(this.apiUrl + '/albums')
    .pipe(
      map(res => res)
    );
  }

  inserAlbum(stu: any) {
    return this.httpclnt.post(this.apiUrl, stu)
    .pipe(
      map(res => res),
      catchError(this.errorHandler)
    );
  }



  updateAlbum(id: number , stu: any) {
    return this.httpclnt.put(this.apiUrl + '/' + id, stu)
    .pipe(
      map(res => res),
      catchError(this.errorHandler)
    );
  }


  deleteAlbum(id: number) {
    return this.httpclnt.delete(this.apiUrl + '/' + id)
    .pipe(
      map(res => res),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error: Response) {
    console.log(error);
    return throwError(error);

  }

}

export interface IAlbum {
    AlbumID: number;
    ArtistID: number;
    Title: string;
    Genre: string;
}

