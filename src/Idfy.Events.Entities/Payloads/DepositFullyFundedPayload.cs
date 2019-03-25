namespace Idfy.Events.Entities
{
    public class DepositFullyFundedPayload : BaseDepositPayload
    {
        public decimal Funds { get; set; }
    }
}