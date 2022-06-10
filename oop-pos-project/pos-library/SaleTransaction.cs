using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pos_library.classes;
namespace pos_library
{
    public class SaleTransaction : Transaction
    {
        public List<SaleItem> SaleItems
        {
            get => default(int);
            set
            {
            }
        }

        public int DiscountItem
        {
            get => default(int);
            set
            {
            }
        }

        public int TaxItem
        {
            get => default(int);
            set
            {
            }
        }
    }

    public class SaleItem : ILineItem
    {
    }

    public class NoSaleItem : ILineItem
    {
    }

    public class TaxItem : ILineItem
    {
    }

    public class DiscountItem : ILineItem
    {
    }

    public class NoSaleTransaction : Transaction
    {
        public int NoSaleItem
        {
            get => default(int);
            set
            {
            }
        }
    }
}