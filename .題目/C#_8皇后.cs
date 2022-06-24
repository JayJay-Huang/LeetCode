
請編寫一個函數，返回8皇后難題的所有不同答案。
每個答案均包含一個獨特的8皇后在棋盤上的配置，其中 'Q' 及 '.' 分別代表一個皇后和一個空白。

---
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindQueens
{
    public class Program
    {
        // 皇后數目(可依條件輸入)
        const int Queens = 8;

        static void Main(string[] args)
        {
            // 建立物件
            var cBoard = new Chessboard(Queens);
            // 取得結果
            cBoard.Get(cBoard,Queens); 
            // 檢視
            Console.ReadLine();
        }
    }

    public class Chessboard
    {
        #region Initialization

        // 棋盤大小
        public int size;
        // 結果次數
        public int solution = 1;
        // 底層棋盤
        public List<int> basePos { get; set; }
        // 皇后分佈
        public List<int> queensPos { get; set; } = new List<int>();

        public Chessboard(int size)
        {
            // 初始棋盤
            this.size = size;
            this.basePos = new List<int>(Enumerable.Range(1, size)
                .SelectMany(x => Enumerable.Range(1, size)
                .Select(y => x * 10 + y)));
        }

        #endregion

        /// <summary>
        /// 輸出結果
        /// </summary>
        /// <param name="board">棋盤</param>
        /// <param name="qNum">皇后數目</param>
        public void Get(Chessboard board, int qNum)
        {
            // 建立一個 newBoard 作篩選輸出用
            var newBoard = new Chessboard(qNum);
            // 放置順序由左上到右下
            var minPos = board.queensPos.Any() ? board.queensPos.Max() : 0;
            foreach (var pos in board.basePos.Where(o => o > minPos))
            {
                newBoard.Remove(board, pos);
                if (newBoard.queensPos.Count == size)
                {
                    Console.WriteLine($"Solution{solution++}");
                    for (var y = 1; y <= size; y++)
                    {
                        for (var x = 1; x <= size; x++)
                        {
                            if (board.queensPos.Contains(x * 10 + y)) { Console.Write("Q"); continue; }
                            Console.Write(".");
                        }
                        Console.WriteLine(); 
                    }
                }
                else
                {
                    Get(newBoard, qNum);
                }
            }
        }

        /// <summary>
        /// 篩選動作
        /// </summary>
        /// <param name="board">棋盤</param>
        /// <param name="qPos">皇后位置</param>
        public void Remove(Chessboard board, int qPos)
        {
            this.basePos = new List<int>(board.basePos.Except(new int[] { qPos }));
            this.queensPos = new List<int>(board.queensPos.Concat(new int[] { qPos }));

            // 移除不合條件位置
            Action<int, int> removePos = (x, y) =>
            {
                if (basePos.Contains(x * 10 + y)) basePos.Remove(x * 10 + y);
            };
            for (var x = 1; x <= size; x++)
            {
                removePos(qPos/10 - qPos%10 + x, x); // 斜角左上右下
                removePos(qPos/10 + qPos%10 - x, x); // 斜角右上左下
                for (var y = 1; y <= size; y++)
                {
                    removePos(x, qPos%10); // 水平
                    removePos(qPos/10, y); // 垂直
                }
            }
        }
    }
}
