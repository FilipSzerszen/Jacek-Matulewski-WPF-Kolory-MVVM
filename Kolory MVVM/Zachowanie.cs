using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Kolory_MVVM
{
    public class ZamknięcieOknaPoNaciśnięciuKlawisza : Behavior<Window>
    {
        public Key Klawisz { get; set; }

        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null) window.PreviewKeyDown += window_PreviewKeyDown;
        }

        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Key == Klawisz) window.Close();
        }
    }
    public class PrzyciskZamykającyOkno : Behavior<Window>
    {
        public static readonly DependencyProperty PrzyciskProperty =
            DependencyProperty.Register("Przycisk", typeof(Button), typeof(PrzyciskZamykającyOkno), new PropertyMetadata(null, przyciskZmieniony));

        public Button Przycisk
        {
            get { return (Button)GetValue(PrzyciskProperty); }
            set { SetValue(PrzyciskProperty, value); }
        }

        private static void przyciskZmieniony(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as PrzyciskZamykającyOkno).AssociatedObject;
            RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { window.Close(); };
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
}
