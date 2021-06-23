import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ValidatorService } from 'src/app/core/services/validator.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  signupForm: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private validatorService: ValidatorService) { 
    this.signupForm = new FormGroup({
      FirstName: new FormControl(''),
      LastName: new FormControl(''),
      Email: new FormControl(''),
      Password: new FormControl(''),
      ConfirmPassword: new FormControl('')
    });
  }

  get f() { return this.signupForm.controls; }

  buildForm() {
    this.signupForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: [null, {validators: [Validators.required, Validators.email]}],
      Password: ['', [Validators.required, this.validatorService.passwordValidator]],
      ConfirmPassword: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.buildForm();
  }

  onSubmit() {
    // console.log('submit clicked');
    console.log(this.signupForm);

    this.submitted = true;
    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }

  }
}
