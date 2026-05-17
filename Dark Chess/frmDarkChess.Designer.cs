namespace Dark_Chess
{
    partial class frmDarkChess
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.lblRedCount = new System.Windows.Forms.Label();
            this.lblBlackCount = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpBoard = new System.Windows.Forms.TableLayoutPanel();
            this.grpFunction = new System.Windows.Forms.GroupBox();
            this.btnRule = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpInformation.SuspendLayout();
            this.grpFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInformation
            // 
            this.grpInformation.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grpInformation.Controls.Add(this.lblRedCount);
            this.grpInformation.Controls.Add(this.lblBlackCount);
            this.grpInformation.Controls.Add(this.lblSelected);
            this.grpInformation.Controls.Add(this.lblTurn);
            this.grpInformation.Controls.Add(this.lblTitle);
            this.grpInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInformation.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpInformation.Location = new System.Drawing.Point(0, 0);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(1153, 116);
            this.grpInformation.TabIndex = 0;
            this.grpInformation.TabStop = false;
            // 
            // lblRedCount
            // 
            this.lblRedCount.AutoSize = true;
            this.lblRedCount.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblRedCount.ForeColor = System.Drawing.Color.Brown;
            this.lblRedCount.Location = new System.Drawing.Point(789, 30);
            this.lblRedCount.Name = "lblRedCount";
            this.lblRedCount.Size = new System.Drawing.Size(136, 25);
            this.lblRedCount.TabIndex = 4;
            this.lblRedCount.Text = "紅方剩餘：16";
            // 
            // lblBlackCount
            // 
            this.lblBlackCount.AutoSize = true;
            this.lblBlackCount.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBlackCount.Location = new System.Drawing.Point(789, 75);
            this.lblBlackCount.Name = "lblBlackCount";
            this.lblBlackCount.Size = new System.Drawing.Size(136, 25);
            this.lblBlackCount.TabIndex = 3;
            this.lblBlackCount.Text = "黑方剩餘：16";
            this.lblBlackCount.Click += new System.EventHandler(this.lblBlackCount_Click);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSelected.Location = new System.Drawing.Point(12, 75);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(112, 25);
            this.lblSelected.TabIndex = 2;
            this.lblSelected.Text = "以選取：無";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTurn.Location = new System.Drawing.Point(12, 30);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(132, 25);
            this.lblTurn.TabIndex = 1;
            this.lblTurn.Text = "目前回合方：";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTitle.Location = new System.Drawing.Point(507, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "暗棋雙人對戰";
            // 
            // tlpBoard
            // 
            this.tlpBoard.ColumnCount = 8;
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpBoard.Location = new System.Drawing.Point(0, 112);
            this.tlpBoard.Name = "tlpBoard";
            this.tlpBoard.RowCount = 4;
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBoard.Size = new System.Drawing.Size(1153, 452);
            this.tlpBoard.TabIndex = 1;
            // 
            // grpFunction
            // 
            this.grpFunction.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grpFunction.Controls.Add(this.btnRule);
            this.grpFunction.Controls.Add(this.btnExit);
            this.grpFunction.Controls.Add(this.btnRestart);
            this.grpFunction.Controls.Add(this.btnStart);
            this.grpFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpFunction.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpFunction.Location = new System.Drawing.Point(0, 570);
            this.grpFunction.Name = "grpFunction";
            this.grpFunction.Size = new System.Drawing.Size(1153, 78);
            this.grpFunction.TabIndex = 2;
            this.grpFunction.TabStop = false;
            // 
            // btnRule
            // 
            this.btnRule.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRule.Location = new System.Drawing.Point(857, 26);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(173, 40);
            this.btnRule.TabIndex = 3;
            this.btnRule.Text = "遊戲規則";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(575, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(173, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "離開遊戲";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRestart.Location = new System.Drawing.Point(307, 21);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(173, 40);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(30, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "開始遊戲";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmDarkChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 648);
            this.Controls.Add(this.grpFunction);
            this.Controls.Add(this.tlpBoard);
            this.Controls.Add(this.grpInformation);
            this.Name = "frmDarkChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "暗棋雙人對戰";
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.grpFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TableLayoutPanel tlpBoard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRedCount;
        private System.Windows.Forms.Label lblBlackCount;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.GroupBox grpFunction;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStart;
    }
}

