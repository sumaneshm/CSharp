﻿// Type: System.Security.Cryptography.CngPropertyOptions
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System;

namespace System.Security.Cryptography
{
  [Flags]
  public enum CngPropertyOptions
  {
    None = 0,
    CustomProperty = 1073741824,
    Persist = -2147483648,
  }
}
