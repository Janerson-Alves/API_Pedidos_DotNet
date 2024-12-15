using System.ComponentModel;
using System.Text.Json.Serialization;


namespace Pedidos.DTOs
{
namespace Pedidos.DTOs
{
    // PedidoCreateDTO é uma classe que representa os dados necessários para criar um novo pedido
    public class PedidoCreateDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [DefaultValue("Aberto")]
        public string Status { get; set; } = "Aberto";
    }
}

}