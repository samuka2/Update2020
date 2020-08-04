using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //um departamento pode ter varios vendedores
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //construtor sem argumentos
        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        //Adicionando o vendedor ao departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //total de vendas do departamento
        public double TotalSalles(DateTime initial, DateTime final)
        {
            //retorna a lista de da soma de vendas de um departamenteo x, usando o método de soma da classe seller vendedores
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }

    }
}
