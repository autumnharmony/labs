namespace GBusManager
{
    partial class ToolsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsPanel));
            this.routesListBox = new System.Windows.Forms.ListBox();
            this.lineBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.pointBtn = new System.Windows.Forms.Button();
            this.destPoint = new System.Windows.Forms.ComboBox();
            this.srcPoint = new System.Windows.Forms.ComboBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.resultBtn = new System.Windows.Forms.Button();
            this.endRoute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // routesListBox
            // 
            this.routesListBox.FormattingEnabled = true;
            this.routesListBox.Location = new System.Drawing.Point(3, 28);
            this.routesListBox.Name = "routesListBox";
            this.routesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.routesListBox.Size = new System.Drawing.Size(78, 82);
            this.routesListBox.TabIndex = 6;
            this.routesListBox.SelectedIndexChanged += new System.EventHandler(this.routesListBox_SelectedIndexChanged);
            this.routesListBox.SelectedValueChanged += new System.EventHandler(this.routesListBox_SelectedValueChanged);
            // 
            // lineBtn
            // 
            this.lineBtn.AutoSize = true;
            this.lineBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lineBtn.Image = global::GBusManager.Resource1.layer_shape_polyline;
            this.lineBtn.Location = new System.Drawing.Point(59, 0);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(22, 22);
            this.lineBtn.TabIndex = 2;
            this.lineBtn.UseVisualStyleBackColor = true;
            this.lineBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.AutoSize = true;
            this.selectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectBtn.Image")));
            this.selectBtn.Location = new System.Drawing.Point(28, 0);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(22, 22);
            this.selectBtn.TabIndex = 1;
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // pointBtn
            // 
            this.pointBtn.AutoSize = true;
            this.pointBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pointBtn.Image = global::GBusManager.Resource1.pin__plus;
            this.pointBtn.Location = new System.Drawing.Point(0, 0);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(22, 22);
            this.pointBtn.TabIndex = 0;
            this.pointBtn.UseVisualStyleBackColor = true;
            this.pointBtn.Click += new System.EventHandler(this.pointBtn_Click);
            // 
            // destPoint
            // 
            this.destPoint.FormattingEnabled = true;
            this.destPoint.Location = new System.Drawing.Point(4, 143);
            this.destPoint.Name = "destPoint";
            this.destPoint.Size = new System.Drawing.Size(77, 21);
            this.destPoint.TabIndex = 13;
            this.destPoint.SelectedIndexChanged += new System.EventHandler(this.destPoint_SelectedIndexChanged);
            // 
            // srcPoint
            // 
            this.srcPoint.FormattingEnabled = true;
            this.srcPoint.Location = new System.Drawing.Point(3, 116);
            this.srcPoint.Name = "srcPoint";
            this.srcPoint.Size = new System.Drawing.Size(78, 21);
            this.srcPoint.TabIndex = 14;
            this.srcPoint.SelectedIndexChanged += new System.EventHandler(this.srcPoint_SelectedIndexChanged);
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(17, 200);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(35, 13);
            this.resultLbl.TabIndex = 15;
            this.resultLbl.Text = "label1";
            // 
            // resultBtn
            // 
            this.resultBtn.Location = new System.Drawing.Point(4, 170);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(75, 23);
            this.resultBtn.TabIndex = 16;
            this.resultBtn.Text = "button7";
            this.resultBtn.UseVisualStyleBackColor = true;
            this.resultBtn.Click += new System.EventHandler(this.resultBtn_Click);
            // 
            // endRoute
            // 
            this.endRoute.Location = new System.Drawing.Point(90, 0);
            this.endRoute.Name = "endRoute";
            this.endRoute.Size = new System.Drawing.Size(75, 23);
            this.endRoute.TabIndex = 17;
            this.endRoute.Text = "button1";
            this.endRoute.UseVisualStyleBackColor = true;
            this.endRoute.Click += new System.EventHandler(this.endRoute_Click);
            // 
            // ToolsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.endRoute);
            this.Controls.Add(this.resultBtn);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.srcPoint);
            this.Controls.Add(this.destPoint);
            this.Controls.Add(this.routesListBox);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.pointBtn);
            this.Name = "ToolsPanel";
            this.Size = new System.Drawing.Size(168, 213);
            this.Load += new System.EventHandler(this.ToolsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.ListBox routesListBox;
        private System.Windows.Forms.ComboBox destPoint;
        private System.Windows.Forms.ComboBox srcPoint;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.Button endRoute;
    }
}
