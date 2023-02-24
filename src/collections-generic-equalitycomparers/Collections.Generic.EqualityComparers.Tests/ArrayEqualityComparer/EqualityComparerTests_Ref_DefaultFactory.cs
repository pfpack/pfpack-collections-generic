using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_DefaultFactory : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_DefaultFactory()
        : base(() => ArrayEqualityComparer<string>.Create())
    {
    }
}
