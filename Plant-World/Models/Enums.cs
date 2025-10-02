namespace Plant_World.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery
    }
}
