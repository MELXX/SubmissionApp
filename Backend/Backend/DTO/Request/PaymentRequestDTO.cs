using DAL.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTO.Request
{
    public class PaymentRequestDTO
    {
        public PaymentRequestDTO(Guid userId, Guid departmentId, DateTime invoiceDate, DateTime paymentRequestDate, Guid managerUserId, 
            string paymentDetails, string description, string idempotencyToken, string name, 
            string surname, string myReference, string recepientReference, string bankName, 
            string branchCode, string swiftCode, DocumentRequestDTO supplierInvoice, DocumentRequestDTO? pOP)
        {
            UserId = userId;
            DepartmentId = departmentId;
            InvoiceDate = invoiceDate;
            PaymentRequestDate = paymentRequestDate;
            ManagerUserId = managerUserId;
            PaymentDetails = paymentDetails;
            Description = description;
            IdempotencyToken = idempotencyToken;
            Name = name;
            Surname = surname;
            MyReference = myReference;
            RecepientReference = recepientReference;
            BankName = bankName;
            BranchCode = branchCode;
            SwiftCode = swiftCode;
            SupplierInvoice = supplierInvoice;
            POP = pOP;
        }

        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentRequestDate { get; set; }
        public Guid ManagerUserId { get; set; }
        public string PaymentDetails { get; set; }
        public string Description { get; set; }
        public string IdempotencyToken { get; set; }
        public string  Name{ get; set; }
        public string  Surname{ get; set; }
        public string MyReference { get; set; }
        public string RecepientReference { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string SwiftCode { get; set; }
        public DocumentRequestDTO SupplierInvoice { get; set; } 
        public DocumentRequestDTO? POP { get; set; }
    }
}
