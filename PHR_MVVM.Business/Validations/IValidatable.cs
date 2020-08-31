using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PHR_MVVM.Business.Validations
{
    public interface IValidatable<T> : INotifyPropertyChanged
    {
        List<IValidationRule<T>> Validations { get; }
        List<string> Errors { get; set; }
        bool Validate();
        bool IsValid { get; set; }
    }
}
