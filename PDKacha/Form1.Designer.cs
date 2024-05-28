namespace PDKacha
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TrainingType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ToTime = new System.Windows.Forms.ComboBox();
            this.FromTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Sorting = new System.Windows.Forms.ComboBox();
            this.ResetFilterB = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TrainingType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ToTime);
            this.panel1.Controls.Add(this.FromTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Sorting);
            this.panel1.Location = new System.Drawing.Point(1011, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 682);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Сортировка";
            // 
            // TrainingType
            // 
            this.TrainingType.FormattingEnabled = true;
            this.TrainingType.Location = new System.Drawing.Point(8, 148);
            this.TrainingType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TrainingType.Name = "TrainingType";
            this.TrainingType.Size = new System.Drawing.Size(313, 24);
            this.TrainingType.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип тренировок";
            // 
            // ToTime
            // 
            this.ToTime.FormattingEnabled = true;
            this.ToTime.Location = new System.Drawing.Point(205, 80);
            this.ToTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToTime.Name = "ToTime";
            this.ToTime.Size = new System.Drawing.Size(116, 24);
            this.ToTime.TabIndex = 9;
            // 
            // FromTime
            // 
            this.FromTime.FormattingEnabled = true;
            this.FromTime.Location = new System.Drawing.Point(35, 80);
            this.FromTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FromTime.Name = "FromTime";
            this.FromTime.Size = new System.Drawing.Size(116, 24);
            this.FromTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "До:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "C:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Время работы";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 620);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(319, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Применить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Sorting
            // 
            this.Sorting.FormattingEnabled = true;
            this.Sorting.Location = new System.Drawing.Point(4, 26);
            this.Sorting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Sorting.Name = "Sorting";
            this.Sorting.Size = new System.Drawing.Size(317, 24);
            this.Sorting.TabIndex = 1;
            // 
            // ResetFilterB
            // 
            this.ResetFilterB.Location = new System.Drawing.Point(736, 16);
            this.ResetFilterB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetFilterB.Name = "ResetFilterB";
            this.ResetFilterB.Size = new System.Drawing.Size(147, 26);
            this.ResetFilterB.TabIndex = 2;
            this.ResetFilterB.Text = "Сброс фильров";
            this.ResetFilterB.UseVisualStyleBackColor = true;
            this.ResetFilterB.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 46);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(975, 650);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(891, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Фильтры>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 711);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ResetFilterB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Главная страница";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ResetFilterB;
        private System.Windows.Forms.ComboBox Sorting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ToTime;
        private System.Windows.Forms.ComboBox FromTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TrainingType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}

