import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '@components/base/base.component.base';
import { LoginService } from '@services/login/login.service';
import { PageTitleService } from '@services/page-title.service';
import { StorageService } from '@services/storage/storage.service';
import { UserProfileService } from '@services/user-profile.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends ComponentBase implements OnInit {
  constructor(
    private pageTitleService: PageTitleService,
    private storageService: StorageService,
    private userProfileService: UserProfileService,
    private loginService: LoginService
  ) {
    super();
  }
  ngOnInit(): void {
    this.pageTitleService.listen().pipe(takeUntil(this.ngUnsubscribe)).subscribe();
  }
}
