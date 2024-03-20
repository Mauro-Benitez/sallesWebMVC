using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }




        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tem que ter entre {2} e {1} caracteres" )]
        [Display(Name = "Nome")]
        public string Name { get; set; }


        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Adicione um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Range(100.0, 50000.0,ErrorMessage ="{0} o valor tem que estar entre {1} e {2}")]
        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
        public double BaseSalary { get; set; }



       
        [Display(Name = "Departamento")]
        public Department Department { get; set; }




        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = departament;
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales (SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
        }
          







    }
}
