using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Chess
{
    internal class ChessPiece
    {
        public string Name { get; set; }       // 棋子名稱：帥、仕、兵...
        public string Color { get; set; }      // Red 或 Black
        public int Rank { get; set; }          // 棋子大小
        public string ImagePath { get; set; }  // 圖片路徑
        public bool IsRevealed { get; set; }   // 是否已翻開

        public ChessPiece(string name, string color, int rank, string imagePath)
        {
            Name = name;
            Color = color;
            Rank = rank;
            ImagePath = imagePath;
            IsRevealed = false;
        }
    }
}

