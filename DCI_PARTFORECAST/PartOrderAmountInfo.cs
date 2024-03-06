using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class PartOrderAmountInfo
    {
        private string p_FISY = "";
        private string p_REV = "";
        private string p_PARTNO = "";
        private string p_CM = "";
        private string p_PARTNAME = "";
        private string p_ROUTE = "";
        private string p_CATMAT = "";
        private string p_ORDER_TYPE = "";
        private double p_ORDER_RATIO = 0;
        private string p_VENDER = "";
        private string p_VDNAME = "";
        private double p_PRICE = 0;
        private string p_CURRENCY = "";
        private double p_EXRATE = 0;
        private double p_APR_IV_QTY = 0;
        private double p_MAY_IV_QTY = 0;
        private double p_JUN_IV_QTY = 0;
        private double p_JUL_IV_QTY = 0;
        private double p_AUG_IV_QTY = 0;
        private double p_SEP_IV_QTY = 0;
        private double p_OCT_IV_QTY = 0;
        private double p_NOV_IV_QTY = 0;
        private double p_DEC_IV_QTY = 0;
        private double p_JAN_IV_QTY = 0;
        private double p_FEB_IV_QTY = 0;
        private double p_MAR_IV_QTY = 0;
        private string p_IVUNIT = "";
        private double p_APR_AMT = 0;
        private double p_MAY_AMT = 0;
        private double p_JUN_AMT = 0;
        private double p_JUL_AMT = 0;
        private double p_AUG_AMT = 0;
        private double p_SEP_AMT = 0;
        private double p_OCT_AMT = 0;
        private double p_NOV_AMT = 0;
        private double p_DEC_AMT = 0;
        private double p_JAN_AMT = 0;
        private double p_FEB_AMT = 0;
        private double p_MAR_AMT = 0;
        private string p_CREATE_BY = "";
        private DateTime p_CREAET_DATE = new DateTime();
        private string p_NONEED_BIT = "";
        private string p_NONEED_REASON = "";
        private DateTime p_NONEED_DATE = new DateTime();
        private string p_NONEED_BY = "";

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

        public double P_PRICE
        {
            get
            {
                return p_PRICE;
            }

            set
            {
                p_PRICE = value;
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

        public double P_EXRATE
        {
            get
            {
                return p_EXRATE;
            }

            set
            {
                p_EXRATE = value;
            }
        }

        public double P_APR_IV_QTY
        {
            get
            {
                return p_APR_IV_QTY;
            }

            set
            {
                p_APR_IV_QTY = value;
            }
        }

        public double P_MAY_IV_QTY
        {
            get
            {
                return p_MAY_IV_QTY;
            }

            set
            {
                p_MAY_IV_QTY = value;
            }
        }

        public double P_JUN_IV_QTY
        {
            get
            {
                return p_JUN_IV_QTY;
            }

            set
            {
                p_JUN_IV_QTY = value;
            }
        }

        public double P_JUL_IV_QTY
        {
            get
            {
                return p_JUL_IV_QTY;
            }

            set
            {
                p_JUL_IV_QTY = value;
            }
        }

        public double P_AUG_IV_QTY
        {
            get
            {
                return p_AUG_IV_QTY;
            }

            set
            {
                p_AUG_IV_QTY = value;
            }
        }

        public double P_SEP_IV_QTY
        {
            get
            {
                return p_SEP_IV_QTY;
            }

            set
            {
                p_SEP_IV_QTY = value;
            }
        }

        public double P_OCT_IV_QTY
        {
            get
            {
                return p_OCT_IV_QTY;
            }

            set
            {
                p_OCT_IV_QTY = value;
            }
        }

        public double P_NOV_IV_QTY
        {
            get
            {
                return p_NOV_IV_QTY;
            }

            set
            {
                p_NOV_IV_QTY = value;
            }
        }

        public double P_DEC_IV_QTY
        {
            get
            {
                return p_DEC_IV_QTY;
            }

            set
            {
                p_DEC_IV_QTY = value;
            }
        }

        public double P_JAN_IV_QTY
        {
            get
            {
                return p_JAN_IV_QTY;
            }

            set
            {
                p_JAN_IV_QTY = value;
            }
        }

        public double P_FEB_IV_QTY
        {
            get
            {
                return p_FEB_IV_QTY;
            }

            set
            {
                p_FEB_IV_QTY = value;
            }
        }

        public double P_MAR_IV_QTY
        {
            get
            {
                return p_MAR_IV_QTY;
            }

            set
            {
                p_MAR_IV_QTY = value;
            }
        }

        public double P_TOTAL_IV_QTY
        {
            get
            {
                return p_APR_IV_QTY + p_MAY_IV_QTY + p_JUN_IV_QTY + p_JUL_IV_QTY + p_AUG_IV_QTY + p_SEP_IV_QTY + p_OCT_IV_QTY +
                    p_NOV_IV_QTY + p_DEC_IV_QTY + p_JAN_IV_QTY + p_FEB_IV_QTY + p_MAR_IV_QTY;
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

        public double P_APR_AMT
        {
            get
            {
                return p_APR_AMT;
            }

            set
            {
                p_APR_AMT = value;
            }
        }

        public double P_MAY_AMT
        {
            get
            {
                return p_MAY_AMT;
            }

            set
            {
                p_MAY_AMT = value;
            }
        }

        public double P_JUN_AMT
        {
            get
            {
                return p_JUN_AMT;
            }

            set
            {
                p_JUN_AMT = value;
            }
        }

        public double P_JUL_AMT
        {
            get
            {
                return p_JUL_AMT;
            }

            set
            {
                p_JUL_AMT = value;
            }
        }

        public double P_AUG_AMT
        {
            get
            {
                return p_AUG_AMT;
            }

            set
            {
                p_AUG_AMT = value;
            }
        }

        public double P_SEP_AMT
        {
            get
            {
                return p_SEP_AMT;
            }

            set
            {
                p_SEP_AMT = value;
            }
        }

        public double P_OCT_AMT
        {
            get
            {
                return p_OCT_AMT;
            }

            set
            {
                p_OCT_AMT = value;
            }
        }

        public double P_NOV_AMT
        {
            get
            {
                return p_NOV_AMT;
            }

            set
            {
                p_NOV_AMT = value;
            }
        }

        public double P_DEC_AMT
        {
            get
            {
                return p_DEC_AMT;
            }

            set
            {
                p_DEC_AMT = value;
            }
        }

        public double P_JAN_AMT
        {
            get
            {
                return p_JAN_AMT;
            }

            set
            {
                p_JAN_AMT = value;
            }
        }

        public double P_FEB_AMT
        {
            get
            {
                return p_FEB_AMT;
            }

            set
            {
                p_FEB_AMT = value;
            }
        }

        public double P_MAR_AMT
        {
            get
            {
                return p_MAR_AMT;
            }

            set
            {
                p_MAR_AMT = value;
            }
        }

        public double P_TOTAL_AMT
        {
            get
            {
                return p_APR_AMT + p_MAY_AMT + p_JUN_AMT + p_JUL_AMT + p_AUG_AMT + p_SEP_AMT + p_OCT_AMT +
                    p_NOV_AMT + p_DEC_AMT + p_JAN_AMT + p_FEB_AMT + p_MAR_AMT;
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

        public double P_ORDER_RATIO
        {
            get
            {
                return p_ORDER_RATIO;
            }

            set
            {
                p_ORDER_RATIO = value;
            }
        }

        public string P_CREATE_BY
        {
            get
            {
                return p_CREATE_BY;
            }

            set
            {
                p_CREATE_BY = value;
            }
        }

        public DateTime P_CREAET_DATE
        {
            get
            {
                return p_CREAET_DATE;
            }

            set
            {
                p_CREAET_DATE = value;
            }
        }

        public string P_NONEED_BIT
        {
            get
            {
                return p_NONEED_BIT;
            }

            set
            {
                p_NONEED_BIT = value;
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

        public DateTime P_NONEED_DATE
        {
            get
            {
                return p_NONEED_DATE;
            }

            set
            {
                p_NONEED_DATE = value;
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
