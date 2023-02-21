using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }

        public static explicit operator Produto(List<Produto> v)
        {
            throw new NotImplementedException();
        }

        //public static explicit operator Produto(IList<Produto> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}