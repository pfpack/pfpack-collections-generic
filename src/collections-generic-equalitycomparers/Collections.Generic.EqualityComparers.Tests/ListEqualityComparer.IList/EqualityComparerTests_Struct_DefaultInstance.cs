using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public sealed class EqualityComparerTests_Struct_DefaultInstance : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultInstance()
        : base(() => ListEqualityComparer<int>.Default)
    {
    }
}
