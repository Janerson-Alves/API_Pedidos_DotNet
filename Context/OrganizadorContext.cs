using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedidos.Entities;

namespace Pedidos.Context
{
    // OrganizadorContext herda de DbContext para representar o contexto do banco de dados
    public class OrganizadorContext : DbContext
    {
        // Construtor que recebe um objeto do tipo DbContextOptions para configurar o contexto
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
        }
        // DbSet de Pedido que será mapeado para uma tabela no banco de dados
        public DbSet<Pedido> Pedidos { get; set; }
        
    }
}