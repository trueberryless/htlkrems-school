using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    public class CalcVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public Add Add { get; set; }
        public Subtract Subtract { get; set; }


        private int? number1;
        public int? Number1
        {
            get { return number1; }
            set
            {
                if (number1 != value)
                {                    
                    number1 = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private int? number2;
        public int? Number2
        {
            get { return number2; }
            set
            {
                if (number2 != value)
                {
                    number2 = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private int? erg;
        public int? Erg
        {
            get { return erg; }
            set
            {
                if (erg != value)
                {
                    erg = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public CalcVM()
        {
            Add = new Add(this);
            Subtract = new Subtract(this);
        }
    }
    public class Add : ICommand
    {
        private CalcVM _CalcVM;
        public Add(CalcVM CalcVM)
        {
            this._CalcVM = CalcVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                this._CalcVM.Number1 != null && 
                this._CalcVM.Number2 != null
            );
        }

        public void Execute(object? parameter)
        {
            this._CalcVM.Erg = this._CalcVM.Number1 + this._CalcVM.Number2;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    public class Subtract : ICommand
    {
        private CalcVM _CalcVM;
        public Subtract(CalcVM CalcVM)
        {
            this._CalcVM = CalcVM;
        }

        public bool CanExecute(object? parameter)
        {
            return (
                this._CalcVM.Number1 != null && 
                this._CalcVM.Number2 != null
            );
        }

        public void Execute(object? parameter)
        {
            this._CalcVM.Erg = this._CalcVM.Number1 - this._CalcVM.Number2;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
