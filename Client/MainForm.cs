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
            //В случае любого закрытия приложения осуществляется его правильное закрытие через функцию closeApplication
            Application.ApplicationExit += new EventHandler(this.closeApplication);
        }
        //Создаём сокет для клиента        
        static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //Создание потока для постоянной прослушки сервера
        Thread clientTH;

        //Имя пользователя
        public string nameClient;        

        
      
        
        //Осуществляет постоянную прослушка на принятие сообщений от сервера
        private void doChat()
        {                   
            while(1==1)
            { 
                        
                    byte[] buffer = new byte[1024];
                    clientSocket.Receive(buffer);
                    string listenMsg =  Encoding.Unicode.GetString(buffer);

                //Осуществляем доступ к элементу управления, который был создан в другом потоке
                cahtRichTextBox.Invoke((Action)delegate { cahtRichTextBox.Text += listenMsg; });
                msgRichTextBox2.Invoke((Action)delegate { msgRichTextBox2.SelectionStart = 0; });
                
            }
        }

        //Посылает сообщение на сервер
        private void sendMsg(string _msg)
        {
           
            try
            {
                string msg = _msg;
                msg = msg.Trim('\n');
            
                //Создаём буфер для хранения кодированных данных и переносим в него эти данные
                byte[] bufer = new byte[1024];
                bufer = Encoding.Unicode.GetBytes(msg);
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
            closeApplication( sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Сообщаем серверу об отключении клиента
            sendMsg(nameClient);
            byte[] aanswerServer = new byte[1024];

            //Завершаем поток, освобождаем ресурсы, закрываем сокет подключение и выходим из приложения            
            clientSocket.Shutdown(SocketShutdown.Both);
            clientTH.Abort();
            clientSocket.Close();
            Application.Exit();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.Start("http://pornosveta.com/categories/");           
        }        
        
        private void msgRichTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //При нажатии на Enter посылается набранное сообщение
            if ( e.KeyData == Keys.Enter)
            {
                sendMsg(nameClient + ": " + msgRichTextBox2.Text);
                msgRichTextBox2.Text = string.Empty;
            }

        }

        private void chatRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //При добавлении текста прокручивает чат вниз
            cahtRichTextBox.SelectionStart = cahtRichTextBox.Text.Length;
            cahtRichTextBox.ScrollToCaret();
        }
        
        //реазилует правильное завершение работы клиента и выход из него
        private void closeApplication(object sender, EventArgs e)
        { //System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
          // System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
          // System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
          // return;
            if (clientSocket.IsBound == true)
            {
                //Сообщаем серверу об отключении клиента
                sendMsg(nameClient);
                byte[] aanswerServer = new byte[1024];

                //Завершаем поток, освобождаем ресурсы, закрываем сокет подключение и выходим из приложения            
                //clientSocket.Shutdown(SocketShutdown.Both);
                clientTH.Abort();
                clientSocket.Close();
                Application.Exit();
            }

            else
            {
                //  System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
                //  System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
                //  System.Diagnostics.Process.Start("http://pornosveta.com/categories/");
                //  return;
                Application.Exit();
            }
        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Подключаемся к серверу...
            clientSocket.Connect("192.168.1.5", 904);


            //Посылаем на сервер имя подключающегося клиента
            byte[] nameBufer = new byte[1024];
            nameBufer = Encoding.Unicode.GetBytes(nameClient);
            clientSocket.Send(nameBufer);

            while (1 == 1)
            {
                //принимаем историю со стороны сервера
                byte[] historyBuffer = new byte[1024];
                clientSocket.Receive(historyBuffer);
                string historyMsg = Encoding.Unicode.GetString(historyBuffer);
                historyMsg = historyMsg.Trim('\0');

                //При получении завершающего слова Last приём истоии завершается
                if (historyMsg == "Last")
                {
                    //подтверждение об успешности принятия строчки истории 
                    sendMsg("OK");
                    break;
                }

                else
                {
                    cahtRichTextBox.Text += historyMsg;
                    sendMsg("OK");
                }
            }


            while(1==1)
            {
                //Принимаем с сервера список подключённых к чату
                byte[] userMsg = new byte[1024];
                clientSocket.Receive(userMsg);
                string user = Encoding.Unicode.GetString(userMsg);
                user = user.Trim('\0');

                //При получении завершающего слова Last приём данныхзавершается
                if (user == "Last\n")
                {
                    //подтверждение об успешности принятия данных
                    sendMsg("OK");
                    break;
                }

                else
                {
                    userList.Items.Add(user);
                    sendMsg("OK");
                }
            }
            

            //Принимаем ответ от сервера об успешном подключении к серверу
            byte[] answerServer = new byte[1024];
            clientSocket.Receive(answerServer);
            cahtRichTextBox.Text += Encoding.Unicode.GetString(answerServer);

            //Создаем отдельный поток для постоянной прослушки сервера на принятие сообщений от него
            clientTH = new Thread(new ThreadStart(doChat));
            clientTH.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //создаём форму создания имени клиента
            //в качаестве параметра передаём главную форму, чтобы получить доступ к её элементам
            NewUser nameForm = new NewUser(this);
            nameForm.ShowDialog();
        }
    }
}
