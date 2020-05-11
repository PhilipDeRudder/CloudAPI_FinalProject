import { Component, OnInit } from '@angular/core';
import { ClientService, IAlbum } from '../client.service';

import { FormsModule, ReactiveFormsModule, Validator, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  insertForm: FormGroup;
  updateForm: FormGroup;

  globalResponse: any;
  inputAlbumForm: IAlbum[];
  allAlbums: IAlbum[];
  selectedAlbums: IAlbum[];
  idValue = 0;

  constructor( private fb: FormBuilder , private cliService: ClientService ) { }



  ngOnInit() {

    this.insertForm = this.fb.group(
      {
        Name: ['', [Validators.required]],
        Phone: ['', [Validators.required]],
        Email: ['', [Validators.required]],
      }
    );
    this.updateForm = this.fb.group(
      {
        Name: ['', [Validators.required]],
        Phone: ['', [Validators.required]],
        Email: ['', [Validators.required]],
      }
    );
  }
  Save() {
    this.inputAlbumForm = this.insertForm.value;
    this.cliService.inserAlbum(this.inputAlbumForm)
      .subscribe((result) => {
        this.globalResponse = result;
        });
  }


  Update() {
    this.inputAlbumForm = this.insertForm.value;
    this.cliService.updateAlbum(this.idValue, this.selectedAlbums)
      .subscribe((result) => {
        this.globalResponse = result;
      });
  }


  Delete() {
    this.cliService.deleteAlbum(this.idValue)
      .subscribe((result) => {
        this.globalResponse = result;
      });
  }


  GetAllAlbums() {
    this.inputAlbumForm = this.insertForm.value;
    this.cliService.getAllAlbums()
      .subscribe((result) => {
        this.globalResponse = result;
        });
  }

  GetSelectedAlbums(stu: any) {
    this.selectedAlbums = stu;
    // tslint:disable-next-line:no-string-literal
    this.updateForm.controls['Title'].setValue(this.selectedAlbums['Title']);
    // tslint:disable-next-line:no-string-literal
    this.updateForm.controls['Genre'].setValue(this.selectedAlbums['Genre']);
    // this.updateForm.controls["Email"].setValue(this.selectedAlbums["Email"]);
    // tslint:disable-next-line:no-string-literal
    this.idValue = this.selectedAlbums['Id'];
  }

}
