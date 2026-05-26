using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Business.Services
{
    public class ProductService
    {//regras de negocio

        private readonly IProdutoRepository _repositorio;

        //readonly -> não vai permitir alteração depois de inicializada

        //declarar um campo privado da Classe que guarda uma referencia
        //a um repositorio, e essa refrencia só pode ser atribuida no construtor 
        //ou na propria declaração

        public ProductService(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;

        }

        //Injenção de dependencia: Em termos práticos a classe ProductService
        //não cria o repositorio, é "alguem de fora" que o vai entregar

        public void AdicionarProduto(string nome, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("O nome não pode ser vazio");
            }
            if (preco <= 0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            //criar um objeto, depois das validações e preencher
            //as suas propriedades
            Produto novo = new Produto();
            novo.Nome = nome;
            novo.Preco = preco;
            _repositorio.Adicionar(novo);
            //a camada de negócio delega a acesso a dados á camada de dados
        }

        public List<Produto> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }

        public Produto? ProcurarProduto(string nome)
        {
            return _repositorio.ObterPorNome(nome);
        }
    }
}
