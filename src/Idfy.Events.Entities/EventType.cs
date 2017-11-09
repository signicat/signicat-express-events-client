using System.Runtime.Serialization;

namespace Idfy.Events.Entities
{
    public enum EventType
    {
        [EnumMember(Value = "document_before_deleted")]
        DocumentBeforeDeleted,
        
        [EnumMember(Value = "document_canceled")]
        DocumentCanceled,
        
        [EnumMember(Value = "document_created")]
        DocumentCreated,
        
        [EnumMember(Value = "document_created")]
        DocumentDeleted,
        
        [EnumMember(Value = "document_created")]
        DocumentExpired,
        
        [EnumMember(Value = "document_email_opened")]
        DocumentEmailOpened,
        
        [EnumMember(Value = "document_form_partially_signed")]
        DocumentFormPartiallySigned,
        
        [EnumMember(Value = "document_form_partially_signed")]
        DocumentFormSigned,
        
        [EnumMember(Value = "document_link_opened")]
        DocumentLinkOpened,
        
        [EnumMember(Value = "document_packaged")]
        DocumentPackaged,
        
        [EnumMember(Value = "document_partially_signed")]
        DocumentPartiallySigned,
        
        [EnumMember(Value = "document_read")]
        DocumentRead,
        
        [EnumMember(Value = "document_signed")]
        DocumentSigned,
    }
}