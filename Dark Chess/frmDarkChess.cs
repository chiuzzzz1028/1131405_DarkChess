using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Dark_Chess
{
    public partial class frmDarkChess : Form
    {
        private Button[,] boardButtons = new Button[4, 8];
        private ChessPiece[,] board = new ChessPiece[4, 8];

        private List<ChessPiece> pieces = new List<ChessPiece>();

        private int selectedRow = -1;
        private int selectedCol = -1;

        private int currentPlayer = 1;          // 目前輪到玩家1或玩家2
        private string player1Color = "";       // 玩家1顏色，Red 或 Black
        private string player2Color = "";       // 玩家2顏色，Red 或 Black
        private bool isColorDecided = false;    // 是否已經決定雙方顏色

        private void PlaySound(string soundPath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(soundPath);
                player.Play();
            }
            catch
            {
                // 如果音效檔找不到，不讓遊戲直接當掉
            }
        }

        public frmDarkChess()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void StartGame()
        {
            tlpBoard.Enabled = true;
            selectedRow = -1;
            selectedCol = -1;

            currentPlayer = 1;
            player1Color = "";
            player2Color = "";
            isColorDecided = false;

            lblTurn.Text = "目前回合方：玩家1";
            lblSelected.Text = "已選取：無";
            lblRedCount.Text = "紅方剩餘：16";
            lblBlackCount.Text = "黑方剩餘：16";


            CreatePieces();
            ShufflePieces();
            CreateBoardButtons();

        }
        private void CreatePieces()
        {
            pieces.Clear();

            // 紅方
            pieces.Add(new ChessPiece("帥", "Red", 7, "Resources/red_king.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("仕", "Red", 6, "Resources/red_guard.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("相", "Red", 5, "Resources/red_elephant.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("俥", "Red", 4, "Resources/red_rook.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("傌", "Red", 3, "Resources/red_knight.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("炮", "Red", 2, "Resources/red_cannon.png"));

            for (int i = 0; i < 5; i++)
                pieces.Add(new ChessPiece("兵", "Red", 1, "Resources/red_pawn.png"));

            // 黑方
            pieces.Add(new ChessPiece("將", "Black", 7, "Resources/black_king.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("士", "Black", 6, "Resources/black_guard.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("象", "Black", 5, "Resources/black_elephant.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("車", "Black", 4, "Resources/black_rook.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("馬", "Black", 3, "Resources/black_knight.png"));

            for (int i = 0; i < 2; i++)
                pieces.Add(new ChessPiece("包", "Black", 2, "Resources/black_cannon.png"));

            for (int i = 0; i < 5; i++)
                pieces.Add(new ChessPiece("卒", "Black", 1, "Resources/black_pawn.png"));
        }
        private void ShufflePieces()
        {
            Random random = new Random();

            pieces = pieces.OrderBy(x => random.Next()).ToList();

            int index = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = pieces[index];
                    index++;
                }
            }
        }
        private void CreateBoardButtons()
        {
            tlpBoard.Controls.Clear();

            tlpBoard.ColumnCount = 8;
            tlpBoard.RowCount = 4;

            tlpBoard.ColumnStyles.Clear();
            tlpBoard.RowStyles.Clear();

            for (int i = 0; i < 8; i++)
            {
                tlpBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            }

            for (int i = 0; i < 4; i++)
            {
                tlpBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button btn = new Button();

                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(3);
                    btn.Tag = new Point(row, col);

                    btn.BackgroundImage = Image.FromFile("Resources/back.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    btn.Click += BoardButton_Click;

                    boardButtons[row, col] = btn;
                    tlpBoard.Controls.Add(btn, col, row);
                }
            }
        }
        private void BoardButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Point pos = (Point)btn.Tag;
            int row = pos.X;
            int col = pos.Y;

            ChessPiece piece = board[row, col];

            // 如果點到空格
            if (piece == null)
            {
                // 如果目前有選取棋子，就嘗試移動
                if (selectedRow != -1 && selectedCol != -1)
                {
                    TryMove(row, col);
                }

                return;
            }

            // 如果棋子還沒翻開，就翻開
            if (!piece.IsRevealed)
            {
                piece.IsRevealed = true;

                btn.BackgroundImage = Image.FromFile(piece.ImagePath);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                PlaySound("Resources/flip.wav");

                // 第一次翻棋時決定玩家顏色
                if (!isColorDecided)
                {
                    DecidePlayerColor(piece.Color);
                }

                selectedRow = -1;
                selectedCol = -1;
                lblSelected.Text = "已選取：無";

                SwitchPlayer();
                return;
            }

            // 如果已經有選取棋子，且點到另一顆棋，嘗試吃棋
            if (selectedRow != -1 && selectedCol != -1)
            {
                // 如果點到同一顆，就取消選取
                if (selectedRow == row && selectedCol == col)
                {
                    ClearSelection();
                    return;
                }

                TryEat(row, col);
                return;
            }

            // 沒有選取棋子時，點自己的棋子才可以選
            SelectPiece(row, col);
        }
        private void DecidePlayerColor(string firstPieceColor)
        {
            isColorDecided = true;

            if (firstPieceColor == "Red")
            {
                player1Color = "Red";
                player2Color = "Black";

                MessageBox.Show("玩家1 翻到紅棋，所以玩家1是紅方，玩家2是黑方！");
            }
            else
            {
                player1Color = "Black";
                player2Color = "Red";

                MessageBox.Show("玩家1 翻到黑棋，所以玩家1是黑方，玩家2是紅方！");
            }
        }
        private string GetCurrentPlayerColor()
        {
            return currentPlayer == 1 ? player1Color : player2Color;
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }

            UpdateTurnLabel();
        }
        private void UpdateTurnLabel()
        {
            if (!isColorDecided)
            {
                lblTurn.Text = $"目前回合方：玩家{currentPlayer}";
                return;
            }

            string colorText;

            if (currentPlayer == 1)
            {
                colorText = player1Color == "Red" ? "紅方" : "黑方";
                lblTurn.Text = $"目前回合方：玩家1（{colorText}）";
            }
            else
            {
                colorText = player2Color == "Red" ? "紅方" : "黑方";
                lblTurn.Text = $"目前回合方：玩家2（{colorText}）";
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsAdjacent(int row1, int col1, int row2, int col2)
        {
            int rowDiff = Math.Abs(row1 - row2);
            int colDiff = Math.Abs(col1 - col2);

            return rowDiff + colDiff == 1;
        }
        private bool CanEat(ChessPiece attacker, ChessPiece target)
        {
            // 不能吃自己的棋
            if (attacker.Color == target.Color)
            {
                return false;
            }

            // 兵 / 卒 可以吃 帥 / 將
            if (attacker.Rank == 1 && target.Rank == 7)
            {
                return true;
            }

            // 帥 / 將 不能吃 兵 / 卒
            if (attacker.Rank == 7 && target.Rank == 1)
            {
                return false;
            }

            // 一般情況：大的吃小的，同級互吃
            return attacker.Rank >= target.Rank;
        }

        private bool IsCannon(ChessPiece piece)
        {
            return piece.Name == "炮" || piece.Name == "包";
        }

        private void SelectPiece(int row, int col)
        {
            ChessPiece piece = board[row, col];

            if (piece == null)
            {
                return;
            }

            if (!piece.IsRevealed)
            {
                return;
            }

            string currentColor = GetCurrentPlayerColor();

            // 顏色還沒決定前，不允許選棋
            if (currentColor == "")
            {
                MessageBox.Show("請先翻第一顆棋決定雙方顏色！");
                return;
            }

            // 只能選自己的棋
            if (piece.Color != currentColor)
            {
                MessageBox.Show("只能選取自己顏色的棋子！");
                return;
            }

            selectedRow = row;
            selectedCol = col;

            lblSelected.Text = "已選取：" + piece.Name;

            // 讓被選取的按鈕有提示
            boardButtons[row, col].FlatStyle = FlatStyle.Flat;
            boardButtons[row, col].FlatAppearance.BorderSize = 3;
        }
        private void ClearSelection()
        {
            if (selectedRow != -1 && selectedCol != -1)
            {
                boardButtons[selectedRow, selectedCol].FlatAppearance.BorderSize = 1;
                boardButtons[selectedRow, selectedCol].FlatStyle = FlatStyle.Standard;
            }

            selectedRow = -1;
            selectedCol = -1;

            lblSelected.Text = "已選取：無";
        }
        private void TryMove(int targetRow, int targetCol)
        {
            if (!IsAdjacent(selectedRow, selectedCol, targetRow, targetCol))
            {
                MessageBox.Show("只能移動到上下左右相鄰的一格！");
                return;
            }

            ChessPiece selectedPiece = board[selectedRow, selectedCol];

            // 目標格必須是空的
            if (board[targetRow, targetCol] != null)
            {
                return;
            }

            board[targetRow, targetCol] = selectedPiece;
            board[selectedRow, selectedCol] = null;

            boardButtons[targetRow, targetCol].BackgroundImage = Image.FromFile(selectedPiece.ImagePath);
            boardButtons[targetRow, targetCol].BackgroundImageLayout = ImageLayout.Stretch;

            boardButtons[selectedRow, selectedCol].BackgroundImage = null;

            PlaySound("Resources/move.wav");

            ClearSelection();
            SwitchPlayer();
        }
        private void TryEat(int targetRow, int targetCol)
        {
            ChessPiece attacker = board[selectedRow, selectedCol];
            ChessPiece target = board[targetRow, targetCol];

            if (attacker == null || target == null)
            {
                return;
            }

            if (!target.IsRevealed)
            {
                MessageBox.Show("不能吃尚未翻開的棋子！");
                return;
            }

            // 炮 / 包的特殊吃法
            if (IsCannon(attacker))
            {
                if (!CanCannonEat(selectedRow, selectedCol, targetRow, targetCol))
                {
                    MessageBox.Show("炮吃棋時必須同一行或同一列，且中間剛好隔一顆棋！");
                    return;
                }
            }
            // 一般棋的吃法
            else
            {
                if (!IsAdjacent(selectedRow, selectedCol, targetRow, targetCol))
                {
                    MessageBox.Show("一般棋只能吃上下左右相鄰的一格！");
                    return;
                }

                if (!CanEat(attacker, target))
                {
                    MessageBox.Show("這顆棋不能吃對方！");
                    return;
                }
            }

            // 吃棋成功
            board[targetRow, targetCol] = attacker;
            board[selectedRow, selectedCol] = null;

            boardButtons[targetRow, targetCol].BackgroundImage = Image.FromFile(attacker.ImagePath);
            boardButtons[targetRow, targetCol].BackgroundImageLayout = ImageLayout.Stretch;

            boardButtons[selectedRow, selectedCol].BackgroundImage = null;
            PlaySound("Resources/eat.wav");

            ClearSelection();
            UpdatePieceCount();

            if (CheckWinner())
            {
                return;
            }

            SwitchPlayer();
        }

        private void UpdatePieceCount()
        {
            int redCount = 0;
            int blackCount = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    ChessPiece piece = board[row, col];

                    if (piece == null)
                    {
                        continue;
                    }

                    if (piece.Color == "Red")
                    {
                        redCount++;
                    }
                    else if (piece.Color == "Black")
                    {
                        blackCount++;
                    }
                }
            }

            lblRedCount.Text = "紅方剩餘：" + redCount;
            lblBlackCount.Text = "黑方剩餘：" + blackCount;
        }
        private bool CheckWinner()
        {
            int redCount = 0;
            int blackCount = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    ChessPiece piece = board[row, col];

                    if (piece == null)
                    {
                        continue;
                    }

                    if (piece.Color == "Red")
                    {
                        redCount++;
                    }
                    else if (piece.Color == "Black")
                    {
                        blackCount++;
                    }
                }
            }

            if (redCount == 0)
            {
                PlaySound("Resources/BlackWin.wav");
                MessageBox.Show("黑方獲勝！");
                lblTurn.Text = "遊戲結束：黑方獲勝";
                tlpBoard.Enabled = false;
                return true;
            }

            if (blackCount == 0)
            {
                PlaySound("Resources/RedWin.wav");
                MessageBox.Show("紅方獲勝！");
                lblTurn.Text = "遊戲結束：紅方獲勝";
                tlpBoard.Enabled = false;
                return true;
            }

            return false;
        }
        private int CountPiecesBetween(int row1, int col1, int row2, int col2)
        {
            int count = 0;

            // 同一列
            if (row1 == row2)
            {
                int startCol = Math.Min(col1, col2) + 1;
                int endCol = Math.Max(col1, col2);

                for (int col = startCol; col < endCol; col++)
                {
                    if (board[row1, col] != null)
                    {
                        count++;
                    }
                }
            }
            // 同一行
            else if (col1 == col2)
            {
                int startRow = Math.Min(row1, row2) + 1;
                int endRow = Math.Max(row1, row2);

                for (int row = startRow; row < endRow; row++)
                {
                    if (board[row, col1] != null)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        private bool CanCannonEat(int fromRow, int fromCol, int targetRow, int targetCol)
        {
            ChessPiece attacker = board[fromRow, fromCol];
            ChessPiece target = board[targetRow, targetCol];

            if (attacker == null || target == null)
            {
                return false;
            }

            // 炮只能吃對方棋
            if (attacker.Color == target.Color)
            {
                return false;
            }

            // 目標必須已翻開
            if (!target.IsRevealed)
            {
                return false;
            }

            // 炮只能直線吃，不能斜吃
            if (fromRow != targetRow && fromCol != targetCol)
            {
                return false;
            }

            // 中間必須剛好隔一顆棋
            int middleCount = CountPiecesBetween(fromRow, fromCol, targetRow, targetCol);

            return middleCount == 1;
        }

        private void btnRule_Click(object sender, EventArgs e)
        {
            string rule =
        "暗棋雙人對戰 遊戲規則\n\n" +
        "1. 遊戲開始後，32 顆棋子會隨機排列在 4 × 8 棋盤上，所有棋子一開始皆為背面。\n\n" +
        "2. 玩家 1 先翻開第一顆棋子，若翻到紅棋，玩家 1 為紅方、玩家 2 為黑方；若翻到黑棋，玩家 1 為黑方、玩家 2 為紅方。\n\n" +
        "3. 雙方輪流行動，每回合可以選擇翻棋、移動棋子或吃棋。\n\n" +
        "4. 已翻開的棋子才可以被選取與移動，玩家只能操作自己顏色的棋子。\n\n" +
        "5. 一般棋子每次只能往上、下、左、右移動一格，不能斜走。\n\n" +
        "6. 一般吃棋規則為大的棋可以吃小的棋，相同等級可以互吃。\n" +
        "   棋子大小順序：帥/將 > 仕/士 > 相/象 > 俥/車 > 傌/馬 > 炮/包 > 兵/卒。\n\n" +
        "7. 特殊規則：兵/卒可以吃帥/將，但帥/將不能吃兵/卒。\n\n" +
        "8. 炮/包的移動方式和一般棋相同，只能移動到上下左右相鄰的一格空格。\n" +
        "   炮/包吃棋時，必須與目標棋在同一列或同一行，且中間剛好隔一顆棋。\n\n" +
        "9. 不能吃尚未翻開的棋子，也不能吃自己的棋子。\n\n" +
        "10. 當其中一方棋子全被吃掉時，另一方獲勝。";

            MessageBox.Show(rule, "遊戲規則", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblBlackCount_Click(object sender, EventArgs e)
        {

        }
    }
}
