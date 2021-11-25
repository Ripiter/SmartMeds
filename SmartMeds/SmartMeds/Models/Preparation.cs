using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMeds.Models
{
    public class Preparation
    {
        public Preparation() { }
        public Preparation(TypeAmount _item, int _amount)
        {
            Item = _item;
            Amount = _amount;
        }
        public TypeAmount Item { get; set; }
        public int Amount { get; set; }

    }
        public enum TypeAmount
        {
            g,
            mg,
            ml,
            liters
        }
}
