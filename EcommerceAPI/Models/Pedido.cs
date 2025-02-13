namespace EcommerceAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
    }
}
