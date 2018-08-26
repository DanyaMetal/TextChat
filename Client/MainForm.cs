using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //Создаём сокет для клиента        
        static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Thread clientTH;

        private void button1_Click(object sender, EventArgs e)
        {                               
            sendMsg(textBox1.Text + ": " + richTextBox2.Text);
        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            //Подключаемся к серверу...
            clientSocket.Connect("127.0.0.1", 904);
            
            
            //Посылаем на сервер имя подключающегося клиента
            byte[] nameBufer = new byte[1024];
            nameBufer = Encoding.Unicode.GetBytes(textBox1.Text);
            clientSocket.Send(nameBufer);

            while(1==1)
            {
                byte[] historyBuffer = new byte[1024];
                clientSocket.Receive(historyBuffer);
                string historyMsg = Encoding.Unicode.GetString(historyBuffer);
                historyMsg = historyMsg.Trim('\0');

                if ( historyMsg == "Last")
                {
                    sendMsg("OK");
                    break;
                }

                else
                {
                    richTextBox1.Text += historyMsg;
                    sendMsg("OK");
                }
            }

           // sendMsg("A");

            //Принимаем ответ от сервера об успешном подключении к серверу
            byte[] answerServer = new byte[1024];
            clientSocket.Receive(answerServer);
            richTextBox1.Text += Encoding.Unicode.GetString(answerServer);            
            
            //Создаем отдельный поток для постоянной прослушки сервера на принятие сообщений от него
            clientTH = new Thread(new ThreadStart(doChat));
            clientTH.Start();
            
        }

        //Осуществляет постоянную прослушка на принятие сообщений от сервера
        private void doChat()
        {                   
            while(1==1)
            { 
                        
                    byte[] buffer = new byte[1024];
                    clientSocket.Receive(buffer);
                    string listenMsg =  Encoding.Unicode.GetString(buffer);

                //Осуществляем доступ к элементу управления, который был создан в другом потоке
                richTextBox1.Invoke((Action)delegate { richTextBox1.Text += listenMsg; });
                
            }
        }

        //Посылает сообщение на сервер
        private void sendMsg(string _msg)
        {
            try
            {
                //Создаём буфер для хранения кодированных данных и переносим в него эти данные
                byte[] bufer = new byte[1024];
                bufer = Encoding.Unicode.GetBytes(_msg);
                //Посылаем на сервер данные
                clientSocket.Send(bufer);
            }
           
            catch(Exception ex)
            {
                return;
            }
        }
          

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Сообщаем серверу об отключении клиента
            //sendMsg(textBox1.Text);
          //  byte[] aanswerServer = new byte[1024];
           /*
            //Завершаем поток, освобождаем ресурсы, закрываем сокет подключение и выходим из приложения            
            clientSocket.Shutdown(SocketShutdown.Both);
            clientTH.Abort();
            */
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Сообщаем серверу об отключении клиента
            sendMsg(textBox1.Text);
            byte[] aanswerServer = new byte[1024];

            //Завершаем поток, освобождаем ресурсы, закрываем сокет подключение и выходим из приложения            
            clientSocket.Shutdown(SocketShutdown.Both);
            clientTH.Abort();
            clientSocket.Close();
            Application.Exit();
        }
    }
}
