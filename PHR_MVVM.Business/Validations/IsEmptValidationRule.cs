using CustomActions.Common.Translation.Resx;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHR_MVVM.Business.Validations
{
    public class IsEmptValidationRule : IValidationRule<string>
    {
        public string ValidationMessage { get => Resource.AllPlaces; }

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
