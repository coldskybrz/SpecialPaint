namespace SpecialPaint
{
    partial class PaintToolStrip
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
            this.strokeSize = new System.Windows.Forms.NumericUpDown();
            this.fillCheckBox = new System.Windows.Forms.CheckBox();
            this.fontChangeButton = new System.Windows.Forms.Button();
            this.dashStyleComboBox = new System.Windows.Forms.ComboBox();
            this.secondColorButton = new SpecialPaint.PaintButton();
            this.firstColorButton = new SpecialPaint.PaintButton();
            this.ellipseButton = new SpecialPaint.PaintButton();
            this.rectangleButton = new SpecialPaint.PaintButton();
            this.lineButton = new SpecialPaint.PaintButton();
            this.pipetteButton = new SpecialPaint.PaintButton();
            this.eraserButton = new SpecialPaint.PaintButton();
            this.textButton = new SpecialPaint.PaintButton();
            this.penButton = new SpecialPaint.PaintButton();
            ((System.ComponentModel.ISupportInitialize)(this.strokeSize)).BeginInit();
            this.SuspendLayout();
            // 
            // strokeSize
            // 
            this.strokeSize.Location = new System.Drawing.Point(325, 14);
            this.strokeSize.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.strokeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.strokeSize.Name = "strokeSize";
            this.strokeSize.ReadOnly = true;
            this.strokeSize.Size = new System.Drawing.Size(49, 20);
            this.strokeSize.TabIndex = 9;
            this.strokeSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fillCheckBox
            // 
            this.fillCheckBox.AutoSize = true;
            this.fillCheckBox.Location = new System.Drawing.Point(588, 18);
            this.fillCheckBox.Name = "fillCheckBox";
            this.fillCheckBox.Size = new System.Drawing.Size(62, 17);
            this.fillCheckBox.TabIndex = 11;
            this.fillCheckBox.Text = "Залить";
            this.fillCheckBox.UseVisualStyleBackColor = true;
            // 
            // fontChangeButton
            // 
            this.fontChangeButton.Location = new System.Drawing.Point(507, 14);
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.Size = new System.Drawing.Size(75, 23);
            this.fontChangeButton.TabIndex = 12;
            this.fontChangeButton.Text = "Шрифт";
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.fontChangeButton_Click);
            // 
            // dashStyleComboBox
            // 
            this.dashStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dashStyleComboBox.FormattingEnabled = true;
            this.dashStyleComboBox.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dash-Dot",
            "Dash-Dot-Dot",
            "Dot"});
            this.dashStyleComboBox.Location = new System.Drawing.Point(380, 14);
            this.dashStyleComboBox.Name = "dashStyleComboBox";
            this.dashStyleComboBox.Size = new System.Drawing.Size(121, 21);
            this.dashStyleComboBox.TabIndex = 13;
            // 
            // secondColorButton
            // 
            this.secondColorButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondColorButton.ImagePath = null;
            this.secondColorButton.Location = new System.Drawing.Point(656, 3);
            this.secondColorButton.Name = "secondColorButton";
            this.secondColorButton.Size = new System.Drawing.Size(40, 40);
            this.secondColorButton.Stroke = System.Drawing.Color.Empty;
            this.secondColorButton.TabIndex = 8;
            // 
            // firstColorButton
            // 
            this.firstColorButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.firstColorButton.ImagePath = null;
            this.firstColorButton.Location = new System.Drawing.Point(702, 3);
            this.firstColorButton.Name = "firstColorButton";
            this.firstColorButton.Size = new System.Drawing.Size(40, 40);
            this.firstColorButton.Stroke = System.Drawing.Color.Empty;
            this.firstColorButton.TabIndex = 7;
            // 
            // ellipseButton
            // 
            this.ellipseButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ellipseButton.ImagePath = null;
            this.ellipseButton.Location = new System.Drawing.Point(279, 3);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(40, 40);
            this.ellipseButton.Stroke = System.Drawing.Color.Empty;
            this.ellipseButton.TabIndex = 6;
            // 
            // rectangleButton
            // 
            this.rectangleButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rectangleButton.ImagePath = null;
            this.rectangleButton.Location = new System.Drawing.Point(233, 3);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(40, 40);
            this.rectangleButton.Stroke = System.Drawing.Color.Empty;
            this.rectangleButton.TabIndex = 5;
            // 
            // lineButton
            // 
            this.lineButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lineButton.ImagePath = null;
            this.lineButton.Location = new System.Drawing.Point(187, 3);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(40, 40);
            this.lineButton.Stroke = System.Drawing.Color.Empty;
            this.lineButton.TabIndex = 4;
            // 
            // pipetteButton
            // 
            this.pipetteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pipetteButton.ImagePath = null;
            this.pipetteButton.Location = new System.Drawing.Point(141, 3);
            this.pipetteButton.Name = "pipetteButton";
            this.pipetteButton.Size = new System.Drawing.Size(40, 40);
            this.pipetteButton.Stroke = System.Drawing.Color.Empty;
            this.pipetteButton.TabIndex = 3;
            // 
            // eraserButton
            // 
            this.eraserButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eraserButton.ImagePath = null;
            this.eraserButton.Location = new System.Drawing.Point(95, 3);
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(40, 40);
            this.eraserButton.Stroke = System.Drawing.Color.Empty;
            this.eraserButton.TabIndex = 2;
            // 
            // textButton
            // 
            this.textButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textButton.ImagePath = null;
            this.textButton.Location = new System.Drawing.Point(49, 3);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(40, 40);
            this.textButton.Stroke = System.Drawing.Color.Empty;
            this.textButton.TabIndex = 1;
            // 
            // penButton
            // 
            this.penButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.penButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.penButton.ImagePath = null;
            this.penButton.Location = new System.Drawing.Point(3, 3);
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(40, 40);
            this.penButton.Stroke = System.Drawing.Color.Empty;
            this.penButton.TabIndex = 0;
            // 
            // PaintToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dashStyleComboBox);
            this.Controls.Add(this.fontChangeButton);
            this.Controls.Add(this.fillCheckBox);
            this.Controls.Add(this.strokeSize);
            this.Controls.Add(this.secondColorButton);
            this.Controls.Add(this.firstColorButton);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.rectangleButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.pipetteButton);
            this.Controls.Add(this.eraserButton);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.penButton);
            this.MinimumSize = new System.Drawing.Size(749, 46);
            this.Name = "PaintToolStrip";
            this.Size = new System.Drawing.Size(749, 46);
            ((System.ComponentModel.ISupportInitialize)(this.strokeSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PaintButton penButton;
        private PaintButton textButton;
        private PaintButton eraserButton;
        private PaintButton pipetteButton;
        private PaintButton lineButton;
        private PaintButton rectangleButton;
        private PaintButton ellipseButton;
        private PaintButton firstColorButton;
        private PaintButton secondColorButton;
        private System.Windows.Forms.NumericUpDown strokeSize;
        private System.Windows.Forms.CheckBox fillCheckBox;
        private System.Windows.Forms.Button fontChangeButton;
        private System.Windows.Forms.ComboBox dashStyleComboBox;
    }
}
