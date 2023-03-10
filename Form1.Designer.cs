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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.run_stop = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox_out_ch1 = new System.Windows.Forms.CheckBox();
            this.checkBox_out_ch2 = new System.Windows.Forms.CheckBox();
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
            this.checkBox_fft = new System.Windows.Forms.CheckBox();
            this.mockCheckBox = new System.Windows.Forms.CheckBox();
            this.accuracyRadioButton15 = new System.Windows.Forms.RadioButton();
            this.accuracyRadioButton213 = new System.Windows.Forms.RadioButton();
            this.accuracyGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.accuracyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // run_stop
            // 
            this.run_stop.Location = new System.Drawing.Point(468, 12);
            this.run_stop.Name = "run_stop";
            this.run_stop.Size = new System.Drawing.Size(75, 23);
            this.run_stop.TabIndex = 0;
            this.run_stop.Text = "run/stop";
            this.run_stop.UseVisualStyleBackColor = true;
            this.run_stop.Click += new System.EventHandler(this.run_stop_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
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
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(878, 572);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "Graf";
            // 
            // checkBox_out_ch1
            // 
            this.checkBox_out_ch1.AutoSize = true;
            this.checkBox_out_ch1.Location = new System.Drawing.Point(6, 42);
            this.checkBox_out_ch1.Name = "checkBox_out_ch1";
            this.checkBox_out_ch1.Size = new System.Drawing.Size(83, 17);
            this.checkBox_out_ch1.TabIndex = 3;
            this.checkBox_out_ch1.Text = "Вывод CH1";
            this.checkBox_out_ch1.UseVisualStyleBackColor = true;
            // 
            // checkBox_out_ch2
            // 
            this.checkBox_out_ch2.AutoSize = true;
            this.checkBox_out_ch2.Location = new System.Drawing.Point(6, 19);
            this.checkBox_out_ch2.Name = "checkBox_out_ch2";
            this.checkBox_out_ch2.Size = new System.Drawing.Size(83, 17);
            this.checkBox_out_ch2.TabIndex = 4;
            this.checkBox_out_ch2.Text = "Вывод CH2";
            this.checkBox_out_ch2.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.checkBox_out_ch2);
            this.groupBox2.Controls.Add(this.checkBox_out_ch1);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Каналы";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 73);
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
            // checkBox_fft
            // 
            this.checkBox_fft.AutoSize = true;
            this.checkBox_fft.Location = new System.Drawing.Point(685, 37);
            this.checkBox_fft.Name = "checkBox_fft";
            this.checkBox_fft.Size = new System.Drawing.Size(45, 17);
            this.checkBox_fft.TabIndex = 13;
            this.checkBox_fft.Text = "FFT";
            this.checkBox_fft.UseVisualStyleBackColor = true;
            this.checkBox_fft.CheckedChanged += new System.EventHandler(this.checkBox_fft_CheckedChanged);
            // 
            // mockCheckBox
            // 
            this.mockCheckBox.AutoSize = true;
            this.mockCheckBox.Location = new System.Drawing.Point(685, 54);
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
            this.accuracyGroupBox.Size = new System.Drawing.Size(147, 100);
            this.accuracyGroupBox.TabIndex = 10;
            this.accuracyGroupBox.TabStop = false;
            this.accuracyGroupBox.Text = "Точность";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 737);
            this.Controls.Add(this.accuracyGroupBox);
            this.Controls.Add(this.mockCheckBox);
            this.Controls.Add(this.checkBox_fft);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run_stop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBox_out_ch1;
        private System.Windows.Forms.CheckBox checkBox_out_ch2;
        private System.Windows.Forms.RadioButton radioButton_std;
        private System.Windows.Forms.RadioButton radioButton_dfm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_export_ch2;
        private System.Windows.Forms.Button button_export_ch1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_fft;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox mockCheckBox;
        private System.Windows.Forms.RadioButton accuracyRadioButton15;
        private System.Windows.Forms.RadioButton accuracyRadioButton213;
        private System.Windows.Forms.GroupBox accuracyGroupBox;
    }
}

