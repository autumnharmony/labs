﻿namespace GBusManager
{
    partial class GraphViewer
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
            this.SuspendLayout();
            // 
            // GraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "GraphViewer";
            this.Size = new System.Drawing.Size(1096, 550);
            this.Load += new System.EventHandler(this.GraphView_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphViewer_MouseMove);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GraphView_MouseClick);
            this.MouseHover += new System.EventHandler(this.GraphViewer_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
