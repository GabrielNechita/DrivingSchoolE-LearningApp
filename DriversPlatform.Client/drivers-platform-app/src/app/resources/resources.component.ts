import { Component, OnInit } from '@angular/core';
import { IResource } from '../interfaces/resource.interface';
import { ResourceService } from '../services/resource.service';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.css']
})
export class ResourcesComponent implements OnInit {

  constructor(private _resourceService: ResourceService) { }

  resources: IResource[];
  openFile(resource) {
    this._resourceService.getResourceById(resource.id)
    .subscribe(data => {
      var file = new Blob([data], { type: 'application/pdf' });
      var fileURL = URL.createObjectURL(file);
      window.open(fileURL);
    });
  }

  ngOnInit(): void {
    this._resourceService.getResources()
      .subscribe((data: IResource[]) => {
        this.resources = data.sort((a, b) => a.name?.localeCompare(b.name));
      });
  }
}
