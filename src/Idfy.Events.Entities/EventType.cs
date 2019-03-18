using System.ComponentModel;
using System.Runtime.Serialization;

namespace Idfy.Events.Entities
{
    public enum EventType
    {
        [EnumMember(Value = "document_before_deleted")]
        [Description("When a document is about to be deleted.")]
        DocumentBeforeDeleted = 0,
        
        [EnumMember(Value = "document_canceled")]
        [Description("When a document is canceled.")]
        DocumentCanceled = 1,
        
        [EnumMember(Value = "document_created")]
        [Description("When a new document is created.")]
        DocumentCreated = 2,
        
        [EnumMember(Value = "document_deleted")]
        [Description("When a document is deleted.")]
        DocumentDeleted = 3,
        
        [EnumMember(Value = "document_expired")]
        [Description("When a document expires.")]
        DocumentExpired = 4,
        
        [EnumMember(Value = "document_email_opened")]
        [Description("When a signer opens a document email.")]
        DocumentEmailOpened = 5,
        
        [EnumMember(Value = "document_form_partially_signed")]
        [Description("When a form is partially signed.")]
        DocumentFormPartiallySigned = 6,
        
        [EnumMember(Value = "document_form_signed")]
        [Description("When a form is signed by all required signers.")]
        DocumentFormSigned = 7,
        
        [EnumMember(Value = "document_link_opened")]
        [Description("When a document link is opened by a signer.")]
        DocumentLinkOpened = 8,
        
        [EnumMember(Value = "document_packaged")]
        [Description("When a document is packaged with all signatures.")]
        DocumentPackaged = 9,
        
        [EnumMember(Value = "document_partially_signed")]
        [Description("When a document is partially signed.")]
        DocumentPartiallySigned = 10,
        
        [EnumMember(Value = "document_read")]
        [Description("When a document is read by a signer.")]
        DocumentRead = 11,
        
        [EnumMember(Value = "document_signed")]
        [Description("When a document is signed by all required signers.")]
        DocumentSigned = 12,
        
        [EnumMember(Value = "resource_created")]
        [Description("When a resource is created and available for download.")]
        ResourceCreated = 13,
        [EnumMember(Value = "share_created")]
        [Description("When a new share is created.")]
        ShareCreated = 14,
                
        [EnumMember(Value = "share_deleted")]
        [Description("When a share is deleted.")]
        ShareDeleted = 15,
                
        [EnumMember(Value = "share_recipients_authenticated")]
        [Description("When a Receipient successfully authenticated.")]
        ShareRecipientsAuthenticated = 16,
                
        [EnumMember(Value = "share_recipient_downloaded")]
        [Description("When a recipient downloaded from share.")]
        ShareRecipientDownloaded = 17,
        [EnumMember(Value = "share_downloaded")]
        [Description("When all shares have been downloaded.")]
        ShareDownloaded = 18,
        [EnumMember(Value = "share_expired")]
        [Description("When a share expires and are being cleaned up.")]
        ShareExpired = 19,
        
        [EnumMember(Value = "deposit_created")]
        [Description("When a new deposit is created.")]
        DepositCreated = 20,
                      
        [EnumMember(Value = "deposit_terminated")]
        [Description("When a deposit is terminated.")]
        DepositTerminated = 21,
        
        [EnumMember(Value = "deposit_fully_funded")]
        [Description("When full payment has been made to the deposit.")]
        DepositFullyFunded = 22,
        
        [EnumMember(Value = "deposit_partially_funded")]
        [Description("When partial payment has been made to the deposit.")]
        DepositPartiallyFunded = 23,
        
        [EnumMember(Value = "deposit_bank_account_created")]
        [Description("When a bank account is created.")]
        DepositBankAccountCreated = 24
    }
}