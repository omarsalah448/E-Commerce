import { ValidatorFn, AbstractControl, ValidationErrors } from "@angular/forms";

/** An actor's name can't match the actor's role */
export const RetypePassword: ValidatorFn = (
    control: AbstractControl,
  ): ValidationErrors | null => {
    let password: string = control.get('Password')?.value;
    let retypePassword: string = control.get('RetypePassword')?.value;
    if (!password || !retypePassword)
      return null;
    let success: boolean = password === retypePassword
    return success ? null : {"NoMatch": true}
  };