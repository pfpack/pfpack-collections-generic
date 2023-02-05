using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public abstract class ArrayEqualityComparerTestsBase_Ref : ArrayEqualityComparerTestsBase<string>
{
    protected ArrayEqualityComparerTestsBase_Ref(Func<ArrayEqualityComparer<string>> comparerFactory)
        : base(comparerFactory)
    {
    }
}
