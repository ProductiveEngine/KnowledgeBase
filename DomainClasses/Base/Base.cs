using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Base
{
    public class Base : IObjectWithState, INotifyPropertyChanged, IDataErrorInfo
    {
        public Base()
        {
            CreatedDate = DateTime.Now;
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        
        [DataType(DataType.DateTime)]        
        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public State State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "Title":
                        if (string.IsNullOrEmpty(Title))
                        {
                            error = "Title required";
                        }
                        break;                    
                }
                Error = error;
                return (Error);
            }
        }

        private string _Error;

        [NotMapped]
        public string Error
        {
            get { return _Error; }
            private set
            {
                _Error = value;
                OnPropertyChanged("Error");
            }
        }
    }
}
