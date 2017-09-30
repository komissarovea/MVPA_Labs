using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Lab8.Model
{
    public class Car : INotifyPropertyChanged
    {
        #region Properties

        public int Id { get; set; }

        public string Firm { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public virtual ObservableCollection<Specification> Specifications { get; set; }

        #endregion

        public Car()
        {
            Specifications = new ObservableCollection<Specification>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Methods

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return String.Format("{0}. {1} {2} ({3})", this.Id, this.Firm ?? "<Unknown firm>", this.Make ?? "<Unknown make>", this.Year);
        }

        #endregion
    }
}
