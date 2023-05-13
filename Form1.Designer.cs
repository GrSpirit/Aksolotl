namespace Aksolotl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.run_stop = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showCheckBox1 = new System.Windows.Forms.CheckBox();
            this.showCheckBox2 = new System.Windows.Forms.CheckBox();
            this.radioButton_std = new System.Windows.Forms.RadioButton();
            this.radioButton_dfm = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_export_ch2 = new System.Windows.Forms.Button();
            this.button_export_ch1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mockCheckBox = new System.Windows.Forms.CheckBox();
            this.accuracyRadioButton15 = new System.Windows.Forms.RadioButton();
            this.accuracyRadioButton213 = new System.Windows.Forms.RadioButton();
            this.accuracyGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numPointsBox = new System.Windows.Forms.TextBox();
            this.numPointsTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frequencyComboBox = new System.Windows.Forms.ComboBox();
            this.saveCsvFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chartMath = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mathBox = new System.Windows.Forms.GroupBox();
            this.fftToTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fftFromTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fftRadioButton = new System.Windows.Forms.RadioButton();
            this.divRadioButton = new System.Windows.Forms.RadioButton();
            this.multRadioButton = new System.Windows.Forms.RadioButton();
            this.addRadioButton = new System.Windows.Forms.RadioButton();
            this.subRadioButton = new System.Windows.Forms.RadioButton();
            this.bufferCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.accuracyGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsTrackBar)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMath)).BeginInit();
            this.mathBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // run_stop
            // 
            this.run_stop.Location = new System.Drawing.Point(670, 23);
            this.run_stop.Name = "run_stop";
            this.run_stop.Size = new System.Drawing.Size(113, 23);
            this.run_stop.TabIndex = 0;
            this.run_stop.Text = "run/stop";
            this.run_stop.UseVisualStyleBackColor = true;
            this.run_stop.Click += new System.EventHandler(this.run_stop_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.LegendText = "CH1";
            series4.Name = "Series1";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.Legend = "Legend1";
            series5.LegendText = "CH2";
            series5.Name = "Series2";
            series5.YValuesPerPoint = 2;
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(878, 572);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "Graf";
            // 
            // showCheckBox1
            // 
            this.showCheckBox1.AutoSize = true;
            this.showCheckBox1.Checked = true;
            this.showCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCheckBox1.Location = new System.Drawing.Point(6, 19);
            this.showCheckBox1.Name = "showCheckBox1";
            this.showCheckBox1.Size = new System.Drawing.Size(83, 17);
            this.showCheckBox1.TabIndex = 3;
            this.showCheckBox1.Text = "Вывод CH1";
            this.showCheckBox1.UseVisualStyleBackColor = true;
            // 
            // showCheckBox2
            // 
            this.showCheckBox2.AutoSize = true;
            this.showCheckBox2.Checked = true;
            this.showCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCheckBox2.Location = new System.Drawing.Point(6, 42);
            this.showCheckBox2.Name = "showCheckBox2";
            this.showCheckBox2.Size = new System.Drawing.Size(83, 17);
            this.showCheckBox2.TabIndex = 4;
            this.showCheckBox2.Text = "Вывод CH2";
            this.showCheckBox2.UseVisualStyleBackColor = true;
            // 
            // radioButton_std
            // 
            this.radioButton_std.AutoSize = true;
            this.radioButton_std.Checked = true;
            this.radioButton_std.Location = new System.Drawing.Point(6, 19);
            this.radioButton_std.Name = "radioButton_std";
            this.radioButton_std.Size = new System.Drawing.Size(65, 17);
            this.radioButton_std.TabIndex = 5;
            this.radioButton_std.TabStop = true;
            this.radioButton_std.Text = "Standart";
            this.radioButton_std.UseVisualStyleBackColor = true;
            this.radioButton_std.CheckedChanged += new System.EventHandler(this.radioButton_std_CheckedChanged);
            // 
            // radioButton_dfm
            // 
            this.radioButton_dfm.AutoSize = true;
            this.radioButton_dfm.Location = new System.Drawing.Point(6, 41);
            this.radioButton_dfm.Name = "radioButton_dfm";
            this.radioButton_dfm.Size = new System.Drawing.Size(100, 17);
            this.radioButton_dfm.TabIndex = 6;
            this.radioButton_dfm.TabStop = true;
            this.radioButton_dfm.Text = "Dual Fast Mode";
            this.radioButton_dfm.UseVisualStyleBackColor = true;
            this.radioButton_dfm.CheckedChanged += new System.EventHandler(this.radioButton_std_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Location = new System.Drawing.Point(24, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 597);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "График";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bufferCheckBox);
            this.groupBox2.Controls.Add(this.showCheckBox2);
            this.groupBox2.Controls.Add(this.showCheckBox1);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Каналы";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(724, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(687, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_std);
            this.groupBox3.Controls.Add(this.radioButton_dfm);
            this.groupBox3.Location = new System.Drawing.Point(138, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выбор режима работы";
            // 
            // button_export_ch2
            // 
            this.button_export_ch2.Location = new System.Drawing.Point(6, 50);
            this.button_export_ch2.Name = "button_export_ch2";
            this.button_export_ch2.Size = new System.Drawing.Size(75, 23);
            this.button_export_ch2.TabIndex = 10;
            this.button_export_ch2.Text = "CH2";
            this.button_export_ch2.UseVisualStyleBackColor = true;
            this.button_export_ch2.Click += new System.EventHandler(this.button_export_ch2_Click);
            // 
            // button_export_ch1
            // 
            this.button_export_ch1.Location = new System.Drawing.Point(6, 21);
            this.button_export_ch1.Name = "button_export_ch1";
            this.button_export_ch1.Size = new System.Drawing.Size(75, 23);
            this.button_export_ch1.TabIndex = 11;
            this.button_export_ch1.Text = "CH1";
            this.button_export_ch1.UseVisualStyleBackColor = true;
            this.button_export_ch1.Click += new System.EventHandler(this.button_export_ch1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_export_ch1);
            this.groupBox4.Controls.Add(this.button_export_ch2);
            this.groupBox4.Location = new System.Drawing.Point(789, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(119, 86);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Выгрузка данных";
            // 
            // mockCheckBox
            // 
            this.mockCheckBox.AutoSize = true;
            this.mockCheckBox.Location = new System.Drawing.Point(724, 76);
            this.mockCheckBox.Name = "mockCheckBox";
            this.mockCheckBox.Size = new System.Drawing.Size(50, 17);
            this.mockCheckBox.TabIndex = 14;
            this.mockCheckBox.Text = "Fake";
            this.mockCheckBox.UseVisualStyleBackColor = true;
            // 
            // accuracyRadioButton15
            // 
            this.accuracyRadioButton15.AutoSize = true;
            this.accuracyRadioButton15.Checked = true;
            this.accuracyRadioButton15.Location = new System.Drawing.Point(6, 19);
            this.accuracyRadioButton15.Name = "accuracyRadioButton15";
            this.accuracyRadioButton15.Size = new System.Drawing.Size(62, 17);
            this.accuracyRadioButton15.TabIndex = 5;
            this.accuracyRadioButton15.TabStop = true;
            this.accuracyRadioButton15.Text = "Грубый";
            this.accuracyRadioButton15.UseVisualStyleBackColor = true;
            this.accuracyRadioButton15.CheckedChanged += new System.EventHandler(this.accuracyRadioButton15_CheckedChanged);
            // 
            // accuracyRadioButton213
            // 
            this.accuracyRadioButton213.AutoSize = true;
            this.accuracyRadioButton213.Location = new System.Drawing.Point(6, 41);
            this.accuracyRadioButton213.Name = "accuracyRadioButton213";
            this.accuracyRadioButton213.Size = new System.Drawing.Size(63, 17);
            this.accuracyRadioButton213.TabIndex = 6;
            this.accuracyRadioButton213.TabStop = true;
            this.accuracyRadioButton213.Text = "Точный";
            this.accuracyRadioButton213.UseVisualStyleBackColor = true;
            // 
            // accuracyGroupBox
            // 
            this.accuracyGroupBox.Controls.Add(this.accuracyRadioButton15);
            this.accuracyGroupBox.Controls.Add(this.accuracyRadioButton213);
            this.accuracyGroupBox.Location = new System.Drawing.Point(291, 12);
            this.accuracyGroupBox.Name = "accuracyGroupBox";
            this.accuracyGroupBox.Size = new System.Drawing.Size(115, 100);
            this.accuracyGroupBox.TabIndex = 10;
            this.accuracyGroupBox.TabStop = false;
            this.accuracyGroupBox.Text = "Точность";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numPointsBox);
            this.groupBox5.Controls.Add(this.numPointsTrackBar);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.frequencyComboBox);
            this.groupBox5.Location = new System.Drawing.Point(412, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 100);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Отображение";
            // 
            // numPointsBox
            // 
            this.numPointsBox.Enabled = false;
            this.numPointsBox.Location = new System.Drawing.Point(6, 59);
            this.numPointsBox.Name = "numPointsBox";
            this.numPointsBox.Size = new System.Drawing.Size(49, 20);
            this.numPointsBox.TabIndex = 4;
            this.numPointsBox.Text = "300";
            // 
            // numPointsTrackBar
            // 
            this.numPointsTrackBar.LargeChange = 100;
            this.numPointsTrackBar.Location = new System.Drawing.Point(61, 43);
            this.numPointsTrackBar.Maximum = 200000;
            this.numPointsTrackBar.Minimum = 5;
            this.numPointsTrackBar.Name = "numPointsTrackBar";
            this.numPointsTrackBar.Size = new System.Drawing.Size(185, 45);
            this.numPointsTrackBar.SmallChange = 50;
            this.numPointsTrackBar.TabIndex = 3;
            this.numPointsTrackBar.TickFrequency = 100;
            this.numPointsTrackBar.Value = 100;
            this.numPointsTrackBar.ValueChanged += new System.EventHandler(this.numPointsTrackBar_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Точек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Частота";
            // 
            // frequencyComboBox
            // 
            this.frequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyComboBox.FormattingEnabled = true;
            this.frequencyComboBox.Location = new System.Drawing.Point(61, 18);
            this.frequencyComboBox.Name = "frequencyComboBox";
            this.frequencyComboBox.Size = new System.Drawing.Size(185, 21);
            this.frequencyComboBox.TabIndex = 0;
            // 
            // saveCsvFileDialog
            // 
            this.saveCsvFileDialog.DefaultExt = "csv";
            this.saveCsvFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
            this.saveCsvFileDialog.RestoreDirectory = true;
            this.saveCsvFileDialog.Title = "Save signal values";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chartMath);
            this.groupBox6.Location = new System.Drawing.Point(930, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(890, 597);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Математика";
            // 
            // chartMath
            // 
            chartArea4.Name = "ChartArea1";
            this.chartMath.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartMath.Legends.Add(legend4);
            this.chartMath.Location = new System.Drawing.Point(6, 19);
            this.chartMath.Name = "chartMath";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Magenta;
            series6.Legend = "Legend1";
            series6.LegendText = "RES";
            series6.Name = "Series1";
            this.chartMath.Series.Add(series6);
            this.chartMath.Size = new System.Drawing.Size(878, 572);
            this.chartMath.TabIndex = 2;
            this.chartMath.Text = "Graf";
            // 
            // mathBox
            // 
            this.mathBox.Controls.Add(this.fftToTextBox);
            this.mathBox.Controls.Add(this.fftFromTextBox);
            this.mathBox.Controls.Add(this.fftRadioButton);
            this.mathBox.Controls.Add(this.divRadioButton);
            this.mathBox.Controls.Add(this.multRadioButton);
            this.mathBox.Controls.Add(this.addRadioButton);
            this.mathBox.Controls.Add(this.subRadioButton);
            this.mathBox.Location = new System.Drawing.Point(936, 12);
            this.mathBox.Name = "mathBox";
            this.mathBox.Size = new System.Drawing.Size(315, 100);
            this.mathBox.TabIndex = 10;
            this.mathBox.TabStop = false;
            this.mathBox.Text = "Выбор операции";
            // 
            // fftToTextBox
            // 
            this.fftToTextBox.Location = new System.Drawing.Point(183, 64);
            this.fftToTextBox.Mask = "00000";
            this.fftToTextBox.Name = "fftToTextBox";
            this.fftToTextBox.Size = new System.Drawing.Size(44, 20);
            this.fftToTextBox.TabIndex = 13;
            this.fftToTextBox.Text = "1000";
            this.fftToTextBox.ValidatingType = typeof(int);
            this.fftToTextBox.TextChanged += new System.EventHandler(this.fftFromTextBox_TextChanged);
            // 
            // fftFromTextBox
            // 
            this.fftFromTextBox.Location = new System.Drawing.Point(183, 38);
            this.fftFromTextBox.Mask = "00000";
            this.fftFromTextBox.Name = "fftFromTextBox";
            this.fftFromTextBox.Size = new System.Drawing.Size(44, 20);
            this.fftFromTextBox.TabIndex = 12;
            this.fftFromTextBox.Text = "0";
            this.fftFromTextBox.ValidatingType = typeof(int);
            this.fftFromTextBox.TextChanged += new System.EventHandler(this.fftFromTextBox_TextChanged);
            // 
            // fftRadioButton
            // 
            this.fftRadioButton.AutoSize = true;
            this.fftRadioButton.Location = new System.Drawing.Point(183, 17);
            this.fftRadioButton.Name = "fftRadioButton";
            this.fftRadioButton.Size = new System.Drawing.Size(44, 17);
            this.fftRadioButton.TabIndex = 9;
            this.fftRadioButton.Text = "FFT";
            this.fftRadioButton.UseVisualStyleBackColor = true;
            // 
            // divRadioButton
            // 
            this.divRadioButton.AutoSize = true;
            this.divRadioButton.Location = new System.Drawing.Point(92, 39);
            this.divRadioButton.Name = "divRadioButton";
            this.divRadioButton.Size = new System.Drawing.Size(70, 17);
            this.divRadioButton.TabIndex = 8;
            this.divRadioButton.Text = "Деление";
            this.divRadioButton.UseVisualStyleBackColor = true;
            // 
            // multRadioButton
            // 
            this.multRadioButton.AutoSize = true;
            this.multRadioButton.Location = new System.Drawing.Point(92, 18);
            this.multRadioButton.Name = "multRadioButton";
            this.multRadioButton.Size = new System.Drawing.Size(85, 17);
            this.multRadioButton.TabIndex = 7;
            this.multRadioButton.Text = "Умножение";
            this.multRadioButton.UseVisualStyleBackColor = true;
            // 
            // addRadioButton
            // 
            this.addRadioButton.AutoSize = true;
            this.addRadioButton.Checked = true;
            this.addRadioButton.Location = new System.Drawing.Point(6, 19);
            this.addRadioButton.Name = "addRadioButton";
            this.addRadioButton.Size = new System.Drawing.Size(76, 17);
            this.addRadioButton.TabIndex = 5;
            this.addRadioButton.TabStop = true;
            this.addRadioButton.Text = "Сложение";
            this.addRadioButton.UseVisualStyleBackColor = true;
            // 
            // subRadioButton
            // 
            this.subRadioButton.AutoSize = true;
            this.subRadioButton.Location = new System.Drawing.Point(6, 41);
            this.subRadioButton.Name = "subRadioButton";
            this.subRadioButton.Size = new System.Drawing.Size(80, 17);
            this.subRadioButton.TabIndex = 6;
            this.subRadioButton.Text = "Вычитание";
            this.subRadioButton.UseVisualStyleBackColor = true;
            // 
            // bufferCheckBox
            // 
            this.bufferCheckBox.AutoSize = true;
            this.bufferCheckBox.Location = new System.Drawing.Point(6, 65);
            this.bufferCheckBox.Name = "bufferCheckBox";
            this.bufferCheckBox.Size = new System.Drawing.Size(58, 17);
            this.bufferCheckBox.TabIndex = 14;
            this.bufferCheckBox.Text = "Буфер";
            this.bufferCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 737);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mathBox);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.accuracyGroupBox);
            this.Controls.Add(this.mockCheckBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.run_stop);
            this.Name = "Form1";
            this.Text = "Аксолотль";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.accuracyGroupBox.ResumeLayout(false);
            this.accuracyGroupBox.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsTrackBar)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMath)).EndInit();
            this.mathBox.ResumeLayout(false);
            this.mathBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run_stop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox showCheckBox1;
        private System.Windows.Forms.CheckBox showCheckBox2;
        private System.Windows.Forms.RadioButton radioButton_std;
        private System.Windows.Forms.RadioButton radioButton_dfm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_export_ch2;
        private System.Windows.Forms.Button button_export_ch1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox mockCheckBox;
        private System.Windows.Forms.RadioButton accuracyRadioButton15;
        private System.Windows.Forms.RadioButton accuracyRadioButton213;
        private System.Windows.Forms.GroupBox accuracyGroupBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox frequencyComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar numPointsTrackBar;
        private System.Windows.Forms.TextBox numPointsBox;
        private System.Windows.Forms.SaveFileDialog saveCsvFileDialog;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMath;
        private System.Windows.Forms.GroupBox mathBox;
        private System.Windows.Forms.RadioButton divRadioButton;
        private System.Windows.Forms.RadioButton multRadioButton;
        private System.Windows.Forms.RadioButton addRadioButton;
        private System.Windows.Forms.RadioButton subRadioButton;
        private System.Windows.Forms.RadioButton fftRadioButton;
        private System.Windows.Forms.MaskedTextBox fftToTextBox;
        private System.Windows.Forms.MaskedTextBox fftFromTextBox;
        private System.Windows.Forms.CheckBox bufferCheckBox;
    }
}

