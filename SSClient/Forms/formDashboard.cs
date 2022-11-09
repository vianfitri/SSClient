using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SSClient.Forms;
using SSClient.Class;

namespace SSClient
{
    public partial class formDashboard : Form
    {
        #region "Fields"
        formMain _parent;
        private Form activeForm = null;

        System.Timers.Timer t;
        int h, m, s;
        private float timeElapsed = 0; // in minute
        private float timeStandard = 0; // in minute

        #region "Help Assistant"
        private ReadWriteFile appConf;
        private string[] dataString = new string[2];
        private readonly string[] identifiedString = { "[HelpServer]", "Host=", "Port=" };
        public string Host, Port;

        private readonly string configDir =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ShipStab";

        private bool connected = false;
        private Thread client = null;
        private struct MyClient
        {
            public string key;
            public string ipaddress;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        private MyClient obj;
        private Task send = null;
        private bool exit = false;
        #endregion

        #endregion

        #region "Constructor"
        public formDashboard(formMain parent)
        {
            InitializeComponent();
            customizeDesign();
            this._parent = parent;
            t = new System.Timers.Timer();
        }
        #endregion

        #region "Properties"
        public float TimeElapsed
        {
            get { return timeElapsed; }
            set { timeElapsed = value; }
        }

        public float TimeStandard
        {
            get { return timeStandard; }
            set { timeStandard = value; }
        }
        #endregion

        #region "Methods"
        private void LoadExercise()
        {
            string qExerc = "SELECT * FROM `shp_assets`.`ss_exercise` WHERE uc = '111-11111-11'";
            int exerciseMode = 0;

            if (ConnectorDB.MySQLConn.GetData(qExerc, "mode", ref exerciseMode))
            {
                if (exerciseMode == 0)
                {
                    ExerciseController.EMode = ExerciseController.ExerciseMode.Training;
                }
                else if (exerciseMode == 1)
                {
                    ExerciseController.EMode = ExerciseController.ExerciseMode.Test;
                }
            }
        }

        private void customizeDesign()
        {
        }

        private void hideSubmenu()
        {
            // Killl Another Application If Exist
            Process[] procs = Process.GetProcessesByName("ShipStability");
            foreach(Process proc in procs)
            {
                proc.Kill();
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void loadLoginInfo(string logId)
        {
            DataTable dtLoginInfo = new DataTable();
            string qrStr = "SELECT a.uc, " +
                "b.first_name, b.last_name, b.birthday, b.sex, b.email, b.photos, " +
                "c.typename " +
                "FROM `shp_assets`.`ss_user` a " +
                "INNER JOIN `shp_assets`.`ss_subject` b " +
                "ON a.uc_subject = b.uc " +
                "INNER JOIN `shp_assets`.`ss_usertype` c " +
                "ON b.type = c.id " +
                "WHERE a.uc = '" + logId + "' LIMIT 0, 1";

            if (ConnectorDB.MySQLConn.GetTableData(qrStr, ref dtLoginInfo))
            {
                lblUsername.Text = dtLoginInfo.Rows[0]["first_name"].ToString();
                lblPriviledge.Text = dtLoginInfo.Rows[0]["typename"].ToString();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Load Setting Page
            openChildForm(new fSetting());

            hideSubmenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserController.isLogin = false;
                UserController.currentUcUser = "";

                // Close Connection from Assistant Server when logout
                ClientClosing();

                this._parent.openChildForm(this._parent.fLogin);
                openChildForm(new formWelcome());
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            // Load Help Assistant Server connection configuration
            LoadHelpConfig();

            // Create Help Assistant Server Connection
            CreateConnection(Host, Port);

            // Load default content
            openChildForm(new formWelcome());

            // Load Exercise mode
            LoadExercise();

            if(ExerciseController.EMode == ExerciseController.ExerciseMode.Test)
            {
                
                btnShip.Visible = false;
                btnStability.Visible = false;

                // Disable Help Assistant Button
                btnHelp.Enabled = false;
                btnHelp.IconColor = Color.White;
                btnHelp.ForeColor = Color.White;

                // Load Scenario and Duplicate DB Scen
                ScenLoad();

                // Init Time For Test
                InitTimeTest();

                pnlTimerTest.Visible = true;
            }
            else
            {
                btnShip.Visible = true;
                btnStability.Visible = true;
                pnlTimerTest.Visible = false;
            }

            loadLoginInfo(UserController.currentUcUser);

            hideSubmenu();
        }

        private void btnStability_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            openChildForm(new fSSS(this));

            hideSubmenu();
        }

        private void hiddenPannel_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            //openChildForm(new fSSS());

            //hideSubmenu();
        }

        private void ScenLoad()
        {
            // Get Active Scenario
            int activeScenNum = 0;

            string qActScen = "SELECT * FROM `shp_assets`.`ss_scenario` WHERE is_active = 1";

            if (ConnectorDB.MySQLConn.GetTotalRow(qActScen, ref activeScenNum))
            {
                if (activeScenNum > 0)
                {
                    // get data from active scenario
                    DataTable dActScen = new DataTable();

                    if (ConnectorDB.MySQLConn.GetTableData(qActScen, ref dActScen))
                    {
                        int ScenPractNum = 0;

                        ExerciseController.VesselType = (int)dActScen.Rows[0]["vessel_type"];

                        // get data scenario practicum for student. if null created
                        string qScenPra = "SELECT * FROM `shp_assets`.`ss_scenario_practicum` " +
                            "WHERE uc_scenario = '" + dActScen.Rows[0]["uc"] + "' " +
                            "AND uc_student = '" + UserController.currentUcUser + "'";

                        if (ConnectorDB.MySQLConn.GetTotalRow(qScenPra, ref ScenPractNum))
                        {
                            if (ScenPractNum > 0)
                            {
                                // get database name for student practicum
                                DataTable dScenPra = new DataTable();
                                if(ConnectorDB.MySQLConn.GetTableData(qScenPra, ref dScenPra))
                                {
                                    ExerciseController.CurrentDBName = dScenPra.Rows[0]["db_name"].ToString();
                                    btnStability_Click(null,null);
                                }
                            }
                            else
                            {
                                // duplicate database
                                string fromDB = dActScen.Rows[0]["db_name"].ToString();
                                string toDB = dActScen.Rows[0]["db_name"].ToString() + "_" + UserController.currentUcUser;

                                if(ConnectorDB.MySQLConn.DuplicateDB(fromDB, toDB))
                                {
                                    // insert data to Scenario Practicum table
                                    string qInScenPra = "INSERT INTO `shp_assets`.`ss_scenario_practicum` " +
                                        "(" +
                                        "`uc`, " +
                                        "`uc_scenario`," +
                                        "`db_name`," +
                                        "`vessel_type`," +
                                        "`uc_student`" +
                                        ") VALUES (" +
                                        "'" + UserController.currentUcUser + "'," +
                                        "'" + dActScen.Rows[0]["uc"] + "'," +
                                        "'" + toDB + "'," +
                                        dActScen.Rows[0]["vessel_type"] + "," +
                                        "'" + UserController.currentUcUser + "'" + 
                                        ")";

                                    if (ConnectorDB.MySQLConn.SetCommand(qInScenPra))
                                    {
                                        ExerciseController.CurrentDBName = toDB;
                                        btnStability_Click(null, null);
                                    }
                                }
                            }
                        }
                    }
                } 
                else
                {
                    Console.WriteLine("No Active Scenario");
                }
            }
        }

        private void InitTimeTest()
        {
            t.Interval = 1000; // 1s
            t.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                txtTimeE.Text = string.Format("{0}:{1}:{2}",
                    h.ToString().PadLeft(2, '0'),
                    m.ToString().PadLeft(2, '0'),
                    s.ToString().PadLeft(2, '0')
                    );

                timeElapsed = (h * 60) + m + (s / 60);
            }));
        }

        public void StartTest()
        {
            int timeStdHour = (int)(timeStandard / 60);
            int timeStdMinute = (int)(timeStandard - (timeStdHour * 60));
            txtStdTime.Text = string.Format("{0}:{1}:{2}",
                timeStdHour.ToString().PadLeft(2, '0'),
                timeStdMinute.ToString().PadLeft(2, '0'),
                "00");
            t.Start();
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            // Load Instructor Data
            openChildForm(new fShipData());

            hideSubmenu();
        }

        public void StopTest()
        {
            t.Stop();

            // Reset h, m, s
            h = 0;
            m = 0;
            s = 0;
            txtTimeE.Text = "00:00:00";
            txtStdTime.Text = "00:00:00";
        }

        private void formDashboard_VisibleChanged(object sender, EventArgs e)
        {
            if (UserController.isLogin)
            {
                loadLoginInfo(UserController.currentUcUser);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Send("rh$");
        }

        #region "Assistant Help"
        private void LoadHelpConfig()
        {
            appConf = new ReadWriteFile();
            if (appConf.LoadConfig(configDir, "help.ini", identifiedString, ref dataString))
            {
                Host = dataString[0];
                Port = dataString[1];
            }
            else
            {
                IPAddress[] ipA = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                Host = ipA[ipA.Length -1].ToString();
                Port = "8789";
                dataString[0] = Host;
                dataString[1] = Port;

                appConf.SaveConfig(configDir, "help.ini", identifiedString, ref dataString);
            }
        }

        public void Connected(bool status)
        {
            if (!exit)
            {
                connected = status;
                if (status)
                {
                    //StatusChange?.Invoke(connected);
                    Console.WriteLine("You are now connected");
                }
                else
                {
                    //StatusChange?.Invoke(connected);
                    Console.WriteLine("You are now disconnected");
                }
            }
        }

        private void Read(IAsyncResult result)
        {
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                    }
                    else
                    {
                        // check assistant help enabled
                        ProcessMessage(obj.data.ToString());

                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Console.WriteLine(ex.Message);
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private void ReadAuth(IAsyncResult result)
        {
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer(); // feel free to use JSON serializer
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(obj.data.ToString());
                        if (data.ContainsKey("status") && data["status"].Equals("ack"))
                        {
                            Connected(true);
                        }
                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Console.WriteLine(ex.Message);
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private bool Authorize()
        {
            bool success = false;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ipaddress", obj.ipaddress);
            data.Add("key", "ShipStability");
            JavaScriptSerializer json = new JavaScriptSerializer(); // feel free to use JSON serializer
            Send(json.Serialize(data));

            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    obj.handle.WaitOne();
                    if (connected)
                    {
                        success = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (!connected)
            {
                Console.WriteLine("Unauthorized");
            }
            return success;
        }

        private void Connection(IPAddress ip, int port)
        {
            try
            {
                obj = new MyClient();
                obj.key = "ShipStability";
                obj.client = new TcpClient();
                obj.client.Connect(ip, port);
                obj.ipaddress = ((IPEndPoint)obj.client.Client.LocalEndPoint).Address.ToString();
                obj.stream = obj.client.GetStream();
                obj.buffer = new byte[obj.client.ReceiveBufferSize];
                obj.data = new StringBuilder();
                obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                if (Authorize())
                {
                    while (obj.client.Connected)
                    {
                        try
                        {
                            obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                            obj.handle.WaitOne();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    obj.client.Close();
                    Connected(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateConnection(string host, string ports)
        {
            if (connected)
            {
                obj.client.Close();
            }
            else if (client == null || !client.IsAlive)
            {
                string address = host;
                string number = ports;
                bool error = false;
                IPAddress ip = null;
                if (address.Length < 1)
                {
                    error = true;
                    Console.WriteLine("Address is required");
                }
                else
                {
                    try
                    {
                        ip = Dns.Resolve(address).AddressList[0];
                    }
                    catch
                    {
                        error = true;
                        Console.WriteLine("Address is not valid");
                    }
                }
                int port = -1;
                if (number.Length < 1)
                {
                    error = true;
                    Console.WriteLine("Port number is required");
                }
                else if (!int.TryParse(number, out port))
                {
                    error = true;
                    Console.WriteLine("Port number is not valid");
                }
                else if (port < 0 || port > 65535)
                {
                    error = true;
                    Console.WriteLine("Port number is out of range");
                }
                if (!error)
                {
                    // encryption key is optional
                    client = new Thread(() => Connection(ip, port))
                    {
                        IsBackground = true
                    };
                    client.Start();
                }
            }
        }

        private void Write(IAsyncResult result)
        {
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void BeginWrite(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Send(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg));
            }
        }

        public void ClientClosing()
        {
            exit = true;
            if (connected)
            {
                obj.client.Close();
            }
        }

        private void ProcessMessage(string msg)
        {
            if (msg.Contains("en$"))
            {
                btnHelp.Enabled = true;
                btnHelp.IconColor = Color.Green;
                btnHelp.ForeColor = Color.Green;
            }
            else if (msg.Contains("dis$"))
            {
                btnHelp.Enabled = false;
                btnHelp.IconColor = Color.White;
                btnHelp.ForeColor = Color.White;
            }
        }
        #endregion

        #endregion
    }
}
