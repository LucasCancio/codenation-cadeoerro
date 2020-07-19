using System;
using System.Collections.Generic;
using System.Text;

namespace CadeOErro.Domain.Filter
{
    public class FilterParameters
    {
        public string orderBy { get; set; }
        public FiledStatus filedStatus { get; set; } = FiledStatus.All;
    }

    public enum FiledStatus
    {
        Unfiled, //0
        Filed,   //1
        All      //2
        
    }
}
