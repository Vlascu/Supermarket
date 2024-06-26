﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManager.Model.EntityLayer
{
    public class Receipt : BasePropertyChanged
    {
        private int? receiptID;
        public int? ReceiptID
        {
            get { return receiptID; }
            set
            {
                receiptID = value;
                NotifyPropertyChanged("ReceiptID");
            }
        }

        private int? monthOfIssuing;
        public int? MonthOfIssuing
        {
            get { return monthOfIssuing; }
            set
            {
                monthOfIssuing = value;
                NotifyPropertyChanged("MonthOfIssuing");
            }
        }

        private int? dayOfIssuing;
        public int? DayOfIssuing
        {
            get { return dayOfIssuing; }
            set
            {
                dayOfIssuing = value;
                NotifyPropertyChanged("DayOfIssuing");
            }
        }
        private int? yearOfIssuing;
        public int? YearOfIssuing
        {
            get { return yearOfIssuing; }
            set
            {
                yearOfIssuing = value;
                NotifyPropertyChanged("YearOfIssuing");
            }
        }

        private string cashierName;
        public string CashierName
        {
            get { return cashierName; }
            set
            {
                cashierName = value;
                NotifyPropertyChanged("CashierName");
            }
        }

        private decimal amountReceived;
        public decimal AmountReceived
        {
            get { return amountReceived; }
            set
            {
                amountReceived = value;
                NotifyPropertyChanged("AmountReceived");
            }
        }
    }
}
