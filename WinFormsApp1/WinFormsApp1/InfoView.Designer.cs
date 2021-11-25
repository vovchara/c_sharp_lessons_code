
namespace WinFormsApp1
{
    partial class InfoView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.showAllBtn = new System.Windows.Forms.Button();
            this.findByIdBtn = new System.Windows.Forms.Button();
            this.findByDestination = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tripIdInputTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.destinationTxt = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(114, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ласкаво просимо до інформаційної довідки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(302, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Виберіть дію:";
            // 
            // showAllBtn
            // 
            this.showAllBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.showAllBtn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showAllBtn.Location = new System.Drawing.Point(134, 151);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(514, 58);
            this.showAllBtn.TabIndex = 2;
            this.showAllBtn.Text = "Показати всі рейси";
            this.showAllBtn.UseVisualStyleBackColor = false;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // findByIdBtn
            // 
            this.findByIdBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.findByIdBtn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.findByIdBtn.Location = new System.Drawing.Point(346, 13);
            this.findByIdBtn.Name = "findByIdBtn";
            this.findByIdBtn.Size = new System.Drawing.Size(400, 50);
            this.findByIdBtn.TabIndex = 2;
            this.findByIdBtn.Text = "Знайти рейс за номером";
            this.findByIdBtn.UseVisualStyleBackColor = false;
            this.findByIdBtn.Click += new System.EventHandler(this.findByIdBtn_Click);
            // 
            // findByDestination
            // 
            this.findByDestination.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.findByDestination.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.findByDestination.Location = new System.Drawing.Point(346, 14);
            this.findByDestination.Name = "findByDestination";
            this.findByDestination.Size = new System.Drawing.Size(400, 50);
            this.findByDestination.TabIndex = 2;
            this.findByDestination.Text = "Знайти рейс за кінцевим пунктом";
            this.findByDestination.UseVisualStyleBackColor = false;
            this.findByDestination.Click += new System.EventHandler(this.findByDestination_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tripIdInputTxt);
            this.groupBox1.Controls.Add(this.findByIdBtn);
            this.groupBox1.Location = new System.Drawing.Point(25, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tripIdInputTxt
            // 
            this.tripIdInputTxt.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tripIdInputTxt.Location = new System.Drawing.Point(193, 22);
            this.tripIdInputTxt.MaxLength = 10;
            this.tripIdInputTxt.Name = "tripIdInputTxt";
            this.tripIdInputTxt.PlaceholderText = "введіть номер";
            this.tripIdInputTxt.Size = new System.Drawing.Size(147, 34);
            this.tripIdInputTxt.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.destinationTxt);
            this.groupBox2.Controls.Add(this.findByDestination);
            this.groupBox2.Location = new System.Drawing.Point(25, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(752, 70);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // destinationTxt
            // 
            this.destinationTxt.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.destinationTxt.Location = new System.Drawing.Point(193, 22);
            this.destinationTxt.MaxLength = 20;
            this.destinationTxt.Name = "destinationTxt";
            this.destinationTxt.PlaceholderText = "введіть куди";
            this.destinationTxt.Size = new System.Drawing.Size(147, 34);
            this.destinationTxt.TabIndex = 4;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.backBtn.Location = new System.Drawing.Point(25, 562);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 5;
            this.backBtn.Text = "<< назад";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // InfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showAllBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InfoView";
            this.Size = new System.Drawing.Size(800, 600);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showAllBtn;
        private System.Windows.Forms.Button findByIdBtn;
        private System.Windows.Forms.Button findByDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TextBox tripIdInputTxt;
        private System.Windows.Forms.TextBox destinationTxt;
    }
}
