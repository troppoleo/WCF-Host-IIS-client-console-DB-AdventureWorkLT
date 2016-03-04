//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Runtime.Serialization;
//using System.ServiceModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryShared
{
    [DataContract]
    public class clsProduct
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ProductNumber { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public decimal StandardCost { get; set; }
        [DataMember]
        public decimal ListPrice { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public Nullable<decimal> Weight { get; set; }
        [DataMember]
        public Nullable<int> ProductCategoryID { get; set; }
        [DataMember]
        public Nullable<int> ProductModelID { get; set; }
        [DataMember]
        public System.DateTime SellStartDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> SellEndDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        [DataMember]
        public byte[] ThumbNailPhoto { get; set; }
        [DataMember]
        public string ThumbnailPhotoFileName { get; set; }
        [DataMember]
        public System.Guid rowguid { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
    }
}
