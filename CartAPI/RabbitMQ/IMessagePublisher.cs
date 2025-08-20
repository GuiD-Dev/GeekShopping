namespace CartAPI.RabbitMQ;

public interface IMessagePublisher
{
    void PublishMessage(CheckoutDTO baseMessage, string queueName);
}