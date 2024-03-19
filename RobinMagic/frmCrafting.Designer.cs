namespace RobinMagic
{
  partial class frmCrafting
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrafting));
      cmbItem = new ComboBox();
      lblDescription = new Label();
      picItem_1 = new PictureBox();
      picItem_2 = new PictureBox();
      picItem_3 = new PictureBox();
      picItem_4 = new PictureBox();
      lblItem_1 = new Label();
      lblItem_2 = new Label();
      lblItem_4 = new Label();
      lblItem_3 = new Label();
      label1 = new Label();
      nudAmount = new NumericUpDown();
      btnCreateItems = new Button();
      ((System.ComponentModel.ISupportInitialize)picItem_1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)picItem_2).BeginInit();
      ((System.ComponentModel.ISupportInitialize)picItem_3).BeginInit();
      ((System.ComponentModel.ISupportInitialize)picItem_4).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
      SuspendLayout();
      // 
      // cmbItem
      // 
      cmbItem.FormattingEnabled = true;
      cmbItem.Items.AddRange(new object[] { "Palo de madera.", "Hacha de madera.", "Pico de madera.", "Pala de madera." });
      cmbItem.Location = new Point(12, 12);
      cmbItem.Name = "cmbItem";
      cmbItem.Size = new Size(250, 23);
      cmbItem.TabIndex = 0;
      cmbItem.TextChanged += CmbItem_TextChanged;
      // 
      // lblDescription
      // 
      lblDescription.BorderStyle = BorderStyle.FixedSingle;
      lblDescription.ForeColor = Color.FromArgb(255, 255, 192);
      lblDescription.Location = new Point(12, 50);
      lblDescription.Name = "lblDescription";
      lblDescription.Size = new Size(250, 248);
      lblDescription.TabIndex = 1;
      // 
      // picItem_1
      // 
      picItem_1.BorderStyle = BorderStyle.FixedSingle;
      picItem_1.Location = new Point(279, 12);
      picItem_1.Name = "picItem_1";
      picItem_1.Size = new Size(50, 50);
      picItem_1.SizeMode = PictureBoxSizeMode.StretchImage;
      picItem_1.TabIndex = 2;
      picItem_1.TabStop = false;
      picItem_1.Visible = false;
      // 
      // picItem_2
      // 
      picItem_2.BorderStyle = BorderStyle.FixedSingle;
      picItem_2.Location = new Point(349, 12);
      picItem_2.Name = "picItem_2";
      picItem_2.Size = new Size(50, 50);
      picItem_2.SizeMode = PictureBoxSizeMode.StretchImage;
      picItem_2.TabIndex = 3;
      picItem_2.TabStop = false;
      picItem_2.Visible = false;
      // 
      // picItem_3
      // 
      picItem_3.BorderStyle = BorderStyle.FixedSingle;
      picItem_3.Location = new Point(419, 12);
      picItem_3.Name = "picItem_3";
      picItem_3.Size = new Size(50, 50);
      picItem_3.TabIndex = 4;
      picItem_3.TabStop = false;
      picItem_3.Visible = false;
      // 
      // picItem_4
      // 
      picItem_4.BorderStyle = BorderStyle.FixedSingle;
      picItem_4.Location = new Point(489, 12);
      picItem_4.Name = "picItem_4";
      picItem_4.Size = new Size(50, 50);
      picItem_4.TabIndex = 5;
      picItem_4.TabStop = false;
      picItem_4.Visible = false;
      // 
      // lblItem_1
      // 
      lblItem_1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      lblItem_1.ForeColor = Color.FromArgb(255, 255, 192);
      lblItem_1.Location = new Point(279, 62);
      lblItem_1.Name = "lblItem_1";
      lblItem_1.Size = new Size(50, 40);
      lblItem_1.TabIndex = 6;
      lblItem_1.Text = "10";
      lblItem_1.TextAlign = ContentAlignment.MiddleCenter;
      lblItem_1.Visible = false;
      // 
      // lblItem_2
      // 
      lblItem_2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      lblItem_2.ForeColor = Color.FromArgb(255, 255, 192);
      lblItem_2.Location = new Point(349, 62);
      lblItem_2.Name = "lblItem_2";
      lblItem_2.Size = new Size(50, 40);
      lblItem_2.TabIndex = 7;
      lblItem_2.Text = "10";
      lblItem_2.TextAlign = ContentAlignment.MiddleCenter;
      lblItem_2.Visible = false;
      // 
      // lblItem_4
      // 
      lblItem_4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      lblItem_4.ForeColor = Color.FromArgb(255, 255, 192);
      lblItem_4.Location = new Point(489, 62);
      lblItem_4.Name = "lblItem_4";
      lblItem_4.Size = new Size(50, 40);
      lblItem_4.TabIndex = 9;
      lblItem_4.Text = "10";
      lblItem_4.TextAlign = ContentAlignment.MiddleCenter;
      lblItem_4.Visible = false;
      // 
      // lblItem_3
      // 
      lblItem_3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      lblItem_3.ForeColor = Color.FromArgb(255, 255, 192);
      lblItem_3.Location = new Point(419, 62);
      lblItem_3.Name = "lblItem_3";
      lblItem_3.Size = new Size(50, 40);
      lblItem_3.TabIndex = 8;
      lblItem_3.Text = "10";
      lblItem_3.TextAlign = ContentAlignment.MiddleCenter;
      lblItem_3.Visible = false;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.ForeColor = Color.FromArgb(255, 255, 192);
      label1.Location = new Point(279, 111);
      label1.Name = "label1";
      label1.Size = new Size(191, 15);
      label1.TabIndex = 10;
      label1.Text = "Cantidad de items que desea crear:";
      // 
      // nudAmount
      // 
      nudAmount.Location = new Point(476, 109);
      nudAmount.Name = "nudAmount";
      nudAmount.Size = new Size(63, 23);
      nudAmount.TabIndex = 11;
      // 
      // btnCreateItems
      // 
      btnCreateItems.BackgroundImage = (Image)resources.GetObject("btnCreateItems.BackgroundImage");
      btnCreateItems.BackgroundImageLayout = ImageLayout.Stretch;
      btnCreateItems.Cursor = Cursors.Hand;
      btnCreateItems.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
      btnCreateItems.FlatAppearance.BorderSize = 2;
      btnCreateItems.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
      btnCreateItems.FlatStyle = FlatStyle.Flat;
      btnCreateItems.ForeColor = Color.FromArgb(255, 255, 192);
      btnCreateItems.Location = new Point(349, 163);
      btnCreateItems.Name = "btnCreateItems";
      btnCreateItems.Size = new Size(120, 120);
      btnCreateItems.TabIndex = 12;
      btnCreateItems.UseVisualStyleBackColor = true;
      btnCreateItems.Click += btnCreateItems_Click;
      // 
      // frmCasting
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(0, 11, 30);
      ClientSize = new Size(558, 309);
      Controls.Add(btnCreateItems);
      Controls.Add(nudAmount);
      Controls.Add(label1);
      Controls.Add(lblItem_4);
      Controls.Add(lblItem_3);
      Controls.Add(lblItem_2);
      Controls.Add(lblItem_1);
      Controls.Add(picItem_4);
      Controls.Add(picItem_3);
      Controls.Add(picItem_2);
      Controls.Add(picItem_1);
      Controls.Add(lblDescription);
      Controls.Add(cmbItem);
      Name = "frmCasting";
      Text = "Crafting";
      ((System.ComponentModel.ISupportInitialize)picItem_1).EndInit();
      ((System.ComponentModel.ISupportInitialize)picItem_2).EndInit();
      ((System.ComponentModel.ISupportInitialize)picItem_3).EndInit();
      ((System.ComponentModel.ISupportInitialize)picItem_4).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ComboBox cmbItem;
    private Label lblDescription;
    private PictureBox picItem_1;
    private PictureBox picItem_2;
    private PictureBox picItem_3;
    private PictureBox picItem_4;
    private Label lblItem_1;
    private Label lblItem_2;
    private Label lblItem_4;
    private Label lblItem_3;
    private Label label1;
    private NumericUpDown nudAmount;
    private Button btnCreateItems;
  }
}