using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_MODELPALLET_REPORT.Model
{
    internal class FIFOInfo
    {
        string wHDATE = "";
        string wHTIME = "";
        string mODEL_CODE = "";
        string mODEL = "";
        string pALLET_NO = "";
        string pALLET_TYPE = "";
        string aREA = "";
        string lINE = "";
        string qTY = "";

        public string WHDATE { get => wHDATE; set => wHDATE = value; }
        public string WHTIME { get => wHTIME; set => wHTIME = value; }
        public string MODEL_CODE { get => mODEL_CODE; set => mODEL_CODE = value; }
        public string MODEL { get => mODEL; set => mODEL = value; }
        public string PALLET_NO { get => pALLET_NO; set => pALLET_NO = value; }
        public string PALLET_TYPE { get => pALLET_TYPE; set => pALLET_TYPE = value; }
        public string AREA { get => aREA; set => aREA = value; }
        public string LINE { get => lINE; set => lINE = value; }
        public string QTY { get => qTY; set => qTY = value; }
    }
}
