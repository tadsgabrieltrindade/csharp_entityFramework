using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    //Essa classe é definida como contexto. 
    //O contexto da aplicação é o local na qual é indicado ao Entity Framework as classes que irá fazer parte para o Mapeamento Objeto-Relacional
    //Essa classe deve herda de DbContext - API do Entity Framework para utilização de funções já prontas

    public class LojaContext : DbContext
    {
        //Indicação das classes que fazeram parte do mapeamento - para isso é utilizado uma propriedade que representa um conjunto de objs das classes
        //A parametrização em DbSet indica a classe e os seus atributos que serão utilizados para criar a tabela. Já o nome da tabela é o 'Produtos'´o nome da variável. 
        public DbSet<Produto> Produtos { get; set; }


        public LojaContext() { }
        //Utilização de Injeção de Dependência para que o código fique flexível ao tipo de banco de dados - Mysql, mssql ...
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        //Esta classe tbm precisa definir qual é o banco de dados e o seu local. Isso é feito a partir de um evento de configuração
        //Para isso, sobreescrevendo o método de DbContext OnConfiguring
        //Nesse método há um construtor de opções, indicamos a string de conexão 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Caso as opções já estiverem configuradas, não precisamos passar o banco, caso contrário passamos 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            }
        }




    }
}