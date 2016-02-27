using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Base
{
    public class Base : IObjectWithState, INotifyPropertyChanged
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
    }
}
