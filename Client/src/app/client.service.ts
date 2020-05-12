import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Http, Response } from '@angular/http';
import { Observable, of, throwError, pipe } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { JsonPipe } from '@angular/common';





@Injectable({
  providedIn: 'root'
})
export class ClientService {
  public apiUrl = 'https://localhost:5001/api/v1/albums';




  constructor( private httpclnt: HttpClient) {
  }

  getAlbums() {
    return this.httpclnt.get<Album[]>(this.apiUrl);


  }

  postAlbum = function(bgenre: string, btitle: string, bid: number ) {

    return this.httpclnt.post(this.apiUrl, {
      title:  btitle,
      genre: bgenre,
      artistId: bid} ).subscribe();
  }



}

export interface Album {
    albumId: number;
    artistId: number;
    title: string;
    genre: string;
}

