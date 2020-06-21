using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Multilingual;

namespace CustomActions.Common.Translation
{
    // You exclude the 'Extension' suffix when using in XAML
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        const string ResourceId = "CustomActions.Common.Translation.Resx.Resource";

        //static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));
        static readonly Lazy<ResourceManager>  ResMgr= new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public TranslateExtension()
        {
            //if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            //{
          //  ci = Thread.CurrentThread.CurrentUICulture;
            //ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();         
            //}
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var ci = Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo;

       var translation = ResMgr.Value.GetString(Text, ci);
            if (translation == null)
            {
                //#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
                //#else
                //                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
                //#endif
            }
            return translation;
        }
    }
}