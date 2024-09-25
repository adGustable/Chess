namespace ChessLogic
{
    public enum Player
    {
        None,
        White,
        Black,
        BlackPlayerName,
        WhitePlayerName
    }

    public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                Player.WhitePlayerName => Player.WhitePlayerName,
                Player.BlackPlayerName => Player.BlackPlayerName,
                _ => Player.None,
            };
        }
    }
}
