using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.List;

public sealed class EqualityComparerTests_Struct_DefaultInstance : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultInstance()
        : base(() => ReadOnlyListEqualityComparer<int>.Default)
    {
    }
}
