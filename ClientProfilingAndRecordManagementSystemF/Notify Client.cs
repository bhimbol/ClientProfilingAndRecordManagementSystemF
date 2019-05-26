using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using System;
using System.Windows.Forms;

namespace ClientProfilingAndRecordManagementSystemF
{
    public partial class Notify_Client : Form
    {
        public Notify_Client()
        {
            InitializeComponent();
        }

        private GsmCommMain commMain;

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            commMain = new GsmCommMain(portNumber: 3, baudRate: 115200, timeout: 500);

            commMain.Open();
        }

        private void bt_Send_Click(object sender, EventArgs e)
        {
            SmsSubmitPdu pdu;
            pdu = new SmsSubmitPdu(textBox1.Text, textBox2.Text, "");

            commMain.SendMessage(pdu);
        }
    }
}
