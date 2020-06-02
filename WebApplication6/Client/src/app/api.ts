import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Component, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Api  {
  apiUrl: string = '/api/';



  constructor(private httpClient: HttpClient) {}

  getImageInBase64(id) {
    const httpOptions = {

      headers: new HttpHeaders({ 'responseType': 'text', 'accept' : '*'}),

    };
    return this.httpClient.get(this.apiUrl + 'images/download/' + id, { responseType: 'text' })
  }

  deleteImage(id) {
    const httpOptions = {

      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),

    };
    return this.httpClient.post(this.apiUrl + 'images/delete', id, httpOptions);
  }
   getImages(name, startDate, endDate) {
     return this.httpClient.get(
       this.apiUrl + 'images?name=' + name + '&startDate=' + startDate + '&endDate=' + endDate);
  }

  renameImages(newName) {
    const httpOptions = {

      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),

    };
    return this.httpClient.post(this.apiUrl + 'images/rename?newFileName=' + newName, httpOptions);
  }
  filteByDateRange(startDate, endDate) {
    return this.httpClient.get(this.apiUrl + 'images/filterByDate?startDate=' + startDate + '&endDate=' + endDate)
  }

  filterByName(name) {
    return this.httpClient.get(this.apiUrl + 'images/filterByName?name=' + name);
  }

  uploadImage(fileList) {
    const httpOptions = {

      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),

    };
    const headers = new HttpHeaders();
    headers.append("Content-Type", "application/json");
    return this.httpClient.post(this.apiUrl + 'images', JSON.stringify(
     fileList), httpOptions);
  }
}
