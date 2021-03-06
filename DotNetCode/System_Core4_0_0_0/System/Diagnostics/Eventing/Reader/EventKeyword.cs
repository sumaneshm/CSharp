﻿// Type: System.Diagnostics.Eventing.Reader.EventKeyword
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System.Collections.Generic;
using System.Runtime;
using System.Security.Permissions;

namespace System.Diagnostics.Eventing.Reader
{
  [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
  public sealed class EventKeyword
  {
    private long value;
    private string name;
    private string displayName;
    private bool dataReady;
    private ProviderMetadata pmReference;
    private object syncObject;

    public string Name
    {
      get
      {
        this.PrepareData();
        return this.name;
      }
    }

    public long Value
    {
      [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.value;
      }
    }

    public string DisplayName
    {
      get
      {
        this.PrepareData();
        return this.displayName;
      }
    }

    internal EventKeyword(long value, ProviderMetadata pmReference)
    {
      this.value = value;
      this.pmReference = pmReference;
      this.syncObject = new object();
    }

    internal EventKeyword(string name, long value, string displayName)
    {
      this.value = value;
      this.name = name;
      this.displayName = displayName;
      this.dataReady = true;
      this.syncObject = new object();
    }

    internal void PrepareData()
    {
      if (this.dataReady)
        return;
      lock (this.syncObject)
      {
        if (this.dataReady)
          return;
        IEnumerable<EventKeyword> local_0 = (IEnumerable<EventKeyword>) this.pmReference.Keywords;
        this.name = (string) null;
        this.displayName = (string) null;
        this.dataReady = true;
        foreach (EventKeyword item_0 in local_0)
        {
          if (item_0.Value == this.value)
          {
            this.name = item_0.Name;
            this.displayName = item_0.DisplayName;
            break;
          }
        }
      }
    }
  }
}
