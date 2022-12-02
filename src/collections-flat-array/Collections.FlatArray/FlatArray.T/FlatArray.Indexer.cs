﻿namespace System.Collections.Generic;

partial struct FlatArray<T>
{
    public ref readonly T this[int index]
    {
        get
        {
            if (index >= 0 && index < length)
            {
                return ref items![index];
            }

            throw InnerExceptionFactory.IndexOutOfRange(nameof(index), index);
        }
    }
}
