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
    public class SegelschiffeVM : PropertyChangedClass
    {
        public AddCmdSegelschiffe AddCmdSegelschiffe { get; set; }
        public DeleteCmdSegelschiffe DeleteCmdSegelschiffe { get; set; }
        public SegelschiffeVM()
        {
            AllSegelschiffe = new ObservableCollection<SegelschiffVM>();
            foreach (var item in SegelschiffVM.FromFile())
            {
                AllSegelschiffe.Add(item);
            }
            if (AllSegelschiffe.Count > 0)
                SelectedSegelschiff = AllSegelschiffe.First();
            else SelectedSegelschiff = new SegelschiffVM();
            ActiveSegelschiff = new SegelschiffVM();
            ActiveSegelschiff = GenerateRandomSchiff();

            // Commands
            AddCmdSegelschiffe = new AddCmdSegelschiffe(this);
            DeleteCmdSegelschiffe = new DeleteCmdSegelschiffe(this);
        }

        private ObservableCollection<SegelschiffVM> _allSegelschiffe;
        public ObservableCollection<SegelschiffVM> AllSegelschiffe
        {
            get { return _allSegelschiffe; }
            set
            {
                _allSegelschiffe = value;
                OnPropertyChanged();
            }
        }

        private SegelschiffVM _selectedSegelschiff;
        public SegelschiffVM SelectedSegelschiff
        {
            get { return _selectedSegelschiff; }
            set
            {
                _selectedSegelschiff = value;
                if (_activeSegelschiff == null) _activeSegelschiff = new SegelschiffVM();
                if(value != null)
                {
                    _activeSegelschiff.Name = value.Name;
                    _activeSegelschiff.Laenge = value.Laenge;
                    _activeSegelschiff.Baujahr = value.Baujahr;
                    _activeSegelschiff.Segelhoehe = value.Segelhoehe;
                    _activeSegelschiff.Segelmaterial = value.Segelmaterial;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveSegelschiff");
            }
        }

        private SegelschiffVM _activeSegelschiff;
        public SegelschiffVM ActiveSegelschiff
        {
            get { return _activeSegelschiff; }
            set
            {
                _activeSegelschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllSegelschiffe");
            }
        }

        static public SegelschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            SegelschiffVM segelschiffVM = new SegelschiffVM();
            segelschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            segelschiffVM.Laenge = random.Next(10, 400);
            segelschiffVM.Baujahr = new DateTime(random.Next(1858, DateTime.Now.Year - 1), random.Next(1, 12), random.Next(1, 28));
            segelschiffVM.Segelhoehe = random.Next(1, 20);
            var segelmaterial = Enum.GetValues(typeof(Segelmaterial));
            segelschiffVM.Segelmaterial = (Segelmaterial)segelmaterial.GetValue(random.Next(1, segelmaterial.Length - 1));
            return segelschiffVM;
        }
    }

    public class AddCmdSegelschiffe : ICommand
    {
        private SegelschiffeVM _SegelschiffeVM;

        public AddCmdSegelschiffe(SegelschiffeVM SegelschiffeVM)
        {
            _SegelschiffeVM = SegelschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _SegelschiffeVM.ActiveSegelschiff.Name != null && _SegelschiffeVM.ActiveSegelschiff.Name != "" &&
                _SegelschiffeVM.ActiveSegelschiff.Laenge > 0 &&
                _SegelschiffeVM.ActiveSegelschiff.Segelhoehe > 0 &&
                _SegelschiffeVM.ActiveSegelschiff.Segelmaterial > 0
            );
        }

        public void Execute(object? parameter)
        {
            Segelschiff Segelschiff = new Segelschiff()
            {
                Name = _SegelschiffeVM.ActiveSegelschiff.Name,
                Laenge = _SegelschiffeVM.ActiveSegelschiff.Laenge,
                Baujahr = _SegelschiffeVM.ActiveSegelschiff.Baujahr,
                Segelhoehe = _SegelschiffeVM.ActiveSegelschiff.Segelhoehe,
                Segelmaterial = _SegelschiffeVM.ActiveSegelschiff.Segelmaterial
            };
            SegelschiffVM.AddToFile(Segelschiff);

            _SegelschiffeVM.AllSegelschiffe.Clear();
            foreach (var item in SegelschiffVM.FromFile())
            {
                _SegelschiffeVM.AllSegelschiffe.Add(item);
            }

            // reset Values in View
            //_SegelschiffeVM.ActiveSegelschiff.Name = String.Empty;
            //_SegelschiffeVM.ActiveSegelschiff.Laenge = 0;
            //_SegelschiffeVM.ActiveSegelschiff.Baujahr = DateTime.Now;
            //_SegelschiffeVM.ActiveSegelschiff.Segelhoehe = 0;
            //_SegelschiffeVM.ActiveSegelschiff.Segelmaterial = 0;
            _SegelschiffeVM.ActiveSegelschiff = SegelschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdSegelschiffe : ICommand
    {
        private SegelschiffeVM _SegelschiffeVM;

        public DeleteCmdSegelschiffe(SegelschiffeVM SegelschiffeVM)
        {
            _SegelschiffeVM = SegelschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _SegelschiffeVM.ActiveSegelschiff.Name != null && _SegelschiffeVM.ActiveSegelschiff.Name != "" &&
                _SegelschiffeVM.ActiveSegelschiff.Laenge > 0 &&
                _SegelschiffeVM.ActiveSegelschiff.Segelhoehe > 0 &&
                _SegelschiffeVM.ActiveSegelschiff.Segelmaterial > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Segelschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Segelschiff {_SegelschiffeVM.ActiveSegelschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Segelschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("segelschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _SegelschiffeVM.AllSegelschiffe.Clear();
                    foreach (var item in SegelschiffVM.FromFile())
                    {
                        _SegelschiffeVM.AllSegelschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = SegelschiffVM.DeleteToFile(_SegelschiffeVM.ActiveSegelschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_SegelschiffeVM.ActiveSegelschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _SegelschiffeVM.AllSegelschiffe.Clear();
                        foreach (var item in SegelschiffVM.FromFile())
                        {
                            _SegelschiffeVM.AllSegelschiffe.Add(item);
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
