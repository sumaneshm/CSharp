﻿// Type: System.Linq.Parallel.OrderedGroupByIdentityQueryOperatorEnumerator`3
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: FF46A1FC-D9B9-4455-A224-A9DA86AA1C2B
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll

using System;
using System.Collections.Generic;
using System.Runtime;
using System.Threading;

namespace System.Linq.Parallel
{
  internal sealed class OrderedGroupByIdentityQueryOperatorEnumerator<TSource, TGroupKey, TOrderKey> : OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>
  {
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    internal OrderedGroupByIdentityQueryOperatorEnumerator(QueryOperatorEnumerator<Pair<TSource, TGroupKey>, TOrderKey> source, Func<TSource, TGroupKey> keySelector, IEqualityComparer<TGroupKey> keyComparer, IComparer<TOrderKey> orderComparer, CancellationToken cancellationToken)
      : base(source, keySelector, keyComparer, orderComparer, cancellationToken)
    {
    }

    protected override HashLookup<Wrapper<TGroupKey>, OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData> BuildHashLookup()
    {
      HashLookup<Wrapper<TGroupKey>, OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData> hashLookup = new HashLookup<Wrapper<TGroupKey>, OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData>((IEqualityComparer<Wrapper<TGroupKey>>) new WrapperEqualityComparer<TGroupKey>(this.m_keyComparer));
      Pair<TSource, TGroupKey> currentElement = new Pair<TSource, TGroupKey>();
      TOrderKey currentKey = default (TOrderKey);
      int num = 0;
      while (this.m_source.MoveNext(ref currentElement, ref currentKey))
      {
        if ((num++ & 63) == 0)
          CancellationState.ThrowIfCanceled(this.m_cancellationToken);
        Wrapper<TGroupKey> key = new Wrapper<TGroupKey>(currentElement.Second);
        OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData groupKeyData = (OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData) null;
        if (hashLookup.TryGetValue(key, ref groupKeyData))
        {
          if (this.m_orderComparer.Compare(currentKey, groupKeyData.m_orderKey) < 0)
            groupKeyData.m_orderKey = currentKey;
        }
        else
        {
          groupKeyData = new OrderedGroupByQueryOperatorEnumerator<TSource, TGroupKey, TSource, TOrderKey>.GroupKeyData(currentKey, key.Value, this.m_orderComparer);
          hashLookup.Add(key, groupKeyData);
        }
        groupKeyData.m_grouping.Add(currentElement.First, currentKey);
      }
      for (int index = 0; index < hashLookup.Count; ++index)
        hashLookup[index].Value.m_grouping.DoneAdding();
      return hashLookup;
    }
  }
}
