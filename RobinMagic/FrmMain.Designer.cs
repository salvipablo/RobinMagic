namespace RobinMagic
{
  partial class FrmMain
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      lblPosition = new Label();
      lblItem = new Label();
      SuspendLayout();
      // 
      // lblPosition
      // 
      lblPosition.BackColor = SystemColors.ActiveCaption;
      lblPosition.ForeColor = SystemColors.ActiveCaptionText;
      lblPosition.Location = new Point(600, 10);
      lblPosition.Name = "lblPosition";
      lblPosition.Size = new Size(200, 30);
      lblPosition.TabIndex = 0;
      lblPosition.Text = "Player Position: (1, 1)";
      lblPosition.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lblItem
      // 
      lblItem.BackColor = SystemColors.ActiveCaption;
      lblItem.ForeColor = SystemColors.ActiveCaptionText;
      lblItem.Location = new Point(600, 50);
      lblItem.Name = "lblItem";
      lblItem.Size = new Size(200, 30);
      lblItem.TabIndex = 1;
      lblItem.Text = "Item en frente: ";
      lblItem.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FrmMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(0, 11, 30);
      ClientSize = new Size(1084, 661);
      Controls.Add(lblItem);
      Controls.Add(lblPosition);
      Location = new Point(500, 250);
      Name = "FrmMain";
      Text = "Robin Magic";
      KeyDown += FrmMain_KeyDown;
      ResumeLayout(false);
    }

    #endregion

    private Label lblPosition;
    private Label lblItem;
  }
}
