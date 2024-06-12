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
    public class FischereischiffeVM : PropertyChangedClass
    {
        public AddCmdFischereischiffe AddCmdFischereischiffe { get; set; }
        public DeleteCmdFischereischiffe DeleteCmdFischereischiffe { get; set; }
        public FischereischiffeVM()
        {
            AllFischereischiffe = new ObservableCollection<FischereischiffVM>();
            foreach (var item in FischereischiffVM.FromFile())
            {
                AllFischereischiffe.Add(item);
            }
            if (AllFischereischiffe.Count > 0)
                SelectedFischereischiff = AllFischereischiffe.First();
            else SelectedFischereischiff = new FischereischiffVM();
            ActiveFischereischiff = new FischereischiffVM();
            ActiveFischereischiff = GenerateRandomSchiff();

            // Commands
            AddCmdFischereischiffe = new AddCmdFischereischiffe(this);
            DeleteCmdFischereischiffe = new DeleteCmdFischereischiffe(this);
        }

        private ObservableCollection<FischereischiffVM> _allFischereischiffe;
        public ObservableCollection<FischereischiffVM> AllFischereischiffe
        {
            get { return _allFischereischiffe; }
            set
            {
                _allFischereischiffe = value;
                OnPropertyChanged();
            }
        }

        private FischereischiffVM _selectedFischereischiff;
        public FischereischiffVM SelectedFischereischiff
        {
            get { return _selectedFischereischiff; }
            set
            {
                _selectedFischereischiff = value;
                if (_activeFischereischiff == null) _activeFischereischiff = new FischereischiffVM();
                if(value != null)
                {
                    _activeFischereischiff.Name = value.Name;
                    _activeFischereischiff.Laenge = value.Laenge;
                    _activeFischereischiff.Baujahr = value.Baujahr;
                    _activeFischereischiff.Netzgroesse = value.Netzgroesse;
                    _activeFischereischiff.Fischlagerkapazitaet = value.Fischlagerkapazitaet;
                }
                OnPropertyChanged();
                OnPropertyChanged("ActiveFischereischiff");
            }
        }

        private FischereischiffVM _activeFischereischiff;
        public FischereischiffVM ActiveFischereischiff
        {
            get { return _activeFischereischiff; }
            set
            {
                _activeFischereischiff = value;
                OnPropertyChanged();
                OnPropertyChanged("AllFischereischiffe");
            }
        }

        static public FischereischiffVM GenerateRandomSchiff()
        {
            Random random = new Random();
            FischereischiffVM fischereischiffVM = new FischereischiffVM();
            fischereischiffVM.Name = ASchiff.Schiffsnamen[random.Next(0, ASchiff.Schiffsnamen.Length - 1)];
            fischereischiffVM.Laenge = random.Next(10, 400);
            fischereischiffVM.Baujahr = new DateTime(random.Next(1858, DateTime.Now.Year - 1), random.Next(1, 12), random.Next(1, 28));
            fischereischiffVM.Netzgroesse = random.Next(1500);
            fischereischiffVM.Fischlagerkapazitaet = random.Next(100, 70000);
            return fischereischiffVM;
        }
    }

    public class AddCmdFischereischiffe : ICommand
    {
        private FischereischiffeVM _FischereischiffeVM;

        public AddCmdFischereischiffe(FischereischiffeVM FischereischiffeVM)
        {
            _FischereischiffeVM = FischereischiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _FischereischiffeVM.ActiveFischereischiff.Name != null && _FischereischiffeVM.ActiveFischereischiff.Name != "" &&
                _FischereischiffeVM.ActiveFischereischiff.Laenge > 0 &&
                _FischereischiffeVM.ActiveFischereischiff.Netzgroesse > 0 &&
                _FischereischiffeVM.ActiveFischereischiff.Fischlagerkapazitaet > 0
            );
        }

        public void Execute(object? parameter)
        {
            Fischereischiff Fischereischiff = new Fischereischiff()
            {
                Name = _FischereischiffeVM.ActiveFischereischiff.Name,
                Laenge = _FischereischiffeVM.ActiveFischereischiff.Laenge,
                Baujahr = _FischereischiffeVM.ActiveFischereischiff.Baujahr,
                Netzgroesse = _FischereischiffeVM.ActiveFischereischiff.Netzgroesse,
                Fischlagerkapazitaet = _FischereischiffeVM.ActiveFischereischiff.Fischlagerkapazitaet
            };
            FischereischiffVM.AddToFile(Fischereischiff);

            _FischereischiffeVM.AllFischereischiffe.Clear();
            foreach (var item in FischereischiffVM.FromFile())
            {
                _FischereischiffeVM.AllFischereischiffe.Add(item);
            }

            // reset Values in View
            //_FischereischiffeVM.ActiveFischereischiff.Name = String.Empty;
            //_FischereischiffeVM.ActiveFischereischiff.Laenge = 0;
            //_FischereischiffeVM.ActiveFischereischiff.Baujahr = DateTime.Now;
            //_FischereischiffeVM.ActiveFischereischiff.Netzgroesse = 0;
            //_FischereischiffeVM.ActiveFischereischiff.Fischlagerkapazitaet = 0;
            _FischereischiffeVM.ActiveFischereischiff = FischereischiffeVM.GenerateRandomSchiff();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class DeleteCmdFischereischiffe : ICommand
    {
        private FischereischiffeVM _FischereischiffeVM;

        public DeleteCmdFischereischiffe(FischereischiffeVM FischereischiffeVM)
        {
            _FischereischiffeVM = FischereischiffeVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                _FischereischiffeVM.ActiveFischereischiff.Name != null && _FischereischiffeVM.ActiveFischereischiff.Name != "" &&
                _FischereischiffeVM.ActiveFischereischiff.Laenge > 0 &&
                _FischereischiffeVM.ActiveFischereischiff.Netzgroesse > 0 &&
                _FischereischiffeVM.ActiveFischereischiff.Fischlagerkapazitaet > 0
            );
        }

        public void Execute(object? parameter)
        {
            System.Windows.MessageBoxResult rs = System.Windows.MessageBox.Show(
                $"Yes: \tSie möchten ALLE Fischereischiffe LÖSCHEN!\n" +
                $"No: \tSie möchten NUR Fischereischiff {_FischereischiffeVM.ActiveFischereischiff.Name} LÖSCHEN!\n" +
                $"\n" +
                $"Cancel: \tSie möchten GAR KEINE Fischereischiffe LÖSCHEN!",
                "DeleteItem",
                System.Windows.MessageBoxButton.YesNoCancel,
                System.Windows.MessageBoxImage.Question,
                System.Windows.MessageBoxResult.No);
            switch (rs)
            {
                case System.Windows.MessageBoxResult.Yes:
                    using (StreamWriter sw = new StreamWriter("fischereischiffe.csv"))
                    {
                        sw.Write("");
                    }
                    _FischereischiffeVM.AllFischereischiffe.Clear();
                    foreach (var item in FischereischiffVM.FromFile())
                    {
                        _FischereischiffeVM.AllFischereischiffe.Add(item);
                    }
                    break;
                case System.Windows.MessageBoxResult.No:
                    bool deleted = FischereischiffVM.DeleteToFile(_FischereischiffeVM.ActiveFischereischiff);
                    if (!deleted)
                        System.Windows.MessageBox.Show($"{_FischereischiffeVM.ActiveFischereischiff.Name} konnte nicht gelöscht werden...\nWir glauben, dass es nicht gefunden wurde. Löschen Sie bitte nur Schiffe, die bereits existieren!",
                            "Mission failed",
                            System.Windows.MessageBoxButton.OK,
                            System.Windows.MessageBoxImage.Error);
                    else
                    {
                        _FischereischiffeVM.AllFischereischiffe.Clear();
                        foreach (var item in FischereischiffVM.FromFile())
                        {
                            _FischereischiffeVM.AllFischereischiffe.Add(item);
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
