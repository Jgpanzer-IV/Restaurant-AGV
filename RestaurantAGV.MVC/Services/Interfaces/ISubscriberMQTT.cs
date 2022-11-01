namespace RestaurantAGV.MVC.Services.Interfaces;


public interface ISubscriberMQTT{

    Task InitialConnectAsync(string broker, int port);
    Task ConnectToTopicAsync(string topic);

}