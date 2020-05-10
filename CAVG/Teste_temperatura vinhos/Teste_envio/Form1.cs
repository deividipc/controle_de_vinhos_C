using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Web.Script.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Teste_envio
{
    public partial class Form1 : Form
    {
        string tpenvio = "vinho/comandos";   //#####TOPICO DE ENVIO
        string tprecebe1 = "vinho1/liquido";  //#####TOPICO DE RECEBIMENTO
        string tprecebe2 = "vinho1/chapeu";  //#####TOPICO DE RECEBIMENTO
        string tprecebe3 = "vinho2/liquido";  //#####TOPICO DE RECEBIMENTO
        string tprecebe4 = "vinho2/chapeu";  //#####TOPICO DE RECEBIMENTO
        string tprecebe5 = "vinho3/liquido";  //#####TOPICO DE RECEBIMENTO
        string tprecebe6 = "vinho3/chapeu";  //#####TOPICO DE RECEBIMENTO
        string tprecebe7 = "sala2/ambiente";  //#####TOPICO DE RECEBIMENTO
        string tprecebe8 = "sala/ambiente";  //#####TOPICO DE RECEBIMENTO

        
        string manager = "172.30.8.171";//"172.28.34.65";
        MqttClient client;
        string clientId="TESTADOR";
       
        public Form1()            
        {
            InitializeComponent();
            // client = new MqttClient(IPAddress.Parse(manager));
            client = new MqttClient("iot.eclipse.org");
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.Connect(clientId);
            client.Subscribe(new string[] {tpenvio}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            
        }
               
        

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                                   
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            textBox1.Text = ""+ ReceivedMessage;
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            while (true)
            {
                client.Publish(tprecebe8, Encoding.UTF8.GetBytes("25,8"));
                client.Publish(tprecebe1, Encoding.UTF8.GetBytes("25,1"));
                client.Publish(tprecebe2, Encoding.UTF8.GetBytes("25,2"));
                client.Publish(tprecebe3, Encoding.UTF8.GetBytes("25,3"));
                client.Publish(tprecebe4, Encoding.UTF8.GetBytes("25,4"));
                client.Publish(tprecebe5, Encoding.UTF8.GetBytes("25,5"));
                client.Publish(tprecebe6, Encoding.UTF8.GetBytes("25,6"));
                client.Publish(tprecebe7, Encoding.UTF8.GetBytes("25,7"));
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                Thread.Sleep(5000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync(2000);
        }
    }
}
