using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.ViewModels
{
    public class LayoutTestModel
    {
        public string Title { get; set; }


        private string _subtitle ;
        public string SubTitle
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_subtitle))
                    return "";
                return " - " + _subtitle;
            }
            set { _subtitle = value; }
        }

    }
}