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
            this.destPoint = new System.Windows.Forms.ComboBox();
            this.srcPoint = new System.Windows.Forms.ComboBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.resultBtn = new System.Windows.Forms.Button();
            this.removeRouteBtn = new System.Windows.Forms.Button();
            this.selectAllRoutesBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.pointBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // routesListBox
            // 
            this.routesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.routesListBox, 3);
            this.routesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routesListBox.FormattingEnabled = true;
            this.routesListBox.Location = new System.Drawing.Point(3, 52);
            this.routesListBox.Name = "routesListBox";
            this.routesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.routesListBox.Size = new System.Drawing.Size(84, 65);
            this.routesListBox.TabIndex = 6;
            this.routesListBox.SelectedIndexChanged += new System.EventHandler(this.routesListBox_SelectedIndexChanged);
            this.routesListBox.SelectedValueChanged += new System.EventHandler(this.routesListBox_SelectedValueChanged);
            // 
            // destPoint
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.destPoint, 3);
            this.destPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.destPoint.FormattingEnabled = true;
            this.destPoint.Location = new System.Drawing.Point(3, 196);
            this.destPoint.Name = "destPoint";
            this.destPoint.Size = new System.Drawing.Size(84, 21);
            this.destPoint.TabIndex = 13;
            this.destPoint.Text = "куда";
            this.destPoint.SelectedIndexChanged += new System.EventHandler(this.destPoint_SelectedIndexChanged);
            // 
            // srcPoint
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.srcPoint, 3);
            this.srcPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.srcPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srcPoint.FormattingEnabled = true;
            this.srcPoint.Location = new System.Drawing.Point(3, 164);
            this.srcPoint.Name = "srcPoint";
            this.srcPoint.Size = new System.Drawing.Size(84, 21);
            this.srcPoint.TabIndex = 14;
            this.srcPoint.Text = "откуда";
            this.srcPoint.SelectedIndexChanged += new System.EventHandler(this.srcPoint_SelectedIndexChanged);
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(3, 218);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(0, 13);
            this.resultLbl.TabIndex = 15;
            // 
            // resultBtn
            // 
            this.resultBtn.AutoSize = true;
            this.resultBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.resultBtn, 3);
            this.resultBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resultBtn.Location = new System.Drawing.Point(0, 130);
            this.resultBtn.Margin = new System.Windows.Forms.Padding(0);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(80, 25);
            this.resultBtn.TabIndex = 16;
            this.resultBtn.Text = "Кратчайший";
            this.resultBtn.UseVisualStyleBackColor = true;
            this.resultBtn.Click += new System.EventHandler(this.resultBtn_Click);
            // 
            // removeRouteBtn
            // 
            this.removeRouteBtn.Location = new System.Drawing.Point(63, 221);
            this.removeRouteBtn.Name = "removeRouteBtn";
            this.removeRouteBtn.Size = new System.Drawing.Size(22, 23);
            this.removeRouteBtn.TabIndex = 17;
            this.removeRouteBtn.Text = "button1";
            this.removeRouteBtn.UseVisualStyleBackColor = true;
            this.removeRouteBtn.Visible = false;
            this.removeRouteBtn.Click += new System.EventHandler(this.removeRouteBtn_Click);
            // 
            // selectAllRoutesBtn
            // 
            this.selectAllRoutesBtn.Location = new System.Drawing.Point(17, 339);
            this.selectAllRoutesBtn.Name = "selectAllRoutesBtn";
            this.selectAllRoutesBtn.Size = new System.Drawing.Size(22, 23);
            this.selectAllRoutesBtn.TabIndex = 18;
            this.selectAllRoutesBtn.Text = "button2";
            this.selectAllRoutesBtn.UseVisualStyleBackColor = true;
            this.selectAllRoutesBtn.Visible = false;
            this.selectAllRoutesBtn.Click += new System.EventHandler(this.selectAllRoutesBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.selectBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.resultLbl, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.removeRouteBtn, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lineBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pointBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.routesListBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.resultBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.destPoint, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.srcPoint, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(90, 271);
            this.tableLayoutPanel1.TabIndex = 21;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // selectBtn
            // 
            this.selectBtn.AutoSize = true;
            this.selectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectBtn.Image")));
            this.selectBtn.Location = new System.Drawing.Point(63, 3);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(24, 24);
            this.selectBtn.TabIndex = 23;
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.AutoSize = true;
            this.lineBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineBtn.Image = global::GBusManager.Resource1.layer_shape_polyline;
            this.lineBtn.Location = new System.Drawing.Point(33, 3);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(24, 24);
            this.lineBtn.TabIndex = 24;
            this.lineBtn.UseVisualStyleBackColor = true;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // pointBtn
            // 
            this.pointBtn.AutoSize = true;
            this.pointBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pointBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pointBtn.Image = global::GBusManager.Resource1.pin__plus;
            this.pointBtn.Location = new System.Drawing.Point(3, 3);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(24, 24);
            this.pointBtn.TabIndex = 22;
            this.pointBtn.UseVisualStyleBackColor = true;
            this.pointBtn.Click += new System.EventHandler(this.pointBtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Маршруты";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ToolsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.selectAllRoutesBtn);
            this.Name = "ToolsPanel";
            this.Size = new System.Drawing.Size(96, 365);
            this.Load += new System.EventHandler(this.ToolsPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox routesListBox;
        private System.Windows.Forms.ComboBox destPoint;
        private System.Windows.Forms.ComboBox srcPoint;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.Button removeRouteBtn;
        private System.Windows.Forms.Button selectAllRoutesBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}
