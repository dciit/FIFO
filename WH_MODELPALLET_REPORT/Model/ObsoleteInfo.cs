using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_MODELPALLET_REPORT.Model
{
    internal class ObsoleteInfo
    {
        string mODEL = "";
        string sERIAL = "";
        string pALLETNO = "";
        string pALLET_TYPE = "";
        string fGDATE = "";
        string sLOWDATE = "";
        string oBSOLETEDATE = "";
        string uNIT = "";
        string aREA = "";
        string cURRENT_WC = "";
        string wAREHOUSECODE = "";
        string sTATUS = "";

        public string MODEL { get => mODEL; set => mODEL = value; }
        public string SERIAL { get => sERIAL; set => sERIAL = value; }
        public string PALLETNO { get => pALLETNO; set => pALLETNO = value; }
        public string PALLET_TYPE { get => pALLET_TYPE; set => pALLET_TYPE = value; }
        public string FGDATE { get => fGDATE; set => fGDATE = value; }
        public string SLOWDATE { get => sLOWDATE; set => sLOWDATE = value; }
        public string OBSOLETEDATE { get => oBSOLETEDATE; set => oBSOLETEDATE = value; }
        public string UNIT { get => uNIT; set => uNIT = value; }
        public string AREA { get => aREA; set => aREA = value; }
        public string CURRENT_WC { get => cURRENT_WC; set => cURRENT_WC = value; }
        public string WAREHOUSECODE { get => wAREHOUSECODE; set => wAREHOUSECODE = value; }
        public string STATUS { get => sTATUS; set => sTATUS = value; }
    }
}
