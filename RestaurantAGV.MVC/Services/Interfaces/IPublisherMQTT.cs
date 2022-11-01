namespace RestaurantAGV.MVC.Services.Interfaces;



public interface IPublisherMQTT{

    Task InitialConnectAsync(string broker, int port);

    Task PublishAsync(string topic,string payload);

}