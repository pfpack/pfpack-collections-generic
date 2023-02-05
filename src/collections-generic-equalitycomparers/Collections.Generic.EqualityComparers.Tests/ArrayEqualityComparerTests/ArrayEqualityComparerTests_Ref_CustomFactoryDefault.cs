using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Ref_CustomFactoryDefault : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_Ref_CustomFactoryDefault()
        : base(() => ArrayEqualityComparer<string>.Create(EqualityComparer<string>.Default))
    {
    }
}
