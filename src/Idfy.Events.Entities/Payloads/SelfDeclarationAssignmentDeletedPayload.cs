namespace Idfy.Events.Entities
{
    public class SelfDeclarationAssignmentDeletedPayload : BaseSelfDeclarationPayload
    {
        public bool AssignmentWasCompleted { get; set; }
    }
}