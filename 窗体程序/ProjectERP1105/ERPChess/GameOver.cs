using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPChess;
namespace ERPChess
{
    public class GameOver
    {
        delegate void lbl_enable();
        private static void stop()
        {
            if (Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].InvokeRequired)
            {
                lbl_enable temp = stop;
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Invoke(temp);
            }
            else
            {
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Enabled = false;
                Program.Forms.frmMain.listLklb[Program.Forms.frmMain.step - 1].Refresh();
            }
            Program.Forms.frmMain.lbl_Cash.Text = Math.Round(PubVar.Fund).ToString() + "百万";
        }
        private delegate void cash_refresh(double fund);
        public static void newCash(double fund)
        {
            if (Program.Forms.frmMain.lbl_Cash.InvokeRequired)
            {
                cash_refresh cash = newCash;
                Program.Forms.frmMain.lbl_Cash.Invoke(cash);
            }
            else
            {
                Program.Forms.frmMain.lbl_Cash.Text = fund.ToString();
                Program.Forms.frmMain.lbl_Cash.Refresh();
            }
        }
        public static void gameOver()
        {
            
            //string Order = "Quit" + "//" + PubVar.PlayerName.ToString() + "//" + MessageType.btnStartGame.ToString();
            //Program.client.ClientNet.BeginSend(Encoding.Unicode.GetBytes(Order));


            // 你用主板自带的串口号是COM1
            Power_Control pc = new Power_Control("COM1");
            pc.Close();
            
            stop();
            Program.Forms.frmMain.step = 0;
            Form_Fail frm = new Form_Fail();
            if(PubVar.year <11)
            frm.ShowDialog();
        }
        public static double total_Points()
        {
            double temp = 0;

            temp += 112 * PubVar.equipment_30kw;
            temp += 594 * PubVar.equipment_60kw;

            if (PubVar.IsHaveISO9000)
            {
                temp += 2;
            }
            if (PubVar.IsHaveISO14000)
            {
                temp += 4;
            }
            if (PubVar.IsHaveISO18000)
            {
                temp += 4;
            }
            if (PubVar.IsHaveSecurity)
            {
                temp += 4;
            }

            temp += Math.Round(PubVar.closing[PubVar.year - 1].Anl_proCash);
            temp += Math.Round(PubVar.closing[PubVar.year - 1].Anl_proRaccount);
            temp -= Math.Round((PubVar.closing[PubVar.year - 1].Cc_o_Sloan + PubVar.closing[PubVar.year - 1].Cc_o_Lloan) / 100);
            temp = PubVar.closing[PubVar.year - 1].Anl_rightsT * (1 + temp / 100) + PubVar.PlayerScore;
            return temp;
        }
    }
}
