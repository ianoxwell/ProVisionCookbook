import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-icon-text',
  templateUrl: './icon-text.component.html',
  styleUrls: ['./icon-text.component.scss']
})
export class IconTextComponent  {
	@Input() text: string;
	@Input() icon: string;
	@Input() titleText: string;
	@Input() color: string;

}
