using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8.Model
{
    public class Specification
    {
        #region Properties

        public int Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int MaxSpeed { get; set; }

        public int CarID { get; set; }

        public virtual Car Car { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return String.Format("{1} ({2}$, {3}km/h)", this.Id, this.Name ?? "<Unknown>", this.Price, this.MaxSpeed);
        }

        #endregion
    }
}
