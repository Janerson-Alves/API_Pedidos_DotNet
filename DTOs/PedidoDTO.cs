using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Pedidos.DTOs
{
    // PedidoDTO é uma classe que representa os dados de um pedido
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<string> Produto { get; set; } = new List<string>();
        public string Status { get; set; }
    }
}

