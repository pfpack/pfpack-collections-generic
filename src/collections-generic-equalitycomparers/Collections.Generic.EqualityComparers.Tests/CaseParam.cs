using System.Collections.Generic;
using System.Collections.Immutable;

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

// This class in intended to make xUnit not to merge test cases with collections equal by value.
// There is a difference between the test cases with collections equal by value and by reference.

public sealed record class CaseParamOfArray<T>(T[]? Items);

public sealed record class CaseParamOfIReadOnlyList<T>(IReadOnlyList<T>? Items);

public sealed record class CaseParamOfIList<T>(IList<T>? Items);

public sealed record class CaseParamOfList<T>(List<T>? Items);

public sealed record class CaseParamOfImmutableArray<T>(ImmutableArray<T> Items);

public sealed record class CaseParamOfImmutableArrayNullable<T>(ImmutableArray<T>? Items);
