(self.webpackChunkcook_book=self.webpackChunkcook_book||[]).push([[167],{7167:function(e,t,r){"use strict";r.r(t),r.d(t,{AccountModule:function(){return Te}});var i=r(8583),o=r(3679),s=r(1095),a=r(3738),n=r(7539),l=r(1769),c=r(8295),m=r(6627),g=r(9983),u=r(6398),d=r(5512),f=r(9876),p=r(8047),h=r(3423),v=r(6025),w=r(1209),Z=r(7851),b=r(5917),y=r(3342),T=r(5304),S=r(6782),x=r(7716),k=r(2684),q=r(448);function A(e,t){if(1&e&&(x.TgZ(0,"mat-error",14),x._UZ(1,"span",15),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function I(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,A,2,1,"mat-error",13),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(2);x.xp6(1),x.Q6J("ngIf",r.f.email.hasError(e.type)&&(r.f.email.dirty||r.f.email.touched))}}function N(e,t){if(1&e){const e=x.EpF();x.TgZ(0,"form",5),x.TgZ(1,"mat-form-field",6),x.TgZ(2,"mat-icon",7),x._uU(3,"email"),x.qZA(),x.TgZ(4,"input",8),x.NdJ("keyup.enter",function(){return x.CHM(e),x.oxw().forgotPassword()}),x.qZA(),x.YNc(5,I,2,1,"mat-error",9),x.qZA(),x.TgZ(6,"div",10),x.TgZ(7,"button",11),x._uU(8,"Cancel"),x.qZA(),x.TgZ(9,"app-save-button",12),x.NdJ("save",function(){return x.CHM(e),x.oxw().forgotPassword()}),x.qZA(),x.qZA(),x.qZA()}if(2&e){const e=x.oxw();x.Q6J("formGroup",e.form),x.xp6(5),x.Q6J("ngForOf",e.validationMessages.email),x.xp6(4),x.Q6J("dirty",e.form.dirty)("valid",e.form.valid)("isSaving",e.isSubmitting)}}function J(e,t){1&e&&(x.TgZ(0,"div"),x._uU(1," Please check your email or your spam folder for a password reset link. "),x.qZA())}let U=(()=>{class e extends v.V{constructor(e,t,r,i,o,s){super(),this.fb=e,this.route=t,this.router=r,this.accountService=i,this.messageService=o,this.cdr=s,this.validationMessages=Z.rm,this.showLookInYourEmail=!1,this.isSubmitting=!1,this.form=this.createForm()}ngOnInit(){const e=this.route.snapshot.queryParams.email;void 0!==e&&(this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),this.f.email.setValue(e),this.f.email.markAsTouched(),this.f.email.markAsDirty())}get f(){return this.form.controls}createForm(){return this.fb.group({email:["",[o.kI.required,o.kI.minLength(2),o.kI.maxLength(120),o.kI.email]]})}forgotPassword(){this.form.invalid||(this.isSubmitting=!0,this.accountService.forgotPassword(this.form.getRawValue().email).pipe((0,y.b)(e=>{"Please login through your Google Account"===e.message?(this.messageService.add({severity:w.r.Warning,summary:"No Password to reset",detail:e.message,life:8e3}),this.f.email.setErrors({googleLogin:!0}),this.cdr.markForCheck(),this.form.updateValueAndValidity()):this.showLookInYourEmail=!0,this.isSubmitting=!1,console.log("email send result",e,this.isSubmitting)}),(0,T.K)(e=>(400===e.status&&this.messageService.add({severity:w.r.Error,summary:"Email Error",detail:"The server did not receive a correctly formatted email address.",life:8e3}),404===e.status&&(this.messageService.add({severity:w.r.Warning,summary:"No Email account found",detail:e.error.message,life:8e3}),this.f.email.setErrors({registrationRequired:!0},{emitEvent:!0}),this.cdr.markForCheck()),this.isSubmitting=!1,(0,b.of)())),(0,S.R)(this.ngUnsubscribe)).subscribe(e=>{console.log("we got to the subscribe conclusion?",e,this.isSubmitting),this.isSubmitting=!1}))}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(o.qu),x.Y36(h.gz),x.Y36(h.F0),x.Y36(f.B),x.Y36(k.e),x.Y36(x.sBO))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-forgot-password"]],features:[x.qOj],decls:9,vars:2,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],[3,"ngSwitch"],["mat-card-content","",3,"formGroup",4,"ngSwitchDefault"],[4,"ngSwitchCase"],["mat-card-content","",3,"formGroup"],[1,"mt-1","w-100"],["matPrefix","",1,"pr-1"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","email",3,"keyup.enter"],[4,"ngFor","ngForOf"],[1,"flex-box","flex-justify-end","mt-4"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login",1,"mr-1"],["label","Submit",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(x.TgZ(0,"mat-card-header"),x.TgZ(1,"mat-card-title"),x.TgZ(2,"h2",0),x.TgZ(3,"mat-icon",1),x._uU(4,"memory"),x.qZA(),x._uU(5,"Forgot Password"),x.qZA(),x.qZA(),x.qZA(),x.TgZ(6,"div",2),x.YNc(7,N,10,5,"form",3),x.YNc(8,J,2,0,"div",4),x.qZA()),2&e&&(x.xp6(6),x.Q6J("ngSwitch",t.showLookInYourEmail),x.xp6(2),x.Q6J("ngSwitchCase",!0))},directives:[a.dk,a.n5,m.Hw,i.RF,i.ED,i.n9,o._Y,o.JL,a.dn,o.sg,c.KE,c.qo,g.Nt,o.Fj,o.JJ,o.u,i.sg,s.lW,h.rH,q.t,c.TO,i.O5],styles:[""]}),e})();var E=r(8948),C=r(5798),P=r(7870),Y=r(9618);const _=["passwordInput"];function F(e,t){if(1&e&&(x.TgZ(0,"mat-error",23),x._UZ(1,"span",24),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function O(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,F,2,1,"mat-error",22),x.qZA()),2&e){const e=t.$implicit,r=x.oxw();x.xp6(1),x.Q6J("ngIf",r.f.usernameControl.hasError(e.type)&&(r.f.usernameControl.dirty||r.f.usernameControl.touched))}}function L(e,t){if(1&e&&(x.TgZ(0,"mat-error",23),x._UZ(1,"span",24),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function M(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,L,2,1,"mat-error",22),x.qZA()),2&e){const e=t.$implicit,r=x.oxw();x.xp6(1),x.Q6J("ngIf",r.f.passwordControl.hasError(e.type)&&(r.f.passwordControl.dirty||r.f.passwordControl.touched))}}let Q=(()=>{class e extends v.V{constructor(e,t,r,i,o,s,a){super(),this.fb=e,this.authService=t,this.loginService=r,this.router=i,this.messageService=o,this.userProfileService=s,this.cdr=a,this.validationMessages=Z.rm,this.isSubmitting=!1}ngOnInit(){this.createForm()}get f(){return this.loginForm.controls}createForm(){this.loginForm=this.fb.group({usernameControl:["",[o.kI.required,o.kI.minLength(2),o.kI.maxLength(120),o.kI.email]],passwordControl:["",[o.kI.required,o.kI.minLength(2)]],rememberControl:!1})}rememberChange(e){console.log("Im not going to remember you, terrible with names",e)}login(){if(this.isSubmitting=!0,this.loginForm.invalid)return null;this.passwordInput.nativeElement.blur();const e=this.loginForm.getRawValue();this.loginService.login(e.usernameControl,e.passwordControl,!1).pipe((0,y.b)(t=>{if(this.isSubmitting=!1,"Successful login"===t.message)this.router.navigate(["/savoury/recipes/browse"]);else if(t.message.indexOf("Lockout")>-1){const r=Number(t.message.substring(9));r&&r>4&&(console.log("here we locking routing,",r,`/account/forgot-password?email=${e.usernameControl}`),this.router.navigate(["/account/forgot-password"],{queryParams:{email:e.usernameControl}}),this.messageService.add({severity:w.r.Warning,summary:"Lockout",detail:"Please wait 20 minutes to try again or reset password.",life:12e3}))}else this.messageService.add({severity:w.r.Warning,summary:"Login problem",detail:t.message,life:12e3})}),(0,T.K)(e=>(this.isSubmitting=!1,e.status===E.WE.BadRequest?(this.f.passwordControl.setErrors({wrongPassword:!0},{emitEvent:!0}),this.cdr.markForCheck(),this.messageService.add({severity:w.r.Warning,summary:"Password error",detail:'You can reset your password through "Forgot Password"',life:12e3})):this.messageService.add(e.status===E.WE.Forbidden?{severity:w.r.Warning,summary:"Account Issue",detail:'Your Account has been deactivated, please email support for more info."',life:12e3}:{severity:w.r.Error,summary:"Major Error",detail:e.message,life:12e3}),(0,b.of)())),(0,S.R)(this.ngUnsubscribe)).subscribe()}googleSignIn(){this.authService.signIn(P.tV.PROVIDER_ID)}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(o.qu),x.Y36(P.xE),x.Y36(C.r),x.Y36(h.F0),x.Y36(k.e),x.Y36(Y.i),x.Y36(x.sBO))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-login-form"]],viewQuery:function(e,t){if(1&e&&x.Gf(_,5),2&e){let e;x.iGM(e=x.CRH())&&(t.passwordInput=e.first)}},features:[x.qOj],decls:39,vars:6,consts:[[1,"flex-box","flex-align-center"],["aria-hidden","false","aria-label","User Login",1,"mr-2"],["mat-card-content","",3,"formGroup"],[1,"flex-box","flex-column",3,"keyup.enter"],[1,"mt-1"],["matPrefix","",1,"pr-1"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","usernameControl"],[4,"ngFor","ngForOf"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","passwordControl"],["passwordInput",""],[1,"flex-box","flex-justify-space-between","flex-align-center","mt-2"],["aria-label","Remember Me","formControlName","rememberControl",3,"change"],["mat-flat-button","","type","button","aria-label","Need an email password reminder?","routerLink","/account/forgot-password"],[1,"mt-4","mb-4","flex-box","flex-column"],["color","accent","label","Login","iconName","chevron_right","iconPosition","right",3,"dirty","valid","isSaving","save"],[1,"pcb-divider"],["mat-flat-button","","color","primary","type","button","aria-label","Sign in with Google button",1,"w-100",3,"click"],[1,"flex-box","flex-row","flex-align-center"],["key","google","aria-label","Google Icon"],[1,"flex-grow-1","flex-box","flex-justify-center"],[1,"pl-2"],["mat-flat-button","","type","button","routerLink","/account/register","aria-label","Sign up Button"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(x.TgZ(0,"mat-card-header"),x.TgZ(1,"mat-card-title"),x.TgZ(2,"h1",0),x.TgZ(3,"mat-icon",1),x._uU(4,"account_circle"),x.qZA(),x._uU(5,"Login"),x.qZA(),x.qZA(),x.qZA(),x.TgZ(6,"form",2),x.TgZ(7,"div",3),x.NdJ("keyup.enter",function(){return t.login()}),x.TgZ(8,"mat-form-field",4),x.TgZ(9,"mat-icon",5),x._uU(10,"email"),x.qZA(),x._UZ(11,"input",6),x.YNc(12,O,2,1,"mat-error",7),x.qZA(),x.TgZ(13,"mat-form-field",4),x.TgZ(14,"mat-icon",5),x._uU(15,"lock"),x.qZA(),x._UZ(16,"input",8,9),x.YNc(18,M,2,1,"mat-error",7),x.qZA(),x.qZA(),x.TgZ(19,"div",10),x.TgZ(20,"mat-checkbox",11),x.NdJ("change",function(e){return t.rememberChange(e)}),x._uU(21,"Remember Me"),x.qZA(),x.TgZ(22,"button",12),x._uU(23,"Forgot password?"),x.qZA(),x.qZA(),x.TgZ(24,"div",13),x.TgZ(25,"app-save-button",14),x.NdJ("save",function(){return t.login()}),x.qZA(),x.TgZ(26,"div",15),x._uU(27,"OR"),x.qZA(),x.TgZ(28,"button",16),x.NdJ("click",function(){return t.googleSignIn()}),x.TgZ(29,"span",17),x._UZ(30,"svg-icon",18),x.TgZ(31,"span",19),x._uU(32,"Continue with Google"),x.qZA(),x.qZA(),x.qZA(),x.qZA(),x.qZA(),x._UZ(33,"mat-divider"),x.TgZ(34,"mat-card-footer",17),x.TgZ(35,"span",20),x._uU(36,"New to Provisioner's CookBook?"),x.qZA(),x.TgZ(37,"button",21),x._uU(38,"Register now!"),x.qZA(),x.qZA()),2&e&&(x.xp6(6),x.Q6J("formGroup",t.loginForm),x.xp6(6),x.Q6J("ngForOf",t.validationMessages.email),x.xp6(6),x.Q6J("ngForOf",t.validationMessages.password),x.xp6(7),x.Q6J("dirty",t.loginForm.dirty)("valid",t.loginForm.valid)("isSaving",t.isSubmitting))},directives:[a.dk,a.n5,m.Hw,o._Y,o.JL,a.dn,o.sg,c.KE,c.qo,g.Nt,o.Fj,o.JJ,o.u,i.sg,n.oG,s.lW,h.rH,q.t,d.bk,l.d,a.rt,c.TO,i.O5],styles:['.mat-card-footer[_ngcontent-%COMP%]{height:3em;display:flex}.pcb-divider[_ngcontent-%COMP%]{overflow:hidden;text-align:center;margin-top:1em;margin-bottom:1em}.pcb-divider[_ngcontent-%COMP%]:after, .pcb-divider[_ngcontent-%COMP%]:before{content:"";display:inline-block;background-color:#eee3d5;height:1px;position:relative;vertical-align:middle;width:50%}.pcb-divider[_ngcontent-%COMP%]:before{right:.5em;margin-left:-50%}.pcb-divider[_ngcontent-%COMP%]:after{left:.5em;margin-right:-50%}']}),e})();var G=r(3720),V=r(8069);function H(e,t){1&e&&(x.TgZ(0,"mat-card"),x._UZ(1,"router-outlet"),x.qZA())}function R(e,t){1&e&&x._UZ(0,"app-loading-indicator")}let W=(()=>{class e extends v.V{constructor(e,t,r,i,o){super(),this.authService=e,this.dialogService=t,this.loginService=r,this.router=i,this.messageService=o,this.isGettingJwt=!1}ngOnInit(){localStorage.getItem("google-user")&&this.getGoogleJwtToken(),this.listenAuthState()}listenAuthState(){this.authService.authState.pipe((0,y.b)(e=>{this.messageService.add({severity:w.r.Success,summary:"Authentication Successful",detail:"Google Account Authenticated, attempting to logon to app."}),e?(this.googleUserData=e,localStorage.setItem("google-user",JSON.stringify(this.googleUserData)),JSON.parse(localStorage.getItem("user")),this.getGoogleJwtToken()):localStorage.setItem("google-user",null),this.loggedIn=null!=e}),(0,T.K)(e=>this.dialogService.alert("Error on Google login attempt",e)),(0,S.R)(this.ngUnsubscribe)).subscribe()}getGoogleJwtToken(){this.isGettingJwt=!0,this.loginService.getTokenUsingGoogleToken(JSON.parse(localStorage.getItem("google-user"))).pipe((0,y.b)(e=>{e&&"string"==typeof e?(this.messageService.add({severity:w.r.Information,summary:"Registration required",detail:"We currently don't have an account registered to that address."}),this.router.navigate(["/account/register"])):this.router.navigate(["/savoury/recipes"])}),(0,T.K)(e=>(e.status===E.WE.Forbidden&&"OK"===e.statusText&&(this.dialogService.alert("403 response","Likely the cached google token has expired, try refreshing browser and logging in with your Google account again."),this.googleClear()),this.dialogService.alert("Login Error",e.message),this.isGettingJwt=!1,(0,b.of)())),(0,S.R)(this.ngUnsubscribe)).subscribe()}googleClear(){localStorage.setItem("google-user",null)}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(P.xE),x.Y36(G.x),x.Y36(C.r),x.Y36(h.F0),x.Y36(k.e))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-login"]],features:[x.qOj],decls:3,vars:2,consts:[[4,"ngIf","ngIfElse"],["showLoading",""]],template:function(e,t){if(1&e&&(x.YNc(0,H,2,0,"mat-card",0),x.YNc(1,R,1,0,"ng-template",null,1,x.W1O)),2&e){const e=x.MAs(2);x.Q6J("ngIf",!t.isGettingJwt)("ngIfElse",e)}},directives:[i.O5,a.a8,h.lC,V.Q],styles:[""]}),e})();class D{constructor(){this.loginProvider="Local"}}var j=r(8049),$=r(5435),B=r(3190);function K(e,t){if(1&e&&(x.TgZ(0,"mat-error",19),x._UZ(1,"span",20),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function z(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,K,2,1,"mat-error",18),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(2);x.xp6(1),x.Q6J("ngIf",r.f.firstName.hasError(e.type)&&(r.f.firstName.dirty||r.f.firstName.touched))}}function X(e,t){if(1&e&&(x.TgZ(0,"mat-error",19),x._UZ(1,"span",20),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function ee(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,X,2,1,"mat-error",18),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(2);x.xp6(1),x.Q6J("ngIf",r.f.lastName.hasError(e.type)&&(r.f.lastName.dirty||r.f.lastName.touched))}}function te(e,t){if(1&e&&(x.TgZ(0,"mat-error",19),x._UZ(1,"span",20),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function re(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,te,2,1,"mat-error",18),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(2);x.xp6(1),x.Q6J("ngIf",r.f.email.hasError(e.type)&&(r.f.email.dirty||r.f.email.touched))}}function ie(e,t){if(1&e&&(x.TgZ(0,"mat-error",19),x._UZ(1,"span",20),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function oe(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,ie,2,1,"mat-error",18),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(3);x.xp6(1),x.Q6J("ngIf",r.f.password.hasError(e.type)&&(r.f.password.dirty||r.f.password.touched))}}function se(e,t){if(1&e&&(x.TgZ(0,"div"),x.TgZ(1,"mat-form-field",11),x._UZ(2,"input",21),x.YNc(3,oe,2,1,"mat-error",8),x.qZA(),x.qZA()),2&e){const e=x.oxw(2);x.xp6(3),x.Q6J("ngForOf",e.validationMessages.password)}}function ae(e,t){if(1&e){const e=x.EpF();x.TgZ(0,"form",4),x.NdJ("keyup.enter",function(){return x.CHM(e),x.oxw().register()}),x.TgZ(1,"div",5),x.TgZ(2,"mat-form-field",6),x._UZ(3,"input",7),x.YNc(4,z,2,1,"mat-error",8),x.qZA(),x.TgZ(5,"mat-form-field",9),x._UZ(6,"input",10),x.YNc(7,ee,2,1,"mat-error",8),x.qZA(),x.qZA(),x.TgZ(8,"div"),x.TgZ(9,"mat-form-field",11),x._UZ(10,"input",12),x.YNc(11,re,2,1,"mat-error",8),x.qZA(),x.qZA(),x.YNc(12,se,4,1,"div",3),x.TgZ(13,"div",13),x.TgZ(14,"mat-checkbox",14),x.NdJ("change",function(){return x.CHM(e),x.oxw().form.markAsTouched()}),x._uU(15,"Accept Terms and conditions (when we get some)"),x.qZA(),x.qZA(),x.TgZ(16,"div",15),x.TgZ(17,"button",16),x._uU(18,"Cancel"),x.qZA(),x.TgZ(19,"app-save-button",17),x.NdJ("save",function(){return x.CHM(e),x.oxw().register()}),x.qZA(),x.qZA(),x.qZA()}if(2&e){const e=x.oxw();x.Q6J("formGroup",e.form),x.xp6(4),x.Q6J("ngForOf",e.validationMessages.username),x.xp6(3),x.Q6J("ngForOf",e.validationMessages.username),x.xp6(4),x.Q6J("ngForOf",e.validationMessages.email),x.xp6(1),x.Q6J("ngIf","GOOGLE"!==e.newUser.loginProvider),x.xp6(7),x.Q6J("dirty",e.form.dirty)("valid",e.form.valid)("isSaving",e.isSubmitting)}}function ne(e,t){1&e&&(x.TgZ(0,"div"),x._uU(1," Please look in your email account (or double check your spam) for a registration email.\n"),x.qZA())}let le=(()=>{class e extends v.V{constructor(e,t,r,i,o){super(),this.formBuilder=e,this.accountService=t,this.loginService=r,this.messageService=i,this.router=o,this.newUser=new D,this.validationMessages=Z.rm,this.displayAwaitingVerificationEmail=!1,this.isSubmitting=!1}ngOnInit(){if(localStorage.getItem("google-user")){const e=JSON.parse(localStorage.getItem("google-user"));this.newUser=e&&null!==e?{firstName:e.firstName,lastName:e.lastName,email:e.email,loginProvider:e.provider,loginProviderId:e.id,photoUrl:e.photoUrl,verified:new Date}:new D}this.createForm(this.newUser)}get f(){return this.form.controls}createForm(e){this.form=this.formBuilder.group({firstName:[e.firstName,o.kI.required],lastName:[e.lastName,o.kI.required],email:[e.email,[o.kI.required,o.kI.email]],acceptTerms:[!1,o.kI.requiredTrue]}),"GOOGLE"!==this.newUser.loginProvider?this.form.addControl("password",new o.NI("",[o.kI.required,o.kI.minLength(6)])):this.f.email.disable()}register(){if(this.form.invalid)return;this.isSubmitting=!0;const e=this.form.getRawValue();this.newUser.firstName=e.firstName,this.newUser.lastName=e.lastName,this.newUser.email=e.email,"GOOGLE"!==this.newUser.loginProvider&&(this.newUser.password=e.password),console.log("register the form",this.form.getRawValue(),this.newUser),this.accountService.register(this.newUser).pipe((0,j.P)(),(0,$.h)(e=>(this.isSubmitting=!1,console.log("isSubmitting",this.isSubmitting),"Email address is already registered"===e.message?(this.messageService.add({severity:w.r.Warning,summary:"Email Conflict",detail:"It seems this email account is already registered with us.",life:12e3}),this.f.email.setErrors({emailConflict:!0}),!1):"GOOGLE"===this.newUser.loginProvider||(this.displayAwaitingVerificationEmail=!0,!1))),(0,B.w)(()=>this.loginService.login(this.newUser.email,null,!0)),(0,$.h)(e=>"Successful login"===e.message),(0,y.b)(()=>this.router.navigate(["/savoury/browse"])),(0,T.K)(e=>(this.isSubmitting=!1,this.messageService.add({severity:w.r.Error,summary:"Something terrible happened",detail:e.message,life:12e3}),(0,b.of)())),(0,S.R)(this.ngUnsubscribe)).subscribe(()=>{this.isSubmitting=!1,console.log("subscription finished",this.isSubmitting)})}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(o.qu),x.Y36(f.B),x.Y36(C.r),x.Y36(k.e),x.Y36(h.F0))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-register-form"]],features:[x.qOj],decls:8,vars:2,consts:[[1,"flex-box","flex-align-center"],["aria-hidden","false","aria-label","Register New User",1,"mr-2"],["mat-card-content","",3,"formGroup","keyup.enter",4,"ngIf"],[4,"ngIf"],["mat-card-content","",3,"formGroup","keyup.enter"],[1,"flex-box","flex-row","mt-2"],[1,"mr-2","w-45"],["matInput","","type","text","placeholder","First Name *","Title","First Name","formControlName","firstName"],[4,"ngFor","ngForOf"],[1,"w-50"],["matInput","","type","text","placeholder","Last Name *","Title","Last Name","formControlName","lastName"],[1,"w-100"],["matInput","","type","email","placeholder","Email *","Title","Email","formControlName","email"],[1,"mt-2","mb-4"],["aria-label","Accept Terms and conditions","formControlName","acceptTerms",3,"change"],[1,"flex-box","flex-justify-end"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login",1,"mr-1"],["color","accent","iconName","chevron_right","iconPosition","right","label","Register",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","password"]],template:function(e,t){1&e&&(x.TgZ(0,"mat-card-header"),x.TgZ(1,"mat-card-title"),x.TgZ(2,"h1",0),x.TgZ(3,"mat-icon",1),x._uU(4,"person_add"),x.qZA(),x._uU(5,"Register"),x.qZA(),x.qZA(),x.qZA(),x.YNc(6,ae,20,8,"form",2),x.YNc(7,ne,2,0,"div",3)),2&e&&(x.xp6(6),x.Q6J("ngIf",!!t.form&&!t.displayAwaitingVerificationEmail),x.xp6(1),x.Q6J("ngIf",t.displayAwaitingVerificationEmail))},directives:[a.dk,a.n5,m.Hw,i.O5,o._Y,o.JL,a.dn,o.sg,c.KE,g.Nt,o.Fj,o.JJ,o.u,i.sg,n.oG,s.lW,h.rH,q.t,c.TO],styles:[""]}),e})();function ce(e,t){1&e&&(x.TgZ(0,"div"),x._uU(1," Validating token... "),x.qZA())}function me(e,t){1&e&&(x.TgZ(0,"div",7),x.TgZ(1,"span"),x._uU(2,"Token validation failed, you can get a new reset token at "),x.qZA(),x.TgZ(3,"button",8),x._uU(4,"Forgot Password"),x.qZA(),x.qZA())}function ge(e,t){if(1&e&&(x.TgZ(0,"mat-error",18),x._UZ(1,"span",19),x.qZA()),2&e){const e=x.oxw().$implicit;x.xp6(1),x.Q6J("innerHTML",e.message,x.oJD)}}function ue(e,t){if(1&e&&(x.TgZ(0,"mat-error"),x.YNc(1,ge,2,1,"mat-error",17),x.qZA()),2&e){const e=t.$implicit,r=x.oxw(2);x.xp6(1),x.Q6J("ngIf",r.f.password.hasError(e.type)&&(r.f.password.dirty||r.f.password.touched))}}function de(e,t){if(1&e){const e=x.EpF();x.TgZ(0,"form",9),x.TgZ(1,"div",7),x.TgZ(2,"mat-form-field",10),x.TgZ(3,"mat-icon",11),x._uU(4,"lock"),x.qZA(),x.TgZ(5,"input",12),x.NdJ("keyup.enter",function(){return x.CHM(e),x.oxw().resetPassword()}),x.qZA(),x.YNc(6,ue,2,1,"mat-error",13),x.qZA(),x.TgZ(7,"div",14),x.TgZ(8,"button",15),x._uU(9,"Cancel"),x.qZA(),x.TgZ(10,"app-save-button",16),x.NdJ("save",function(){return x.CHM(e),x.oxw().resetPassword()}),x.qZA(),x.qZA(),x.qZA(),x.qZA()}if(2&e){const e=x.oxw();x.Q6J("formGroup",e.form),x.xp6(6),x.Q6J("ngForOf",e.validationMessages.password),x.xp6(4),x.Q6J("dirty",e.form.dirty)("valid",e.form.valid)("isSaving",e.isSubmitting)}}function fe(e,t){1&e&&(x.TgZ(0,"div"),x._uU(1," Oops you need to confirm a token to reset a password this way. "),x.qZA())}var pe=(()=>(function(e){e[e.Validating=0]="Validating",e[e.Valid=1]="Valid",e[e.Invalid=2]="Invalid"}(pe||(pe={})),pe))();let he=(()=>{class e extends v.V{constructor(e,t,r,i,o){super(),this.fb=e,this.route=t,this.router=r,this.accountService=i,this.messageService=o,this.validationMessages=Z.rm,this.TokenStatus=pe,this.tokenStatus=pe.Validating,this.token=null,this.isSubmitting=!1,this.isLoading=!1}ngOnInit(){this.form=this.createForm();const e=this.route.snapshot.queryParams.token;this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),void 0===e?this.tokenStatus=pe.Invalid:this.accountService.validateResetToken(e).pipe((0,j.P)(),(0,y.b)(t=>{"Invalid Token"===t.message?(this.messageService.add({severity:w.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),this.tokenStatus=pe.Invalid):(this.token=e,this.tokenStatus=pe.Valid),console.log("returned result",t,this.tokenStatus)}),(0,T.K)(e=>(this.tokenStatus=pe.Invalid,this.messageService.add({severity:w.r.Error,summary:"Reset Token Error",detail:"The server did not receive a correctly formatted token.",life:8e3}),(0,b.of)()))).subscribe()}get f(){return this.form.controls}createForm(){return this.fb.group({password:["",[o.kI.required,o.kI.minLength(6),o.kI.maxLength(120)]]})}resetPassword(){this.form.invalid||(this.isSubmitting=!0,this.accountService.resetPassword(this.token,this.f.password.value,this.f.password.value).pipe((0,j.P)(),(0,y.b)(e=>{console.log("Message result from reset password attempt",e),"Success"===e.message?(this.messageService.add({severity:w.r.Success,summary:"Password reset",detail:"Password reset you can now login with your new password.",life:8e3}),this.router.navigate(["/account/login"])):(this.messageService.add({severity:w.r.Warning,summary:"Password reset failed",detail:e.message,life:8e3}),this.tokenStatus=pe.Invalid)}),(0,T.K)(e=>(this.tokenStatus=pe.Invalid,this.messageService.add({severity:w.r.Error,summary:"Password reset Error",detail:e.message,life:8e3}),(0,b.of)()))).subscribe(()=>{this.isSubmitting=!1}))}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(o.qu),x.Y36(h.gz),x.Y36(h.F0),x.Y36(f.B),x.Y36(k.e))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-reset-password-form"]],features:[x.qOj],decls:11,vars:4,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],["mat-card-content","",3,"ngSwitch"],[4,"ngSwitchCase"],["class","flex-box flex-column",4,"ngSwitchCase"],[3,"formGroup",4,"ngSwitchCase"],[4,"ngSwitchDefault"],[1,"flex-box","flex-column"],["mat-flat-button","","color","accent","aria-label","Navigate to forgot password","type","button","routerLink","/account/forgot-password",1,"mt-2","mb-2"],[3,"formGroup"],[1,"mt-1"],["matPrefix","",1,"pr-1"],["matInput","","type","password","placeholder","Password *","Title","Password","formControlName","password",3,"keyup.enter"],[4,"ngFor","ngForOf"],[1,"flex-box","flex-justify-end","mt-2"],["mat-flat-button","","type","button","aria-label","Cancel","routerLink","/account/login"],["label","Reset Password",3,"dirty","valid","isSaving","save"],["class","error-message",4,"ngIf"],[1,"error-message"],[3,"innerHTML"]],template:function(e,t){1&e&&(x.TgZ(0,"mat-card-header"),x.TgZ(1,"mat-card-title"),x.TgZ(2,"h1",0),x.TgZ(3,"mat-icon",1),x._uU(4,"security icon"),x.qZA(),x._uU(5,"Reset Password"),x.qZA(),x.qZA(),x.qZA(),x.TgZ(6,"div",2),x.YNc(7,ce,2,0,"div",3),x.YNc(8,me,5,0,"div",4),x.YNc(9,de,11,5,"form",5),x.YNc(10,fe,2,0,"div",6),x.qZA()),2&e&&(x.xp6(6),x.Q6J("ngSwitch",t.tokenStatus),x.xp6(1),x.Q6J("ngSwitchCase",t.TokenStatus.Validating),x.xp6(1),x.Q6J("ngSwitchCase",t.TokenStatus.Invalid),x.xp6(1),x.Q6J("ngSwitchCase",t.TokenStatus.Valid))},directives:[a.dk,a.n5,m.Hw,a.dn,i.RF,i.n9,i.ED,s.lW,h.rH,o._Y,o.JL,o.sg,c.KE,c.qo,g.Nt,o.Fj,o.JJ,o.u,i.sg,q.t,c.TO,i.O5],styles:["h2[_ngcontent-%COMP%]{display:flex}"]}),e})();function ve(e,t){1&e&&(x.TgZ(0,"div"),x._uU(1," Verifying... "),x.qZA())}function we(e,t){1&e&&(x.TgZ(0,"p"),x._uU(1,"Unfortunately, the verify email token failed, you can get a new token at "),x.qZA(),x.TgZ(2,"button",5),x._uU(3,"Forgot Password"),x.qZA())}var Ze=(()=>(function(e){e[e.Verifying=0]="Verifying",e[e.Failed=1]="Failed"}(Ze||(Ze={})),Ze))();const be=[{path:"",component:W,children:[{path:"login",component:Q},{path:"register",component:le},{path:"verify-email",component:(()=>{class e{constructor(e,t,r,i){this.route=e,this.router=t,this.accountService=r,this.messageService=i,this.EmailStatus=Ze,this.emailStatus=Ze.Verifying}ngOnInit(){const e=this.route.snapshot.queryParams.token;this.router.navigate([],{relativeTo:this.route,replaceUrl:!0}),void 0===e?(this.emailStatus=Ze.Failed,this.messageService.add({severity:w.r.Error,summary:"Invalid Token",detail:"Please obtain a new verify token.",life:8e3})):this.accountService.verifyEmail(e).pipe((0,j.P)(),(0,y.b)(e=>{"Verification Failed"===e.message?(this.messageService.add({severity:w.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),this.emailStatus=Ze.Failed):(this.messageService.add({severity:w.r.Success,summary:"Email Verified",detail:"Well done, email verified, please login to start making amazing recipes.",life:8e3}),this.router.navigate(["/account/login"]))}),(0,T.K)(e=>(this.messageService.add({severity:w.r.Error,summary:"Invalid Token",detail:"Please obtain a new password reset token.",life:8e3}),this.emailStatus=Ze.Failed,(0,b.of)()))).subscribe()}}return e.\u0275fac=function(t){return new(t||e)(x.Y36(h.gz),x.Y36(h.F0),x.Y36(f.B),x.Y36(k.e))},e.\u0275cmp=x.Xpm({type:e,selectors:[["app-verify-email"]],decls:10,vars:2,consts:[[1,"flex-box"],["aria-hidden","false","aria-label","Forgot Password",1,"mr-2"],["mat-card-content",""],[4,"ngIf","ngIfElse"],["showFailed",""],["mat-flat-button","","color","accent","aria-label","Navigate to register","type","button","routerLink","/account/register",1,"mt-2","mb-2"]],template:function(e,t){if(1&e&&(x.TgZ(0,"mat-card-header"),x.TgZ(1,"mat-card-title"),x.TgZ(2,"h1",0),x.TgZ(3,"mat-icon",1),x._uU(4,"security icon"),x.qZA(),x._uU(5,"Reset Password"),x.qZA(),x.qZA(),x.qZA(),x.TgZ(6,"div",2),x.YNc(7,ve,2,0,"div",3),x.YNc(8,we,4,0,"ng-template",null,4,x.W1O),x.qZA()),2&e){const e=x.MAs(9);x.xp6(7),x.Q6J("ngIf",t.emailStatus===t.EmailStatus.Verifying)("ngIfElse",e)}},directives:[a.dk,a.n5,m.Hw,a.dn,i.O5,s.lW,h.rH],styles:[""]}),e})()},{path:"forgot-password",component:U},{path:"reset-password",component:he}]}];let ye=(()=>{class e{}return e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=x.oAB({type:e}),e.\u0275inj=x.cJS({imports:[[h.Bz.forChild(be)],h.Bz]}),e})(),Te=(()=>{class e{}return e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=x.oAB({type:e}),e.\u0275inj=x.cJS({providers:[f.B],imports:[[i.ez,o.UX,ye,m.Ps,a.QW,c.lN,l.t,g.c,s.ot,n.p9,u.v,d.Kz.forRoot({icons:p.Z})]]}),e})()}}]);