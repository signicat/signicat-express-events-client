using System.ComponentModel;
using System.Runtime.Serialization;

namespace Idfy.Events.Entities
{
    public enum EventType
    {
        [EnumMember(Value = "document_before_deleted")]
        [Description("When a document is about to be deleted.")]
        DocumentBeforeDeleted,
        
        [EnumMember(Value = "document_canceled")]
        [Description("When a document is canceled.")]
        DocumentCanceled,
        
        [EnumMember(Value = "document_created")]
        [Description("When a new document is created.")]
        DocumentCreated,
        
        [EnumMember(Value = "document_deleted")]
        [Description("When a document is deleted.")]
        DocumentDeleted,
        
        [EnumMember(Value = "document_expired")]
        [Description("When a document expires.")]
        DocumentExpired,
        
        [EnumMember(Value = "document_email_opened")]
        [Description("When a signer opens a document email.")]
        DocumentEmailOpened,
        
        [EnumMember(Value = "document_form_partially_signed")]
        [Description("When a form is partially signed.")]
        DocumentFormPartiallySigned,
        
        [EnumMember(Value = "document_form_signed")]
        [Description("When a form is signed by all required signers.")]
        DocumentFormSigned,
        
        [EnumMember(Value = "document_link_opened")]
        [Description("When a document link is opened by a signer.")]
        DocumentLinkOpened,
        
        [EnumMember(Value = "document_packaged")]
        [Description("When a document is packaged with all signatures.")]
        DocumentPackaged,
        
        [EnumMember(Value = "document_partially_signed")]
        [Description("When a document is partially signed.")]
        DocumentPartiallySigned,
        
        [EnumMember(Value = "document_read")]
        [Description("When a document is read by a signer.")]
        DocumentRead,
        
        [EnumMember(Value = "document_signed")]
        [Description("When a document is signed by all required signers.")]
        DocumentSigned,
        
        [EnumMember(Value = "resource_created")]
        [Description("When a resource is created and available for download.")]
        ResourceCreated,
        [EnumMember(Value = "share_created")]
        [Description("When a new share is created.")]
        ShareCreated,
                
        [EnumMember(Value = "share_deleted")]
        [Description("When a share is deleted.")]
        ShareDeleted,
                
        [EnumMember(Value = "share_recipients_authenticated")]
        [Description("When a Receipient successfully authenticated.")]
        ShareRecipientsAuthenticated,
                
        [EnumMember(Value = "share_recipient_downloaded")]
        [Description("When a recipient downloaded from share.")]
        ShareRecipientDownloaded,
        [EnumMember(Value = "share_downloaded")]
        [Description("When all shares have been downloaded.")]
        ShareDownloaded,
        [EnumMember(Value = "share_expired")]
        [Description("When a share expires and are being cleaned up.")]
        ShareExpired,
        
        [EnumMember(Value = "deposit_created")]
        [Description("When a new deposit is created.")]
        DepositCreated,
                      
        [EnumMember(Value = "deposit_terminated")]
        [Description("When a deposit is terminated.")]
        DepositTerminated,
        
        [EnumMember(Value = "deposit_fully_funded")]
        [Description("When full payment has been made to the deposit.")]
        DepositFullyFunded,
        
        [EnumMember(Value = "deposit_partially_funded")]
        [Description("When partial payment has been made to the deposit.")]
        DepositPartiallyFunded
    }
}