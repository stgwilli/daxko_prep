using System;

namespace nothinbutdotnetprep.specs.utility
{
    public interface ISpecification<T>
    {
        bool matches(T item);
    }

    public class Specification<T, PROP> : ISpecification<T>
    {
        readonly Func<T, PROP> property_accessor;
        readonly PROP value;

        public Specification(Func<T, PROP>  property_accessor, PROP value)
        {
            this.property_accessor = property_accessor;
            this.value = value;
        }

        public bool matches(T item)
        {
            return property_accessor(item).Equals(value);
        }
    }

    public class OrSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> spec1;
        readonly ISpecification<T> spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        public bool matches(T item)
        {
            return spec1.matches(item) || spec2.matches(item);
        }
    }

    //public class ChainedSpecification<T> : ISpecification<T>
    //{
    //    readonly ISpecification<T> spec1;
    //    readonly ISpecification<T> spec2;

    //    public ChainedSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    //    {
    //        this.spec1 = spec1;
    //        this.spec2 = spec2;
    //    }

    //    public bool matches(T item1)
    //    {
            
    //    }
    //}
}