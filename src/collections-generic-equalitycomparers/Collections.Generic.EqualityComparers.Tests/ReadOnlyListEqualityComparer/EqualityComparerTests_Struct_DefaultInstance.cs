using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTests_Struct_DefaultInstance : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultInstance()
        : base(() => ReadOnlyListEqualityComparer<int>.Default)
    {
    }
}
