using System;
using System.Collections.Generic;

#nullable disable

namespace SophosSolutions.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int IdVenta { get; set; }
        public int? IdCliente { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int? Total { get; set; }
        public DateTime? FechaVenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
