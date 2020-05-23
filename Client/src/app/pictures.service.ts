
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {


constructor(private http: HttpClient) { }

GetPhotos(name: string) {
   // tslint:disable-next-line:max-line-length
   return this.http.get<any>('https://app.zenserp.com/api/v2/search?apikey=f2a40000-9867-11ea-bfa0-5740b8c51e76&q=' + name + '&tbm=isch&device=desktop&location=Manhattan,New%20York,United%20States');
}

}

export interface RootObject {
  query: Query;
  related_searches: any[];
  image_results: Imageresult[];
}

export interface Imageresult {
  position: number;
  thumbnail: string;
  sourceUrl: string;
  title: string;
  link: string;
  source: string;
}

export interface Query {
  apikey: string;
  q: string;
  tbm: string;
  device: string;
  location: string;
  url: string;
}
