using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_DefaultInstance : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_DefaultInstance()
        : base(() => ArrayEqualityComparer<string>.Default)
    {
    }
}
