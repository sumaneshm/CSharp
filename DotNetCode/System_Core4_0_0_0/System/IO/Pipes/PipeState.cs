﻿// Type: System.IO.Pipes.PipeState
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System;

namespace System.IO.Pipes
{
  [Serializable]
  internal enum PipeState
  {
    WaitingToConnect,
    Connected,
    Broken,
    Disconnected,
    Closed,
  }
}
