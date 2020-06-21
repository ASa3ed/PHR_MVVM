namespace CustomActions.Common.CustomControls.Interface
{
    public interface IControlValidation
    {
        bool HasError { get;  }
        string ErrorMessage { get; }
        bool ShowErrorMessage { get; set; }

        bool BtnEnabled { get;}
    }
}
