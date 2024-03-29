﻿namespace Aksolotl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.run_stop = new System.Windows.Forms.Button();
            this.chartSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showCheckBoxCH2 = new System.Windows.Forms.CheckBox();
            this.showCheckBoxCH1 = new System.Windows.Forms.CheckBox();
            this.radioButton_std = new System.Windows.Forms.RadioButton();
            this.radioButton_dfm = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bufferCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_export_ch2 = new System.Windows.Forms.Button();
            this.button_export_ch1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mockCheckBox = new System.Windows.Forms.CheckBox();
            this.accuracyGroupBox = new System.Windows.Forms.GroupBox();
            this.triggerTextBox = new System.Windows.Forms.TextBox();
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
            this.sampleComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).BeginInit();
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
            this.run_stop.Location = new System.Drawing.Point(690, 25);
            this.run_stop.Name = "run_stop";
            this.run_stop.Size = new System.Drawing.Size(93, 23);
            this.run_stop.TabIndex = 0;
            this.run_stop.Text = "run/stop";
            this.run_stop.UseVisualStyleBackColor = true;
            this.run_stop.Click += new System.EventHandler(this.run_stop_Click);
            // 
            // chartSignal
            // 
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = -100D;
            chartArea1.Name = "ChartArea1";
            this.chartSignal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSignal.Legends.Add(legend1);
            this.chartSignal.Location = new System.Drawing.Point(6, 19);
            this.chartSignal.Name = "chartSignal";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "CH1";
            series1.Name = "Series1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.LegendText = "CH2";
            series2.Name = "Series2";
            series2.YValuesPerPoint = 2;
            this.chartSignal.Series.Add(series1);
            this.chartSignal.Series.Add(series2);
            this.chartSignal.Size = new System.Drawing.Size(878, 572);
            this.chartSignal.TabIndex = 2;
            this.chartSignal.Text = "Graf";
            // 
            // showCheckBoxCH2
            // 
            this.showCheckBoxCH2.AutoSize = true;
            this.showCheckBoxCH2.Checked = true;
            this.showCheckBoxCH2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCheckBoxCH2.Location = new System.Drawing.Point(6, 42);
            this.showCheckBoxCH2.Name = "showCheckBoxCH2";
            this.showCheckBoxCH2.Size = new System.Drawing.Size(83, 17);
            this.showCheckBoxCH2.TabIndex = 3;
            this.showCheckBoxCH2.Text = "Вывод CH2";
            this.showCheckBoxCH2.UseVisualStyleBackColor = true;
            // 
            // showCheckBoxCH1
            // 
            this.showCheckBoxCH1.AutoSize = true;
            this.showCheckBoxCH1.Checked = true;
            this.showCheckBoxCH1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCheckBoxCH1.Location = new System.Drawing.Point(6, 19);
            this.showCheckBoxCH1.Name = "showCheckBoxCH1";
            this.showCheckBoxCH1.Size = new System.Drawing.Size(83, 17);
            this.showCheckBoxCH1.TabIndex = 4;
            this.showCheckBoxCH1.Text = "Вывод CH1";
            this.showCheckBoxCH1.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.chartSignal);
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
            this.groupBox2.Controls.Add(this.showCheckBoxCH1);
            this.groupBox2.Controls.Add(this.showCheckBoxCH2);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Каналы";
            // 
            // bufferCheckBox
            // 
            this.bufferCheckBox.AutoSize = true;
            this.bufferCheckBox.Location = new System.Drawing.Point(6, 65);
            this.bufferCheckBox.Name = "bufferCheckBox";
            this.bufferCheckBox.Size = new System.Drawing.Size(58, 17);
            this.bufferCheckBox.TabIndex = 5;
            this.bufferCheckBox.Text = "Буфер";
            this.bufferCheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(724, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(687, 58);
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
            this.mockCheckBox.Location = new System.Drawing.Point(1345, 25);
            this.mockCheckBox.Name = "mockCheckBox";
            this.mockCheckBox.Size = new System.Drawing.Size(50, 17);
            this.mockCheckBox.TabIndex = 14;
            this.mockCheckBox.Text = "Fake";
            this.mockCheckBox.UseVisualStyleBackColor = true;
            // 
            // accuracyGroupBox
            // 
            this.accuracyGroupBox.Controls.Add(this.triggerTextBox);
            this.accuracyGroupBox.Location = new System.Drawing.Point(291, 12);
            this.accuracyGroupBox.Name = "accuracyGroupBox";
            this.accuracyGroupBox.Size = new System.Drawing.Size(126, 100);
            this.accuracyGroupBox.TabIndex = 10;
            this.accuracyGroupBox.TabStop = false;
            this.accuracyGroupBox.Text = "Триггер";
            // 
            // triggerTextBox
            // 
            this.triggerTextBox.Location = new System.Drawing.Point(6, 19);
            this.triggerTextBox.Name = "triggerTextBox";
            this.triggerTextBox.Size = new System.Drawing.Size(58, 20);
            this.triggerTextBox.TabIndex = 0;
            this.triggerTextBox.Text = "2.0";
            this.triggerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TriggerTextBox_Validating);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numPointsBox);
            this.groupBox5.Controls.Add(this.numPointsTrackBar);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.frequencyComboBox);
            this.groupBox5.Location = new System.Drawing.Point(429, 12);
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
            this.numPointsBox.Text = "100";
            // 
            // numPointsTrackBar
            // 
            this.numPointsTrackBar.LargeChange = 100;
            this.numPointsTrackBar.Location = new System.Drawing.Point(61, 43);
            this.numPointsTrackBar.Maximum = 200000;
            this.numPointsTrackBar.Minimum = 10;
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
            chartArea2.Name = "ChartArea1";
            this.chartMath.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMath.Legends.Add(legend2);
            this.chartMath.Location = new System.Drawing.Point(6, 19);
            this.chartMath.Name = "chartMath";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Magenta;
            series3.Legend = "Legend1";
            series3.LegendText = "RES";
            series3.Name = "Series1";
            this.chartMath.Series.Add(series3);
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
            this.mathBox.Size = new System.Drawing.Size(245, 100);
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
            // sampleComboBox
            // 
            this.sampleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleComboBox.FormattingEnabled = true;
            this.sampleComboBox.Location = new System.Drawing.Point(1199, 49);
            this.sampleComboBox.Name = "sampleComboBox";
            this.sampleComboBox.Size = new System.Drawing.Size(185, 21);
            this.sampleComboBox.TabIndex = 5;
            this.sampleComboBox.SelectedIndexChanged += new System.EventHandler(this.sampleComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 737);
            this.Controls.Add(this.sampleComboBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartSignal)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSignal;
        private System.Windows.Forms.CheckBox showCheckBoxCH2;
        private System.Windows.Forms.CheckBox showCheckBoxCH1;
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
        private System.Windows.Forms.TextBox triggerTextBox;
        private System.Windows.Forms.ComboBox sampleComboBox;
    }
}

