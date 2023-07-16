namespace Змейка
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Head = new System.Windows.Forms.PictureBox();
            this.Fruit = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Head)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fruit)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.SteelBlue;
            this.Head.Location = new System.Drawing.Point(335, 272);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(61, 64);
            this.Head.TabIndex = 0;
            this.Head.TabStop = false;
            // 
            // Fruit
            // 
            this.Fruit.BackColor = System.Drawing.Color.Transparent;
            this.Fruit.Image = ((System.Drawing.Image)(resources.GetObject("Fruit.Image")));
            this.Fruit.Location = new System.Drawing.Point(566, 179);
            this.Fruit.Name = "Fruit";
            this.Fruit.Size = new System.Drawing.Size(73, 75);
            this.Fruit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Fruit.TabIndex = 1;
            this.Fruit.TabStop = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(58, 53);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(122, 36);
            this.Score.TabIndex = 2;
            this.Score.Text = "Счет: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Fruit);
            this.Controls.Add(this.Head);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Head)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fruit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Head;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox Fruit;
        private System.Windows.Forms.Label Score;
    }
}

