import {Component, OnInit, ViewChild} from '@angular/core';
import {DateTimeService} from '../../services/date-time.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
//   @ViewChild('calendar', {static: false}) calendarComponent: FullCalendarComponent;
// //   calendarPlugins = [dayGridPlugin, resourceTimelinePlugin, timeGrigPlugin, interactionPlugin, listPlugin];
//   calendarEvents: EventInput[] = [
// 	{ title: 'Event Now ish',
// 	  start: new Date(),
// 	  description: 'Something has to be happening, right?',
// 	  end: DateTimeService.addHours(new Date(), 2),
// 	  allDay: false
// 	}
//   ];
//   calendarOptions = {
// 		plugins: this.calendarPlugins,
// 		events: this.calendarEvents,
// 		//   defaultView="dayGridMonth"
// 		schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
// 		initialView: 'dayGridMonth',
// 		dateClick: this.handleDateClick.bind(this, 'dateClick'),
// 		headerToolbar: {
// 			left: 'prev,next today',
// 			center: 'title',
// 			right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
// 			},
// 		eventClick: this.handleDateClick.bind(this, 'event')
// 	};

  constructor() { }
  handleDateClick(event: any, source: string) {
	console.log('date clicked, ', event);
  }
  ngOnInit() {
  }

}
