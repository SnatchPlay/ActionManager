using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLogic;
using DTO;
using WPFAuction.Command;
using WPFAuction;

namespace WPFAuction.ViewModels
{
    public class MainViewModel: ViewModel, INotifyPropertyChanged, IDataErrorInfo
    {
        private ActionLogic actionLogic;
        private ViewModel _selectedViewModel;
        private List<ActionDTO> actionList;
        private List<Goods> goodsList;
        private List<string> types;
        private ActionDTO action;
        private List<string> propertyNames;
        

        public EditCommand EditCommand { get; set; }
        public FutureCommand FutureCommand { get; set; }
        public ActiveCommand ActiveCommand { get; set; }
        public PastCommand PastCommand { get; set; }
        public AllCommand AllCommand { get; set; }
        public AddGoodsCommand AddGoodsCommand { get; set; }
        public Action GetFuture { get; set; }
        public Action EditValue { get; set; }
        public Action GetPast { get; set; }
        public Action GetActive { get; set; }
        public Action GetAll { get; set; } 
        public Action AddAction { get; set; }
        public Action AddGoods { get; set; }
        
        private string Name;
        private float Discount;
        private DateTime startTime;
        private DateTime endTime;
        private string category;
        private int ActionId;
        private string selectedProperty;
        private Goods selectedgoods;

        
        #region Properties
        private string NewValue;
        public List<string> TypeNames
        {
            get => types;
            set { types = value;
                OnPropertyChanged("TypeNames");
            }
        }
        public string GetNewValue
        {
            get { return NewValue; }
            set { NewValue = value;
                OnPropertyChanged("GetNewValue");
            }
        }

        public string SelectedProperty
        {
            get { return selectedProperty; }
            set { selectedProperty = value;
                OnPropertyChanged("SelectedProperty");
            }
        }
        public Goods SelectedGoods
        {
            get { return selectedgoods; }
            set
            {
                selectedgoods = value;
                OnPropertyChanged("SelectedGoods");
            }            
        }
        public int SelectedActionId
        {
            get { return ActionId; }
            set { ActionId = value;
                OnPropertyChanged("SelectedActionId");
            }
        }
        public ActionDTO SelectedAction
        {
            get { return action; }
            set
            {
                action = value;
                OnPropertyChanged("SelectedPhone");
            }
        }
        
        public string TypedName
        {
            get { return this.Name; }
            set
            {
                this.Name = value;
                OnPropertyChanged("TypedName");
            }
        }
        public float TypedDiscount
        {
            get { return this.Discount; }
            set
            {
                this.Discount = value;
                OnPropertyChanged("TypedDiscount");
            }
        }

        public DateTime StartTime
        {
            get => this.startTime;
            set
            {
                this.startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        public DateTime EndTime
        {
            get => this.endTime;
            set
            {
                this.endTime = value;
                OnPropertyChanged("EndTime");
            }
        }
        public string SelectedCategory
        {
            get => this.category;
            set
            {
                this.category = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public void EditAction()
        {
            if(selectedProperty=="Name")
            {
                actionLogic.UpdateActionName(NewValue, this.SelectedActionId);
            }
            else if (selectedProperty == "Discount")
            {
                actionLogic.UpdateActionDiscount(float.Parse(NewValue), this.SelectedActionId);
            }
            else if (selectedProperty =="Start Time")
            {
                actionLogic.UpdateActionStartTime(Convert.ToDateTime(NewValue), this.SelectedActionId);
            }
            else
            {
                actionLogic.UpdateActionEndTime(Convert.ToDateTime(NewValue),this.SelectedActionId);
            }
            
        }
        
        #endregion

        public List<ActionDTO> ActionList
        {
            get => actionList;
            set
            {
                actionList = value;
                OnPropertyChanged(nameof(ActionList));
            }
        }
        public List<Goods> GoodsList
        {
            get => goodsList;
            set
            {
                goodsList = value;
                OnPropertyChanged("GoodsList");
            }
        }
        public List<string> PropertyName { get => propertyNames;
            set { propertyNames = value;
                OnPropertyChanged("PropertyName");
            }
        }
        public void AllActions()
        {
            actionList=actionLogic.actionrep.GetEnteties();
        }
        public void FutureActions()
        {
            
            actionList = actionLogic.GetFutureAction();
        }
        public void PastActions()
        {
            actionList=actionLogic.GetPastAction();
        }
        public void ActiveActions()
        {
            actionList= actionLogic.GetActiveAction();
            
        }
        public void AddGood()
        {
            actionLogic.supplyRep.GetObj(selectedgoods.ActionId = ActionId);
        }
       

        public MainViewModel(ActionLogic actionLogic)
        {
            this.actionLogic = actionLogic;
            this.goodsList = actionLogic.avalaibleSupply();
            this.types=actionLogic.TypeNames();
            propertyNames = actionLogic.PropertyNames();
            FutureCommand = new FutureCommand(this);
            ActiveCommand = new ActiveCommand(this); 
            PastCommand = new PastCommand(this);
            AllCommand = new AllCommand(this);
            EditCommand = new EditCommand(this);
            AddGoodsCommand = new AddGoodsCommand(this);
            AddGoods = AddGood;
            EditValue = EditAction;
            GetAll = AllActions;
            GetActive = ActiveActions;
            GetFuture = FutureActions;
            GetPast=PastActions;
           
            

            actionList= actionLogic.actionrep.GetEnteties();
        }
        public ICommand UpdateViewCommand { get; set; }
        public ActionLogic ActionLogic
        {
            get => this.actionLogic; 
            set => this.actionLogic = value; 
        }
        public ViewModel SelectedViewModel
        {
            get => this._selectedViewModel;
            set
            {
                this._selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public string this[string columnName] => throw new NotImplementedException();

       

        public string Error => throw new NotImplementedException();
    }
}
