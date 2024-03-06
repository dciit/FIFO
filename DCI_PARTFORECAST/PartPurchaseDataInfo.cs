using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class PartPurchaseDataInfo
    {
        private string p_NONEED = "";
        private string p_NONEED_REASON = "";
        private string p_FISY = "";
        private string p_REV = "";
        private string p_PARTNO = "";
        private string p_CM = "";
        private string p_PARTNAME = "";
        private string p_WHUNIT = "";
        private string p_ROUTE = "";
        private string p_CATMAT = "";
        private string p_ORDER_TYPE = "";
        private string p_VENDER = "";
        private string p_VDNAME = "";
        private double p_UNIT_PRICE = 0;
        private string p_IVUNIT = "";
        private string p_CURRENCY = "";
        private string p_NONEED_BY = "";

        public string P_NONEED
        {
            get
            {
                return p_NONEED;
            }

            set
            {
                p_NONEED = value;
            }
        }

        public string P_FISY
        {
            get
            {
                return p_FISY;
            }

            set
            {
                p_FISY = value;
            }
        }

        public string P_REV
        {
            get
            {
                return p_REV;
            }

            set
            {
                p_REV = value;
            }
        }

        public string P_PARTNO
        {
            get
            {
                return p_PARTNO;
            }

            set
            {
                p_PARTNO = value;
            }
        }

        public string P_CM
        {
            get
            {
                return p_CM;
            }

            set
            {
                p_CM = value;
            }
        }

        public string P_PARTNAME
        {
            get
            {
                return p_PARTNAME;
            }

            set
            {
                p_PARTNAME = value;
            }
        }

        public string P_WHUNIT
        {
            get
            {
                return p_WHUNIT;
            }

            set
            {
                p_WHUNIT = value;
            }
        }

        public string P_ROUTE
        {
            get
            {
                return p_ROUTE;
            }

            set
            {
                p_ROUTE = value;
            }
        }

        public string P_CATMAT
        {
            get
            {
                return p_CATMAT;
            }

            set
            {
                p_CATMAT = value;
            }
        }

        public string P_ORDER_TYPE
        {
            get
            {
                return p_ORDER_TYPE;
            }

            set
            {
                p_ORDER_TYPE = value;
            }
        }

        public string P_VENDER
        {
            get
            {
                return p_VENDER;
            }

            set
            {
                p_VENDER = value;
            }
        }

        public string P_VDNAME
        {
            get
            {
                return p_VDNAME;
            }

            set
            {
                p_VDNAME = value;
            }
        }

        public double P_UNIT_PRICE
        {
            get
            {
                return p_UNIT_PRICE;
            }

            set
            {
                p_UNIT_PRICE = value;
            }
        }

        public string P_IVUNIT
        {
            get
            {
                return p_IVUNIT;
            }

            set
            {
                p_IVUNIT = value;
            }
        }

        public string P_CURRENCY
        {
            get
            {
                return p_CURRENCY;
            }

            set
            {
                p_CURRENCY = value;
            }
        }

        public string P_NONEED_REASON
        {
            get
            {
                return p_NONEED_REASON;
            }

            set
            {
                p_NONEED_REASON = value;
            }
        }

        public string P_NONEED_BY
        {
            get
            {
                return p_NONEED_BY;
            }

            set
            {
                p_NONEED_BY = value;
            }
        }
    }
}
