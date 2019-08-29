using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SystemMonitor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelCpu;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelMemP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelMemV;
		private System.Windows.Forms.Label labelDiskR;
		private System.Windows.Forms.Label labelDiskW;
		private System.Windows.Forms.Label labelNetO;
		private System.Windows.Forms.Label labelNetI;
		private System.Windows.Forms.Label labelNames;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxProcessor;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelModel;

		private SystemMonitor.DataBar dataBarCPU;
		private SystemMonitor.DataBar dataBarMemP;
		private SystemMonitor.DataBar dataBarMemV;
		private SystemMonitor.DataChart dataChartDiskR;
		private SystemMonitor.DataChart dataChartDiskW;
		private SystemMonitor.DataChart dataChartNetI;
		private SystemMonitor.DataChart dataChartNetO;
		private SystemMonitor.DataChart dataChartCPU;
		private SystemMonitor.DataChart dataChartMem;

		private ArrayList  _listDiskR = new ArrayList();
		private ArrayList  _listDiskW = new ArrayList();
		private ArrayList  _listNetI = new ArrayList();
		private ArrayList  _listNetO = new ArrayList();

		private ArrayList  _listCPU = new ArrayList();
		private ArrayList  _listMem = new ArrayList();

		private SystemData sd = new SystemData();
		private Size _sizeOrg;
		private Size _size;

		public Form1()
		{
			InitializeComponent();

			_size = Size;
			_sizeOrg = Size;

			labelModel.Text = sd.QueryComputerSystem("manufacturer") +", " + sd.QueryComputerSystem("model");
			textBoxProcessor.Text = sd.QueryEnvironment("%PROCESSOR_IDENTIFIER%");
			labelNames.Text = "User: " +sd.QueryComputerSystem("username");  //sd.LogicalDisk();

			UpdateData();
			timer.Interval = 1000;
			timer.Start();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.labelNetI = new System.Windows.Forms.Label();
            this.labelNetO = new System.Windows.Forms.Label();
            this.labelDiskW = new System.Windows.Forms.Label();
            this.labelDiskR = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMemV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMemP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCpu = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelNames = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxProcessor = new System.Windows.Forms.TextBox();
            this.dataChartMem = new SystemMonitor.DataChart();
            this.dataChartCPU = new SystemMonitor.DataChart();
            this.dataChartNetI = new SystemMonitor.DataChart();
            this.dataChartNetO = new SystemMonitor.DataChart();
            this.dataChartDiskW = new SystemMonitor.DataChart();
            this.dataChartDiskR = new SystemMonitor.DataChart();
            this.dataBarMemV = new SystemMonitor.DataBar();
            this.dataBarMemP = new SystemMonitor.DataBar();
            this.dataBarCPU = new SystemMonitor.DataBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNetI
            // 
            this.labelNetI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetI.Location = new System.Drawing.Point(13, 468);
            this.labelNetI.Name = "labelNetI";
            this.labelNetI.Size = new System.Drawing.Size(256, 23);
            this.labelNetI.TabIndex = 18;
            this.labelNetI.Text = "Net I";
            // 
            // labelNetO
            // 
            this.labelNetO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetO.Location = new System.Drawing.Point(282, 468);
            this.labelNetO.Name = "labelNetO";
            this.labelNetO.Size = new System.Drawing.Size(256, 23);
            this.labelNetO.TabIndex = 17;
            this.labelNetO.Text = "Net O";
            // 
            // labelDiskW
            // 
            this.labelDiskW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskW.Location = new System.Drawing.Point(282, 398);
            this.labelDiskW.Name = "labelDiskW";
            this.labelDiskW.Size = new System.Drawing.Size(256, 23);
            this.labelDiskW.TabIndex = 16;
            this.labelDiskW.Text = "Disk W";
            // 
            // labelDiskR
            // 
            this.labelDiskR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskR.Location = new System.Drawing.Point(13, 398);
            this.labelDiskR.Name = "labelDiskR";
            this.labelDiskR.Size = new System.Drawing.Size(256, 23);
            this.labelDiskR.TabIndex = 15;
            this.labelDiskR.Text = "Disk R";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mem V";
            // 
            // labelMemV
            // 
            this.labelMemV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemV.Location = new System.Drawing.Point(256, 257);
            this.labelMemV.Name = "labelMemV";
            this.labelMemV.Size = new System.Drawing.Size(294, 24);
            this.labelMemV.TabIndex = 13;
            this.labelMemV.Text = "Mem V";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mem P";
            // 
            // labelMemP
            // 
            this.labelMemP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemP.Location = new System.Drawing.Point(256, 292);
            this.labelMemP.Name = "labelMemP";
            this.labelMemP.Size = new System.Drawing.Size(294, 24);
            this.labelMemP.TabIndex = 11;
            this.labelMemP.Text = "Mem P";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "CPU";
            // 
            // labelCpu
            // 
            this.labelCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCpu.Location = new System.Drawing.Point(256, 140);
            this.labelCpu.Name = "labelCpu";
            this.labelCpu.Size = new System.Drawing.Size(294, 24);
            this.labelCpu.TabIndex = 10;
            this.labelCpu.Text = "CPU";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "CPU Usage History";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 24);
            this.label5.TabIndex = 28;
            this.label5.Text = "Memory Usage History";
            // 
            // labelModel
            // 
            this.labelModel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModel.Location = new System.Drawing.Point(13, 12);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(525, 23);
            this.labelModel.TabIndex = 30;
            this.labelModel.Text = "Model";
            // 
            // labelNames
            // 
            this.labelNames.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNames.Location = new System.Drawing.Point(13, 82);
            this.labelNames.Name = "labelNames";
            this.labelNames.Size = new System.Drawing.Size(525, 23);
            this.labelNames.TabIndex = 33;
            this.labelNames.Text = "user";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 3);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "Processor:";
            // 
            // textBoxProcessor
            // 
            this.textBoxProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProcessor.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxProcessor.Location = new System.Drawing.Point(128, 41);
            this.textBoxProcessor.Name = "textBoxProcessor";
            this.textBoxProcessor.ReadOnly = true;
            this.textBoxProcessor.Size = new System.Drawing.Size(398, 26);
            this.textBoxProcessor.TabIndex = 35;
            // 
            // dataChartMem
            // 
            this.dataChartMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChartMem.BackColor = System.Drawing.Color.Silver;
            this.dataChartMem.ChartType = SystemMonitor.ChartType.Line;
            this.dataChartMem.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartMem.GridColor = System.Drawing.Color.Gold;
            this.dataChartMem.GridPixels = 12;
            this.dataChartMem.InitialHeight = 100;
            this.dataChartMem.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartMem.Location = new System.Drawing.Point(13, 351);
            this.dataChartMem.Name = "dataChartMem";
            this.dataChartMem.Size = new System.Drawing.Size(513, 35);
            this.dataChartMem.TabIndex = 29;
            // 
            // dataChartCPU
            // 
            this.dataChartCPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChartCPU.BackColor = System.Drawing.Color.Silver;
            this.dataChartCPU.ChartType = SystemMonitor.ChartType.Line;
            this.dataChartCPU.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartCPU.GridColor = System.Drawing.Color.Yellow;
            this.dataChartCPU.GridPixels = 8;
            this.dataChartCPU.InitialHeight = 100;
            this.dataChartCPU.LineColor = System.Drawing.Color.Green;
            this.dataChartCPU.Location = new System.Drawing.Point(13, 199);
            this.dataChartCPU.Name = "dataChartCPU";
            this.dataChartCPU.Size = new System.Drawing.Size(513, 35);
            this.dataChartCPU.TabIndex = 27;
            // 
            // dataChartNetI
            // 
            this.dataChartNetI.BackColor = System.Drawing.Color.Silver;
            this.dataChartNetI.ChartType = SystemMonitor.ChartType.Stick;
            this.dataChartNetI.GridColor = System.Drawing.Color.Yellow;
            this.dataChartNetI.GridPixels = 0;
            this.dataChartNetI.InitialHeight = 1000;
            this.dataChartNetI.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartNetI.Location = new System.Drawing.Point(13, 491);
            this.dataChartNetI.Name = "dataChartNetI";
            this.dataChartNetI.Size = new System.Drawing.Size(256, 35);
            this.dataChartNetI.TabIndex = 25;
            // 
            // dataChartNetO
            // 
            this.dataChartNetO.BackColor = System.Drawing.Color.Silver;
            this.dataChartNetO.ChartType = SystemMonitor.ChartType.Stick;
            this.dataChartNetO.GridColor = System.Drawing.Color.Yellow;
            this.dataChartNetO.GridPixels = 0;
            this.dataChartNetO.InitialHeight = 1000;
            this.dataChartNetO.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartNetO.Location = new System.Drawing.Point(282, 491);
            this.dataChartNetO.Name = "dataChartNetO";
            this.dataChartNetO.Size = new System.Drawing.Size(256, 35);
            this.dataChartNetO.TabIndex = 24;
            // 
            // dataChartDiskW
            // 
            this.dataChartDiskW.BackColor = System.Drawing.Color.Silver;
            this.dataChartDiskW.ChartType = SystemMonitor.ChartType.Stick;
            this.dataChartDiskW.GridColor = System.Drawing.Color.Gold;
            this.dataChartDiskW.GridPixels = 0;
            this.dataChartDiskW.InitialHeight = 100000;
            this.dataChartDiskW.LineColor = System.Drawing.Color.Blue;
            this.dataChartDiskW.Location = new System.Drawing.Point(282, 421);
            this.dataChartDiskW.Name = "dataChartDiskW";
            this.dataChartDiskW.Size = new System.Drawing.Size(256, 35);
            this.dataChartDiskW.TabIndex = 23;
            // 
            // dataChartDiskR
            // 
            this.dataChartDiskR.BackColor = System.Drawing.Color.Silver;
            this.dataChartDiskR.ChartType = SystemMonitor.ChartType.Stick;
            this.dataChartDiskR.GridColor = System.Drawing.Color.Gold;
            this.dataChartDiskR.GridPixels = 0;
            this.dataChartDiskR.InitialHeight = 100000;
            this.dataChartDiskR.LineColor = System.Drawing.Color.Blue;
            this.dataChartDiskR.Location = new System.Drawing.Point(13, 421);
            this.dataChartDiskR.Name = "dataChartDiskR";
            this.dataChartDiskR.Size = new System.Drawing.Size(256, 35);
            this.dataChartDiskR.TabIndex = 22;
            // 
            // dataBarMemV
            // 
            this.dataBarMemV.BackColor = System.Drawing.Color.Silver;
            this.dataBarMemV.BarColor = System.Drawing.Color.DarkBlue;
            this.dataBarMemV.Location = new System.Drawing.Point(90, 257);
            this.dataBarMemV.Name = "dataBarMemV";
            this.dataBarMemV.Size = new System.Drawing.Size(153, 24);
            this.dataBarMemV.TabIndex = 21;
            this.dataBarMemV.Value = 0;
            // 
            // dataBarMemP
            // 
            this.dataBarMemP.BackColor = System.Drawing.Color.Silver;
            this.dataBarMemP.BarColor = System.Drawing.Color.SlateBlue;
            this.dataBarMemP.Location = new System.Drawing.Point(90, 292);
            this.dataBarMemP.Name = "dataBarMemP";
            this.dataBarMemP.Size = new System.Drawing.Size(153, 24);
            this.dataBarMemP.TabIndex = 20;
            this.dataBarMemP.Value = 0;
            // 
            // dataBarCPU
            // 
            this.dataBarCPU.BackColor = System.Drawing.Color.Silver;
            this.dataBarCPU.BarColor = System.Drawing.Color.Green;
            this.dataBarCPU.Location = new System.Drawing.Point(90, 140);
            this.dataBarCPU.Name = "dataBarCPU";
            this.dataBarCPU.Size = new System.Drawing.Size(153, 24);
            this.dataBarCPU.TabIndex = 19;
            this.dataBarCPU.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(538, 568);
            this.Controls.Add(this.textBoxProcessor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelNames);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.dataChartMem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataChartCPU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataChartNetI);
            this.Controls.Add(this.dataChartNetO);
            this.Controls.Add(this.dataChartDiskW);
            this.Controls.Add(this.dataChartDiskR);
            this.Controls.Add(this.dataBarMemV);
            this.Controls.Add(this.dataBarMemP);
            this.Controls.Add(this.dataBarCPU);
            this.Controls.Add(this.labelNetI);
            this.Controls.Add(this.labelNetO);
            this.Controls.Add(this.labelDiskW);
            this.Controls.Add(this.labelDiskR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelMemV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMemP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCpu);
            this.Controls.Add(this.label9);
            this.Name = "Form1";
            this.Text = "System Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			timer.Stop();
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			UpdateData();
		}

		private void UpdateData()
		{
			string s = sd.GetProcessorData();
			labelCpu.Text = s;
			double d = double.Parse(s.Substring(0, s.IndexOf("%")));
			dataBarCPU.Value = (int)d;
			dataChartCPU.UpdateChart(d);

			s = sd.GetMemoryVData();
			labelMemV.Text = s;
			d = double.Parse(s.Substring(0, s.IndexOf("%")));
			dataBarMemV.Value = (int)d;
			dataChartMem.UpdateChart(d);

			s = sd.GetMemoryPData();
			labelMemP.Text = s;
			dataBarMemP.Value = (int)double.Parse(s.Substring(0, s.IndexOf("%")));

			d = sd.GetDiskData(SystemData.DiskData.Read);
			labelDiskR.Text = "Disk R (" + sd.FormatBytes(d) + "/s)";
			dataChartDiskR.UpdateChart(d);

			d = sd.GetDiskData(SystemData.DiskData.Write); 
			labelDiskW.Text = "Disk W (" + sd.FormatBytes(d) + "/s)";
			dataChartDiskW.UpdateChart(d);

			d = sd.GetNetData(SystemData.NetData.Received);
			labelNetI.Text = "Net I (" + sd.FormatBytes(d) + "/s)";
			dataChartNetI.UpdateChart(d);

			d = sd.GetNetData(SystemData.NetData.Sent);
			labelNetO.Text = "Net O (" + sd.FormatBytes(d) + "/s)";
			dataChartNetO.UpdateChart(d);
		}

		protected override void OnResize(EventArgs e)
		{
			if (0==_sizeOrg.Width || 0== _sizeOrg.Height) return;

			if (Size.Width != _size.Width && Size.Width > _sizeOrg.Width)		
			{
				int xChange = Size.Width - _size.Width;	  // Client window

				// Adjust three bars
				int newWidth = dataBarCPU.Size.Width +xChange;
				int labelStart = labelCpu.Location.X + xChange;

				dataBarCPU.Size = new Size(newWidth, dataBarCPU.Size.Height);
				labelCpu.Location = new Point(labelStart, labelCpu.Location.Y);

				dataBarMemV.Size = new Size(newWidth, dataBarCPU.Size.Height);
				labelMemV.Location = new Point(labelStart, labelMemV.Location.Y);

				dataBarMemP.Size = new Size(newWidth, dataBarCPU.Size.Height);
				labelMemP.Location = new Point(labelStart, labelMemP.Location.Y);
					
				// Resize four charts
				int margin = 8;
				Rectangle rt = this.ClientRectangle;

				newWidth = (rt.Width - 3*margin)/2;
				labelStart = newWidth +2*margin;

				dataChartDiskR.Size = new Size(newWidth, dataChartDiskR.Size.Height);
				labelDiskW.Location = new Point(labelStart, labelDiskW.Location.Y);
				dataChartDiskW.Location = new Point(labelStart, dataChartDiskW.Location.Y);
				dataChartDiskW.Size = new Size(newWidth, dataChartDiskW.Size.Height);

				dataChartNetI.Size = new Size(newWidth, dataChartNetI.Size.Height);
				labelNetO.Location = new Point(labelStart, labelNetO.Location.Y);
				dataChartNetO.Location = new Point(labelStart, dataChartNetO.Location.Y);
				dataChartNetO.Size = new Size(newWidth, dataChartNetO.Size.Height);

				// I use Anchor so not to Resize two usage charts
//				dataChartCPU.Size = new Size(rt.Width - 2*margin, dataChartCPU.Size.Height);
//				dataChartMem.Size = new Size(rt.Width - 2*margin, dataChartMem.Size.Height);

				_size = Size;
			}

			Size = new Size(Size.Width, _sizeOrg.Height);
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
