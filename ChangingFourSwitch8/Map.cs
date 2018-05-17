using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGamesSolver
{
    class Map : SearchableState
    {
        public string[] Layout = new string[8];
        public string Type { get; set; }
        public Map() { }
        public Map(string[] InitialLayout)
        {
            Layout = InitialLayout;
        }
        public override List<SearchableState> GetAllNeighbors()
        {
            List<SearchableState> possibleMoves = new List<SearchableState>();

            for (int i = 0; i < Layout.Length; i++)
            {
                if (Layout[i] == "A")
                {
                    if (i + 1 < Layout.Length && Layout[i + 1] == " ")
                    {
                        Map newMove = Clone();
                        newMove.Layout[i] = " ";
                        newMove.Layout[i + 1] = "A";
                        newMove.Type = "M";
                        possibleMoves.Add(newMove);
                    }
                    if (i + 2 < Layout.Length && Layout[i + 1] == "B" && Layout[i + 2] == " ")
                    {
                        Map newMove = Clone();
                        newMove.Layout[i] = " ";
                        newMove.Layout[i + 2] = "A";
                        newMove.Type = "J";
                        possibleMoves.Add(newMove);
                    }
                }
            }
            for (int i = Layout.Length - 1; i >= 0; i--)
            {
                if (Layout[i] == "B")
                {
                    if (i - 1 >= 0 && Layout[i - 1] == " ")
                    {
                        Map newMove = Clone();
                        newMove.Layout[i] = " ";
                        newMove.Layout[i - 1] = "B";
                        newMove.Type = "M";
                        possibleMoves.Add(newMove);
                    }
                    if (i - 2 >= 0 && Layout[i - 1] == "A" && Layout[i - 2] == " ")
                    {
                        Map newMove = Clone();
                        newMove.Layout[i] = " ";
                        newMove.Layout[i - 2] = "B";
                        newMove.Type = "J";
                        possibleMoves.Add(newMove);
                    }
                }
            }
            return possibleMoves;
        }
        private Map Clone()
        {
            Map newMap = new Map();
            newMap.Layout = new string[Layout.Length];
            for (int i = 0; i < Layout.Length; i++)
            {
                newMap.Layout[i] = Layout[i];
            }
            newMap.Origin = this;
            return newMap;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in Layout)
            {
                sb.Append(i + ',');
            }
            return sb.ToString().TrimEnd(',');
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }       
        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }
    }
}
