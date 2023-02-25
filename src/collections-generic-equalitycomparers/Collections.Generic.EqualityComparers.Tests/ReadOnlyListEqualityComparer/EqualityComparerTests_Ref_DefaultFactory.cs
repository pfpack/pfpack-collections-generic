using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTests_Ref_DefaultFactory : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_DefaultFactory()
        : base(() => ReadOnlyListEqualityComparer<string?>.Create())
    {
    }
}
