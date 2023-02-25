using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ArrayEqualityComparer;

public sealed class EqualityComparerTests_Struct_DefaultFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_DefaultFactory()
        : base(() => ArrayEqualityComparer<int?>.Create())
    {
    }
}
