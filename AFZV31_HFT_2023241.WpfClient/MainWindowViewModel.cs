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
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private Annual selectedAnnual;

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


        public ICommand CreateAnnualCommand { get; set; }

        public ICommand DeleteAnnualCommand { get; set; }

        public ICommand UpdateAnnualCommand { get; set; }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Annuals = new RestCollection<Annual>("http://localhost:6495", "annual", "hub");
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
            }
        }
    }
}
