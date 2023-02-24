﻿using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Ref_CustomFactoryNull : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryNull()
        : base(() => ArrayEqualityComparer<string>.Create(null))
    {
    }
}