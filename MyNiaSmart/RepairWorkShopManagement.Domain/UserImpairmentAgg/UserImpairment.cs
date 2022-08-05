using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.UserImpairmentAgg
{
    public class UserImpairment:BaseEntity
    {
        public long UserId { get; private set; }
        public long UserDeviceId { get;private set; }
        public string Description { get;private set; }
        public bool HasUserDeviceWarranty { get; private set; }
        public bool IsImpairmentSoftwareBased { get; private set; }
        public DateTime ReportDate { get; private set; }

        public UserImpairment(long userId, long userDeviceId, string description,
            bool hasUserDeviceWarranty, bool isImpairmentSoftwareBased, DateTime reportDate)
        {
            UserId = userId;
            UserDeviceId = userDeviceId;
            Description = description;
            HasUserDeviceWarranty = hasUserDeviceWarranty;
            IsImpairmentSoftwareBased = isImpairmentSoftwareBased;
            ReportDate = reportDate;
        }
    }
}
