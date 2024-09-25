using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessLogic;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected;
        public string WhitePlayerName { get; set; }
        public string BlackPlayerName { get; set; }
        public GameOverMenu(GameState gameState,string whitePlayerName, string blackPlayerName)
        {
            this.WhitePlayerName = whitePlayerName;
            this.BlackPlayerName = blackPlayerName;
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner, WhitePlayerName, BlackPlayerName);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
            

        }

        //Mess with this later to implement other names
        private static string GetWinnerText(Player winner, string WhitePlayerName, string BlackPlayerName)
        {
            if (WhitePlayerName == null || BlackPlayerName == null)
            {
                return winner switch
                {
                    Player.White => "White Wins!",
                    Player.Black => "Black Wins!",
                    _ => "It's a Draw"
                };
            }
            else
            {
                return winner switch
                {
                    Player.White => WhitePlayerName+ " Wins!",
                    Player.Black => BlackPlayerName+ " Wins!",
                    _ => "It's a Draw"
                };
            }

        }
       
        private static string PlayerString (Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"Stalemate - {PlayerString(currentPlayer)} Can't Move",
                EndReason.Checkmate => $"Checkmate - {PlayerString(currentPlayer)} Can't Move",
                EndReason.FiftyMoveRule => $"Fifty Move Rule Has Been Reached - It's A Draw",
                EndReason.InsufficientMaterial => $"Not Enough Material To Win - It's A Draw",
                EndReason.ThreeFoldRepetition => $"Three Fold Repetition - It's A Draw",
                _ => ""
            };
        }


        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
