using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Entities
{
    // Pedido é uma classe que representa um pedido feito por um cliente
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [DisplayName("Produto")]
        public string Produto { get; set; }
        public string Status { get; set; }
    }

}