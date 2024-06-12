using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schiffe
{
    public class SpielzeugschiffeVM : PropertyChangedClass
    {
        public AddCmdSpielzeugschiffe AddCmdSpielzeugschiffe { get; set; }
        public DeleteCmdSpielzeugschiffe DeleteCmdSpielzeugschiffe { get; set; }
        public SpielzeugschiffeVM()
        {
            AllSpielzeugschiffe = new ObservableCollection<SpielzeugschiffVM>();
            foreach (var item in SpielzeugschiffVM.FromFile())
            {
                AllSpielzeugschiffe.Add(item);
            }
            if (AllSpielzeugschiffe.Count > 0)
                SelectedSpielzeugschiff = AllSpielzeugschiffe.First();
            else SelectedSpielzeugschiff = new SpielzeugschiffVM();
            ActiveSpielzeugschiff = new SpielzeugschiffVM();
            ActiveSpielzeugschiff = GenerateRandomSchiff();

            // Commands
            AddCmdSpielzeugschiffe = new AddCmdSpielzeugschiffe(this);
            DeleteCmdSpielzeugschiffe = new DeleteCmdSpielzeugschiffe(this);
        }

        private ObservableCollection<SpielzeugschiffVM> _allSpielzeugschiffe;
        public ObservableCollection<SpielzeugschiffVM> AllSpielzeugschiffe
        {
            get { return _allSpielzeugschiffe; }
            set
            {
                _allSpielzeugschiffe = value;
                OnPropertyChanged();
            }
        }

        private SpielzeugschiffVM _selectedSpielzeugschiff;
        public SpielzeugschiffVM SelectedSpielzeugschiff
        {
            get { return _selectedSpielzeugschiff; }
            set
            {
                _selectedSpielzeugschiff = value;
                if (_activeSpielzeugschiff == null) _activeSpielzeugschiff = new SpielzeugschiffVM();
                if(value != null)
                {
                    _activeSpielzeugschiff.Name = value.Name;
                    _activeSpielzeugschiff.Laenge = value.Laenge;
                    _activeSpielzeugschiff.Baujahr = value.Baujahr;
                    _activeSpielzeugschiff.Farbe = value.Farbe;
                    _activeSpielzeugschiff.Marke = value.Marke;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveSpielzeugschiff");
            }
        }

        private SpielzeugschiffVM _activeSpielzeugschiff;
        public SpielzeugschiffVM ActiveSpielzeugschiff
        {
            get { return _activeSpielzeugschiff; }
            set
            {
                _activeSpielzeugschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllSpielzeugschiffe");
            }
        }

        static public SpielzeugschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            SpielzeugschiffVM spielzeugschiffVM = new SpielzeugschiffVM();
            spielzeugschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            spielzeugschiffVM.Laenge = random.Next(5, 80);
            spielzeugschiffVM.Baujahr = new DateTime(random.Next(1950, DateTime.Now.Year), random.Next(1, 12), random.Next(1, 28));
            var farbe = Enum.GetValues(typeof(Farbe));
            spielzeugschiffVM.Farbe = (Farbe)farbe.GetValue(random.Next(1, farbe.Length - 1));
            var marke = Enum.GetValues(typeof(Marke));
            spielzeugschiffVM.Marke = (Marke)marke.GetValue(random.Next(1, marke.Length - 1));
            return spielzeugschiffVM;
        }
    }

    public class AddCmdSpielzeugschiffe : ICommand
    {
        private SpielzeugschiffeVM _SpielzeugschiffeVM;

        public AddCmdSpielzeugschiffe(SpielzeugschiffeVM SpielzeugschiffeVM)
        {
            _SpielzeugschiffeVM = SpielzeugschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Name != null && _SpielzeugschiffeVM.ActiveSpielzeugschiff.Name != "" &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Laenge > 0 &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Farbe > 0 &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Marke > 0
            );
        }

        public void Execute(object? parameter)
        {
            Spielzeugschiff Spielzeugschiff = new Spielzeugschiff()
            {
                Name = _SpielzeugschiffeVM.ActiveSpielzeugschiff.Name,
                Laenge = _SpielzeugschiffeVM.ActiveSpielzeugschiff.Laenge,
                Baujahr = _SpielzeugschiffeVM.ActiveSpielzeugschiff.Baujahr,
                Farbe = _SpielzeugschiffeVM.ActiveSpielzeugschiff.Farbe,
                Marke = _SpielzeugschiffeVM.ActiveSpielzeugschiff.Marke
            };
            SpielzeugschiffVM.AddToFile(Spielzeugschiff);

            _SpielzeugschiffeVM.AllSpielzeugschiffe.Clear();
            foreach (var item in SpielzeugschiffVM.FromFile())
            {
                _SpielzeugschiffeVM.AllSpielzeugschiffe.Add(item);
            }

            // reset Values in View
            //_SpielzeugschiffeVM.ActiveSpielzeugschiff.Name = String.Empty;
            //_SpielzeugschiffeVM.ActiveSpielzeugschiff.Laenge = 0;
            //_SpielzeugschiffeVM.ActiveSpielzeugschiff.Baujahr = DateTime.Now;
            //_SpielzeugschiffeVM.ActiveSpielzeugschiff.Farbe = 0;
            //_SpielzeugschiffeVM.ActiveSpielzeugschiff.Marke = 0;
            _SpielzeugschiffeVM.ActiveSpielzeugschiff = SpielzeugschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdSpielzeugschiffe : ICommand
    {
        private SpielzeugschiffeVM _SpielzeugschiffeVM;

        public DeleteCmdSpielzeugschiffe(SpielzeugschiffeVM SpielzeugschiffeVM)
        {
            _SpielzeugschiffeVM = SpielzeugschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Name != null && _SpielzeugschiffeVM.ActiveSpielzeugschiff.Name != "" &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Laenge > 0 &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Farbe > 0 &&
                _SpielzeugschiffeVM.ActiveSpielzeugschiff.Marke > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Spielzeugschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Spielzeugschiff {_SpielzeugschiffeVM.ActiveSpielzeugschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Spielzeugschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("spielzeugschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _SpielzeugschiffeVM.AllSpielzeugschiffe.Clear();
                    foreach (var item in SpielzeugschiffVM.FromFile())
                    {
                        _SpielzeugschiffeVM.AllSpielzeugschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = SpielzeugschiffVM.DeleteToFile(_SpielzeugschiffeVM.ActiveSpielzeugschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_SpielzeugschiffeVM.ActiveSpielzeugschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _SpielzeugschiffeVM.AllSpielzeugschiffe.Clear();
                        foreach (var item in SpielzeugschiffVM.FromFile())
                        {
                            _SpielzeugschiffeVM.AllSpielzeugschiffe.Add(item);
                        }
                    }
                    break;
                case System.Windows.MessageBoxResult.Cancel: break;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
