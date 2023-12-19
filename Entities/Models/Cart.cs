using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines
        {
            get; set;
        }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        
        public virtual void AddItem(Phone phone, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Phone.PhoneID.Equals(phone.PhoneID))
            .FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Phone = phone,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }
        public virtual void UpdateItemQuantity(Phone product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Phone.PhoneID == product.PhoneID).FirstOrDefault();
            if (line != null)
            {
                line.Quantity = quantity;
            }
        }
        public virtual void RemoveLine(Phone phone) =>
            Lines.RemoveAll(l => l.Phone.PhoneID.Equals(phone.PhoneID));
        public decimal ComputeTotalQuantity() =>
            Lines.Sum(e => e.Quantity);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Phone.PhonePrice * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}
