!function(){function e(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function t(e,t){for(var r=0;r<t.length;r++){var i=t[r];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(e,i.key,i)}}function r(e,r,i){return r&&t(e.prototype,r),i&&t(e,i),e}function i(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function");e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,writable:!0,configurable:!0}}),t&&o(e,t)}function o(e,t){return(o=Object.setPrototypeOf||function(e,t){return e.__proto__=t,e})(e,t)}function n(e){var t=function(){if("undefined"==typeof Reflect||!Reflect.construct)return!1;if(Reflect.construct.sham)return!1;if("function"==typeof Proxy)return!0;try{return Boolean.prototype.valueOf.call(Reflect.construct(Boolean,[],function(){})),!0}catch(e){return!1}}();return function(){var r,i=s(e);if(t){var o=s(this).constructor;r=Reflect.construct(i,arguments,o)}else r=i.apply(this,arguments);return a(this,r)}}function a(e,t){return!t||"object"!=typeof t&&"function"!=typeof t?function(e){if(void 0===e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return e}(e):t}function s(e){return(s=Object.setPrototypeOf?Object.getPrototypeOf:function(e){return e.__proto__||Object.getPrototypeOf(e)})(e)}(self.webpackChunkcook_book=self.webpackChunkcook_book||[]).push([[823],{8823:function(t,o,a){"use strict";a.r(o),a.d(o,{AccountModule:function(){return Ne}});var s=a(8583),l=a(3679),u=a(1095),c=a(3738),m=a(7539),g=a(1769),f=a(8295),d=a(6627),p=a(9983),v=a(6398),h=a(5512),w=a(9876),y=a(8047),Z=a(3423),b=a(6025),T=a(1209),k=a(7851),S=a(5917),x=a(3342),q=a(5304),A=a(6782),I=a(7716),N=a(2684),J=a(448);function U(e,t){if(1&e&&(I.TgZ(0,"mat-error",14),I._UZ(1,"span",15),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function P(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,U,2,1,"mat-error",13),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(2);I.xp6(1),I.Q6J("ngIf",i.f.email.hasError(r.type)&&(i.f.email.dirty||i.f.email.touched))}}function E(e,t){if(1&e){var r=I.EpF();I.TgZ(0,"form",5),I.TgZ(1,"mat-form-field",6),I.TgZ(2,"mat-icon",7),I._uU(3,"email"),I.qZA(),I.TgZ(4,"input",8),I.NdJ("keyup.enter",function(){return I.CHM(r),I.oxw().forgotPassword()}),I.qZA(),I.YNc(5,P,2,1,"mat-error",9),I.qZA(),I.TgZ(6,"div",10),I.TgZ(7,"button",11),I._uU(8,"Cancel"),I.qZA(),I.TgZ(9,"app-save-button",12),I.NdJ("save",function(){return I.CHM(r),I.oxw().forgotPassword()}),I.qZA(),I.qZA(),I.qZA()}if(2&e){var i=I.oxw();I.Q6J("formGroup",i.form),I.xp6(5),I.Q6J("ngForOf",i.validationMessages.email),I.xp6(4),I.Q6J("dirty",i.form.dirty)("valid",i.form.valid)("isSaving",i.isSubmitting)}}function _(e,t){1&e&&(I.TgZ(0,"div"),I._uU(1," Please check your email or your spam folder for a password reset link. "),I.qZA())}var C=function(){var t=function(t){i(a,t);var o=n(a);function a(t,r,i,n,s,l){var u;return e(this,a),(u=o.call(this)).fb=t,u.route=r,u.router=i,u.accountService=n,u.messageService=s,u.cdr=l,u.validationMessages=k.rm,u.showLookInYourEmail=!1,u.isSubmitting=!1,u.form=u.createForm(),u}return r(a,[{key:"ngOnInit",value:function(){var e=this.route.snapshot.queryParams.email;void 0!==e&&(this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),this.f.email.setValue(e),this.f.email.markAsTouched(),this.f.email.markAsDirty())}},{key:"f",get:function(){return this.form.controls}},{key:"createForm",value:function(){return this.fb.group({email:["",[l.kI.required,l.kI.minLength(2),l.kI.maxLength(120),l.kI.email]]})}},{key:"forgotPassword",value:function(){var e=this;this.form.invalid||(this.isSubmitting=!0,this.accountService.forgotPassword(this.form.getRawValue().email).pipe((0,x.b)(function(t){"Please login through your Google Account"===t.message?(e.messageService.add({severity:T.r.Warning,summary:"No Password to reset",detail:t.message,life:8e3}),e.f.email.setErrors({googleLogin:!0}),e.cdr.markForCheck(),e.form.updateValueAndValidity()):e.showLookInYourEmail=!0,e.isSubmitting=!1,console.log("email send result",t,e.isSubmitting)}),(0,q.K)(function(t){return 400===t.status&&e.messageService.add({severity:T.r.Error,summary:"Email Error",detail:"The server did not receive a correctly formatted email address.",life:8e3}),404===t.status&&(e.messageService.add({severity:T.r.Warning,summary:"No Email account found",detail:t.error.message,life:8e3}),e.f.email.setErrors({registrationRequired:!0},{emitEvent:!0}),e.cdr.markForCheck()),e.isSubmitting=!1,(0,S.of)()}),(0,A.R)(this.ngUnsubscribe)).subscribe(function(t){console.log("we got to the subscribe conclusion?",t,e.isSubmitting),e.isSubmitting=!1}))}}]),a}(b.V);return t.\u0275fac=function(e){return new(e||t)(I.Y36(l.qu),I.Y36(Z.gz),I.Y36(Z.F0),I.Y36(w.B),I.Y36(N.e),I.Y36(I.sBO))},t.\u0275cmp=I.Xpm({type:t,selectors:[["app-forgot-password"]],features:[I.qOj],decls:9,vars:2,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],[3,"ngSwitch"],["mat-card-content","",3,"formGroup",4,"ngSwitchDefault"],[4,"ngSwitchCase"],["mat-card-content","",3,"formGroup"],[1,"mt-1","w-100"],["matPrefix","",1,"pr-1"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","email",3,"keyup.enter"],[4,"ngFor","ngForOf"],[1,"flex-box","flex-justify-end","mt-4"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login",1,"mr-1"],["label","Submit",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(I.TgZ(0,"mat-card-header"),I.TgZ(1,"mat-card-title"),I.TgZ(2,"h2",0),I.TgZ(3,"mat-icon",1),I._uU(4,"memory"),I.qZA(),I._uU(5,"Forgot Password"),I.qZA(),I.qZA(),I.qZA(),I.TgZ(6,"div",2),I.YNc(7,E,10,5,"form",3),I.YNc(8,_,2,0,"div",4),I.qZA()),2&e&&(I.xp6(6),I.Q6J("ngSwitch",t.showLookInYourEmail),I.xp6(2),I.Q6J("ngSwitchCase",!0))},directives:[c.dk,c.n5,d.Hw,s.RF,s.ED,s.n9,l._Y,l.JL,c.dn,l.sg,f.KE,f.qo,p.Nt,l.Fj,l.JJ,l.u,s.sg,u.lW,Z.rH,J.t,f.TO,s.O5],styles:[""]}),t}(),O=a(8948),Y=a(5798),F=a(7870),L=["passwordInput"];function M(e,t){if(1&e&&(I.TgZ(0,"mat-error",23),I._UZ(1,"span",24),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function Q(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,M,2,1,"mat-error",22),I.qZA()),2&e){var r=t.$implicit,i=I.oxw();I.xp6(1),I.Q6J("ngIf",i.f.usernameControl.hasError(r.type)&&(i.f.usernameControl.dirty||i.f.usernameControl.touched))}}function R(e,t){if(1&e&&(I.TgZ(0,"mat-error",23),I._UZ(1,"span",24),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function G(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,R,2,1,"mat-error",22),I.qZA()),2&e){var r=t.$implicit,i=I.oxw();I.xp6(1),I.Q6J("ngIf",i.f.passwordControl.hasError(r.type)&&(i.f.passwordControl.dirty||i.f.passwordControl.touched))}}var V=function(){var t=function(t){i(a,t);var o=n(a);function a(t,r,i,n,s,l){var u;return e(this,a),(u=o.call(this)).fb=t,u.authService=r,u.loginService=i,u.router=n,u.messageService=s,u.cdr=l,u.validationMessages=k.rm,u.isSubmitting=!1,u}return r(a,[{key:"ngOnInit",value:function(){this.loginForm=this.createForm()}},{key:"f",get:function(){return this.loginForm.controls}},{key:"createForm",value:function(){return this.fb.group({usernameControl:["",[l.kI.required,l.kI.minLength(2),l.kI.maxLength(120),l.kI.email]],passwordControl:["",[l.kI.required,l.kI.minLength(2)]],rememberControl:!1})}},{key:"rememberChange",value:function(e){console.log("Im not going to remember you, terrible with names",e)}},{key:"login",value:function(){var e=this;if(this.isSubmitting=!0,this.loginForm.invalid)return null;this.passwordInput.nativeElement.blur();var t=this.loginForm.getRawValue();this.loginService.login(t.usernameControl,t.passwordControl,!1).pipe((0,x.b)(function(r){return e.loginResult(r,t)}),(0,q.K)(function(t){return e.catchFormError(t)}),(0,A.R)(this.ngUnsubscribe)).subscribe()}},{key:"loginResult",value:function(e,t){if(this.isSubmitting=!1,"Successful login"===e.message)this.router.navigate(["/savoury/recipes/browse"]);else if(e.message.indexOf("Lockout")>-1){var r=Number(e.message.substring(9));r&&r>4&&(console.log("here we locking routing,",r,"/account/forgot-password?email=".concat(t.usernameControl)),this.router.navigate(["/account/forgot-password"],{queryParams:{email:t.usernameControl}}),this.messageService.add({severity:T.r.Warning,summary:"Lockout",detail:"Please wait 20 minutes to try again or reset password.",life:12e3}))}else this.messageService.add({severity:T.r.Warning,summary:"Login problem",detail:e.message,life:12e3})}},{key:"catchFormError",value:function(e){return this.isSubmitting=!1,e.status===O.WE.BadRequest?(this.f.passwordControl.setErrors({wrongPassword:!0},{emitEvent:!0}),this.cdr.markForCheck(),this.messageService.add({severity:T.r.Warning,summary:"Password error",detail:'You can reset your password through "Forgot Password"',life:12e3})):this.messageService.add(e.status===O.WE.Forbidden?{severity:T.r.Warning,summary:"Account Issue",detail:'Your Account has been deactivated, please email support for more info."',life:12e3}:{severity:T.r.Error,summary:"Major Error",detail:e.message,life:12e3}),(0,S.of)()}},{key:"googleSignIn",value:function(){this.authService.signIn(F.tV.PROVIDER_ID)}}]),a}(b.V);return t.\u0275fac=function(e){return new(e||t)(I.Y36(l.qu),I.Y36(F.xE),I.Y36(Y.r),I.Y36(Z.F0),I.Y36(N.e),I.Y36(I.sBO))},t.\u0275cmp=I.Xpm({type:t,selectors:[["app-login-form"]],viewQuery:function(e,t){var r;(1&e&&I.Gf(L,5),2&e)&&(I.iGM(r=I.CRH())&&(t.passwordInput=r.first))},features:[I.qOj],decls:39,vars:6,consts:[[1,"flex-box","flex-align-center"],["aria-hidden","false","aria-label","User Login",1,"mr-2"],["mat-card-content","",3,"formGroup"],[1,"flex-box","flex-column",3,"keyup.enter"],[1,"mt-1"],["matPrefix","",1,"pr-1"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","usernameControl"],[4,"ngFor","ngForOf"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","passwordControl"],["passwordInput",""],[1,"flex-box","flex-justify-space-between","flex-align-center","mt-2"],["aria-label","Remember Me","formControlName","rememberControl",3,"change"],["mat-flat-button","","type","button","aria-label","Need an email password reminder?","routerLink","/account/forgot-password"],[1,"mt-4","mb-4","flex-box","flex-column"],["color","accent","label","Login","iconName","chevron_right","iconPosition","right",3,"dirty","valid","isSaving","save"],[1,"pcb-divider"],["mat-flat-button","","color","primary","type","button","aria-label","Sign in with Google button",1,"w-100",3,"click"],[1,"flex-box","flex-row","flex-align-center"],["key","google","aria-label","Google Icon"],[1,"flex-grow-1","flex-box","flex-justify-center"],[1,"pl-2"],["mat-flat-button","","type","button","routerLink","/account/register","aria-label","Sign up Button"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(I.TgZ(0,"mat-card-header"),I.TgZ(1,"mat-card-title"),I.TgZ(2,"h1",0),I.TgZ(3,"mat-icon",1),I._uU(4,"account_circle"),I.qZA(),I._uU(5,"Login"),I.qZA(),I.qZA(),I.qZA(),I.TgZ(6,"form",2),I.TgZ(7,"div",3),I.NdJ("keyup.enter",function(){return t.login()}),I.TgZ(8,"mat-form-field",4),I.TgZ(9,"mat-icon",5),I._uU(10,"email"),I.qZA(),I._UZ(11,"input",6),I.YNc(12,Q,2,1,"mat-error",7),I.qZA(),I.TgZ(13,"mat-form-field",4),I.TgZ(14,"mat-icon",5),I._uU(15,"lock"),I.qZA(),I._UZ(16,"input",8,9),I.YNc(18,G,2,1,"mat-error",7),I.qZA(),I.qZA(),I.TgZ(19,"div",10),I.TgZ(20,"mat-checkbox",11),I.NdJ("change",function(e){return t.rememberChange(e)}),I._uU(21,"Remember Me"),I.qZA(),I.TgZ(22,"button",12),I._uU(23,"Forgot password?"),I.qZA(),I.qZA(),I.TgZ(24,"div",13),I.TgZ(25,"app-save-button",14),I.NdJ("save",function(){return t.login()}),I.qZA(),I.TgZ(26,"div",15),I._uU(27,"OR"),I.qZA(),I.TgZ(28,"button",16),I.NdJ("click",function(){return t.googleSignIn()}),I.TgZ(29,"span",17),I._UZ(30,"svg-icon",18),I.TgZ(31,"span",19),I._uU(32,"Continue with Google"),I.qZA(),I.qZA(),I.qZA(),I.qZA(),I.qZA(),I._UZ(33,"mat-divider"),I.TgZ(34,"mat-card-footer",17),I.TgZ(35,"span",20),I._uU(36,"New to Provisioner's CookBook?"),I.qZA(),I.TgZ(37,"button",21),I._uU(38,"Register now!"),I.qZA(),I.qZA()),2&e&&(I.xp6(6),I.Q6J("formGroup",t.loginForm),I.xp6(6),I.Q6J("ngForOf",t.validationMessages.email),I.xp6(6),I.Q6J("ngForOf",t.validationMessages.password),I.xp6(7),I.Q6J("dirty",t.loginForm.dirty)("valid",t.loginForm.valid)("isSaving",t.isSubmitting))},directives:[c.dk,c.n5,d.Hw,l._Y,l.JL,c.dn,l.sg,f.KE,f.qo,p.Nt,l.Fj,l.JJ,l.u,s.sg,m.oG,u.lW,Z.rH,J.t,h.bk,g.d,c.rt,f.TO,s.O5],styles:['.mat-card-footer[_ngcontent-%COMP%]{height:3em;display:flex}.pcb-divider[_ngcontent-%COMP%]{overflow:hidden;text-align:center;margin-top:1em;margin-bottom:1em}.pcb-divider[_ngcontent-%COMP%]:after, .pcb-divider[_ngcontent-%COMP%]:before{content:"";display:inline-block;background-color:#eee3d5;height:1px;position:relative;vertical-align:middle;width:50%}.pcb-divider[_ngcontent-%COMP%]:before{right:.5em;margin-left:-50%}.pcb-divider[_ngcontent-%COMP%]:after{left:.5em;margin-right:-50%}']}),t}(),H=a(3720),j=a(1188),W=a(8069);function D(e,t){1&e&&(I.TgZ(0,"mat-card"),I._UZ(1,"router-outlet"),I.qZA())}function B(e,t){1&e&&I._UZ(0,"app-loading-indicator")}var $=function(){var t=function(t){i(a,t);var o=n(a);function a(t,r,i,n,s,l){var u;return e(this,a),(u=o.call(this)).authService=t,u.dialogService=r,u.loginService=i,u.router=n,u.messageService=s,u.storageService=l,u.isGettingJwt=!1,u}return r(a,[{key:"ngOnInit",value:function(){var e=this.storageService.getItem("google-user");e&&e.length>0&&"null"!==e?this.getGoogleJwtToken(e):this.listenAuthState()}},{key:"listenAuthState",value:function(){var e=this;this.authService.authState.pipe((0,x.b)(function(t){e.messageService.add({severity:T.r.Success,summary:"Authentication Successful",detail:"Google Account Authenticated, attempting to logon to app."}),t?(e.googleUserData=t,e.storageService.setItem("google-user",JSON.stringify(e.googleUserData)),JSON.parse(e.storageService.getItem("user")),e.getGoogleJwtToken(e.googleUserData)):localStorage.setItem("google-user",null),e.loggedIn=null!=t}),(0,q.K)(function(t){return e.dialogService.confirm(T.r.Alert,"Error on Google login attempt",t.message)}),(0,A.R)(this.ngUnsubscribe)).subscribe()}},{key:"getGoogleJwtToken",value:function(e){var t=this;this.isGettingJwt=!0,this.loginService.getTokenUsingGoogleToken(e).pipe((0,x.b)(function(e){t.isGettingJwt=!1,e&&"string"==typeof e?(t.dialogService.confirm(T.r.Information,"Registration required","We currently don't have an account registered to that address."),t.router.navigate(["/account/register"])):t.router.navigate(["/savoury/recipes"])}),(0,q.K)(function(e){return e.status===O.WE.Forbidden&&"OK"===e.statusText&&(t.dialogService.confirm(T.r.Alert,"403 response","Likely the cached google token has expired, try refreshing browser and logging in with your Google account again."),t.googleClear()),t.dialogService.alert("Google Login Error",e.message),t.isGettingJwt=!1,(0,S.of)()}),(0,A.R)(this.ngUnsubscribe)).subscribe()}},{key:"googleClear",value:function(){localStorage.setItem("google-user",null)}}]),a}(b.V);return t.\u0275fac=function(e){return new(e||t)(I.Y36(F.xE),I.Y36(H.x),I.Y36(Y.r),I.Y36(Z.F0),I.Y36(N.e),I.Y36(j.V))},t.\u0275cmp=I.Xpm({type:t,selectors:[["app-login"]],features:[I.qOj],decls:3,vars:2,consts:[[4,"ngIf","ngIfElse"],["showLoading",""]],template:function(e,t){if(1&e&&(I.YNc(0,D,2,0,"mat-card",0),I.YNc(1,B,1,0,"ng-template",null,1,I.W1O)),2&e){var r=I.MAs(2);I.Q6J("ngIf",!t.isGettingJwt)("ngIfElse",r)}},directives:[s.O5,c.a8,Z.lC,W.Q],styles:[""]}),t}(),K=function t(){e(this,t),this.loginProvider="Local"},z=a(8049),X=a(5435),ee=a(3190);function te(e,t){if(1&e&&(I.TgZ(0,"mat-error",19),I._UZ(1,"span",20),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function re(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,te,2,1,"mat-error",18),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(2);I.xp6(1),I.Q6J("ngIf",i.f.firstName.hasError(r.type)&&(i.f.firstName.dirty||i.f.firstName.touched))}}function ie(e,t){if(1&e&&(I.TgZ(0,"mat-error",19),I._UZ(1,"span",20),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function oe(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,ie,2,1,"mat-error",18),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(2);I.xp6(1),I.Q6J("ngIf",i.f.lastName.hasError(r.type)&&(i.f.lastName.dirty||i.f.lastName.touched))}}function ne(e,t){if(1&e&&(I.TgZ(0,"mat-error",19),I._UZ(1,"span",20),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function ae(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,ne,2,1,"mat-error",18),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(2);I.xp6(1),I.Q6J("ngIf",i.f.email.hasError(r.type)&&(i.f.email.dirty||i.f.email.touched))}}function se(e,t){if(1&e&&(I.TgZ(0,"mat-error",19),I._UZ(1,"span",20),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function le(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,se,2,1,"mat-error",18),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(3);I.xp6(1),I.Q6J("ngIf",i.f.password.hasError(r.type)&&(i.f.password.dirty||i.f.password.touched))}}function ue(e,t){if(1&e&&(I.TgZ(0,"div"),I.TgZ(1,"mat-form-field",11),I._UZ(2,"input",21),I.YNc(3,le,2,1,"mat-error",8),I.qZA(),I.qZA()),2&e){var r=I.oxw(2);I.xp6(3),I.Q6J("ngForOf",r.validationMessages.password)}}function ce(e,t){if(1&e){var r=I.EpF();I.TgZ(0,"form",4),I.NdJ("keyup.enter",function(){return I.CHM(r),I.oxw().register()}),I.TgZ(1,"div",5),I.TgZ(2,"mat-form-field",6),I._UZ(3,"input",7),I.YNc(4,re,2,1,"mat-error",8),I.qZA(),I.TgZ(5,"mat-form-field",9),I._UZ(6,"input",10),I.YNc(7,oe,2,1,"mat-error",8),I.qZA(),I.qZA(),I.TgZ(8,"div"),I.TgZ(9,"mat-form-field",11),I._UZ(10,"input",12),I.YNc(11,ae,2,1,"mat-error",8),I.qZA(),I.qZA(),I.YNc(12,ue,4,1,"div",3),I.TgZ(13,"div",13),I.TgZ(14,"mat-checkbox",14),I.NdJ("change",function(){return I.CHM(r),I.oxw().form.markAsTouched()}),I._uU(15,"Accept Terms and conditions (when we get some)"),I.qZA(),I.qZA(),I.TgZ(16,"div",15),I.TgZ(17,"button",16),I._uU(18,"Cancel"),I.qZA(),I.TgZ(19,"app-save-button",17),I.NdJ("save",function(){return I.CHM(r),I.oxw().register()}),I.qZA(),I.qZA(),I.qZA()}if(2&e){var i=I.oxw();I.Q6J("formGroup",i.form),I.xp6(4),I.Q6J("ngForOf",i.validationMessages.username),I.xp6(3),I.Q6J("ngForOf",i.validationMessages.username),I.xp6(4),I.Q6J("ngForOf",i.validationMessages.email),I.xp6(1),I.Q6J("ngIf","GOOGLE"!==i.newUser.loginProvider),I.xp6(7),I.Q6J("dirty",i.form.dirty)("valid",i.form.valid)("isSaving",i.isSubmitting)}}function me(e,t){1&e&&(I.TgZ(0,"div"),I.TgZ(1,"p"),I.TgZ(2,"strong"),I._uU(3,"Note"),I.qZA(),I._uU(4," - Email is currently trapped in mailtrap.io"),I.qZA(),I.TgZ(5,"p"),I._uU(6,"Please look in your email account (or double check your spam) for a registration email."),I.qZA(),I.qZA())}var ge=function(){var t=function(t){i(a,t);var o=n(a);function a(t,r,i,n,s,l){var u;return e(this,a),(u=o.call(this)).formBuilder=t,u.accountService=r,u.loginService=i,u.messageService=n,u.storageService=s,u.router=l,u.newUser=new K,u.validationMessages=k.rm,u.displayAwaitingVerificationEmail=!1,u.isSubmitting=!1,u}return r(a,[{key:"ngOnInit",value:function(){var e=this.storageService.getItem("google-user");if(e){var t=JSON.parse(e);this.newUser=t&&null!==t?{firstName:t.firstName,lastName:t.lastName,email:t.email,loginProvider:t.provider,loginProviderId:t.id,photoUrl:t.photoUrl,verified:new Date}:new K}this.createForm(this.newUser)}},{key:"f",get:function(){return this.form.controls}},{key:"createForm",value:function(e){this.form=this.formBuilder.group({firstName:[e.firstName,l.kI.required],lastName:[e.lastName,l.kI.required],email:[e.email,[l.kI.required,l.kI.email]],acceptTerms:[!1,l.kI.requiredTrue]}),"GOOGLE"!==this.newUser.loginProvider?this.form.addControl("password",new l.NI("",[l.kI.required,l.kI.minLength(6)])):this.f.email.disable()}},{key:"register",value:function(){var e=this;if(!this.form.invalid){this.isSubmitting=!0;var t=this.form.getRawValue();this.newUser.firstName=t.firstName,this.newUser.lastName=t.lastName,this.newUser.email=t.email,"GOOGLE"!==this.newUser.loginProvider&&(this.newUser.password=t.password),console.log("register the form",this.form.getRawValue(),this.newUser),this.accountService.register(this.newUser).pipe((0,z.P)(),(0,X.h)(function(t){return e.isSubmitting=!1,console.log("isSubmitting",e.isSubmitting),"Email address is already registered"===t.message?(e.messageService.add({severity:T.r.Warning,summary:"Email Conflict",detail:"It seems this email account is already registered with us.",life:12e3}),e.f.email.setErrors({emailConflict:!0}),!1):"GOOGLE"===e.newUser.loginProvider||(e.displayAwaitingVerificationEmail=!0,!1)}),(0,ee.w)(function(){return e.loginService.login(e.newUser.email,null,!0)}),(0,X.h)(function(e){return"Successful login"===e.message}),(0,x.b)(function(){return e.router.navigate(["/savoury/browse"])}),(0,q.K)(function(t){return e.isSubmitting=!1,e.messageService.add({severity:T.r.Error,summary:"Something terrible happened",detail:t.message,life:12e3}),(0,S.of)()}),(0,A.R)(this.ngUnsubscribe)).subscribe(function(){e.isSubmitting=!1,console.log("subscription finished",e.isSubmitting)})}}}]),a}(b.V);return t.\u0275fac=function(e){return new(e||t)(I.Y36(l.qu),I.Y36(w.B),I.Y36(Y.r),I.Y36(N.e),I.Y36(j.V),I.Y36(Z.F0))},t.\u0275cmp=I.Xpm({type:t,selectors:[["app-register-form"]],features:[I.qOj],decls:8,vars:2,consts:[[1,"flex-box","flex-align-center"],["aria-hidden","false","aria-label","Register New User",1,"mr-2"],["mat-card-content","",3,"formGroup","keyup.enter",4,"ngIf"],[4,"ngIf"],["mat-card-content","",3,"formGroup","keyup.enter"],[1,"flex-box","flex-row","mt-2"],[1,"mr-2","w-45"],["matInput","","type","text","placeholder","First Name *","Title","First Name","formControlName","firstName"],[4,"ngFor","ngForOf"],[1,"w-50"],["matInput","","type","text","placeholder","Last Name *","Title","Last Name","formControlName","lastName"],[1,"w-100"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","email"],[1,"mt-2","mb-4"],["aria-label","Accept Terms and conditions","formControlName","acceptTerms",3,"change"],[1,"flex-box","flex-justify-end"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login",1,"mr-1"],["color","accent","iconName","chevron_right","iconPosition","right","label","Register",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","password"]],template:function(e,t){1&e&&(I.TgZ(0,"mat-card-header"),I.TgZ(1,"mat-card-title"),I.TgZ(2,"h1",0),I.TgZ(3,"mat-icon",1),I._uU(4,"person_add"),I.qZA(),I._uU(5,"Register"),I.qZA(),I.qZA(),I.qZA(),I.YNc(6,ce,20,8,"form",2),I.YNc(7,me,7,0,"div",3)),2&e&&(I.xp6(6),I.Q6J("ngIf",!!t.form&&!t.displayAwaitingVerificationEmail),I.xp6(1),I.Q6J("ngIf",t.displayAwaitingVerificationEmail))},directives:[c.dk,c.n5,d.Hw,s.O5,l._Y,l.JL,c.dn,l.sg,f.KE,p.Nt,l.Fj,l.JJ,l.u,s.sg,m.oG,u.lW,Z.rH,J.t,f.TO],styles:[""]}),t}(),fe=(function(e){e[e.Verifying=0]="Verifying",e[e.Failed=1]="Failed"}(fe||(fe={})),fe),de=(function(e){e[e.Validating=0]="Validating",e[e.Valid=1]="Valid",e[e.Invalid=2]="Invalid"}(de||(de={})),de),pe=a(8002);function ve(e,t){1&e&&(I.TgZ(0,"div"),I._uU(1," Validating token... "),I.qZA())}function he(e,t){1&e&&(I.TgZ(0,"div",7),I.TgZ(1,"span"),I._uU(2,"Token validation failed, you can get a new reset token at "),I.qZA(),I.TgZ(3,"button",8),I._uU(4,"Forgot Password"),I.qZA(),I.qZA())}function we(e,t){if(1&e&&(I.TgZ(0,"mat-error",18),I._UZ(1,"span",19),I.qZA()),2&e){var r=I.oxw().$implicit;I.xp6(1),I.Q6J("innerHTML",r.message,I.oJD)}}function ye(e,t){if(1&e&&(I.TgZ(0,"mat-error"),I.YNc(1,we,2,1,"mat-error",17),I.qZA()),2&e){var r=t.$implicit,i=I.oxw(2);I.xp6(1),I.Q6J("ngIf",i.fPassword.hasError(r.type)&&(i.fPassword.dirty||i.fPassword.touched))}}function Ze(e,t){if(1&e){var r=I.EpF();I.TgZ(0,"form",9),I.TgZ(1,"div",7),I.TgZ(2,"mat-form-field",10),I.TgZ(3,"mat-icon",11),I._uU(4,"lock"),I.qZA(),I.TgZ(5,"input",12),I.NdJ("keyup.enter",function(){return I.CHM(r),I.oxw().resetPassword()}),I.qZA(),I.YNc(6,ye,2,1,"mat-error",13),I.qZA(),I.TgZ(7,"div",14),I.TgZ(8,"button",15),I._uU(9,"Cancel"),I.qZA(),I.TgZ(10,"app-save-button",16),I.NdJ("save",function(){return I.CHM(r),I.oxw().resetPassword()}),I.qZA(),I.qZA(),I.qZA(),I.qZA()}if(2&e){var i=I.oxw();I.Q6J("formGroup",i.form),I.xp6(6),I.Q6J("ngForOf",i.validationMessages.password),I.xp6(4),I.Q6J("dirty",i.form.dirty)("valid",i.form.valid)("isSaving",i.isSubmitting)}}function be(e,t){1&e&&(I.TgZ(0,"div"),I._uU(1," Oops you need to confirm a token to reset a password this way. "),I.qZA())}var Te=function(){var t=function(t){i(a,t);var o=n(a);function a(t,r,i,n,s){var l;return e(this,a),(l=o.call(this)).fb=t,l.route=r,l.router=i,l.accountService=n,l.messageService=s,l.validationMessages=k.rm,l.TokenStatus=de,l.currentTokenStatus=(0,S.of)(de.Validating),l.isSubmitting=!1,l.isLoading=!1,l}return r(a,[{key:"ngOnInit",value:function(){this.form=this.createForm(),this.token=this.route.snapshot.queryParams.token,this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),this.currentTokenStatus=this.resolveTokenStatus()}},{key:"resolveTokenStatus",value:function(){var e=this;return void 0===this.token?(0,S.of)(de.Invalid):this.accountService.validateResetToken(this.token).pipe((0,z.P)(),(0,pe.U)(function(t){return e.validateResetTokenResult(t)}),(0,q.K)(function(t){return e.catchErrorMessage("Reset Token Error","The server did not receive a correctly formatted token.")}))}},{key:"validateResetTokenResult",value:function(e){return"Invalid Token"===e.message?(this.messageService.add({severity:T.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),de.Invalid):de.Valid}},{key:"fPassword",get:function(){return this.form.get("password")}},{key:"createForm",value:function(){return this.fb.group({password:["",[l.kI.required,l.kI.minLength(6),l.kI.maxLength(20)]]})}},{key:"resetPassword",value:function(){var e=this;this.form.invalid||(this.isSubmitting=!0,this.accountService.resetPassword(this.token,this.fPassword.value,this.fPassword.value).pipe((0,z.P)(),(0,x.b)(function(t){return e.resetPasswordResult(t)}),(0,q.K)(function(t){return e.catchErrorMessage("Password reset Error",t.message)})).subscribe())}},{key:"resetPasswordResult",value:function(e){this.isSubmitting=!1,"Success"===e.message?(this.messageService.add({severity:T.r.Success,summary:"Password reset",detail:"Password reset you can now login with your new password.",life:8e3}),this.router.navigate(["/account/login"])):this.messageService.add({severity:T.r.Warning,summary:"Password reset failed",detail:e.message,life:8e3})}},{key:"catchErrorMessage",value:function(e,t){return this.messageService.add({severity:T.r.Error,summary:e,detail:t,life:8e3}),(0,S.of)(de.Invalid)}}]),a}(b.V);return t.\u0275fac=function(e){return new(e||t)(I.Y36(l.qu),I.Y36(Z.gz),I.Y36(Z.F0),I.Y36(w.B),I.Y36(N.e))},t.\u0275cmp=I.Xpm({type:t,selectors:[["app-reset-password-form"]],features:[I.qOj],decls:12,vars:6,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],["mat-card-content","",3,"ngSwitch"],[4,"ngSwitchCase"],["class","flex-box flex-column",4,"ngSwitchCase"],[3,"formGroup",4,"ngSwitchCase"],[4,"ngSwitchDefault"],[1,"flex-box","flex-column"],["mat-flat-button","","color","accent","aria-label","Navigate to forgot password","type","button","routerLink","/account/forgot-password",1,"mt-2","mb-2"],[3,"formGroup"],[1,"mt-1"],["matPrefix","",1,"pr-1"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","password",3,"keyup.enter"],[4,"ngFor","ngForOf"],[1,"flex-box","flex-justify-end","mt-2"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login"],["label","Reset Password",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(I.TgZ(0,"mat-card-header"),I.TgZ(1,"mat-card-title"),I.TgZ(2,"h1",0),I.TgZ(3,"mat-icon",1),I._uU(4,"security icon"),I.qZA(),I._uU(5,"Reset Password "),I.qZA(),I.qZA(),I.qZA(),I.TgZ(6,"div",2),I.ALo(7,"async"),I.YNc(8,ve,2,0,"div",3),I.YNc(9,he,5,0,"div",4),I.YNc(10,Ze,11,5,"form",5),I.YNc(11,be,2,0,"div",6),I.qZA()),2&e&&(I.xp6(6),I.Q6J("ngSwitch",I.lcZ(7,4,t.currentTokenStatus)),I.xp6(2),I.Q6J("ngSwitchCase",t.TokenStatus.Validating),I.xp6(1),I.Q6J("ngSwitchCase",t.TokenStatus.Invalid),I.xp6(1),I.Q6J("ngSwitchCase",t.TokenStatus.Valid))},directives:[c.dk,c.n5,d.Hw,c.dn,s.RF,s.n9,s.ED,u.lW,Z.rH,l._Y,l.JL,l.sg,f.KE,f.qo,p.Nt,l.Fj,l.JJ,l.u,s.sg,J.t,f.TO,s.O5],pipes:[s.Ov],styles:["h2[_ngcontent-%COMP%]{display:flex}"]}),t}();function ke(e,t){1&e&&(I.TgZ(0,"div"),I._uU(1," Verifying... "),I.qZA())}function Se(e,t){1&e&&(I.TgZ(0,"p"),I._uU(1,"Unfortunately, the verify email token failed, you can get a new token at "),I.qZA(),I.TgZ(2,"button",5),I._uU(3,"Forgot Password"),I.qZA())}var xe,qe,Ae=[{path:"",component:$,children:[{path:"login",component:V},{path:"register",component:ge},{path:"verify-email",component:(xe=function(){function t(r,i,o,n){e(this,t),this.route=r,this.router=i,this.accountService=o,this.messageService=n,this.EmailStatus=fe,this.emailStatus=fe.Verifying}return r(t,[{key:"ngOnInit",value:function(){var e=this,t=this.route.snapshot.queryParams.token;this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),void 0===t?(this.emailStatus=fe.Failed,this.messageService.add({severity:T.r.Error,summary:"Invalid Token",detail:"Please obtain a new verify token.",life:8e3})):this.accountService.verifyEmail(t).pipe((0,z.P)(),(0,x.b)(function(t){"Verification Failed"===t.message?(e.messageService.add({severity:T.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),e.emailStatus=fe.Failed):(e.messageService.add({severity:T.r.Success,summary:"Email Verified",detail:"Well done, email verified, please login to start making amazing recipes.",life:8e3}),e.router.navigate(["/account/login"]))}),(0,q.K)(function(t){return e.messageService.add({severity:T.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),e.emailStatus=fe.Failed,(0,S.of)()})).subscribe()}}]),t}(),xe.\u0275fac=function(e){return new(e||xe)(I.Y36(Z.gz),I.Y36(Z.F0),I.Y36(w.B),I.Y36(N.e))},xe.\u0275cmp=I.Xpm({type:xe,selectors:[["app-verify-email"]],decls:10,vars:2,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],["mat-card-content",""],[4,"ngIf","ngIfElse"],["showFailed",""],["mat-flat-button","","color","accent","aria-label","Navigate to register","type","button","routerLink","/account/register",1,"mt-2","mb-2"]],template:function(e,t){if(1&e&&(I.TgZ(0,"mat-card-header"),I.TgZ(1,"mat-card-title"),I.TgZ(2,"h1",0),I.TgZ(3,"mat-icon",1),I._uU(4,"security icon"),I.qZA(),I._uU(5,"Reset Password"),I.qZA(),I.qZA(),I.qZA(),I.TgZ(6,"div",2),I.YNc(7,ke,2,0,"div",3),I.YNc(8,Se,4,0,"ng-template",null,4,I.W1O),I.qZA()),2&e){var r=I.MAs(9);I.xp6(7),I.Q6J("ngIf",t.emailStatus===t.EmailStatus.Verifying)("ngIfElse",r)}},directives:[c.dk,c.n5,d.Hw,c.dn,s.O5,u.lW,Z.rH],styles:[""]}),xe)},{path:"forgot-password",component:C},{path:"reset-password",component:Te}]}],Ie=function(){var t=function t(){e(this,t)};return t.\u0275fac=function(e){return new(e||t)},t.\u0275mod=I.oAB({type:t}),t.\u0275inj=I.cJS({imports:[[Z.Bz.forChild(Ae)],Z.Bz]}),t}(),Ne=((qe=function t(){e(this,t)}).\u0275fac=function(e){return new(e||qe)},qe.\u0275mod=I.oAB({type:qe}),qe.\u0275inj=I.cJS({providers:[w.B],imports:[[s.ez,l.UX,Ie,d.Ps,c.QW,f.lN,g.t,p.c,u.ot,m.p9,v.v,h.Kz.forRoot({icons:y.Z})]]}),qe)}}])}();