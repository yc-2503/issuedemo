using NetCorePal.Extensions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Domain.Extensions;

public class AggregateRoot<TKey>:Entity<TKey>, IAggregateRoot where TKey : notnull
{
}
