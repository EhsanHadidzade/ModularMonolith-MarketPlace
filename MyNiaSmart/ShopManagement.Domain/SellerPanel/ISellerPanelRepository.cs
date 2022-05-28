using _0_Framework.Domain;
using ShopManagement.Application.Contract.SellerPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerPanel
{
    public interface ISellerPanelRepository:IRepository<long,SellerPanel>
    {
        List<SellerPanelViewModel> GetList();
    }
}
