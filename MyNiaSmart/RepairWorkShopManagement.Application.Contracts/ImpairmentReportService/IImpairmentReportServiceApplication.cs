using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application.Contracts.ImpairmentReportService
{
    public interface IImpairmentReportServiceApplication
    {
        List<ImpairmentReportServiceViewModel> GetListByImpairmentReportId(long impairmentReportId);
    }
}
