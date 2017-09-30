using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8.Model
{
    public class Car
    {
        #region Properties

        public int Id { get; set; }

        public string Firm { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Specification> Specifications { get; set; }

        #endregion

        public Car()
        {
            Specifications = new List<Specification>();
        }

        #region Methods

        public override string ToString()
        {
            return String.Format("{0}. {1} {2} ({3})", this.Id, this.Firm ?? "<Unknown firm>", this.Make ?? "<Unknown make>", this.Year);
        }

        #endregion
    }
}
