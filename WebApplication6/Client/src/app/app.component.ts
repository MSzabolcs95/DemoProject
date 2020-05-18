import { Component, OnInit } from '@angular/core';
import { Api } from '../api';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  startDate = null;
  filterByName = null;
  endDate = new Date().toISOString().slice(0, 10);
  images;
 async onFilesSelected(evt: Event) {
   let reader = new FileReader();
   let fileList = [];
    const files: FileList = (evt.target as HTMLInputElement).files;
   for (let i = 0; i < files.length; i++) {
     let reader = new FileReader();
      const file = files[i];
       reader.readAsDataURL(file);
      reader.onload = async () => {
        fileList.push({ Name: file.name, Date: new Date(), Base64Picture: reader.result });
        if (fileList.length === files.length) {
          await this.api.uploadImage(fileList).subscribe(res => this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
            console.log(data);
            this.images = data;
          }));
          
        }
      };
    }
  }

  applyFilter(event) {
    if (event.target.value.length > 0) {
      this.filterByName = event.target.value
    }
    else {
      this.filterByName = null;
    }
      this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
        console.log(data);
        this.images = data;
      });
    };
 

  b64toBlob (b64Data, contentType = '', sliceSize = 512) {
    const byteCharacters = atob(b64Data);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
      const slice = byteCharacters.slice(offset, offset + sliceSize);

      const byteNumbers = new Array(slice.length);
      for (let i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }

      const byteArray = new Uint8Array(byteNumbers);
      byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
  }

  async OnDeleteSelected(id) {
    await this.api.deleteImage(id).subscribe(()=>
      this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
      console.log(data);
      this.images = data;
    }));
  }

  addEvent(event) {
    this.endDate = new Date(event.value).toISOString();
    if (typeof this.startDate !== 'undefined') {
      this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
        console.log(data);
        this.images = data;
      });;
    }
    //console.log(event.value);
  };

  rename(event) {
    if (event.length > 0) {
      this.api.renameImages(event).subscribe(() =>
        this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
          console.log(data);
          this.images = data;
        }));
    }
  }

  startDateChange(event) {
    this.startDate = new Date(event.value).toISOString();
    this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
      console.log(data);
      this.images = data;
    });
   //console.log(this.endDate);
    //console.log(this.startDate);
  }

  OnDownloadSelected(fileName, id) {
    var contentType = 'image/' + fileName.split('.')[fileName.split('.').length - 1];
    this.api.getImageInBase64(id).subscribe((data) => {
      const blob = this.b64toBlob(data, contentType);
      const blobUrl = URL.createObjectURL(blob);
      var a = document.createElement("a");
      document.body.appendChild(a);
      a.href = blobUrl;
      a.download = fileName;
      a.click();
    })
  };
  constructor(private api: Api) { }
  ngOnInit() {
    this.api.getImages(this.filterByName, this.startDate, this.endDate).subscribe((data) => {
      console.log(data);
      this.images = data;
    });
  }
  date = new FormControl(new Date())
  displayedColumns: string[] = ['position', 'name', 'weight','actions'];
  dataSource = this.images;
  title = 'ClientApp';
}
