﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SophosSolutions.Models
{
    public partial class DetalleVentum
    {
        public int IdDetalle { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCliente { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
