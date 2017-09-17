using System;

namespace Lab3.AutoLib
{
    public class Car
    {
        #region Properties

        public int Id { get; set; }

        public string Firm { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public int MaxSpeed { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return String.Format("{0}. {1} {2}", this.Id, this.Firm ?? "<Unknown firm>", this.Make ?? "<Unknown make>");
        } 
        
        #endregion
    }
}
