using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAuction.ViewModels;

namespace WPFAuction.Command
{
    internal class AddAuctionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainViewModel _mainViewModel;
        public AddAuctionCommand(MainViewModel mainViewModel) { _mainViewModel = mainViewModel; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ActionDTO action = new ActionDTO(this._mainViewModel.TypedName,this._mainViewModel.TypedDiscount,Convert.ToInt32(this._mainViewModel.SelectedCategory),this._mainViewModel.StartTime,
                this._mainViewModel.EndTime,DateTime.UtcNow,DateTime.UtcNow);
            this._mainViewModel.ActionLogic.actionrep.AddObj(action);
        }
    }
}
