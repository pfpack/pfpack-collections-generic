using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Struct_CustomFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactory()
        : base(() => ArrayEqualityComparer<int>.Create(CustomEqualityComparer<int>.Default))
    {
    }
}
