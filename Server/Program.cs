using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        //Хранит имя и его сокет подключение клиента
        static Hashtable clientHS = new Hashtable();         

        static Socket serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //Переменная хранящая переданое сообщение со стороны клиента
        static string msg;

        //Хранит всю историю сообщений в чате
        static List<string> historyMsg = new List<string>()
        {
            "Last"
        };
       
        
        static void Main(string[] args)
      
        {
            //подключаем сокет к нашему серверу
            serverSoket.Bind(new IPEndPoint(IPAddress.Any, 904));
            Console.WriteLine("Запуск сервера выполен успешно");
            
            Console.WriteLine("Выполняется прослушивание порта...");
            serverSoket.Listen(5);

            //Создаём новый сокет для подключившегося пользователя
            Socket clientSocket;
          
           
            
            while (1 == 1)
            {
                //Создаём новый сокет для подключившегося пользователя
                clientSocket = serverSoket.Accept();
                Console.WriteLine("Новое подключение....");

                //создаём буфер для хранения считывания данных из потока с которым связан сокет
                byte[] buffer = new byte[1024];
                clientSocket.Receive(buffer);
                
                //декодируем полученные данные и выводим их на экран 
                msg = Encoding.Unicode.GetString(buffer);
                //Удаляем все пробелы в конце сообщения
                msg = msg.Trim('\0');

                //Добавляем клиента и его сокет подключение в хэш таблицу
                clientHS.Add(msg, clientSocket);

                msg += " подключился к чату\n";
                Console.WriteLine(msg);

                foreach(string history in historyMsg)
                {                   
                    clientSocket.Send(Encoding.Unicode.GetBytes(history));
                    clientSocket.Receive(buffer);
                }
                historyMsg.Remove("Last");

                //Передаем новому пользователю спикок подключенных к чату пользователей
                userState(clientSocket);
                

                //Поток для постоянной прослушки со стороны каждого клиента на придмет принятия сообщения с его стороны
                Thread UserChat = new Thread(new ParameterizedThreadStart(doChat));
                UserChat.Start(clientSocket);

                historyMsg.Add(msg);
                historyMsg.Add("Last");

                //Сообщаем всем клиентам о новом подключившемся пользователе
                broadcast(msg);
                
            }                
            
        }

        //Метод для рассылки всем подключенным клиентам сообщений со стороны сервера
        static void broadcast(string _msg)
        {
            //сокет принимающий на себя подключения подключённых полбзователей чата
            Socket otherSocket;

            byte[] buffer = new byte[1024];
            string otherMsg = _msg;
            otherMsg += "\n";
            buffer = Encoding.Unicode.GetBytes(otherMsg);
           


            foreach (string key in clientHS.Keys)
            {                
                otherSocket = (Socket)clientHS[key];
                otherSocket.Send(buffer);
            }            
        }

        //Метод для постоянной прослушки со стороны каждого клиента на придмет принятия сообщения с его стороны
        static void doChat(object _userSocket)
        {
            Socket userSocket = (Socket) _userSocket;
            string userMsg;
            

            while (1 == 1)
            {
                try
                {

                    byte[] buffer = new byte[1024];
                    userSocket.Receive(buffer);
                    userMsg = Encoding.Unicode.GetString(buffer);
                    userMsg = userMsg.Trim('\0');



                    //Если со стороны клиента полученно только его имя, то необходимо закрыть соединение для этого пользователя
                    foreach (string nameCls in clientHS.Keys)
                    {
                        if (userMsg == nameCls)
                        {
                            string disCl;
                            disCl = nameCls + " отключился от сервера";
                            clientHS.Remove(nameCls);
                            Console.WriteLine(disCl);

                            broadcast(disCl);
                            //Освобождаем ресурсы связанные с сокетом данного подключения и закрываем сокет
                            userSocket.Shutdown(SocketShutdown.Both);
                            userSocket.Close();
                            return;
                        }
                    }
                        //При отсутствия подходящего имени просто выполняем рассылку сообщения            
                        
                        Console.WriteLine(userMsg);

                        //Добавляем в историю сообщение рассылаемое клиентам            
                        historyMsg.RemoveAt(historyMsg.Count - 1);
                        historyMsg.Add(userMsg + "\n");
                        historyMsg.Add("Last");

                        broadcast(userMsg);
                         

                }

                catch(Exception ex)
                {
                    return;
                }
                
            }         

        }

        //Метод посылающий клиентам информация о подключенных к серверу пользователей
        static void userState(Socket _userSocket)
        {
            Socket userSocket = _userSocket;
            byte[] buffer = new byte[1024];

            foreach(string nameCls in clientHS.Keys)
            {
                broadcast(nameCls);
                userSocket.Receive(buffer);
            }

            broadcast("Last");
            userSocket.Receive(buffer);
        }
        
    }
}
