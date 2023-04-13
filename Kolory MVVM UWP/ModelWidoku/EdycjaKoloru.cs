namespace Kolory_MVVM.ModelWidoku
{
    using Model;
    using System.Windows.Input;
    using Windows.UI;

    public class EdycjaKoloru : ObservedObject
    {
        private readonly Kolor model = new Kolor(0,0,0);

        public byte R
        {
            get
            {
                return model.R;
            }
            set
            {
                model.R = value;
                OnPropertyChanged(nameof(R), nameof(Kolor));
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
                OnPropertyChanged(nameof(G), nameof(Kolor));
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
                OnPropertyChanged(nameof(B), nameof(Kolor));
            }
        }
        public Color Kolor
        {
            get
            {
                return Color.FromArgb(255, model.R, model.G, model.B);
            }
        }


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
                      (object p) => { return true; }//model.R != 0 || model.G != 0 || model.B != 0; }
                      );

                return resetuj;

            }
        }
        public void _Zapisz()
        {
            //Ustawienia.Zapisz(model);
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
