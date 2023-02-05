﻿using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

public sealed class ArrayEqualityComparerTests_CustomFactory_Struct : ArrayEqualityComparerTestsBase<int>
{
    public ArrayEqualityComparerTests_CustomFactory_Struct()
        : base(() => ArrayEqualityComparer<int>.Create(EqualityComparer<int>.Default))
    {
    }
}
