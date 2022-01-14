using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SWCRM.Models;

namespace _SWCRM.ViewModel
{
    public class ListViewModel
    {
        public IEnumerable<Deal> Deal { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}