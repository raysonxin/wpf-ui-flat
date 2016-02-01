using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlatApp.UI.Helper;

namespace FlatApp.UI.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlatApp.UI.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:FlatApp.UI.Controls;assembly=FlatApp.UI.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:IconButton/>
    ///
    /// </summary>
    public class IconButton : Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(IconButton), new PropertyMetadata(""));

        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(IconButton), new PropertyMetadata(""));

        public string Icon
        {
            get { return (string)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IsShowTitleProperty =
            DependencyProperty.Register("IsShowTitle", typeof(bool), typeof(IconButton), new PropertyMetadata(true, OnVisibilityChanged));

        public bool IsShowTitle
        {
            get { return (bool)this.GetValue(IsShowTitleProperty); }
            set { this.SetValue(IsShowTitleProperty, value); }
        }

        private static void OnVisibilityChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is IconButton)
            {
                var btn = obj as IconButton;
                var container = XamlHelper.GetChildObject<StackPanel>(obj, "Container");

                if (container == null)
                    return;



                var textblock = XamlHelper.GetChildObject<TextBlock>(container, "IconBtnText");
                if (textblock == null)
                    return;

                textblock.Visibility = btn.IsShowTitle ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
