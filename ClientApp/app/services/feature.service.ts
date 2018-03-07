import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class FeatureService {

  constructor(private http:Http) { }
  getFeatures(){
    this.http.get("/api/features").map(res=>res.json());
  }
}
