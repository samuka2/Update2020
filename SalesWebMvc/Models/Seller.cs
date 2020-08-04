using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        //instanciando um vendedor só pode ter um departamento
        public Department department { get; set; }
        //um vendedor pode ter varias vendas
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //Construtor sem argumentos
        public Seller()
        {
        }
        //Construtor com Argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            this.department = department;
        }
        //adicionando venda
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        //removenda a venda
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        //método para somar as vendas em determinado periodo do vendedor
        public double TotalSales(DateTime initial, DateTime final)
        {
            //retorna a soma das vendas (lista Sales) entre as datas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
