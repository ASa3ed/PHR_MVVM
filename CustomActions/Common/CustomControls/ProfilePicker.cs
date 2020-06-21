using CustomActions.Common.Translation.Resx;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomActions.Common.CustomControls
{
  public class ProfilePicker : Picker 
    {
        #region Property
        public string CancelButtonText
        {
            get
            {
                return (string)GetValue(CancelButtonTextProperty);
            }
            set
            {
                SetValue(CancelButtonTextProperty, value);
            }
        }


        #endregion
        public static readonly BindableProperty CancelButtonTextProperty = BindableProperty.Create(
                                                         propertyName: "CancelButtonTextProperty",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(ProfilePicker),
                                                         defaultValue: Resource.Cancel,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: CancelButtonTextPropertyChanged);

        private static void CancelButtonTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ProfilePicker).Title = string.Empty;
            (bindable as ProfilePicker).CancelButtonText = newValue.ToString();
        }

    }
}
