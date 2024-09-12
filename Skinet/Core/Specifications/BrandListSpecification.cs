using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification()
    {
        AddSelct(x => x.Brand);
        ApplyDistinct();
    }
}
