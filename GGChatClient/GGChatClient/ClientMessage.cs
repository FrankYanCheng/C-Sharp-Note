using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GGChatClient
{
    /// <summary>
    /// 用于对客户端所需的信息进行定义
    /// </summary>
    class ClientMessage
    {
        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string question;

        public string Question
        {
            get { return question; }
            set { question = value; }
        }
        private string answer;

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
    }
}
