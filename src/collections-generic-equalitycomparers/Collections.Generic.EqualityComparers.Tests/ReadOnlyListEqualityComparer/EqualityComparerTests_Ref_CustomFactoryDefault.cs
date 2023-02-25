using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTests_Ref_CustomFactoryDefault : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryDefault()
        : base(() => ReadOnlyListEqualityComparer<string?>.Create(EqualityComparer<string?>.Default))
    {
    }
}
