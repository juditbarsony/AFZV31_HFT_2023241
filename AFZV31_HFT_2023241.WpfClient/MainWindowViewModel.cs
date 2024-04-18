using AFZV31_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AFZV31_HFT_2023241.WpfClient
{
    public class MainWindowViewModel: ObservableRecipient
    {
        private string errorMessage;

      

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Annual> Annuals{ get; set; }
        public RestCollection<Area> Areas { get; set; }
        public RestCollection<Order> Orders { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private Annual selectedAnnual;
        private Area selectedArea;
        private Order selectedOrder;

        public Annual SelectedAnnual
        {
            get { return selectedAnnual; }
            set
            {
                if (value != null)
                {
                    selectedAnnual = new Annual()
                    {
                        AnnualName = value.AnnualName,
                        AnnualId = value.AnnualId
                    };
                    OnPropertyChanged();
                    (DeleteAnnualCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Area SelectedArea
        {
            get { return selectedArea; }
            set
            {
                if (value != null)
                {
                    selectedArea = new Area()
                    {
                        AreaSize = value.AreaSize,
                        AreaId = value.AreaId
                    };
                    OnPropertyChanged();
                    (DeleteAreaCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (value != null)
                {
                    selectedOrder = new Order()
                    {
                        OrderCompany = value.OrderCompany,
                        OrderId = value.OrderId
                    };
                    OnPropertyChanged();
                    (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAnnualCommand { get; set; }

        public ICommand DeleteAnnualCommand { get; set; }

        public ICommand UpdateAnnualCommand { get; set; }

        public ICommand CreateOrderCommand { get; set; }

        public ICommand DeleteOrderCommand { get; set; }

        public ICommand UpdateOrderCommand { get; set; }

        public ICommand CreateAreaCommand { get; set; }

        public ICommand DeleteAreaCommand { get; set; }

        public ICommand UpdateAreaCommand { get; set; }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Annuals = new RestCollection<Annual>("http://localhost:6495/", "annual", "hub");
                Areas = new RestCollection<Area>("http://localhost:6495/", "area", "hub");
                Orders = new RestCollection<Order>("http://localhost:6495/", "order", "hub");

                //ANNUAL
                CreateAnnualCommand = new RelayCommand(() =>
                {
                    Annuals.Add(new Annual()
                    {
                        AnnualName = SelectedAnnual.AnnualName
                    });
                });

                UpdateAnnualCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Annuals.Update(SelectedAnnual);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAnnualCommand = new RelayCommand(() =>
                {
                    Annuals.Delete(SelectedAnnual.AnnualId);
                },
                () =>
                {
                    return SelectedAnnual != null;
                });
                SelectedAnnual = new Annual();

                //AREA
                CreateAreaCommand = new RelayCommand(() =>
                {
                    Areas.Add(new Area()
                    {
                        AreaSize = SelectedArea.AreaSize
                    });
                });

                UpdateAreaCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Areas.Update(SelectedArea);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAreaCommand = new RelayCommand(() =>
                {
                    Areas.Delete(SelectedArea.AreaId);
                },
                () =>
                {
                    return SelectedArea != null;
                });
                SelectedArea = new Area();

                //ORDER

                CreateOrderCommand = new RelayCommand(() =>
                {
                    Orders.Add(new Order()
                    {
                        OrderCompany = SelectedOrder.OrderCompany
                    });
                });

                UpdateOrderCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Orders.Update(SelectedOrder);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteOrderCommand = new RelayCommand(() =>
                {
                    Orders.Delete(SelectedOrder.OrderId);
                },
                () =>
                {
                    return SelectedOrder != null;
                });
                SelectedOrder = new Order();

            }
        }
    }
}
