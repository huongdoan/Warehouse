using System;
using System.ComponentModel;

namespace SuiteXamarin
{
    public class ProductExportViewModel : INotifyPropertyChanged
    {
        public string producID = "bb";
        public string barCode ="aa";
        public string description = "cc";
        public DateTime exportDate =DateTime.Now;

        //public void ProductExportViewModel()
        //{

        //}

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("description");
                }
            }
        }

        public string ProductID
        {
            get
            {
                return producID;
            }
            set
            {
                if (producID != value)
                {
                    producID = value;
                    OnPropertyChanged("ProducID");
                }
            }
        }

        public string BarCode
        {
            get
            {
                return barCode;
            }
            set
            {
                if (barCode != value)
                {
                    barCode = value;
                    OnPropertyChanged("BarCode");
                }
            }
        }

        public DateTime ExportDate
        {
            get
            {
                return exportDate;
            }
            set
            {
                if (exportDate != value)
                {
                    exportDate = value;
                    OnPropertyChanged("ExportDate");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
