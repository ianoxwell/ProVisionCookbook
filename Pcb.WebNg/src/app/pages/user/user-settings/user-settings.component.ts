import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../../../services/user-profile.service';
import { User } from '../../../models/user';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.scss']
})
export class UserSettingsComponent implements OnInit {
  cookBookUserProfile: User | null = null;

  constructor(
	public userProfileService: UserProfileService
  ) { }

  ngOnInit() {
	  this.userProfileService.currentData.subscribe(profile => this.cookBookUserProfile = profile);
  }

}
