using CustomActions.Common.CustomControls.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomActions.Common.CustomControls
{
    public class DiagnoseEntryControl : Entry, IControlValidation
    {
        public bool HasError => throw new NotImplementedException();

        public string ErrorMessage => throw new NotImplementedException();

        public bool ShowErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool BtnEnabled => throw new NotImplementedException();
    }
}
