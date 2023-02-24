﻿using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ImmutableArrayEqualityComparer.Nullable;

public sealed class EqualityComparerTests_Ref_CustomFactoryDefault : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactoryDefault()
        : base(() => ListEqualityComparer<string>.Create(EqualityComparer<string>.Default))
    {
    }
}