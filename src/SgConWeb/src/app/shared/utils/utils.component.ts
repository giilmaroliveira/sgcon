import { FormBuilder, FormGroup, Validators } from '@angular/forms';

export module UtilsComponent {

  export function applyCss(field: string, form: FormGroup) {
    if (form.get(field).valid && form.get(field).touched) {
      return {
        'has-success': form.get(field).valid && form.get(field).touched,
        'has-feedback': form.get(field).valid && form.get(field).touched,
        'form-control-success': form.get(field).valid && form.get(field).touched
      };
    } else {
      return {
        'has-danger': !form.get(field).valid && form.get(field).touched,
        'has-feedback': !form.get(field).valid && form.get(field).touched,
        'form-control-danger': form.get(field).valid && form.get(field).touched
      };
    }
  }
}