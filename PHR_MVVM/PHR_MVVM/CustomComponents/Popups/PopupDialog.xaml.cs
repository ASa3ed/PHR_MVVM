using CustomActions.Common.Cache;
using CustomActions.Common.Translation.Resx;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHR_MVVM.CustomComponents.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDialog 
    {
        #region PopupDialogTitle
        public static readonly BindableProperty PopupDialogTitleProperty =
           BindableProperty.Create(nameof(PopupDialogTitle), typeof(string), typeof(PopupDialog), string.Empty, BindingMode.OneWay);
        public string PopupDialogTitle
        {
            get
            {
                return (string)GetValue(PopupDialogTitleProperty);
            }
            set
            {
                SetValue(PopupDialogTitleProperty, value);
            }
        }
        #endregion

        #region MsgBody
        public static readonly BindableProperty MsgBodyProperty =
          BindableProperty.Create(nameof(MsgBody), typeof(string), typeof(PopupDialog), string.Empty, BindingMode.OneWay);
        public string MsgBody
        {
            get
            {
                return (string)GetValue(MsgBodyProperty);
            }
            set
            {
                SetValue(MsgBodyProperty, value);
            }
        }
        #endregion

        #region ActionButtonText
        public static readonly BindableProperty ActionButtonTextProperty =
            BindableProperty.Create(nameof(ActionButtonText), typeof(string), typeof(PopupDialog), string.Empty, BindingMode.OneWay);
        public string ActionButtonText
        {
            get
            {
                return (string)GetValue(ActionButtonTextProperty);
            }
            set
            {
                SetValue(ActionButtonTextProperty, value);
            }
        }
        #endregion

        #region CancelButtonText
        public static readonly BindableProperty CancelButtonTextProperty =
           BindableProperty.Create(nameof(CancelButtonText), typeof(string), typeof(PopupDialog), Resource.No, BindingMode.OneWay);
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

        #region ActionButtonColor
        public static readonly BindableProperty ActionButtonColorProperty =
            BindableProperty.Create(nameof(ActionButtonColor), typeof(Color), typeof(PopupDialog), Color.FromHex("#FA7370"), BindingMode.OneWay);
        public Color ActionButtonColor
        {
            get
            {
                return (Color)GetValue(ActionButtonColorProperty);
            }
            set
            {
                SetValue(ActionButtonColorProperty, value);
            }
        }
        #endregion

        #region CancelButtonColor
        public static readonly BindableProperty CancelButtonColorProperty =
            BindableProperty.Create(nameof(CancelButtonColor), typeof(Color), typeof(PopupDialog), Color.FromHex("#045DAD"), BindingMode.OneWay);
        public Color CancelButtonColor
        {
            get
            {
                return (Color)GetValue(CancelButtonColorProperty);
            }
            set
            {
                SetValue(CancelButtonColorProperty, value);
            }
        }
        #endregion

        #region ActionButtonCommand
        public static readonly BindableProperty ActionButtonCommandProperty =
           BindableProperty.Create(nameof(ActionButtonCommand), typeof(ICommand), typeof(PopupDialog));
        public ICommand ActionButtonCommand
        {
            get
            {
                return (ICommand)GetValue(ActionButtonCommandProperty);
            }
            set
            {
                SetValue(ActionButtonCommandProperty, value);
            }
        }
        #endregion

        #region CancelButtonCommand
        public static readonly BindableProperty CancelButtonCommandProperty =
           BindableProperty.Create(nameof(CancelButtonCommand), typeof(ICommand), typeof(PopupDialog));
        public ICommand CancelButtonCommand
        {
            get
            {
                return (ICommand)GetValue(CancelButtonCommandProperty);
            }
            set
            {
                SetValue(CancelButtonCommandProperty, value);
            }
        }
        #endregion

        #region HasActionButton
        public static readonly BindableProperty HasActionButtonProperty =
            BindableProperty.Create(nameof(HasActionButton), typeof(bool), typeof(PopupDialog), true, BindingMode.OneWay);
        public bool HasActionButton
        {
            get
            {
                return (bool)GetValue(HasActionButtonProperty);
            }
            set
            {
                SetValue(HasActionButtonProperty, value);
            }
        }
        #endregion

        #region HasCancelButton
        public static readonly BindableProperty HasCancelButtonProperty =
            BindableProperty.Create(nameof(HasCancelButton), typeof(bool), typeof(PopupDialog), true, BindingMode.OneWay);
        public bool HasCancelButton
        {
            get
            {
                return (bool)GetValue(HasCancelButtonProperty);
            }
            set
            {
                SetValue(HasCancelButtonProperty, value);
            }
        }
        #endregion

        #region PopupWidth
        public static readonly BindableProperty PopupWidthProperty = BindableProperty.Create(nameof(PopupWidth), typeof(double), typeof(PopupDialog), 260d);
        public double PopupWidth
        {
            get => (double)GetValue(PopupWidthProperty);
            set => SetValue(PopupWidthProperty, value);
        }
        #endregion

        #region PopupHeight
        public static readonly BindableProperty PopupHeightProperty = BindableProperty.Create(nameof(PopupHeight), typeof(double), typeof(PopupDialog), 180d);
        public double PopupHeight
        {
            get => (double)GetValue(PopupHeightProperty);
            set => SetValue(PopupHeightProperty, value);
        }
        #endregion

        public PopupDialog()
        {
            InitializeComponent();

            if (ApplicationProperties.Language == "ar")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
            }
        }
    }
}