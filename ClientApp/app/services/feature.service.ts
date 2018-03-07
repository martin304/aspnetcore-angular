import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class FeatureService {

  constructor(private http:Http) { }
  getFeature(){
   return this.http.get("/api/features").subscribe(res=>res.json());
  }
}
