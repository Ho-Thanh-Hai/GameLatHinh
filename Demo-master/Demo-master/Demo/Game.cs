using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Game
    {
        // Màn chơi hiện tại
        public int Level { get; private set; }

        // Số cặp hình của màn hiện tại
        public int TotalPairs { get; private set; }

        // Thời gian giới hạn của màn chơi (giây)
        public int TimeLimit { get; private set; }

        // Điểm người chơi
        public int Score { get; private set; }

        // Số cặp đã tìm đúng 
        public int MatchedPairs { get; private set; }

        // Số combo hiện tại 
        public int Combo { get; private set; }

        // Các hình trên bàn chơi
        public List<int> Cards { get; private set; }

        // Khởi tạo game theo màn
        public Game(int level, int score = 0)
        {
            Level = level;

            switch (Level)
            {
                case 1:
                    TotalPairs = 2;
                    break;

                case 2:
                    TotalPairs = 4;
                    break;

                case 3:
                    TotalPairs = 6;
                    break;

                case 4:
                    TotalPairs = 8;
                    break;

                case 5:
                    TotalPairs = 8;
                    break;

                case 6:
                    TotalPairs = 4;
                    break;

                case 7:
                    TotalPairs = 6;
                    break;

                case 8:
                    TotalPairs = 8;
                    break;

                case 9:
                    TotalPairs = 10;
                    break;

                case 10:
                    TotalPairs = 10;
                    break;
            }

            // Xác định thời gian theo từng màn
            switch (Level)
            {
                case 1:
                    TimeLimit = 180; // 3:00
                    break;

                case 2:
                    TimeLimit = 180; // 3:00
                    break;

                case 3:
                    TimeLimit = 150; // 2:30
                    break;

                case 4:
                    TimeLimit = 150; // 2:30
                    break;

                case 5:
                    TimeLimit = 120; // 2:00
                    break;

                case 6:
                    TimeLimit = 110; // 1:50
                    break;

                case 7:
                    TimeLimit = 100; // 1:40
                    break;

                case 8:
                    TimeLimit = 90;  // 1:30
                    break;

                case 9:
                    TimeLimit = 80;  // 1:20
                    break;

                case 10:
                    TimeLimit = 70;  // 1:10
                    break;
            }

            //Giữ điểm 
            Score = score;
            MatchedPairs = 0;

            Cards = new List<int>();

            // Tạo các cặp hình
            for (int i = 1; i <= TotalPairs; i++)
            {
                Cards.Add(i);
                Cards.Add(i);
            }

            // Từ Level 2 trở đi thì xáo trộn 
            if (Level >= 2)
            {
                Random random = new Random();
                // Xóa trộn các hình
                for (int i = Cards.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);

                    int temp = Cards[i];
                    Cards[i] = Cards[j];
                    Cards[j] = temp;
                }
            }
        }
        // Kiểm tra 2 ô có phải là một cặp 
        public bool CheckMatch(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Cards.Count)
                return false;

            if (secondIndex < 0 || secondIndex >= Cards.Count)
                return false;

            if (firstIndex == secondIndex)
                return false;

            if (Cards[firstIndex] == Cards[secondIndex])
            {
                MatchedPairs++;

                if (Level <= 5)
                {
                    // Level 1-5: mỗi cặp đúng +1 điểm
                    Score++;
                }
                else
                {
                    // Level 6-10: đúng liên tiếp thì tăng Combo
                    Combo++;
                    Score += Combo;
                }

                return true;
            }
            else
            {
                if (Level >= 6)
                {
                    // Level 6-10: sai bị -1 điểm và reset Combo
                    Score--;
                    Combo = 0;
                }

                return false;
            }
        }
        // Kiểm tra người chơi đã hoàn thành màn 
        public bool IsLevelComplete()
        {
            return MatchedPairs == TotalPairs;
        }
    }
}
