import { Validations } from '../common.model';

export class QuestionBase<T> {
	value: T;
	key: string;
	label: string;
	validators: {
		required: boolean;
		minLength: number;
		min: number;
		maxLength: number;
		max: number;
		pattern: string;
	};
	order: number;
	controlType: string;
	type: string | boolean;
	options: {key: string, value: string}[];
	outerClass: string;
	innerClass: string;
	validationMessages: Validations[];
	childQuestion: QuestionBase<T>;

	constructor(options: {
		value?: T,
		key?: string,
		label?: string,
		validators?: {
			required?: boolean,
			minLength?: number,
			min?: number;
			maxLength?: number;
			max?: number;
			pattern?: string;
		},
		order?: number,
		controlType?: string,
		type?: string,
		outerClass?: string,
		innerClass?: string,
		validationMessages?: Validations[];
		childQuestion?: QuestionBase<T>;
		} = {}) {
		this.value = options.value;
		this.key = options.key || '';
		this.label = options.label || '';
		if (options.validators && Object.keys(options.validators).length > 0) {
		this.validators = {
				required: !!options.validators.required,
				minLength: options.validators.minLength || null,
				min: options.validators.min || null,
				maxLength: options.validators.maxLength || null,
				max: options.validators.max || null,
				pattern: options.validators.pattern || null
			};
		}
		this.order = options.order === undefined ? 1 : options.order;
		this.controlType = options.controlType || '';
		this.type = options.type || '';
		this.outerClass = options.outerClass;
		this.innerClass = options.innerClass;
		this.validationMessages = options.validationMessages ? options.validationMessages : null;
		if (options.childQuestion) {
		this.childQuestion = options.childQuestion;
		}
	}
  }
