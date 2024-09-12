using System;
using Core.Entities;

namespace Core.Specifications;

public class TypeListSpecification : BaseSpecification<Product, string>
{
    public TypeListSpecification()
    {
        AddSelct(x => x.Type);
        ApplyDistinct();
    }

}
