/** Validation */
export enum ValidationMessageType {
	Info,
	Warning,
	Error,
	Critical
}

/** A representation of the status types */
export enum MessageStatus {
	None = '',
	Success = 'success',
	Error = 'error',
	Warning = 'warning',
	Information = 'information',
	Critical = 'critical'
}

export interface MessageModel {
	status: number;
	statusLevel: MessageStatus;
	statusText: string;
}

export interface StatusUpdate {
	status: MessageStatus;
	message: string;
	persist?: boolean;
}

export interface Message {
	severity?: MessageStatus;
	summary?: string;
	detail?: string;
	id?: any;
	key?: string;
	life?: number;
	sticky?: boolean;
	closable?: boolean;
	data?: any;
}
