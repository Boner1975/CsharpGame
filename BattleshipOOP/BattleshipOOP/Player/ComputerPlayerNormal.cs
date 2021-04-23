using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class ComputerPlayerNormal : ComputerPlayer
    {
        public ComputerPlayerNormal(string name = "Computer")
        {
            Name = name;
            IsHuman = false;
            list = new List<Ship>();
        }

        public override Square ChooseSquare(Board board)
        {
            Square square = HandleHits(board);
            if (square != null)
                return square;
            Random rand = new Random();
            int x, y;
            do {
                x = rand.Next(0, board.size);
                y = rand.Next(0, board.size);

            } while (!IsEmptySquare(board, x, y) || IsShipNeighbour(board, x, y));

            return GetSquare(board, x, y);

        }
        protected Square HandleHits(Board board)
        {
            for(int i = 0 ; i < board.size;i++)
                for(int j = 0 ; j < board.size;j++)                   
                {
                    if (GetSquareStatus(board,i,j) == SquareStatus.Hit)
                    {
                        if(GetSquareStatus(board, i + 1, j) == SquareStatus.Hit)
                        {
                            //idziemy po i
                            if(IsEmptySquare(board, i - 1, j))
                            {
                                return GetSquare(board, i - 1, j);
                            }
                            
                            return GetNextEmptyToRight(board, i + 1, j);
                        }
                        else if(GetSquareStatus(board, i, j + 1) == SquareStatus.Hit)
                        {
                            //TODO idziemy po j
                            if(IsEmptySquare(board, i, j - 1))
                            {
                                return GetSquare(board, i, j - 1);
                            }

                            return GetNextEmptyToBottom(board, i, j + 1);
                        }
                        else
                        {
                            List<Square> list = new List<Square>();
                            Square temp = GetSquare(board, i - 1, j);
                            if(temp!=null)
                            {
                                list.Add(temp);
                            }
                            temp = GetSquare(board, i, j - 1);
                            if (temp != null)
                            {
                                list.Add(temp);
                            }
                            temp = GetSquare(board, i + 1, j);
                            if (temp != null)
                            {
                                list.Add(temp);
                            }
                            temp = GetSquare(board, i, j + 1);
                            if (temp != null)
                            {
                                list.Add(temp);
                            }
                            Random rand = new Random();
                            int index = rand.Next(0, list.Count);

                            return list[index];
                        }
                    }                    
                }

            return null;
        }

        protected Square GetNextEmptyToRight(Board board, int i, int j)
        {
            if (IsEmptySquare(board, i, j))
                return GetSquare(board, i, j);

            return GetNextEmptyToRight(board, i + 1, j);
        }

        protected Square GetNextEmptyToBottom(Board board, int i, int j)
        {
            if (IsEmptySquare(board, i, j))
                return GetSquare(board, i, j);

            return GetNextEmptyToBottom(board, i, j + 1);
        }

        protected Square GetSquare(Board board, int i, int j)
        {
            if (i >= board.size || i < 0 || j >= board.size || j < 0)
            {
                return null;
            }
            return board.ocean[i, j];
        }

        protected SquareStatus? GetSquareStatus(Board board, int i, int j)
        {
            if(i>=board.size || i<0 || j>=board.size || j < 0)
            {
                return null;
            }
            return board.ocean[i, j].SquareStatus;
        }

        protected bool IsEmptySquare(Board board, int i, int j)
        {
            var status = GetSquareStatus(board, i, j);
            return status == SquareStatus.Empty || status == SquareStatus.Ship;
        }

        protected bool IsShipSquare(Board board, int i, int j)
        {
            var status = GetSquareStatus(board, i, j);
            return status == SquareStatus.Sunk || status == SquareStatus.Hit;
        }

        protected bool IsShipNeighbour(Board board, int i, int j)
        {
            if (IsShipSquare(board, i - 1, j))
                return true;
            if (IsShipSquare(board, i + 1, j))
                return true;
            if (IsShipSquare(board, i, j - 1))
                return true;
            if (IsShipSquare(board, i, j + 1))
                return true;

            return false;
        }
    }
}
