using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            //GravarUsandoAdoNet();
            //GravarUsandoEntity();

            /*   RecuperarProdutos();
               Console.WriteLine("\r\nAntes de Deletar:\r\n");
               //DeletarProduto();
               DeletarProdutosFiltrdos();
               Console.WriteLine("\r\nDepois de Deletar:\r\n");
               RecuperarProdutos();
            */


            RecuperarProdutos();
            AtualizarProduto();
            RecuperarProdutos();

        }


       

        private static void GravarUsandoEntity()
        { 
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Câmera Secreta";
            p.Categoria = "Livros";
            p.Preco = 23.99;

            //LojaContext é o contexto da aplicação
            using (var contexto = new LojaContext())
            {
                //Tudo que for feito de manipulação no Banco vai ser passado por uma instância do contexto, neste caso LojaContext
                //Nesse caso, como estamos incluindo um novo registro em Produtos, indicamos a classe e logo depois o método que quero passando o Obj
                //Poderia ser utilizado a função AddRange para adicionar mais de um objeto de forma eficiênte
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var contexto = new LojaContext())
            {
                //Segue a mesma lógica do cadastrar - Solicito a listagem através do método ToList() pelo contexto que é Produtos
                //O ToList converte em uma lista
                IList<Produto> produtos = contexto.Produtos.ToList();
                foreach (Produto produto in produtos)
                {
                    Console.WriteLine("Nome: " + produto.Nome);
                    Console.WriteLine("Categoria: " + produto.Categoria);
                    Console.WriteLine("Preço: R$" + produto.Preco);
                    Console.WriteLine("\r\n");
                }
            }
        }


        private static void DeletarProduto()
        {
           using(var contexto = new LojaContext())
            {
                IList<Produto> lista = contexto.Produtos.ToList();
                Console.WriteLine("Removendo o produto " + lista[1].Nome + "...");
                contexto.Produtos.Remove(lista[1]);
                
                contexto.SaveChanges();
            }
        }

        private static void DeletarProdutosFiltrdos()
        {
            using (var contexto = new LojaContext())
            {
                IList<Produto> lista = contexto.Produtos.Where(x => x.Nome == "Harry Potter e a Câmera Secreta").ToList();
                foreach (Produto produto in lista)
                {
                    contexto.Produtos.Remove(produto);

                }
                contexto.SaveChanges();
            }
        }

        private static void AtualizarProduto()
        {
            using (var contexto = new LojaContext())
            {
                try
                {
                    IList<Produto> produto = contexto.Produtos.Where(x => x.Nome == "Harry Potter e a Câmera Secreta").ToList();

                    produto[0].Nome = "Harry Potter e a Câmera Secreta - Versão Extendida";

                    contexto.Produtos.Update(produto[0]);

                    contexto.SaveChanges();

                }
                catch (Exception e)
                {

                    Console.WriteLine("Ocorreu um erro");
                    throw;
                }
            }
        }




        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
