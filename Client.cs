using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace rabbitmqClient
{
    public class Client
    {
        public void Start(){
            //Create factory 1
            ConnectionFactory fact = new ConnectionFactory();
            fact.HostName="rtfqyvyt";
            fact.VirtualHost="rtfqyvyt";
            fact.Uri=new Uri("amqps://rtfqyvyt:Xv_HTzNblQqofHgEsbtx2M3lA2ttWodY@codfish.rmq.cloudamqp.com/rtfqyvyt");
            fact.UserName="rtfqyvyt";
            fact.Password="Xv_HTzNblQqofHgEsbtx2M3lA2ttWodY";

            //Create connection 2
            IConnection cnn= fact.CreateConnection();
            //Create channel 3
            IModel channel= cnn.CreateModel();
            //Create queue 4
            channel.QueueDeclare(queue: "WorkOrders", durable:false, exclusive:false, autoDelete:false,arguments:null) ;
            while(true){
                Console.WriteLine("Type the message to be sent (1=finalizar)");
                string? mensaje=Console.ReadLine();
                if (mensaje=="1") break;

                var json = JsonSerializer.Serialize(mensaje);
                var item = Encoding.UTF8.GetBytes(json);
                //Send data to the queue 5
                channel.BasicPublish(exchange:"", routingKey:"WorkOrders",body:item);
                Console.WriteLine("Message sent successfuly");
            }
            
            channel.Close();
            cnn.Close();
        }
    }
}