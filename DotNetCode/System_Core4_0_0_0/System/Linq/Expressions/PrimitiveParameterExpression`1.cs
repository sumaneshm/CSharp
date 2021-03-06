﻿// Type: System.Linq.Expressions.PrimitiveParameterExpression`1
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System;

namespace System.Linq.Expressions
{
  internal sealed class PrimitiveParameterExpression<T> : ParameterExpression
  {
    public override sealed Type Type
    {
      get
      {
        return typeof (T);
      }
    }

    internal PrimitiveParameterExpression(string name)
      : base(name)
    {
    }
  }
}
