using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Controle_de_vinhos
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
        string tprecebe7 = "sala2/ambiente"; //#####TOPICO DE RECEBIMENTO
        string tprecebe8 = "sala/ambiente";  //#####TOPICO DE RECEBIMENTO
        string broker = "192.168.1.104";

        MqttClient client;
        string clientId;
        string Recebido;
        float Recnum;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        
        private void pb_temp_1_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_2_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_3_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_4_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_5_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_6_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_7_Click(object sender, EventArgs e)
        {

        }
        private void pb_temp_8_Click(object sender, EventArgs e)
        {

        }

        
        private void bt_conectar_Click(object sender, EventArgs e)
        {

            client = new MqttClient("iot.eclipse.org");    //###COM endereço###########
            //client = new MqttClient(IPAddress.Parse(broker));    //###COM IP###########
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] {tprecebe1,tprecebe2,tprecebe3,tpenvio, tprecebe4,
                tprecebe5, tprecebe6,tprecebe7, tprecebe8 }, new byte[] {
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});
                
            
            if (client.IsConnected)
            {
                bt_conectar.Text = "Conectado";
                bt_conectar.BackColor = Color.Green;
            }
           
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            base.OnClosed(e);
            if (bt_conectar.Text=="Conectado") client.Disconnect();
            Close();
        }//### FECHAR ####
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic.ToString() == tpenvio)
            {

            }
            if (e.Topic.ToString() == tprecebe1)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_1.Value = (Convert.ToInt32(Recnum))/100;
                //tb_1.Value = (Convert.ToInt32(Recnum));
                lb_1.Text = (Recebido)+" C°";
            }
            if (e.Topic.ToString() == tprecebe2)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_2.Value = (Convert.ToInt32(Recnum))/100;
                //tb_2.Value = (Convert.ToInt32(Recnum));
                lb_2.Text = (Recebido)+" C°";

            }
            if (e.Topic.ToString() == tprecebe3)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_3.Value = (Convert.ToInt32(Recnum))/100;
                //tb_3.Value = (Convert.ToInt32(Recnum));
                lb_3.Text = (Recebido) + " C°";

            }
            if (e.Topic.ToString() == tprecebe4)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_4.Value = (Convert.ToInt32(Recnum))/100;
                //tb_4.Value = (Convert.ToInt32(Recnum));
                lb_4.Text = (Recebido) + " C°";

            }
            if (e.Topic.ToString() == tprecebe5)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_5.Value = (Convert.ToInt32(Recnum))/100;
                //tb_5.Value = (Convert.ToInt32(Recnum));
                lb_5.Text = (Recebido) + " C°";

            }
            if (e.Topic.ToString() == tprecebe6)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_6.Value = (Convert.ToInt32(Recnum))/100;
                //tb_6.Value = (Convert.ToInt32(Recnum));
                lb_6.Text = (Recebido) + " C°";

            }
            if (e.Topic.ToString() == tprecebe7)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_7.Value = (Convert.ToInt32(Recnum))/100;
                //tb_7.Value = (Convert.ToInt32(Recnum));
                lb_7.Text = (Recebido) + " C°";

            }
            if (e.Topic.ToString() == tprecebe8)
            {
                Recebido = Encoding.UTF8.GetString(e.Message);
                Recnum = float.Parse(Recebido);
                if (Recnum <= 1000) Recnum = Recnum * 10;
                tb_8.Value = (Convert.ToInt32(Recnum))/100;
                //tb_8.Value = (Convert.ToInt32(Recnum)) ;
                lb_8.Text = (Recebido) + " C°";

            }
            
        }

        private void lb_1_Click(object sender, EventArgs e)
        {

        }
        private void lb_2_Click(object sender, EventArgs e)
        {

        }
        private void lb_3_Click(object sender, EventArgs e)
        {

        }
        private void lb_4_Click(object sender, EventArgs e)
        {

        }
        private void lb_5_Click(object sender, EventArgs e)
        {

        }
        private void lb_6_Click(object sender, EventArgs e)
        {

        }
        private void lb_7_Click(object sender, EventArgs e)
        {

        }
        private void lb_8_Click(object sender, EventArgs e)
        {

        }
               

        private void tb_1_Scroll(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
