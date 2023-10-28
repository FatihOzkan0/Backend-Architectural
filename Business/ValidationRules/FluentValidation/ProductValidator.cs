using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()     //Kurallar Constructor içine yazılır.
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);   //O dan büyük olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);   //UnitPrice minimum 1 olmalı categoryId eşit 1 olduğunda.
            RuleFor(p => p.ProductName).Must(StartA).WithMessage("Ürünler A harfi ile başlamalı");     //WithMessage ile kendi isteğime göre mesaj döndürebilirim.
        }

        private bool StartA(string arg)
        {
            return arg.StartsWith("A");     //Kendim kural yazdım A ile başlıcak.
        }
    }
}
