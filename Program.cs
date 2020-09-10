using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace loops
{
    class Program
    {
        public static byte[] Combine(byte[] first, byte[] second)//saying if you give me two gyte i will combine them and give a bigger one, two thing that whated to be joined
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        public static void runCommand(String cmndPath)//GOAL!!!
        {
            byte[] data = Encoding.ASCII.GetBytes("C" + "M" + "N" + "D" + "\0");//bacially saying take hello world and converted it to ones and zeros
             //git changes and cats, doggies; bambi, lucero, max and princess                                                                  //string cmndPath = "sim/flight_controls/brakes_regular";
            //string cmndPath = "sim/engines/throttle_up";
            byte[] cmndData = Encoding.ASCII.GetBytes(cmndPath + "\0");
            byte[] combineData = Combine(data, cmndData);

            string ipAddress = "127.0.0.1";//local host in a # verison
            int sendPort = 49000;//like house numbers on a street
            try//this has to live in a try and catch block
            {
                using (var client = new UdpClient())//"book" checked out is being used
                {
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), sendPort);//names of book that are being used, that other people ave written that i use and book need info like ipAddress and port
                    client.Connect(ep);//like a call that sends data over, also can recive
                    client.Send(combineData, combineData.Length);
                    Console.WriteLine("your data was sent "+cmndPath);
                    //Console.ReadLine(); 
                }
            }
            catch (Exception ex)//go here to print out what happen, only if bad thing happen it will go down here
            {
                Console.WriteLine(ex.ToString());//printing out to the console
            }
        }


            static void Main(string[] args)
        {
            
            string brakecmnd = "sim/flight_controls/brakes_regular";
            string cmnd2 = "sim/engines/throttle_up";
            string cmnd3 = "sim/flight_controls/pitch_trim_takeoff";
            string cmnd4 = "sim/engines/throttle_down";
            string cmnd5 = "sim/flight_controls/pitch_trim_up";
            string leftRudder = "sim/flight_controls/rudder_lft";
            string rightRudder = "sim/flight_controls/rudder_rgt";
            string cmnd8 = "sim/flight_controls/pitch_trim_down";
            string cmnd10 = "sim/flight_controls/rudder_ctr";
            string cmnd11 = "sim/flight_controls/brakes_toggle_max";

            int i = 1;//a value
            while (i != 99)//use the loop if i is less then 10, 99 is reversed
                //landing commands, brakes are done, throttle down is also done, try to put it in a for loop.
            {
                Console.WriteLine("1 - Brakes", brakecmnd);
                Console.WriteLine("2 - Throttle up", cmnd2);
                Console.WriteLine("3 - Pitch takeoff", cmnd3);
                Console.WriteLine("4 - Throttle down", cmnd4);
                Console.WriteLine("5 - pitch up", cmnd5);
                Console.WriteLine("6 - left rudder", leftRudder);
                Console.WriteLine("7 - right rudder", rightRudder);
                Console.WriteLine("8 - pitch down", cmnd8);
                Console.WriteLine("9 - takeoff");
                Console.WriteLine("10 - center rudder", cmnd10);
                Console.WriteLine("11 - brakes", cmnd11);

                Console.WriteLine("enter choose, 99 to exit");
                i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("you have chosen", i);

                if (i == 1) {
                    Console.WriteLine("brakes ", brakecmnd);
                    runCommand(brakecmnd);
                }

                else if (i == 2)
                {
                    Console.WriteLine("throttle up ", cmnd2);
                    runCommand(cmnd2);
                }
                else if (i == 3)
                {
                    Console.WriteLine("pitch takeoff ", cmnd3);
                    runCommand(cmnd3);
                }
                else if (i == 4)
                {
                    Console.WriteLine("throttle down", cmnd4);
                }
                else if (i == 5)
                {
                    Console.WriteLine("pitch up", cmnd5);
                }
                else if (i == 6)
                {
                    Console.WriteLine("left rudder", leftRudder);
                }
                else if (i == 7)
                {
                    Console.WriteLine("right rudder", rightRudder);
                }
                else if (i == 8)
                {
                    Console.WriteLine("pitch down", cmnd8);
                }

                else if (i == 9)
                {
                    Console.WriteLine("takeoff");
                    runCommand(brakecmnd);//this is brakes off
                    Thread.Sleep(3000);

                    for (int j = 0; j < 30; j++) 
                    {
                        runCommand(cmnd2);//throttle up
                        Thread.Sleep(100);
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        runCommand(cmnd2);
                        Thread.Sleep(100);
                        runCommand(rightRudder);
                        Thread.Sleep(4500);
                        runCommand(cmnd10);
                        Thread.Sleep(1000);
                    }
                    for (int y = 0; y < 30; y++)
                    {
                        runCommand(cmnd2);
                        Thread.Sleep(100);
                    }
                    for (int k = 0; k < 2; k++)
                    {
                        //runCommand(leftRudder);
                        //Thread.Sleep(1000);
                        runCommand(rightRudder);
                        Thread.Sleep(2000);
                        runCommand(cmnd10);
                        Thread.Sleep(1000);
                    }
                    for (int k = 0; k < 1; k++)
                    {
                        runCommand(rightRudder);
                        Thread.Sleep(2000);
                    }

                    Thread.Sleep(5000);
                    for (int u = 0; u < 25; u++)
                    {
                        runCommand(cmnd5);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(15000);

                    for (int f = 0; f < 5; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                        runCommand(cmnd4);
                        runCommand(cmnd4);
                    }
                   
                    Thread.Sleep(3000);

                    for (int f = 0; f < 10; f++)
                    {
                        runCommand(cmnd5);
                        Thread.Sleep(100);
                    }
                    for (int f = 0; f < 5; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(5000);
                    for (int f = 0; f < 10; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    for (int f = 0; f < 10; f++)
                    {
                        runCommand(cmnd5);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(5000);
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(5000);
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(10000);
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd4);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(10000);
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(10000);
                    for (int f = 0; f < 15; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }
                    
                    for (int f = 0; f < 6; f++)
                    {
                        runCommand(cmnd5);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(5000);
                    for (int f = 0; f < 6; f++)
                    {
                        runCommand(cmnd8);
                        Thread.Sleep(100);
                    }

                    for (int f = 0; f < 30; f++)
                    {
                        runCommand(cmnd4);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(1000);
                    for (int f = 0; f < 1; f++)
                    {
                        runCommand(cmnd11);
                        Thread.Sleep(100);
                    }
                    //sim/flight_controls/brakes_toggle_max


                }
                else if (i == 10)
                {
                    runCommand(cmnd10);
                }
                else if (i == 11)
                {
                    runCommand(cmnd11);
                }

                //sim/flight_controls/aileron_trim_left

            }
            Console.WriteLine("Good Bye");
            Console.ReadLine();//lets the black box open
        }
    }
  }
