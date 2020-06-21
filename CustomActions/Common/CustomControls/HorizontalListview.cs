using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomActions.Common.CustomControls
{
    public class HorizontalListview : ScrollView
    {

        public static BindableProperty ItemsSourceProperty =
       BindableProperty.Create(propertyName: "ItemsSource", returnType: typeof(IEnumerable), declaringType: typeof(HorizontalListview), defaultValue: null, defaultBindingMode: BindingMode.TwoWay , propertyChanged: ItemsSourcePropertyChanged);

        //public static readonly BindableProperty ItemsSourceProperty =
        //    BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(HorizontalListview), default(IEnumerable), propertyChanged: ItemsSourcePropertyChanged);


        private static void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var HorizontalScroller = bindable as ScrollView;

            if (!(bindable is HorizontalListview control)) return;

            var items = (ICollection)newValue;

            
            if (control.ItemTemplate == null || control.ItemsSource == null)
                return;

            var layout = new StackLayout();
            layout.Spacing = 0;

            layout.Orientation = control.Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal;

            foreach (var item in items)
            {
                var command = control.SelectedCommand ?? new Command((obj) =>
                {
                    var args = new ItemTappedEventArgs(items, item);
                    control.ItemSelected?.Invoke(control, args);
                });
                var commandParameter = control.SelectedCommandParameter ?? item;

                var viewCell = control.ItemTemplate.CreateContent() as ViewCell;
                viewCell.View.BindingContext = item;
                viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = command,
                    CommandParameter = commandParameter,
                    NumberOfTapsRequired = 1
                });
                layout.Children.Add(viewCell.View);
            }

            if (control.FooterTemplate != null)
            {
                var footerViewCell = control.FooterTemplate.CreateContent() as ViewCell;
                layout.Children.Add(footerViewCell.View);
            }

            control.Content = layout;

            HorizontalScroller.ScrollToAsync(HorizontalScroller, ScrollToPosition.End, false);
        }
        
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(HorizontalListview), default(DataTemplate));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty FooterTemplateProperty =
            BindableProperty.Create("FooterTemplate", typeof(DataTemplate), typeof(HorizontalListview), default(DataTemplate));

        public DataTemplate FooterTemplate
        {
            get { return (DataTemplate)GetValue(FooterTemplateProperty); }
            set { SetValue(FooterTemplateProperty, value); }
        }


        public event EventHandler<ItemTappedEventArgs> ItemSelected;

        public static readonly BindableProperty SelectedCommandProperty =
            BindableProperty.Create("SelectedCommand", typeof(ICommand), typeof(HorizontalListview), null);

        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        public static readonly BindableProperty SelectedCommandParameterProperty =
            BindableProperty.Create("SelectedCommandParameter", typeof(object), typeof(HorizontalListview), null);

        public object SelectedCommandParameter
        {
            get { return GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
        }


        //public void Render()
        //{
        //    if (ItemTemplate == null || ItemsSource == null)
        //        return;

        //    var layout = new StackLayout();
        //    layout.Spacing = 0;

        //    layout.Orientation = Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal;

        //    foreach (var item in ItemsSource)
        //    {
        //        var command = SelectedCommand ?? new Command((obj) =>
        //        {
        //            var args = new ItemTappedEventArgs(ItemsSource, item);
        //            ItemSelected?.Invoke(this, args);
        //        });
        //        var commandParameter = SelectedCommandParameter ?? item;

        //        var viewCell = ItemTemplate.CreateContent() as ViewCell;
        //        viewCell.View.BindingContext = item;
        //        viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer
        //        {
        //            Command = command,
        //            CommandParameter = commandParameter,
        //            NumberOfTapsRequired = 1
        //        });
        //        layout.Children.Add(viewCell.View);
        //    }

        //    if (FooterTemplate != null) {
        //        var footerViewCell = FooterTemplate.CreateContent() as ViewCell;
        //        layout.Children.Add(footerViewCell.View);
        //    }

        //   Content = layout;
        //}
    }
}