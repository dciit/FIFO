using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_SALEORDERLOADING.Model
{
    internal class SaleAndLoadinginfo
    {
        private string dOC_NO = "";
        private string iNVOICE_NO = "";
        private string mODEL = "";
        private string cUSTOMER_CODE = "";
        private string cUSTOMER_NAME = "";
        private string tRUCK_NO = "";
        private string pALLET_NO = "";
        private string pALLET_TYPE = "";
        private string wAREHOUSE = "";
        private string cTNO = "";
        private string eTD = "";
        private string oRDER_TYPE = "";
        private string lOADDATE = "";
        private string dELBIT = "";

        public string DOC_NO { get => dOC_NO; set => dOC_NO = value; }
        public string INVOICE_NO { get => iNVOICE_NO; set => iNVOICE_NO = value; }
        public string MODEL { get => mODEL; set => mODEL = value; }
        public string CUSTOMER_CODE { get => cUSTOMER_CODE; set => cUSTOMER_CODE = value; }
        public string CUSTOMER_NAME { get => cUSTOMER_NAME; set => cUSTOMER_NAME = value; }
        public string TRUCK_NO { get => tRUCK_NO; set => tRUCK_NO = value; }
        public string PALLET_NO { get => pALLET_NO; set => pALLET_NO = value; }
        public string PALLET_TYPE { get => pALLET_TYPE; set => pALLET_TYPE = value; }
        public string WAREHOUSE { get => wAREHOUSE; set => wAREHOUSE = value; }
        public string CTNO { get => cTNO; set => cTNO = value; }
        public string ETD { get => eTD; set => eTD = value; }
        public string ORDER_TYPE { get => oRDER_TYPE; set => oRDER_TYPE = value; }
        public string LOADDATE { get => lOADDATE; set => lOADDATE = value; }
        public string DELBIT { get => dELBIT; set => dELBIT = value; }
    }
}
