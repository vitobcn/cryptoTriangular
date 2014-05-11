using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Auth;
using CryptoTriangular.Properties;
using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CryptoTriangular
{
    public partial class MainWindow : Form
    {
        #region Properties
        private DataCollector background;
        public Options _options;
        private bool m_isExiting;
        private Timer _timer;
        private Timer _timerAuth;
        private ServerPackage _authPackage;
        public bool isLoop = false;
        public bool firstLoop = true;
        int actualSortColumn;
        SortOrder sortType;
        private string earlierBallonText = "";
        private int balloonCounter = 0;
        #endregion

        #region constructor
        public MainWindow(ServerPackage package)
        {
            InitializeComponent();
            background = new DataCollector();
            toolStripStatusInfo.Text = Resources.Ready;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Visible = false;
            LoadOptions();
            InitTimerValidation();
            UpdateSettings();
            UpdateCurrencies();
            UpdateToolStripUpdates(package);
        }
        #endregion

        #region Timers and validation
        public void InitTimer()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(button1_Click);
            _timer.Interval = Convert.ToInt32(Options.Instance.TimerInterval);
            _timer.Start();
        }

        public void InitTimerValidation()
        {
            _timerAuth = new Timer();
            _timerAuth.Tick += new EventHandler(InvokeValidation);
            _timerAuth.Interval = 21600000; //6h
            _timerAuth.Start();
        }

        public void InvokeValidation(object o, EventArgs arg)
        {
            bool shouldClose = false;
            var auth = new AuthUser();
            _authPackage = auth.ValidateUser();
            if (_authPackage == null)
            {
                MessageBox.Show("Could not connect to server. Application will be closed immediately.");
                Application.Exit();
                shouldClose = true;
            }
            if (_authPackage != null && _authPackage.validationResult == ValidationResult.expired)
            {
                MessageBox.Show(
                    @"Your account has expired. Please Upgrade your account.\nNow, program will be closed immediately.",
                    @"CryptoDelivery",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                shouldClose = true;
            }

            if (shouldClose)
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName("CryptoTriangular");
                    foreach (Process prog in proc)
                        prog.Kill();
                }
                catch (Exception)
                {
                    Environment.Exit(0);
                }
            }

            UpdateToolStripUpdates(_authPackage);
        }

        #endregion

        #region Worker methods
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            toolStripStatusInfo.Text = Resources.Processing;
            background.InvokeComputingMethod();     
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IList<ArbitrageItem> resultsToDataGrid = new List<ArbitrageItem>();
            foreach (var item in background.arbitrageList.OrderByDescending(x => x.PercentBenefit))
            {
                resultsToDataGrid.Add(item);
            }
            if (resultsToDataGrid.Count > 0)
                dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns["PercentBenefit"].DefaultCellStyle.Format = "###.##########";
            dataGridView1.DataSource = resultsToDataGrid;
            toolStripStatusInfo.Text = Resources.Ready;
            if (isLoop != true)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            if (background.arbitrageList.Count > 0)
            {
                dataGridView1.Visible = true;
                if (Options.Instance.SoundNotification == true && FormWindowState.Normal == this.WindowState)
                {
                    var player = new System.Media.SoundPlayer();
                    player.Stream = Resources.doorbell;
                    player.Play();
                }

                if (Options.Instance.DisplayBalloonWhenPercentChanges == true && FormWindowState.Minimized == this.WindowState)
                {
                    var BallonText = String.Format("Best offer brings you {0}% of benefit",resultsToDataGrid.First().PercentBenefit.ToString("##.######"));
                    if (earlierBallonText.Equals(BallonText) == false)
                    {
                        notifyIcon1.BalloonTipText = BallonText;
                        earlierBallonText = BallonText;
                        if(Options.Instance.HideBalloonAfter5thDisplay==false && balloonCounter<5)
                            if (Options.Instance.SoundNotification == true)
                            {
                                var player = new System.Media.SoundPlayer();
                                player.Stream = Resources.doorbell;
                                player.Play();
                                notifyIcon1.ShowBalloonTip(1500);
                            }
                            else
                                notifyIcon1.ShowBalloonTip(1500);
                        balloonCounter++;
                    }
                }
            }
        }
        #endregion

        #region menu actions
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
           // _options = optionsWindow.ReceiveOptions();
            this.Enabled = true;
            UpdateSettings();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var currenciesWindow = new CurrenciesWindow();
            currenciesWindow.ShowDialog();
            this.Enabled = true;
            UpdateCurrencies();
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:mail@cryptocurrencyworld.eu");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainWindow_FormClosing(new object(), new FormClosingEventArgs(CloseReason.ApplicationExitCall, false));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void PaymentsMenuItem_Click(object sender, EventArgs e)
        {
            var paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_isExiting)
            {
                var result = MessageBox.Show(@"Do you really want to exit?", @"CryptoTriangular", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    m_isExiting = true;
                    Application.Exit();
                }
            }
        }
        #endregion

        #region updating view
        public void UpdateToolStripUpdates(ServerPackage package)
        {
            var currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (System.String.Compare(package.newestVersion, currentVersion, System.StringComparison.Ordinal) > 0)
            {
                UpdateToolStripUpdates(true);
            }
            else
            {
                UpdateToolStripUpdates(false);
            }
        }

        public void UpdateSettings()
        {
            lb_sound.Text = Options.Instance.SoundNotification == true ? "ON" : "OFF";
            lb_allpaths.Text = Options.Instance.displayAllPaths == true ? "ON" : "OFF";
            lb_favRoutes.Text = Options.Instance.OnlyFavouriteTracks == true ? "ON" : "OFF";
            lb_refInterval.Text = Options.Instance.TimerInterval / 1000 + " sec";
            lb_minbenefit.Text = Options.Instance.minPercentBenefit + " %";
        }

        public void UpdateCurrencies()
        {
            lb_doge.Text = Options.Instance.selectedCurrency.Contains("DOGE") == true ? "ON" : "OFF";
            lb_aur.Text = Options.Instance.selectedCurrency.Contains("AUR") == true ? "ON" : "OFF";
            lb_nxt.Text = Options.Instance.selectedCurrency.Contains("NXT") == true ? "ON" : "OFF";
            lb_ppc.Text = Options.Instance.selectedCurrency.Contains("PPC") == true ? "ON" : "OFF";
            lb_wdc.Text = Options.Instance.selectedCurrency.Contains("WDC") == true ? "ON" : "OFF";
            lb_qrk.Text = Options.Instance.selectedCurrency.Contains("QRK") == true ? "ON" : "OFF";

            lb_zetcoin.Text = Options.Instance.selectedCurrency.Contains("ZET") == true ? "ON" : "OFF";
            lb_bc.Text = Options.Instance.selectedCurrency.Contains("BC") == true ? "ON" : "OFF";
            lb_infinitecoin.Text = Options.Instance.selectedCurrency.Contains("IFC") == true ? "ON" : "OFF";
            lb_primecoin.Text = Options.Instance.selectedCurrency.Contains("XPM") == true ? "ON" : "OFF";
            lb_digitalcoin.Text = Options.Instance.selectedCurrency.Contains("DGC") == true ? "ON" : "OFF";
            lb_franco.Text = Options.Instance.selectedCurrency.Contains("FRK") == true ? "ON" : "OFF";

            lb_goldcoin.Text = Options.Instance.selectedCurrency.Contains("GLD") == true ? "ON" : "OFF";
            lb_netcoin.Text = Options.Instance.selectedCurrency.Contains("NET") == true ? "ON" : "OFF";
            lb_PhoenixCoin.Text = Options.Instance.selectedCurrency.Contains("PXC") == true ? "ON" : "OFF";
            lb_stablecoin.Text = Options.Instance.selectedCurrency.Contains("SBC") == true ? "ON" : "OFF";
            lb_yacoin.Text = Options.Instance.selectedCurrency.Contains("YAC") == true ? "ON" : "OFF";
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                       
            ArbitrageItemSorter sorter = null;
            DrawSortArrow(e.ColumnIndex);
            string column = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            switch (column)
            {
                case "StepOne":
                    sorter = new ArbitrageItemSorter(ArbitrageItemSorter.SField.StepOne, sortType); //ArbitrageItemSorter.SField.PercentBenefit, SetOrderDirection(column));
                    break;
                case "StepTwo":
                    sorter = new ArbitrageItemSorter(ArbitrageItemSorter.SField.StepTwo, sortType); //ArbitrageItemSorter.SField.PercentBenefit, SetOrderDirection(column));
                    break;
                case "StepThree":
                    sorter = new ArbitrageItemSorter(ArbitrageItemSorter.SField.StepThree, sortType); //ArbitrageItemSorter.SField.PercentBenefit, SetOrderDirection(column));
                    break;
                case "Profit":
                    sorter = new ArbitrageItemSorter(ArbitrageItemSorter.SField.Profit, sortType); //ArbitrageItemSorter.SField.PercentBenefit, SetOrderDirection(column));
                    break;
                case "PercentBenefit":
                    sorter = new ArbitrageItemSorter(ArbitrageItemSorter.SField.PercentBenefit, sortType); //ArbitrageItemSorter.SField.PercentBenefit, SetOrderDirection(column));
                    break;
            }
            

            List<ArbitrageItem> ailist = dataGridView1.DataSource as List<ArbitrageItem>;
            if (ailist == null || ailist.Count==0)
                return;
            ailist.Sort(sorter);
            dataGridView1.DataSource = ailist;
            dataGridView1.Refresh();
        }

        private void DrawSortArrow(int columnIndex)
        {
            dataGridView1.Columns[actualSortColumn].HeaderCell.SortGlyphDirection = SortOrder.None;
            SetOrderDirection(columnIndex);
            dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = sortType;

        }

        private void SetOrderDirection(int columnIndex)
        {
            if (actualSortColumn == columnIndex)
            {
                sortType = sortType == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                actualSortColumn = columnIndex;
                sortType = SortOrder.Ascending;
            }         
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows) 
                row.Cells[4].Style = style;
        }

        private void UpdateToolStripUpdates(bool updatesAvailable=false)
        {
            if (updatesAvailable == false)
            {
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "No Updates";
                toolStripStatusLabel1.IsLink = false;
            }
            else
            {
                toolStripStatusLabel1.ForeColor = Color.Blue;
                toolStripStatusLabel1.Text = "New version available";
                toolStripStatusLabel1.IsLink = true;
                toolStripStatusLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
                toolStripStatusLabel1.VisitedLinkColor = Color.Brown;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = "@Has been minimized to tray";
                notifyIcon1.ShowBalloonTip(900);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            balloonCounter = 0;
        }
        #endregion

        #region buttons Action
        private void button1_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy != true)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                worker.RunWorkerAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //_timer.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            if (worker.IsBusy != true)
            {
                if (isLoop == false)
                {
                    if (firstLoop == true)
                    {
                        worker.RunWorkerAsync();
                    }
                    firstLoop = false;
                    InitTimer();
                    isLoop = true;
                    button2.Text = Resources.Cancel_Loop;
                }
                else
                {
                    _timer.Stop();
                    isLoop = false;
                    firstLoop = true;
                    worker.CancelAsync();
                    toolStripStatusInfo.Text = Resources.Ready;
                    button1.Enabled = true;
                    
                    button2.Text = Resources.Get_in_Loop;
                }

            }
            else
            {
                worker.CancelAsync();
                toolStripStatusInfo.Text = Resources.Ready;
                button2.Text = Resources.Get_in_Loop;
                button1.Enabled = true;
                _timer.Stop();
            }       
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text != "No Updates")
                Process.Start("http://cryptocurrencyworld.eu");
        }
        #endregion

        #region Options from/to XML

        public void LoadOptions()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                System.Xml.Serialization.XmlSerializer reader =
                    new System.Xml.Serialization.XmlSerializer(typeof(Options));
                System.IO.StreamReader file = new System.IO.StreamReader(path + "\\options.xml");
                var _options = (Options)reader.Deserialize(file);
                if(_options.selectedCurrency.Count==0)
                    _options.selectedCurrency = Enum.GetNames(typeof(CurrencyCode)).ToList();
                Options.Instance = _options;
            }
            catch (FileNotFoundException e)
            {
                Options.Instance.selectedCurrency = Enum.GetNames(typeof(CurrencyCode)).ToList();
                SaveOptions();
            }
            catch (Exception e)
            {
                //Log.Error(e);
            }

        }

        public void SaveOptions()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                System.Xml.Serialization.XmlSerializer writer = new XmlSerializer(typeof(Options));
                System.IO.StreamWriter file = new StreamWriter(path + "\\options.xml");
                writer.Serialize(file, Options.Instance);
                file.Close();
            }
            catch (Exception e)
            {
                //Log.Error(e);
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveOptions();
        }
        #endregion
    }
}