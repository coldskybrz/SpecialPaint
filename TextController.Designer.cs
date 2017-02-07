namespace SpecialPaint
{
    partial class TextController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.distanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.textDistanceLabel = new System.Windows.Forms.Label();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(305, 134);
            this.textBox.TabIndex = 0;
            this.textBox.WordWrap = false;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // distanceNumericUpDown
            // 
            this.distanceNumericUpDown.Location = new System.Drawing.Point(221, 152);
            this.distanceNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.distanceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanceNumericUpDown.Name = "distanceNumericUpDown";
            this.distanceNumericUpDown.ReadOnly = true;
            this.distanceNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.distanceNumericUpDown.TabIndex = 1;
            this.distanceNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(218, 179);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(47, 20);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "Вверх";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(218, 205);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(47, 20);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "Вниз";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(159, 191);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(53, 20);
            this.leftButton.TabIndex = 4;
            this.leftButton.Text = "Влево";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(271, 191);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(55, 20);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "Вправо";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // textDistanceLabel
            // 
            this.textDistanceLabel.AutoSize = true;
            this.textDistanceLabel.Location = new System.Drawing.Point(12, 154);
            this.textDistanceLabel.Name = "textDistanceLabel";
            this.textDistanceLabel.Size = new System.Drawing.Size(203, 13);
            this.textDistanceLabel.TabIndex = 6;
            this.textDistanceLabel.Text = "Расстояние перемещения в пикселях:";
            // 
            // okayButton
            // 
            this.okayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okayButton.Location = new System.Drawing.Point(13, 190);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(56, 34);
            this.okayButton.TabIndex = 7;
            this.okayButton.Text = "Готово";
            this.okayButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(75, 191);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 34);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // TextController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 232);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.textDistanceLabel);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.distanceNumericUpDown);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextController";
            this.ShowIcon = false;
            this.Text = "Редактор установки текста";
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown distanceNumericUpDown;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Label textDistanceLabel;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
    }
}