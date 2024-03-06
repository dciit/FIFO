using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_PARTFORECAST
{
    public class VenderInfo
    {
        private string p_VENDER = "";
        private string p_VDNAME = "";
        private string p_CURRENCY = "";

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
    }
}
