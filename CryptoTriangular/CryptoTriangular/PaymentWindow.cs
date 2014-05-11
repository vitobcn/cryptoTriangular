using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth;
using Data;

namespace CryptoTriangular
{
    public partial class PaymentWindow : Form
    {
        public ServerPackage package;
        public PaymentWindow()
        {
            InitializeComponent();
            btn_checkStatus_Click(new object(),new EventArgs());
        }

        public PaymentWindow(ServerPackage receivedPackage)
        {
            InitializeComponent();
            lb_accountHasExpired.Text = String.Format("Your account has expired!");
            receivedPackage.locked = true;
            package = receivedPackage;
            lb_addressBtc.Text = package.wallet;
            this.Enabled = true;
            btn_checkStatus.Enabled = true;
        }

        public void UpdateUser()
        {
            Options.Instance.accountLocked = package.locked;
        }

        private void btn_checkStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                btn_checkStatus.Enabled = false;
                AuthUser auth = new AuthUser();
                var serverpackage = auth.ValidateUser();
                if (serverpackage.validationResult == ValidationResult.actual)
                {
                    lb_accountHasExpired.Text = String.Format("Account active for {0} day(s)",
                        serverpackage.GetDaysToExpire());
                    serverpackage.locked = false;
                }
                else if (serverpackage.validationResult == ValidationResult.expired)
                {
                    lb_accountHasExpired.Text = String.Format("Your account has expired!");
                    serverpackage.locked = true;
                }
                else if (serverpackage.validationResult == ValidationResult.temporary)
                {
                    lb_accountHasExpired.Text = String.Format("Right now, you use it for free!");
                    serverpackage.locked = false;
                    label9.Visible = true;
                    button2.Visible = true;
                    lb_accountHasExpired.Location = new System.Drawing.Point(36, 9);
                    label1.Visible = label2.Visible = label3.Visible = label4.Visible =
                        label5.Visible = label6.Visible = label7.Visible =
                        label8.Visible = btn_checkStatus.Visible = false;
                }
                package = serverpackage;
                lb_addressBtc.Text = package.wallet;
                this.Enabled = true;
                btn_checkStatus.Enabled = true;
            }
            catch (Exception ee)
            {
                //Log.Error(ee);
                //HandleError.CloseProgram();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
            this.Enabled = true;
        }
    }
}
