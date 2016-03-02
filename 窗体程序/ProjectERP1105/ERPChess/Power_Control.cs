using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace ERPChess
{
    class Power_Control
    {
        /// <summary>
        ///  串口
        /// </summary>
        private SerialPort comPort = null;

        /// <summary>
        ///  串口缓冲区
        /// </summary>
        private byte[] comBuffer = new byte[4096];

        public String ComPortNo;

        public Power_Control(String comPort)
        {
            this.ComPortNo = comPort;
        }


        private bool SendCmd(String cmdText)
        {
            try
            {
                comPort = new SerialPort(ComPortNo) { ReadTimeout = 500, BaudRate = 9600, DataBits = 8 };
                comPort.Parity = Parity.None;
                comPort.ReadBufferSize = 8096;

                comPort.StopBits = StopBits.One;
                comPort.WriteTimeout = 500;
                comPort.Open();

                // 发送过程
                string[] str_cmd = cmdText.Trim().Split(' ');
                byte[] cmd = new byte[str_cmd.Length];

                for (int i = 0; i < str_cmd.Length; i++)
                {
                    cmd[i] = Convert.ToByte(str_cmd[i], 16);


                }

                if (comPort != null && comPort.IsOpen)
                {
                    comPort.Write(cmd, 0, cmd.Length);

                    comPort.Close();
                    comPort = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return false;
        }

        /// <summary>
        /// 打开1路继电器
        /// </summary>
        /// <returns>成功返回True</returns>
        public bool Open()
        {
            return SendCmd("55 01 01 02 00 00 00 59");
        }


        /// <summary>
        /// 关闭 1 路继电器
        /// </summary>
        /// <returns>成功返回True</returns>
        public bool Close()
        {
            return SendCmd("55 01 01 01 00 00 00 58");
        }
    }
}
