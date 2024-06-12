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
    public class DampfschiffeVM : PropertyChangedClass
    {
        public AddCmdDampfschiffe AddCmdDampfschiffe { get; set; }
        public DeleteCmdDampfschiffe DeleteCmdDampfschiffe { get; set; }
        public DampfschiffeVM()
        {
            AllDampfschiffe = new ObservableCollection<DampfschiffVM>();
            foreach (var item in DampfschiffVM.FromFile())
            {
                AllDampfschiffe.Add(item);
            }
            if (AllDampfschiffe.Count > 0)
                SelectedDampfschiff = AllDampfschiffe.First();
            else SelectedDampfschiff = new DampfschiffVM();
            ActiveDampfschiff = new DampfschiffVM();
            ActiveDampfschiff = GenerateRandomSchiff();

            // Commands
            AddCmdDampfschiffe = new AddCmdDampfschiffe(this);
            DeleteCmdDampfschiffe = new DeleteCmdDampfschiffe(this);
        }

        private ObservableCollection<DampfschiffVM> _allDampfschiffe;
        public ObservableCollection<DampfschiffVM> AllDampfschiffe
        {
            get { return _allDampfschiffe; }
            set
            {
                _allDampfschiffe = value;
                OnPropertyChanged();
            }
        }

        private DampfschiffVM _selectedDampfschiff;
        public DampfschiffVM SelectedDampfschiff
        {
            get { return _selectedDampfschiff; }
            set
            {
                _selectedDampfschiff = value;
                if (_activeDampfschiff == null) _activeDampfschiff = new DampfschiffVM();
                if(value != null)
                {
                    _activeDampfschiff.Name = value.Name;
                    _activeDampfschiff.Laenge = value.Laenge;
                    _activeDampfschiff.Baujahr = value.Baujahr;
                    _activeDampfschiff.CO2Ausstoss = value.CO2Ausstoss;
                    _activeDampfschiff.Passagiere = value.Passagiere;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveDampfschiff");
            }
        }

        private DampfschiffVM _activeDampfschiff;
        public DampfschiffVM ActiveDampfschiff
        {
            get { return _activeDampfschiff; }
            set
            {
                _activeDampfschiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllDampfschiffe");
            }
        }

        static public DampfschiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            DampfschiffVM dampfschiffVM = new DampfschiffVM();
            dampfschiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            dampfschiffVM.Laenge = random.Next(10, 400);
            dampfschiffVM.Baujahr = new DateTime(random.Next(1858, DateTime.Now.Year - 1), random.Next(1, 12), random.Next(1, 28));
            dampfschiffVM.CO2Ausstoss = random.Next(1000);
            dampfschiffVM.Passagiere = random.Next(100, 7000);
            return dampfschiffVM;
        }
    }

    public class AddCmdDampfschiffe : ICommand
    {
        private DampfschiffeVM _DampfschiffeVM;

        public AddCmdDampfschiffe(DampfschiffeVM DampfschiffeVM)
        {
            _DampfschiffeVM = DampfschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _DampfschiffeVM.ActiveDampfschiff.Name != null && _DampfschiffeVM.ActiveDampfschiff.Name != "" &&
                _DampfschiffeVM.ActiveDampfschiff.Laenge > 0 &&
                _DampfschiffeVM.ActiveDampfschiff.CO2Ausstoss >= 0 &&
                _DampfschiffeVM.ActiveDampfschiff.Passagiere >= 0
            );
        }

        public void Execute(object? parameter)
        {
            Dampfschiff Dampfschiff = new Dampfschiff()
            {
                Name = _DampfschiffeVM.ActiveDampfschiff.Name,
                Laenge = _DampfschiffeVM.ActiveDampfschiff.Laenge,
                Baujahr = _DampfschiffeVM.ActiveDampfschiff.Baujahr,
                CO2Ausstoss = _DampfschiffeVM.ActiveDampfschiff.CO2Ausstoss,
                Passagiere = _DampfschiffeVM.ActiveDampfschiff.Passagiere
            };
            DampfschiffVM.AddToFile(Dampfschiff);

            _DampfschiffeVM.AllDampfschiffe.Clear();
            foreach (var item in DampfschiffVM.FromFile())
            {
                _DampfschiffeVM.AllDampfschiffe.Add(item);
            }

            // reset Values in View
            //_DampfschiffeVM.ActiveDampfschiff.Name = String.Empty;
            //_DampfschiffeVM.ActiveDampfschiff.Laenge = 0;
            //_DampfschiffeVM.ActiveDampfschiff.Baujahr = DateTime.Now;
            //_DampfschiffeVM.ActiveDampfschiff.CO2Ausstoss = 0;
            //_DampfschiffeVM.ActiveDampfschiff.Passagiere = 0;
            _DampfschiffeVM.ActiveDampfschiff = DampfschiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdDampfschiffe : ICommand
    {
        private DampfschiffeVM _DampfschiffeVM;

        public DeleteCmdDampfschiffe(DampfschiffeVM DampfschiffeVM)
        {
            _DampfschiffeVM = DampfschiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _DampfschiffeVM.ActiveDampfschiff.Name != null && _DampfschiffeVM.ActiveDampfschiff.Name != "" &&
                _DampfschiffeVM.ActiveDampfschiff.Laenge > 0 &&
                _DampfschiffeVM.ActiveDampfschiff.CO2Ausstoss >= 0 &&
                _DampfschiffeVM.ActiveDampfschiff.Passagiere >= 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Dampfschiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Dampfschiff {_DampfschiffeVM.ActiveDampfschiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Dampfschiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("dampfschiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _DampfschiffeVM.AllDampfschiffe.Clear();
                    foreach (var item in DampfschiffVM.FromFile())
                    {
                        _DampfschiffeVM.AllDampfschiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = DampfschiffVM.DeleteToFile(_DampfschiffeVM.ActiveDampfschiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_DampfschiffeVM.ActiveDampfschiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _DampfschiffeVM.AllDampfschiffe.Clear();
                        foreach (var item in DampfschiffVM.FromFile())
                        {
                            _DampfschiffeVM.AllDampfschiffe.Add(item);
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
