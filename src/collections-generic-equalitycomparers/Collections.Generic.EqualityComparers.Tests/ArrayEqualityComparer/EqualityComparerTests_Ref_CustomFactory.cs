using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_CustomFactory : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactory()
        : base(() => ArrayEqualityComparer<string?>.Create(CustomEqualityComparer<string?>.Default))
    {
    }
}
