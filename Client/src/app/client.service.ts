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
  public apiUrl = 'https://localhost:5001/api/v1/';




  constructor( private httpclnt: HttpClient) {}


  ///////////////////////////// ALBUM ////////////////////////////////////////////
  getAlbums() {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums');


  }

  getAlbumsByArtistId(artistId: number) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums/' + artistId);
  }

  ////////// COMBINE //////////////
  getAlbumsPaging(page: number) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums?page=' + page + '&length=10');
    // https://localhost:5001/api/v1/albums?page=2&length=2
  }

  getAlbumsSorting(sort: string, dir: string) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums?sort=' + sort + '&dir=' + dir);
      // https://localhost:5001/api/v1/books?sort=title&dir=desc

  }

  /////////////////////////////

  postAlbum = function(btitle: string, bgenre: string, bartistid: number ) {

    return this.httpclnt.post(this.apiUrl  + 'albums', {
      title:  btitle,
      genre: bgenre,
      artistId: bartistid} ).subscribe();

  };

  updateAlbum(bgenre: string, btitle: string, balbum: number ) {

    return this.httpclnt.put(this.apiUrl + 'albums', {
      title: btitle,
      genre: bgenre,
      albumId: balbum} ).subscribe();

  }


  deleteAlbum(Bid: number) {


    const deleteUrl = this.apiUrl  + 'albums' + '/' + Bid;
    console.log(deleteUrl);
    return this.httpclnt.delete(deleteUrl).subscribe();
  }
  ///////////////////////////// ALBUM ////////////////////////////////////////////

  ///////////////////////////// ARTIST //////////////////////////////////////////

  getAllArtist() {
    return this.httpclnt.get<Artist[]>(this.apiUrl + 'artists');

  }


    ///////////////////////////// ARTIST //////////////////////////////////////////

}

export interface Album {
    albumId: number;
    artistId: number;
    title: string;
    genre: string;
}

export interface Artist {
  id: number;
  artistname: string;

}


