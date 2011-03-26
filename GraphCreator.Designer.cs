namespace GBusManager
{
    partial class GraphCreator
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
            // GraphCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "GraphCreator";
            this.Size = new System.Drawing.Size(331, 238);
            this.Load += new System.EventHandler(this.GraphCreator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphCreator_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphCreator_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphCreator_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphCreator_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
