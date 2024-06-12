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
    public class FrachtschiffeVM : PropertyChangedClass
    {
        public AddCmdFrachtschiffe AddCmdFrachtschiffe { get; set; }
        public DeleteCmdFrachtschiffe DeleteCmdFrachtschiffe { get; set; }
        public FrachtschiffeVM()
        {
            AllFrachtschiffe = new ObservableCollection<FrachtschiffVM>();
            foreach (var item in FrachtschiffVM.FromFile())
            {
                AllFrachtschiffe.Add(item);
            }
            if (AllFrachtschiffe.Count > 0)
                SelectedFrachtschiff = AllFrachtschiffe.First();
            else SelectedFrachtschiff = new FrachtschiffVM();
            ActiveFrachtschiff = new FrachtschiffVM();
            ActiveFrachtschiff = GenerateRandomSchiff();

            // Commands
            AddCmdFrachtschiffe = new AddCmdFrachtschiffe(this);
            DeleteCmdFrachtschiffe = new DeleteCmdFrachtschiffe(this);
        }

        private ObservableCollection<FrachtschiffVM> _allFrachtschiffe;
        public ObservableCollection<FrachtschiffVM> AllFrachtschiffe
        {
            get { return _allFrachtschiffe; }
            set
            {
                _allFrachtschiffe = value;
                OnPropertyChanged();
            }
        }

        private FrachtschiffVM _selectedFrachtschiff;
        public FrachtschiffVM SelectedFrachtschiff
        {
            get { return _selectedFrachtschiff; }
            set
            {
                _selectedFrachtschiff = value;
                if (_activeFrachtschiff == null) _activeFrachtschiff = new FrachtschiffVM();
                if(value != null)
                {
                    _activeFrachtschiff.Name = value.Name;
                    _activeFrachtschiff.Laenge = value.Laenge;
                    _activeFrachtschiff.Baujahr = value.Baujahr;
                    _activeFrachtschiff.RouteVon = value.RouteVon;
                    _activeFrachtschiff.RouteNach = value.RouteNach;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveFrachtschiff");
            }
        }

        private FrachtschiffVM _activeFrachtschiff;
        public FrachtschiffVM ActiveFrachtschiff
        {
            get { return _activeFrachtschiff; }
            set
            {
                _activeFrachtschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllFrachtschiffe");
            }
        }

        static public FrachtschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            FrachtschiffVM frachtschiffVM = new FrachtschiffVM();
            frachtschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            frachtschiffVM.Laenge = random.Next(10, 400);
            frachtschiffVM.Baujahr = new DateTime(random.Next(1858, DateTime.Now.Year - 1), random.Next(1, 12), random.Next(1, 28));
            var hafen = Enum.GetValues(typeof(Hafen));
            frachtschiffVM.RouteVon = (Hafen)hafen.GetValue(random.Next(1, hafen.Length - 1));
            do
            {
                frachtschiffVM.RouteNach = (Hafen)hafen.GetValue(random.Next(1, hafen.Length - 1));
            } while (frachtschiffVM.RouteVon == frachtschiffVM.RouteNach);
            return frachtschiffVM;
        }
    }

    public class AddCmdFrachtschiffe : ICommand
    {
        private FrachtschiffeVM _FrachtschiffeVM;

        public AddCmdFrachtschiffe(FrachtschiffeVM FrachtschiffeVM)
        {
            _FrachtschiffeVM = FrachtschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _FrachtschiffeVM.ActiveFrachtschiff.Name != null && _FrachtschiffeVM.ActiveFrachtschiff.Name != "" &&
                _FrachtschiffeVM.ActiveFrachtschiff.Laenge > 0 &&
                _FrachtschiffeVM.ActiveFrachtschiff.RouteVon > 0 &&
                _FrachtschiffeVM.ActiveFrachtschiff.RouteNach > 0
            );
        }

        public void Execute(object? parameter)
        {
            Frachtschiff Frachtschiff = new Frachtschiff()
            {
                Name = _FrachtschiffeVM.ActiveFrachtschiff.Name,
                Laenge = _FrachtschiffeVM.ActiveFrachtschiff.Laenge,
                Baujahr = _FrachtschiffeVM.ActiveFrachtschiff.Baujahr,
                RouteVon = _FrachtschiffeVM.ActiveFrachtschiff.RouteVon,
                RouteNach = _FrachtschiffeVM.ActiveFrachtschiff.RouteNach
            };
            FrachtschiffVM.AddToFile(Frachtschiff);

            _FrachtschiffeVM.AllFrachtschiffe.Clear();
            foreach (var item in FrachtschiffVM.FromFile())
            {
                _FrachtschiffeVM.AllFrachtschiffe.Add(item);
            }

            // reset Values in View
            //_FrachtschiffeVM.ActiveFrachtschiff.Name = String.Empty;
            //_FrachtschiffeVM.ActiveFrachtschiff.Laenge = 0;
            //_FrachtschiffeVM.ActiveFrachtschiff.Baujahr = DateTime.Now;
            //_FrachtschiffeVM.ActiveFrachtschiff.RouteVon = 0;
            //_FrachtschiffeVM.ActiveFrachtschiff.RouteNach = 0;
            _FrachtschiffeVM.ActiveFrachtschiff = FrachtschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdFrachtschiffe : ICommand
    {
        private FrachtschiffeVM _FrachtschiffeVM;

        public DeleteCmdFrachtschiffe(FrachtschiffeVM FrachtschiffeVM)
        {
            _FrachtschiffeVM = FrachtschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _FrachtschiffeVM.ActiveFrachtschiff.Name != null && _FrachtschiffeVM.ActiveFrachtschiff.Name != "" &&
                _FrachtschiffeVM.ActiveFrachtschiff.Laenge > 0 &&
                _FrachtschiffeVM.ActiveFrachtschiff.RouteVon > 0 &&
                _FrachtschiffeVM.ActiveFrachtschiff.RouteNach > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Frachtschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Frachtschiff {_FrachtschiffeVM.ActiveFrachtschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Frachtschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("frachtschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _FrachtschiffeVM.AllFrachtschiffe.Clear();
                    foreach (var item in FrachtschiffVM.FromFile())
                    {
                        _FrachtschiffeVM.AllFrachtschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = FrachtschiffVM.DeleteToFile(_FrachtschiffeVM.ActiveFrachtschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_FrachtschiffeVM.ActiveFrachtschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _FrachtschiffeVM.AllFrachtschiffe.Clear();
                        foreach (var item in FrachtschiffVM.FromFile())
                        {
                            _FrachtschiffeVM.AllFrachtschiffe.Add(item);
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
