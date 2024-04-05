using AFZV31_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AFZV31_HFT_2023241.WpfClient
{
    
    public class MainWindowViewModel
    {
        public RestCollection<Annual> Annuals { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        { 
            Annuals = new RestCollection<Annual>("http://localhost:53910/", "annual", "hub");
        }
            
        //        CreateAnnualCommand = new RelayCommand(() =>
        //        {
        //    Annuals.Add(new Annual()
        //    {
        //        AnnualName = SelectedAnnual.AnnualName
        //    });
        //});

      
          

    }


}






