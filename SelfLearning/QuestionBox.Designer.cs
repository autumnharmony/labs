namespace SelfLearning
{
    partial class QuestionBox
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.yesBtn = new System.Windows.Forms.Button();
            this.noBtn = new System.Windows.Forms.Button();
            this.questionLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesBtn
            // 
            this.yesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yesBtn.Location = new System.Drawing.Point(37, 115);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(75, 23);
            this.yesBtn.TabIndex = 0;
            this.yesBtn.Text = "Да";
            this.yesBtn.UseVisualStyleBackColor = true;
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // noBtn
            // 
            this.noBtn.Location = new System.Drawing.Point(143, 115);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(75, 23);
            this.noBtn.TabIndex = 1;
            this.noBtn.Text = "Нет";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // questionLbl
            // 
            this.questionLbl.AutoSize = true;
            this.questionLbl.Location = new System.Drawing.Point(15, 29);
            this.questionLbl.Name = "questionLbl";
            this.questionLbl.Size = new System.Drawing.Size(61, 13);
            this.questionLbl.TabIndex = 2;
            this.questionLbl.Text = "questionLbl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вопрос:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // QuestionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionLbl);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Name = "QuestionBox";
            this.Size = new System.Drawing.Size(266, 146);
            this.Load += new System.EventHandler(this.QuestionBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Label questionLbl;
        private System.Windows.Forms.Label label1;
    }
}
