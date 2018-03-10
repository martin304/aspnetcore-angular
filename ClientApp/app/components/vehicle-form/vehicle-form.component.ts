

import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes:any[];
  models:any[];
  vehicle:any={
    features:[]
  };
  features:any[];
  constructor(private vehicleService:VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes=>{
      this.makes=makes;
      console.log("Makes",this.makes);
    });
    this.vehicleService.getFeatures().subscribe(features=>{
      this.features=features;
      console.log("Features",this.features);
    });
  }
  onMakeChange(){
   var selectedMake=this.makes.find(m=>m.id==this.vehicle.makeId);
  this.models= selectedMake?selectedMake.models:[]
     console.log("sm",selectedMake);
     delete this.vehicle.modelId;
  }
  onFeatureToggle(featureId:any,$event:any){
    if($event.target.checked)
    this.vehicle.features.push(featureId);
    else{
      var index=this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index,1);
    }
  }
}
