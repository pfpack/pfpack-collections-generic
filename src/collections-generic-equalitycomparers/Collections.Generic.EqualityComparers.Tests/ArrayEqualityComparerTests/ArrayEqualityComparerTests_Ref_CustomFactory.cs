using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_Ref_CustomFactory : ArrayEqualityComparerTestsBase_Ref
{
    public ArrayEqualityComparerTests_Ref_CustomFactory()
        : base(() => ArrayEqualityComparer<string>.Create(CustomEqualityComparer<string>.Default))
    {
    }
}
