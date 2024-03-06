using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_MODELPALLET_REPORT.Model
{
    internal class ObsoletePDTInfo
    {
        string mODEL = "";
        string sERIAL = "";
        string fGDATE = "";
        string sLOWDATE = "";
        string oBSOLETEDATE = "";
        string uNIT = "";
        string aREA = "";
        string sTATUS = "";
        string lOCATION = "";
        string tOTALMONTH = "";

        public string MODEL { get => mODEL; set => mODEL = value; }
        public string SERIAL { get => sERIAL; set => sERIAL = value; }
        public string FGDATE { get => fGDATE; set => fGDATE = value; }
        public string SLOWDATE { get => sLOWDATE; set => sLOWDATE = value; }
        public string OBSOLETEDATE { get => oBSOLETEDATE; set => oBSOLETEDATE = value; }
        public string UNIT { get => uNIT; set => uNIT = value; }
        public string AREA { get => aREA; set => aREA = value; }
        public string STATUS { get => sTATUS; set => sTATUS = value; }
        public string LOCATION { get => lOCATION; set => lOCATION = value; }
        public string TOTALMONTH { get => tOTALMONTH; set => tOTALMONTH = value; }
    }
}
