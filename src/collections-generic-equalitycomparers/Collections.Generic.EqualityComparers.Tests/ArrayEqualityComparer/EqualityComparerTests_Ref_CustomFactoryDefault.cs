using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_CustomFactoryDefault : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryDefault()
        : base(() => ArrayEqualityComparer<string?>.Create(EqualityComparer<string?>.Default))
    {
    }
}
