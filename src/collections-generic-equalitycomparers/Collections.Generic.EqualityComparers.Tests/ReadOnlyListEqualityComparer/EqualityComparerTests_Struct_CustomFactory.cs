using System.Collections.Generic;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests.ReadOnlyListEqualityComparer;

public sealed class EqualityComparerTests_Struct_CustomFactory : EqualityComparerTestsBase_Struct
{
    public EqualityComparerTests_Struct_CustomFactory()
        : base(() => ReadOnlyListEqualityComparer<int?>.Create(CustomEqualityComparer<int?>.Default))
    {
    }
}
