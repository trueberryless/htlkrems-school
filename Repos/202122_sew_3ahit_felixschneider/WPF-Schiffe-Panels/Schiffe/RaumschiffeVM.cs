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
    public class RaumschiffeVM : PropertyChangedClass
    {
        public AddCmdRaumschiffe AddCmdRaumschiffe { get; set; }
        public DeleteCmdRaumschiffe DeleteCmdRaumschiffe { get; set; }
        public RaumschiffeVM()
        {
            AllRaumschiffe = new ObservableCollection<RaumschiffVM>();
            foreach (var item in RaumschiffVM.FromFile())
            {
                AllRaumschiffe.Add(item);
            }
            if (AllRaumschiffe.Count > 0)
                SelectedRaumschiff = AllRaumschiffe.First();
            else SelectedRaumschiff = new RaumschiffVM();
            ActiveRaumschiff = new RaumschiffVM();
            ActiveRaumschiff = GenerateRandomSchiff();

            // Commands
            AddCmdRaumschiffe = new AddCmdRaumschiffe(this);
            DeleteCmdRaumschiffe = new DeleteCmdRaumschiffe(this);
        }

        private ObservableCollection<RaumschiffVM> _allRaumschiffe;
        public ObservableCollection<RaumschiffVM> AllRaumschiffe
        {
            get { return _allRaumschiffe; }
            set
            {
                _allRaumschiffe = value;
                OnPropertyChanged();
            }
        }

        private RaumschiffVM _selectedRaumschiff;
        public RaumschiffVM SelectedRaumschiff
        {
            get { return _selectedRaumschiff; }
            set
            {
                _selectedRaumschiff = value;
                if (_activeRaumschiff == null) _activeRaumschiff = new RaumschiffVM();
                if (value != null)
                {
                    _activeRaumschiff.Name = value.Name;
                    _activeRaumschiff.Laenge = value.Laenge;
                    _activeRaumschiff.Baujahr = value.Baujahr;
                    _activeRaumschiff.MaxGeschwindigkeit = value.MaxGeschwindigkeit;
                    _activeRaumschiff.AnzahlLaserkanonen = value.AnzahlLaserkanonen;
                    _activeRaumschiff.AnzahlFluegel = value.AnzahlFluegel;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveRaumschiff");
            }
        }

        private RaumschiffVM _activeRaumschiff;
        public RaumschiffVM ActiveRaumschiff
        {
            get { return _activeRaumschiff; }
            set
            {
                _activeRaumschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllRaumschiffe");
            }
        }

        static public RaumschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            RaumschiffVM raumschiffVM = new RaumschiffVM();
            raumschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            raumschiffVM.Laenge = random.Next(100, 10000);
            raumschiffVM.Baujahr = new DateTime(random.Next(3000, 4000), random.Next(1, 12), random.Next(1, 28));
            raumschiffVM.MaxGeschwindigkeit = random.Next(1, 5) == 1 ? random.Next(100, 1000) : random.Next(100, 299792458);
            int laserkanonen = random.Next(1, 1000);
            raumschiffVM.AnzahlLaserkanonen = laserkanonen % 2 != 0 ? laserkanonen + 1: laserkanonen;
            int fluegel = random.Next(1, 100);
            raumschiffVM.AnzahlFluegel = fluegel % 2 != 0 ? fluegel + 1 : fluegel;
            return raumschiffVM;
        }
    }

    public class AddCmdRaumschiffe : ICommand
    {
        private RaumschiffeVM _RaumschiffeVM;

        public AddCmdRaumschiffe(RaumschiffeVM RaumschiffeVM)
        {
            _RaumschiffeVM = RaumschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _RaumschiffeVM.ActiveRaumschiff.Name != null && _RaumschiffeVM.ActiveRaumschiff.Name != "" &&
                _RaumschiffeVM.ActiveRaumschiff.Laenge > 0 &&
                _RaumschiffeVM.ActiveRaumschiff.MaxGeschwindigkeit >= 0 &&
                _RaumschiffeVM.ActiveRaumschiff.AnzahlLaserkanonen > 0 &&
                _RaumschiffeVM.ActiveRaumschiff.AnzahlFluegel > 0
            );
        }

        public void Execute(object? parameter)
        {
            Raumschiff Raumschiff = new Raumschiff()
            {
                Name = _RaumschiffeVM.ActiveRaumschiff.Name,
                Laenge = _RaumschiffeVM.ActiveRaumschiff.Laenge,
                Baujahr = _RaumschiffeVM.ActiveRaumschiff.Baujahr,
                MaxGeschwindigkeit = _RaumschiffeVM.ActiveRaumschiff.MaxGeschwindigkeit,
                AnzahlLaserkanonen = _RaumschiffeVM.ActiveRaumschiff.AnzahlLaserkanonen,
                AnzahlFluegel = _RaumschiffeVM.ActiveRaumschiff.AnzahlFluegel
            };
            RaumschiffVM.AddToFile(Raumschiff);

            _RaumschiffeVM.AllRaumschiffe.Clear();
            foreach (var item in RaumschiffVM.FromFile())
            {
                _RaumschiffeVM.AllRaumschiffe.Add(item);
            }

            // reset Values in View
            //_RaumschiffeVM.ActiveRaumschiff.Name = String.Empty;
            //_RaumschiffeVM.ActiveRaumschiff.Laenge = 0;
            //_RaumschiffeVM.ActiveRaumschiff.Baujahr = DateTime.Now;
            //_RaumschiffeVM.ActiveRaumschiff.MaxGeschwindigkeit = 0;
            //_RaumschiffeVM.ActiveRaumschiff.AnzahlLaserkanonen = 0;
            //_RaumschiffeVM.ActiveRaumschiff.AnzahlFluegel = 0;
            _RaumschiffeVM.ActiveRaumschiff = RaumschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdRaumschiffe : ICommand
    {
        private RaumschiffeVM _RaumschiffeVM;

        public DeleteCmdRaumschiffe(RaumschiffeVM RaumschiffeVM)
        {
            _RaumschiffeVM = RaumschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _RaumschiffeVM.ActiveRaumschiff.Name != null && _RaumschiffeVM.ActiveRaumschiff.Name != "" &&
                _RaumschiffeVM.ActiveRaumschiff.Laenge > 0 &&
                _RaumschiffeVM.ActiveRaumschiff.MaxGeschwindigkeit >= 0 &&
                _RaumschiffeVM.ActiveRaumschiff.AnzahlLaserkanonen > 0 &&
                _RaumschiffeVM.ActiveRaumschiff.AnzahlFluegel > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Raumschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Raumschiff {_RaumschiffeVM.ActiveRaumschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Raumschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("raumschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _RaumschiffeVM.AllRaumschiffe.Clear();
                    foreach (var item in RaumschiffVM.FromFile())
                    {
                        _RaumschiffeVM.AllRaumschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = RaumschiffVM.DeleteToFile(_RaumschiffeVM.ActiveRaumschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_RaumschiffeVM.ActiveRaumschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _RaumschiffeVM.AllRaumschiffe.Clear();
                        foreach (var item in RaumschiffVM.FromFile())
                        {
                            _RaumschiffeVM.AllRaumschiffe.Add(item);
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
