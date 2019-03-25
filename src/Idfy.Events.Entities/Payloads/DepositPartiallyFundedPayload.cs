namespace Idfy.Events.Entities
{
    public class DepositPartiallyFundedPayload : BaseDepositPayload
    {
        public decimal Funds { get; set; }
    }
}