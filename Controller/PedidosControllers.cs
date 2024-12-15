using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Context;
using Pedidos.Entities;
using Pedidos.DTOs;
using Pedidos.DTOs.Pedidos.DTOs;

namespace Pedidos.Controllers
{
    // Rotas para acessar os métodos desse controller
    [ApiController]
    [Route("api/[controller]")]
    // PedidosControllers é uma classe que representa um controller de pedidos
    public class PedidosControllers : ControllerBase
    {
        // Contexto do banco de dados
        //privado para que não seja acessado por outras classes
        private readonly OrganizadorContext _context;
        // Construtor que recebe o contexto do banco de dados
        public PedidosControllers(OrganizadorContext context)
        {
            _context = context;
        }
        //rotas para acessar os métodos desse controller
        // Iniciar um novo pedido
        [HttpPost("iniciar-pedido")]
        // O método IniciarPedido recebe um objeto do tipo PedidoCreateDTO
        public async Task<ActionResult> IniciarPedido(PedidoCreateDTO pedidoCreateDTO)
        {
            // Cria um novo pedido com os dados recebidos na requisição
            var pedido = new Pedido
            {
                Nome = pedidoCreateDTO.Nome,
                Endereco = pedidoCreateDTO.Endereco,
                Telefone = pedidoCreateDTO.Telefone,
                Email = pedidoCreateDTO.Email,
                Produto = string.Empty, // Produto começa vazio
                Status = pedidoCreateDTO.Status
            };
            // Adiciona o pedido ao banco de dados
            _context.Pedidos.Add(pedido);
            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retorna um objeto com os dados do pedido criado
            return CreatedAtAction(nameof(IniciarPedido), new { id = pedido.Id }, new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = new List<string>(), // Produto vazio na resposta inicial
                Status = pedido.Status
            });
        }



        // Adicionar produtos a um pedido
        [HttpPut("adicionar-produtos/{id}")]
        public async Task<ActionResult<PedidoDTO>> AdicionarProduto(int id, [FromBody] IEnumerable<string> produtos)
        {
            // Busca o pedido no banco de dados pelo ID
            var pedido = await _context.Pedidos.FindAsync(id);
            // Se o pedido não existir, retorna um erro 404
            if (pedido == null)
            {
                return NotFound();
            }
            // Se o pedido estiver fechado, retorna um erro 400
            if (pedido.Status == "Fechado")
            {
                return BadRequest("Não é possível adicionar produtos a um pedido fechado.");
            }
            if (pedido.Produto == null)
            {
                return BadRequest("E Necessário adicionar produtos ao pedido.");
            }
            // Adiciona os produtos ao pedido
            pedido.Produto = string.Join(",", produtos);
            //Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Converte o pedido para um PedidoDTO
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = produtos.ToList(),
                Status = pedido.Status
            };

            return Ok(pedidoDTO);
        }


        // Remover produtos de um pedido
        [HttpPut("remover-produtos/{id}")]
        // O método RemoverProduto recebe o ID do pedido e uma lista de produtos a serem removidos
        public async Task<ActionResult<PedidoDTO>> RemoverProduto(int id, List<string> produtos)
        {
            // Busca o pedido no banco de dados pelo ID
            var pedido = await _context.Pedidos.FindAsync(id);
            // Se o pedido não existir, retorna um erro 404
            if (pedido == null)
            {
                return NotFound();
            }

            if (pedido.Status == "Fechado")
            {
                return BadRequest("Não é possível remover produtos de um pedido fechado.");
            }

            // Converte a lista de produtos para uma lista de strings
            var produtosAtuais = pedido.Produto.Split(',').ToList();

            // Remove os produtos passados na requisição
            foreach (var produto in produtos)
            {
                produtosAtuais.Remove(produto);
            }

            // Atualiza a string de produtos no pedido
            pedido.Produto = string.Join(",", produtosAtuais);
            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Converte o pedido para um PedidoDTO
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = produtosAtuais,
                Status = pedido.Status
            };

            return Ok(pedidoDTO);
        }

        // Fechar pedido
        [HttpPut("fechar-pedido/{id}")]
        public async Task<ActionResult<PedidoDTO>> FecharPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Verifica se o pedido contém produtos
            if (string.IsNullOrEmpty(pedido.Produto))
            {
                return BadRequest("Não é possível fechar um pedido sem produtos.");
            }

            // Atualiza o status do pedido para "Fechado"
            pedido.Status = "Fechado";
            //Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Converte o pedido para um PedidoDTO
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = pedido.Produto.Split(',').ToList(),
                Status = pedido.Status
            };

            return Ok(pedidoDTO);
        }

        // Listar todos os pedidos
        [HttpGet("listar-pedidos")]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> ListarPedidos()
        {
            // Obtém todos os pedidos do banco de dados
            var pedidos = await _context.Pedidos.ToListAsync();

            // Converte os pedidos para uma lista de PedidoDTO
            var pedidoDTOs = pedidos.Select(pedido => new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = pedido.Produto.Split(',').ToList(),
                Status = pedido.Status
            }).ToList();

            return Ok(pedidoDTOs);
        }

        // Obter pedido por ID
        [HttpGet("Obter-Pedido-Por-Id/{id}")]
        // O método ObterPedidoPorId recebe o ID do pedido
        public async Task<ActionResult<PedidoDTO>> ObterPedidoPorId(int id)
        {
            // Busca o pedido no banco de dados pelo ID
            var pedido = await _context.Pedidos.FindAsync(id);
            // Se o pedido não existir, retorna um erro 404
            if (pedido == null)
            {
                return NotFound();
            }
            // Converte o pedido para um PedidoDTO
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Nome = pedido.Nome,
                Endereco = pedido.Endereco,
                Telefone = pedido.Telefone,
                Email = pedido.Email,
                Produto = pedido.Produto.Split(',').ToList(),
                Status = pedido.Status
            };
            // Retorna o PedidoDTO
            return Ok(pedidoDTO);
        }
    }
}
