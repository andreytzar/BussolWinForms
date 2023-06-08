namespace BussolWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button5 = new Button();
            panel = new Panel();
            TXTMeasureSize = new TextBox();
            label6 = new Label();
            BTNMeasure = new Button();
            TXTScaleSize = new TextBox();
            label5 = new Label();
            BTNAddScale = new Button();
            BussolsCombo = new ComboBox();
            ClearBtn = new Button();
            TXTAngle = new TextBox();
            button1 = new Button();
            label4 = new Label();
            TXTDistance = new TextBox();
            label3 = new Label();
            TXTZoom = new TextBox();
            label2 = new Label();
            TXTFontSize = new TextBox();
            label1 = new Label();
            RePaint = new Button();
            AddBussol = new Button();
            StayOnTop = new CheckBox();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Location = new Point(0, 2);
            button5.Margin = new Padding(10);
            button5.Name = "button5";
            button5.Size = new Size(25, 25);
            button5.TabIndex = 5;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.UseWaitCursor = true;
            button5.Click += button5_Click;
            // 
            // panel
            // 
            panel.BackColor = Color.White;
            panel.Controls.Add(TXTMeasureSize);
            panel.Controls.Add(label6);
            panel.Controls.Add(BTNMeasure);
            panel.Controls.Add(TXTScaleSize);
            panel.Controls.Add(label5);
            panel.Controls.Add(BTNAddScale);
            panel.Controls.Add(BussolsCombo);
            panel.Controls.Add(ClearBtn);
            panel.Controls.Add(TXTAngle);
            panel.Controls.Add(button1);
            panel.Controls.Add(label4);
            panel.Controls.Add(TXTDistance);
            panel.Controls.Add(label3);
            panel.Controls.Add(TXTZoom);
            panel.Controls.Add(label2);
            panel.Controls.Add(TXTFontSize);
            panel.Controls.Add(label1);
            panel.Controls.Add(RePaint);
            panel.Controls.Add(AddBussol);
            panel.Controls.Add(StayOnTop);
            panel.Controls.Add(button5);
            panel.Location = new Point(1, 0);
            panel.Name = "panel";
            panel.Size = new Size(403, 92);
            panel.TabIndex = 1;
            panel.UseWaitCursor = true;
            panel.MouseDown += panel1_MouseDown;
            panel.MouseMove += panel_MouseMove;
            panel.MouseUp += panel_MouseUp;
            // 
            // TXTMeasureSize
            // 
            TXTMeasureSize.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTMeasureSize.Location = new Point(186, 68);
            TXTMeasureSize.Name = "TXTMeasureSize";
            TXTMeasureSize.Size = new Size(56, 22);
            TXTMeasureSize.TabIndex = 26;
            TXTMeasureSize.UseWaitCursor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(180, 53);
            label6.Name = "label6";
            label6.Size = new Size(71, 13);
            label6.TabIndex = 25;
            label6.Text = "MeasureSize";
            label6.UseWaitCursor = true;
            // 
            // BTNMeasure
            // 
            BTNMeasure.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            BTNMeasure.Location = new Point(28, 68);
            BTNMeasure.Name = "BTNMeasure";
            BTNMeasure.Size = new Size(86, 23);
            BTNMeasure.TabIndex = 24;
            BTNMeasure.Text = "Measure";
            BTNMeasure.UseVisualStyleBackColor = true;
            BTNMeasure.UseWaitCursor = true;
            BTNMeasure.Click += button3_Click;
            // 
            // TXTScaleSize
            // 
            TXTScaleSize.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTScaleSize.Location = new Point(117, 67);
            TXTScaleSize.Name = "TXTScaleSize";
            TXTScaleSize.Size = new Size(56, 22);
            TXTScaleSize.TabIndex = 23;
            TXTScaleSize.Text = "1";
            TXTScaleSize.UseWaitCursor = true;
            TXTScaleSize.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(120, 52);
            label5.Name = "label5";
            label5.Size = new Size(53, 13);
            label5.TabIndex = 22;
            label5.Text = "ScaleSize";
            label5.UseWaitCursor = true;
            // 
            // BTNAddScale
            // 
            BTNAddScale.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            BTNAddScale.Location = new Point(28, 48);
            BTNAddScale.Name = "BTNAddScale";
            BTNAddScale.Size = new Size(86, 23);
            BTNAddScale.TabIndex = 21;
            BTNAddScale.Text = "AddScaleBar";
            BTNAddScale.UseVisualStyleBackColor = true;
            BTNAddScale.UseWaitCursor = true;
            BTNAddScale.Click += BTNAddScale_Click;
            // 
            // BussolsCombo
            // 
            BussolsCombo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            BussolsCombo.FormattingEnabled = true;
            BussolsCombo.Location = new Point(319, 5);
            BussolsCombo.Name = "BussolsCombo";
            BussolsCombo.Size = new Size(73, 21);
            BussolsCombo.TabIndex = 10;
            BussolsCombo.UseWaitCursor = true;
            BussolsCombo.SelectedValueChanged += BussolsCombo_SelectedValueChanged;
            // 
            // ClearBtn
            // 
            ClearBtn.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            ClearBtn.Location = new Point(324, 48);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(60, 23);
            ClearBtn.TabIndex = 20;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.UseWaitCursor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // TXTAngle
            // 
            TXTAngle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTAngle.Location = new Point(169, 29);
            TXTAngle.Name = "TXTAngle";
            TXTAngle.Size = new Size(46, 22);
            TXTAngle.TabIndex = 19;
            TXTAngle.UseWaitCursor = true;
            TXTAngle.TextChanged += TXTAngle_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(324, 27);
            button1.Name = "button1";
            button1.Size = new Size(60, 23);
            button1.TabIndex = 17;
            button1.Text = "Dellete";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(163, 14);
            label4.Name = "label4";
            label4.Size = new Size(62, 13);
            label4.TabIndex = 18;
            label4.Text = "Cam Angle";
            label4.UseWaitCursor = true;
            // 
            // TXTDistance
            // 
            TXTDistance.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTDistance.Location = new Point(220, 29);
            TXTDistance.Name = "TXTDistance";
            TXTDistance.Size = new Size(46, 22);
            TXTDistance.TabIndex = 16;
            TXTDistance.UseWaitCursor = true;
            TXTDistance.TextChanged += TXTDistance_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(221, 14);
            label3.Name = "label3";
            label3.Size = new Size(51, 13);
            label3.TabIndex = 15;
            label3.Text = "Distance";
            label3.UseWaitCursor = true;
            // 
            // TXTZoom
            // 
            TXTZoom.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTZoom.Location = new Point(117, 29);
            TXTZoom.Name = "TXTZoom";
            TXTZoom.Size = new Size(46, 22);
            TXTZoom.TabIndex = 14;
            TXTZoom.UseWaitCursor = true;
            TXTZoom.TextChanged += TXTZoom_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(117, 14);
            label2.Name = "label2";
            label2.Size = new Size(41, 13);
            label2.TabIndex = 13;
            label2.Text = "ZOOM";
            label2.UseWaitCursor = true;
            // 
            // TXTFontSize
            // 
            TXTFontSize.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTFontSize.Location = new Point(272, 29);
            TXTFontSize.Name = "TXTFontSize";
            TXTFontSize.Size = new Size(46, 22);
            TXTFontSize.TabIndex = 12;
            TXTFontSize.UseWaitCursor = true;
            TXTFontSize.TextChanged += TXTFontSize_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(278, 14);
            label1.Name = "label1";
            label1.Size = new Size(31, 13);
            label1.TabIndex = 11;
            label1.Text = "Font";
            label1.UseWaitCursor = true;
            // 
            // RePaint
            // 
            RePaint.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            RePaint.Location = new Point(324, 68);
            RePaint.Name = "RePaint";
            RePaint.Size = new Size(60, 23);
            RePaint.TabIndex = 8;
            RePaint.Text = "RePaint";
            RePaint.UseVisualStyleBackColor = true;
            RePaint.UseWaitCursor = true;
            RePaint.Click += RePaint_Click;
            // 
            // AddBussol
            // 
            AddBussol.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            AddBussol.Location = new Point(28, 27);
            AddBussol.Name = "AddBussol";
            AddBussol.Size = new Size(86, 23);
            AddBussol.TabIndex = 7;
            AddBussol.Text = "AddBussol";
            AddBussol.UseVisualStyleBackColor = true;
            AddBussol.UseWaitCursor = true;
            AddBussol.Click += AddBussol_Click;
            // 
            // StayOnTop
            // 
            StayOnTop.AutoSize = true;
            StayOnTop.Checked = true;
            StayOnTop.CheckState = CheckState.Checked;
            StayOnTop.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            StayOnTop.Location = new Point(28, 6);
            StayOnTop.Name = "StayOnTop";
            StayOnTop.Size = new Size(61, 17);
            StayOnTop.TabIndex = 6;
            StayOnTop.Text = "OnTop";
            StayOnTop.UseVisualStyleBackColor = true;
            StayOnTop.UseWaitCursor = true;
            StayOnTop.CheckStateChanged += StayOnTop_CheckStateChanged;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(1900, 1037);
            Controls.Add(panel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            ImeMode = ImeMode.On;
            MinimizeBox = false;
            Name = "Form1";
            Text = "X";
            TopMost = true;
            TransparencyKey = Color.Green;
 
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            MouseDown += Form_MouseDown;
            MouseMove += Form_MouseMove;
            MouseUp += Form_MouseUp;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button5;
        private Panel panel;
        private CheckBox StayOnTop;
        private Button AddBussol;
        private Button RePaint;
        private ComboBox BussolsCombo;
        private Label label1;
        private TextBox TXTFontSize;
        private Label label2;
        private TextBox TXTZoom;
        private TextBox TXTDistance;
        private Label label3;
        private Button button1;
        private TextBox TXTAngle;
        private Label label4;
        private Button ClearBtn;
        private Button BTNAddScale;
        private TextBox TXTScaleSize;
        private Label label5;
        private TextBox TXTMeasureSize;
        private Label label6;
        private Button BTNMeasure;
    }
}