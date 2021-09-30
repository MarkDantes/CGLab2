namespace WindowsFormsApp1
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
            this.checkBoxLineDrawer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxLineDrawer
            // 
            this.checkBoxLineDrawer.AutoSize = true;
            this.checkBoxLineDrawer.Location = new System.Drawing.Point(12, 12);
            this.checkBoxLineDrawer.Name = "checkBoxLineDrawer";
            this.checkBoxLineDrawer.Size = new System.Drawing.Size(222, 29);
            this.checkBoxLineDrawer.TabIndex = 0;
            this.checkBoxLineDrawer.Text = "Enable line drawer";
            this.checkBoxLineDrawer.UseVisualStyleBackColor = true;
            this.checkBoxLineDrawer.CheckedChanged += new System.EventHandler(this.onCheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxLineDrawer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onMouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxLineDrawer;
    }
}

