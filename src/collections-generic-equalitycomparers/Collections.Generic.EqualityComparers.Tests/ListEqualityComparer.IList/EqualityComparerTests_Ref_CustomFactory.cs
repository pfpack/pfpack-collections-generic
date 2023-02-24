﻿using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ListEqualityComparer.IList;

public sealed class EqualityComparerTests_Ref_CustomFactory : EqualityComparerTestsBase_Ref
{
    public EqualityComparerTests_Ref_CustomFactory()
        : base(() => ListEqualityComparer<string>.Create(CustomEqualityComparer<string>.Default))
    {
    }
}