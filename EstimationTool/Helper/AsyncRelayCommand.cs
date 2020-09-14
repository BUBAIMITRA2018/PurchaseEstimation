using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EstimationTool.Helper
{
    class AsyncRelayCommand : ICommand
    {

        private Func<object, Task> _action;
        private Task _task;

        public AsyncRelayCommand(Func<object, Task> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _task == null || _task.IsCompleted;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            _task = _action(parameter);
            OnCanExecuteChanged();
            await _task;
            OnCanExecuteChanged();
        }

        private void OnCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }


        //private ICommand myCommand;
        //public ICommand MyCommand
        //{
        //    get { return myCommand ?? (myCommand = new AsyncRelayCommand(p => Task.Factory.StartNew(doStuff))); }
        //}

        //private void doStuff()
        //{
        //    System.Threading.Thread.Sleep(5000);
        //}


        //private ICommand myCommand2;
        //public ICommand MyCommand2
        //{
        //    get { return myCommand2 ?? (myCommand2 = new AsyncRelayCommand(p => doStuff2())); }
        //}
        //private async Task doStuff2()
        //{
        //    await Task.Delay(5000);
        //}



    }

}
