using System.Runtime.Serialization;

namespace Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending = 0,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived = 1,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed = 2,
        //Shipped
    }
}