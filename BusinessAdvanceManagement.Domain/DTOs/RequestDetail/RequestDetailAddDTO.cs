using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Domain.DTOs.RequestDetail
{
    public class RequestDetailAddDTO
    {
        public int AdvanceRequestID { get; set; }
        public int RequestStatuID { get; set; }
        public int StatuID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TransactionOwner { get; set; }
        public int NextStageUser { get; set; }
        public int NextStatu { get; set; }
        public int ConfirmAmount { get; set; }

        //son kullanıcılarda AR tablosuna update atmak için
        public DateTime DeterminedPaymentDate { get; set; }
        public string AdvanceReceiptNumber { get; set; }
        public int ApprovingDisapproving { get; set; }
        public int ApprovingDisapprovingRole { get; set; }
    }
}
