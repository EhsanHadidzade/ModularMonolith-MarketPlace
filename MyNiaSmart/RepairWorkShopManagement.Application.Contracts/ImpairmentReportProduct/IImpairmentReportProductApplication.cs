using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.ImpairmentReportProduct
{
    public interface IImpairmentReportProductApplication
    {
        List<ImpairmentReportProductViewModel> GetListByImpairmentReportId(long impairmentReportId);

    }
}
