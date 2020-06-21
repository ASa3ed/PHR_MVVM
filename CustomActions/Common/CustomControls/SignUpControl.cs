using CustomActions.Common.CustomControls.Interface;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace CustomActions.Common.CustomControls
{

    public class SignUpControl : Entry, IControlValidation
    {
        #region Property
        private INotifyDataErrorInfo _NotifyErrors;
        private string BindingPath = "";      

        #endregion

        #region Btn Opacity
        public static readonly BindableProperty BtnOpacityProperty =
            BindableProperty.Create("BtnOpacity", typeof(double), typeof(double), 0.3, defaultBindingMode: BindingMode.TwoWay);

        public double BtnOpacity
        {
            get { return (double)GetValue(BtnOpacityProperty); }
            private set { SetValue(BtnOpacityProperty, value); }
        }
        #endregion

        #region Btn Enabled
        public static readonly BindableProperty BtnEnabledProperty =
            BindableProperty.Create("BtnEnabled", typeof(bool), typeof(bool), false, defaultBindingMode: BindingMode.TwoWay);

        public bool BtnEnabled
        {
            get { return (bool)GetValue(BtnEnabledProperty); }
            private set { SetValue(BtnEnabledProperty, value); }
        }
        #endregion

        #region Has Error
        public static readonly BindableProperty HasErrorProperty =
            BindableProperty.Create("HasError", typeof(bool), typeof(bool), false, defaultBindingMode: BindingMode.TwoWay);

        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            private set { SetValue(HasErrorProperty, value); }
        }
        #endregion

        #region ErrorMessage

        public static readonly BindableProperty ErrorMessageProperty =
           BindableProperty.Create("ErrorMessage", typeof(string), typeof(string), string.Empty, defaultBindingMode: BindingMode.TwoWay);

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        #endregion

        #region ShowErrorMessage

        public static readonly BindableProperty ShowErrorMessageProperty =
           BindableProperty.Create("ShowErrorMessage", typeof(bool), typeof(bool), false, propertyChanged: OnShowErrorMessageChanged, defaultBindingMode: BindingMode.TwoWay);

        private static void OnShowErrorMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // execute on bindable context changed method

            SignUpControl control = bindable as SignUpControl;
            if (control != null && control.BindingContext != null)
            {
                control.CheckValidation();
            }
        }

        public bool ShowErrorMessage
        {
            get { return (bool)GetValue(ShowErrorMessageProperty); }
            set { SetValue(ShowErrorMessageProperty, value); }
        }
        #endregion

        #region Override Binding context change property
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            CheckValidation();
        }

        /// <summary>
        /// Method will subscibe and unsubsribe Error changed event
        /// Get bindable property path of text property
        /// </summary>
        public void CheckValidation()
        {
            // Reset variables values
            ErrorMessage = "";
            HasError = false;
            BindingPath = "";

            if (_NotifyErrors != null)
            {
                // Unsubscribe event
                _NotifyErrors.ErrorsChanged += _NotifyErrors_ErrorsChanged;
                _NotifyErrors = null; // Set null value on binding context change          
            }



            // Do nothing if show error message property value is false
            if (!this.ShowErrorMessage)
                return;

            //this.Placeholder = ""; // Change place holder value

            if (this.BindingContext != null && this.BindingContext is INotifyDataErrorInfo)
            {
                // Get 
                _NotifyErrors = this.BindingContext as INotifyDataErrorInfo;

                if (_NotifyErrors == null)
                    return;

                // Subscribe event
                _NotifyErrors.ErrorsChanged += _NotifyErrors_ErrorsChanged;

                // Remove notify scroll to property


                // get property name for windows and other operating system
                // for windows 10 property name will be : properties
                // And other operation system its value : _properties
                string condition = "properties";






                // Get bindable properties
                var _propertiesFieldInfo = typeof(BindableObject)
                           .GetRuntimeFields()
                           .Where(x => x.IsPrivate == true && x.Name.Contains(condition))
                           .FirstOrDefault();


                IDictionary _properties = ((IDictionary)_propertiesFieldInfo
                                 .GetValue(this));

              


                if (_properties == null)
                {
                    return;
                }

                // Get first object
              
                DictionaryEntry field;
                foreach (DictionaryEntry fp in _properties)
                {
                    dynamic key = (dynamic)fp.Key;
                    var propertyName = key.PropertyName;


                    if (propertyName == "Text")
                    {
                        field = fp;
                        break;
                    }
                }

                var binding = field.Value;
                Binding bindings = ((Binding) binding.GetType().GetRuntimeField("Binding").GetValue(binding));
                string bindingsfullpath = bindings.Path;

                if (bindings != null)
                {
                    BindingPath = bindingsfullpath;
                   // SetPlaceHolder();
                }

            }
        }

        //// Scroll to control when request for scroll to property
        //private void NotifyScroll_ScrollToProperty(string PropertyName)
        //{
        //    // If property is requested property
        //    if (this.BindingPath.Equals(PropertyName))
        //    {
        //        // Get scroll 


        //    }
        //}

        /// <summary>
        /// Method will fire on property changed
        /// Check validation of text property
        /// Set validation if any validation message on property changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _NotifyErrors_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            // Error changed
            BtnOpacity = _NotifyErrors.HasErrors ? 0.3 : 1;
            if (e.PropertyName.Equals(this.BindingPath))
            { 
                // Get errors
                string errors = _NotifyErrors
                        .GetErrors(e.PropertyName)
                        ?.Cast<string>()
                        .FirstOrDefault();
                 

                // If has error
                // assign validation values
                if (!string.IsNullOrEmpty(errors))
            {
                HasError = true; //set has error value to true
                ErrorMessage = errors; // assign error
                BtnEnabled = false;
              //  BtnOpacity = 0.3;
            }
            else
            {
                // reset error message and flag
                HasError = false;
                ErrorMessage = "";
                BtnEnabled = true;
               // BtnOpacity = 1;
                }
            }


        }

        private void SetPlaceHolder()
        {
            if (!string.IsNullOrEmpty(BindingPath) && this.BindingContext != null)
            {
                // Get display attributes
                var _attributes = this.BindingContext.GetType()
                    .GetRuntimeProperty(BindingPath)
                    .GetCustomAttribute<DisplayAttribute>();

                // Set place holder
                if (_attributes != null)
                {
                    this.Placeholder = _attributes.Name; // assign placeholder property
                    
                }
            }

        }
        #endregion
    }


}
