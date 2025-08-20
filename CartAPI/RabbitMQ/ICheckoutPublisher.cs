namespace CartAPI.RabbitMQ;

public interface ICheckoutPublisher
{
    void PublishMessage(CheckoutDTO baseMessage, string queueName);
}