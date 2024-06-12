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
    public class RuderschiffeVM : PropertyChangedClass
    {
        public AddCmdRuderschiffe AddCmdRuderschiffe { get; set; }
        public DeleteCmdRuderschiffe DeleteCmdRuderschiffe { get; set; }
        public RuderschiffeVM()
        {
            AllRuderschiffe = new ObservableCollection<RuderschiffVM>();
            foreach (var item in RuderschiffVM.FromFile())
            {
                AllRuderschiffe.Add(item);
            }
            if (AllRuderschiffe.Count > 0)
                SelectedRuderschiff = AllRuderschiffe.First();
            else SelectedRuderschiff = new RuderschiffVM();
            ActiveRuderschiff = new RuderschiffVM();
            ActiveRuderschiff = GenerateRandomSchiff();

            // Commands
            AddCmdRuderschiffe = new AddCmdRuderschiffe(this);
            DeleteCmdRuderschiffe = new DeleteCmdRuderschiffe(this);
        }

        private ObservableCollection<RuderschiffVM> _allRuderschiffe;
        public ObservableCollection<RuderschiffVM> AllRuderschiffe
        {
            get { return _allRuderschiffe; }
            set
            {
                _allRuderschiffe = value;
                OnPropertyChanged();
            }
        }

        private RuderschiffVM _selectedRuderschiff;
        public RuderschiffVM SelectedRuderschiff
        {
            get { return _selectedRuderschiff; }
            set
            {
                _selectedRuderschiff = value;
                if (_activeRuderschiff == null) _activeRuderschiff = new RuderschiffVM();
                if(value != null)
                {
                    _activeRuderschiff.Name = value.Name;
                    _activeRuderschiff.Laenge = value.Laenge;
                    _activeRuderschiff.Baujahr = value.Baujahr;
                    _activeRuderschiff.Ruderanzahl = value.Ruderanzahl;
                    _activeRuderschiff.Flagge = value.Flagge;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveRuderschiff");
            }
        }

        private RuderschiffVM _activeRuderschiff;
        public RuderschiffVM ActiveRuderschiff
        {
            get { return _activeRuderschiff; }
            set
            {
                _activeRuderschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllRuderschiffe");
            }
        }

        static public RuderschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            RuderschiffVM ruderschiffVM = new RuderschiffVM();
            ruderschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            ruderschiffVM.Laenge = random.Next(10, 400);
            ruderschiffVM.Baujahr = new DateTime(random.Next(1858, DateTime.Now.Year - 1), random.Next(1, 12), random.Next(1, 28));
            ruderschiffVM.Ruderanzahl = random.Next(1, 10);
            var flagge = Enum.GetValues(typeof(Flagge));
            ruderschiffVM.Flagge = (Flagge)flagge.GetValue(random.Next(1, flagge.Length - 1));
            return ruderschiffVM;
        }
    }

    public class AddCmdRuderschiffe : ICommand
    {
        private RuderschiffeVM _RuderschiffeVM;

        public AddCmdRuderschiffe(RuderschiffeVM RuderschiffeVM)
        {
            _RuderschiffeVM = RuderschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _RuderschiffeVM.ActiveRuderschiff.Name != null && _RuderschiffeVM.ActiveRuderschiff.Name != "" &&
                _RuderschiffeVM.ActiveRuderschiff.Laenge > 0 &&
                _RuderschiffeVM.ActiveRuderschiff.Ruderanzahl > 0 &&
                _RuderschiffeVM.ActiveRuderschiff.Flagge > 0
            );
        }

        public void Execute(object? parameter)
        {
            Ruderschiff Ruderschiff = new Ruderschiff()
            {
                Name = _RuderschiffeVM.ActiveRuderschiff.Name,
                Laenge = _RuderschiffeVM.ActiveRuderschiff.Laenge,
                Baujahr = _RuderschiffeVM.ActiveRuderschiff.Baujahr,
                Ruderanzahl = _RuderschiffeVM.ActiveRuderschiff.Ruderanzahl,
                Flagge = _RuderschiffeVM.ActiveRuderschiff.Flagge
            };
            RuderschiffVM.AddToFile(Ruderschiff);

            _RuderschiffeVM.AllRuderschiffe.Clear();
            foreach (var item in RuderschiffVM.FromFile())
            {
                _RuderschiffeVM.AllRuderschiffe.Add(item);
            }

            // reset Values in View
            //_RuderschiffeVM.ActiveRuderschiff.Name = String.Empty;
            //_RuderschiffeVM.ActiveRuderschiff.Laenge = 0;
            //_RuderschiffeVM.ActiveRuderschiff.Baujahr = DateTime.Now;
            //_RuderschiffeVM.ActiveRuderschiff.Ruderanzahl = 0;
            //_RuderschiffeVM.ActiveRuderschiff.Flagge = 0;
            _RuderschiffeVM.ActiveRuderschiff = RuderschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdRuderschiffe : ICommand
    {
        private RuderschiffeVM _RuderschiffeVM;

        public DeleteCmdRuderschiffe(RuderschiffeVM RuderschiffeVM)
        {
            _RuderschiffeVM = RuderschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _RuderschiffeVM.ActiveRuderschiff.Name != null && _RuderschiffeVM.ActiveRuderschiff.Name != "" &&
                _RuderschiffeVM.ActiveRuderschiff.Laenge > 0 &&
                _RuderschiffeVM.ActiveRuderschiff.Ruderanzahl > 0 &&
                _RuderschiffeVM.ActiveRuderschiff.Flagge > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Ruderschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Ruderschiff {_RuderschiffeVM.ActiveRuderschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Ruderschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("ruderschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _RuderschiffeVM.AllRuderschiffe.Clear();
                    foreach (var item in RuderschiffVM.FromFile())
                    {
                        _RuderschiffeVM.AllRuderschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = RuderschiffVM.DeleteToFile(_RuderschiffeVM.ActiveRuderschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_RuderschiffeVM.ActiveRuderschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _RuderschiffeVM.AllRuderschiffe.Clear();
                        foreach (var item in RuderschiffVM.FromFile())
                        {
                            _RuderschiffeVM.AllRuderschiffe.Add(item);
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
