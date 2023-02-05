using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ArrayEqualityComparerTestsBase_Struct : ArrayEqualityComparerTestsBase<int>
{
    protected ArrayEqualityComparerTestsBase_Struct(Func<ArrayEqualityComparer<int>> comparerFactory)
        : base(comparerFactory)
    {
    }
}
