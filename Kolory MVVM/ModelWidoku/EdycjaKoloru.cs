using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kolory_MVVM.ModelWidoku
{
    using Model;
    using System.Windows.Input;
    using System.Windows.Media;

    public class EdycjaKoloru : ObservedObject
    {
        private readonly Kolor model = Ustawienia.Czytaj();

        public byte R
        {
            get
            {
                return model.R;
            }
            set
            {
                model.R = value;
                OnPropertyChanged(nameof(R));
            }
        }
        public byte G
        {
            get
            {
                return model.G;
            }
            set
            {
                model.G = value;
                OnPropertyChanged(nameof(G));
            }
        }
        public byte B
        {
            get
            {
                return model.B;
            }
            set
            {
                model.B = value;
                OnPropertyChanged(nameof(B));
            }
        }
        //public Color Kolor
        //{
        //    get
        //    {
        //        return Color.FromRgb(model.R, model.G, model.B);
        //    }
        //}


        private ICommand resetuj = null;
        public ICommand Resetuj
        {
            get
            {
                if (resetuj == null) resetuj = new RelayCommand(
                      (object p) =>
                      {
                          model.Resetuj();
                          OnPropertyChanged(nameof(R), nameof(G), nameof(B));
                      },
                      (object p) => { return model.R != 0 || model.G != 0 || model.B != 0; }
                      );

                return resetuj;

            }
        }
        public void _Zapisz()
        {
            Ustawienia.Zapisz(model);
        }

        public ICommand Zapisz
        {
            get
            {
                return new RelayCommand((object o) => { _Zapisz(); });
            }
        }
    }
}
