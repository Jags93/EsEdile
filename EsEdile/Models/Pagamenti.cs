using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsEdile.Models
{
    public class Pagamenti
    {
        public int IdPagamento { get; set; }
        private int IdDipendente { get; set; }
        public DateTime PeriodoDiPagamento { get; set; }
        public decimal Ammontare { get; set; }
        public string Tipo { get; set; }
    }
}