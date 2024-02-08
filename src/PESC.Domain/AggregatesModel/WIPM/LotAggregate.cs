using PESC.Domain.Extensions;
using PESC.Domain.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESC.Domain.AggregatesModel.WIPM
{
    public class LotAggregate : AggregateRoot<string>, IMultiTenant
    {
        public string TenantId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
