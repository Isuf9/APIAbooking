using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class CanAddExplorer
    {
        public string ExplorerIdFk { get; set; }
        public string ClientIdFk { get; set; }

        public virtual ClientServices ClientIdFkNavigation { get; set; }
        public virtual Explore ExplorerIdFkNavigation { get; set; }
    }
}
