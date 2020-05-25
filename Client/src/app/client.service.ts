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

  getAlbumById(id: number) {
    return this.httpclnt.get<Album>(this.apiUrl + 'albums/' + id );
  }

  getAlbumsByArtistId(artistId: number) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums/artist?idin=' + artistId);
  }

  ////////// COMBINE //////////////
  getAlbumsPaging(page: number, itemsperpage: number, dir: string ) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums?page=' + page + '&length=' + itemsperpage + '&sort=title' + '&dir=' + dir);
    // https://localhost:5001/api/v1/albums?page=2&length=2
  }

  getAlbumsSorting(sort: string, dir: string) {
    return this.httpclnt.get<Album[]>(this.apiUrl + 'albums?sort=' + sort + '&dir=' + dir);
      // https://localhost:5001/api/v1/books?sort=title&dir=desc

  }

  GetAlbumByGenre(genre: string) {
      return this.httpclnt.get<Album[]>(this.apiUrl + 'albums?genre=' + genre);

    // http://localhost:5000/api/v1/albums?genre=hip-hop
  }

  /////////////////////////////

  postAlbum = function(btitle: string = '', bgenre: string = '', bartistid: number ) {
    return this.httpclnt.post(this.apiUrl  + 'albums', {
      title:  btitle,
      genre: bgenre,
      artistId: bartistid} ).subscribe();

  };


  updateAlbum(bgenre: string = '', btitle: string = '', balbum: number ) {

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

    //////////// 3RD PARTY //////////////////

 GetAlbumCoverImage(albumname: string) {
      // tslint:disable-next-line:max-line-length
      return this.httpclnt.get<Image[]>('https://app.zenserp.com/api/v2/search?apikey=f2a40000-9867-11ea-bfa0-5740b8c51e76&q=' + albumname + '&tbm=isch');
  }

}

export interface Album {
    albumId: number;
    artistId: number;
    title: string;
    genre: string;
    release_date: Date;
}

export interface Artist {
  id: number;
  artistname: string;

}

export interface Image {
  thumbnail: string;

}


