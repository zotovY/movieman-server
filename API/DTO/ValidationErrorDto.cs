using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace API.DTO {
    public sealed class ValidateErrorDto {
        public bool success => false;
        public string error => "validation-error";
        public List<ValidateErrorElement> errors { get; set; }

        public ValidateErrorDto(List<ValidateErrorElement> errors) {
            this.errors = errors;
        }

        public ValidateErrorDto(List<ValidationFailure> failures) {
            errors = new ();
            foreach (var error in failures) {
                errors.Add(new ValidateErrorElement(error.PropertyName, error.ErrorCode, error.ErrorMessage));
            }
        }
    }

    public sealed class ValidateErrorElement {
        public string path { get; set; }
        public string error { get; set; }
        #nullable enable
        public string? message { get; set; }

        public ValidateErrorElement(string path, string error, string? message) {
            this.path = path;
            this.error = error;
            this.message = message;
        }
    }
}