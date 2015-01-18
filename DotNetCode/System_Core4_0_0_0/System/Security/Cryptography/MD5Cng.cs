﻿// Type: System.Security.Cryptography.MD5Cng
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System;
using System.Security.Permissions;

namespace System.Security.Cryptography
{
  [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
  public sealed class MD5Cng : MD5
  {
    private BCryptHashAlgorithm m_hashAlgorithm;

    public MD5Cng()
    {
      if (CryptoConfig.AllowOnlyFipsAlgorithms)
        throw new InvalidOperationException(SR.GetString("Cryptography_NonCompliantFIPSAlgorithm"));
      this.m_hashAlgorithm = new BCryptHashAlgorithm(CngAlgorithm.MD5, "Microsoft Primitive Provider");
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing)
          return;
        this.m_hashAlgorithm.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    public override void Initialize()
    {
      this.m_hashAlgorithm.Initialize();
    }

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
      this.m_hashAlgorithm.HashCore(array, ibStart, cbSize);
    }

    protected override byte[] HashFinal()
    {
      return this.m_hashAlgorithm.HashFinal();
    }
  }
}
