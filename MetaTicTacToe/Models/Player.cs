namespace MetaTicTacToe.Models
{
    public class Player
    {
        public string Name { get; set; }
        public bool Symbol { get; set; }  // true for one player, false for the other

        public Player(string name, bool symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        public override string ToString()
        {
            return Symbol ? "X" : "O";
        }
    }
}
