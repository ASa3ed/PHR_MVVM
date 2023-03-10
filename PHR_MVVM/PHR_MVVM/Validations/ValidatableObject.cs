using PHR_MVVM.Business.Validations;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PHR_MVVM.Validations
{
    public class ValidatableObject<T> : BindableBase, IValidatable<T>
    {
        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsValid { get; set; } = true;

        public bool CleanOnChange { get; set; } = true;

        T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;

                if (CleanOnChange)
                    IsValid = true;
            }
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
