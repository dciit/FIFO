using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_OBSOLETEREPORT.Model
{
    internal class FIFOInfo
    {

        string mODEL_NAME = "";
        string mODEL_CODE = "";
        string pALLET_NO = "";
        string pALLET_TYPE = "";
        string qTY_IN_PALLET = "";
        string lOCATION_CODE = "";
        string fINISHED_GOODS_DATE = "";
        string wAREHOUSE_DATE = "";
        string wAREHOUSE_CODE = "";
        string lINE = "";
        string currnetWCDate = "";
        string previousWC = "";

        public string MODEL_NAME { get => mODEL_NAME; set => mODEL_NAME = value; }
        public string MODEL_CODE { get => mODEL_CODE; set => mODEL_CODE = value; }
        public string PALLET_NO { get => pALLET_NO; set => pALLET_NO = value; }
        public string PALLET_TYPE { get => pALLET_TYPE; set => pALLET_TYPE = value; }
        public string QTY_IN_PALLET { get => qTY_IN_PALLET; set => qTY_IN_PALLET = value; }
        public string LOCATION_CODE { get => lOCATION_CODE; set => lOCATION_CODE = value; }
        public string WAREHOUSE_DATE { get => wAREHOUSE_DATE; set => wAREHOUSE_DATE = value; }
        public string FINISHED_GOODS_DATE { get => fINISHED_GOODS_DATE; set => fINISHED_GOODS_DATE = value; }
        public string WAREHOUSE_CODE { get => wAREHOUSE_CODE; set => wAREHOUSE_CODE = value; }
        public string LINE { get => lINE; set => lINE = value; }
        public string CurrnetWCDate { get => currnetWCDate; set => currnetWCDate = value; }
        public string PreviousWC { get => previousWC; set => previousWC = value; }
    }
}
