using RestaurantAGV.MVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestaurantAGV.MVC.Database;

using MQTTnet;
using MQTTnet.Client;

namespace RestaurantAGV.MVC.Services.Classes;

public class PublisherMQTT : IPublisherMQTT
{
    private readonly DbContextOptions<RestaurantDbContext> _dbContext;

    private MqttFactory _mqttFactory;
    private IMqttClient _mqttClient;

    public PublisherMQTT(DbContextOptions<RestaurantDbContext> dbContext)
    {
        _dbContext = dbContext;
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
    }

    ~PublisherMQTT(){
        _mqttClient.Dispose();
    }

    public async Task InitialConnectAsync(string broker, int port)
    {
        var clientOption = new MqttClientOptionsBuilder()
            .WithTcpServer(broker,port)
            .Build();
        await _mqttClient.ConnectAsync(clientOption,CancellationToken.None); 
    }

    public async Task PublishAsync(string topic, string payload)
    {
        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .Build();
        await _mqttClient.PublishAsync(applicationMessage,CancellationToken.None);
    }
}