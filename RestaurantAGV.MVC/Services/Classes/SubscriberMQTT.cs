using RestaurantAGV.MVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestaurantAGV.MVC.Database;
using MQTTnet;
using MQTTnet.Client;
using System.Text;

namespace RestaurantAGV.MVC.Services.Classes;

public class SubscriberMQTT : ISubscriberMQTT
{
    private readonly DbContextOptions<RestaurantDbContext> _dbContext;

    private MqttFactory _mqttFactory;
    private IMqttClient _mqttClient;

    public SubscriberMQTT(DbContextOptions<RestaurantDbContext> dbContext)
    {
        _dbContext = dbContext;
        _mqttFactory = new MqttFactory();
        _mqttClient = _mqttFactory.CreateMqttClient();
    
        _mqttClient.ApplicationMessageReceivedAsync += e => MessageHandlerAsync(e);
        _mqttClient.DisconnectedAsync += e => DisconnectedAsync();
    }

    ~SubscriberMQTT(){
        _mqttClient.Dispose();
    }

    public async Task InitialConnectAsync(string broker, int port)
    {
        try{
            var clientOption = new MqttClientOptionsBuilder()
                .WithTcpServer(broker,port)
                .Build();
            await _mqttClient.ConnectAsync(clientOption,CancellationToken.None);
        }catch(Exception ex){
            Console.WriteLine("[-] Cannot to connect to the broker\n[message] "+ex.Message);
        }
    }

    public async Task ConnectToTopicAsync(string topic)
    {
        var mqttSubscribeOption = _mqttFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(f => {f.WithTopic(topic);})
            .Build();

        await _mqttClient.SubscribeAsync(mqttSubscribeOption,CancellationToken.None);

        Console.WriteLine($"[+] Subscribe to the {topic} topic");

    }

    private Task MessageHandlerAsync(MqttApplicationMessageReceivedEventArgs e){
        // Define what to do when there is incomming message.
        Console.WriteLine(" ~~~~ New Message ~~~~");
        string message = Encoding.ASCII.GetString(e.ApplicationMessage.Payload);
        Console.WriteLine(message);
        

        return Task.CompletedTask;
    }

    private Task DisconnectedAsync(){
        // Define the disconnected action.
        Console.WriteLine("[!] Disconnected to the broker");

        return Task.CompletedTask;
    }

}