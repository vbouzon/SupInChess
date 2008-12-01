using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ChessLib;
using ChessLib.Pieces;

namespace ChessGUI
{
    /// <summary>
    /// Logique d'interaction pour MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private readonly Game _game;
        private PiecePosition _srcPosition;

        ///<summary>
        ///
        ///</summary>
        public MainForm()
        {
            this.InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this._game = new Game();

                    BasePiece piece = this._game.Board.GetPiece(new PiecePosition(j, 7 - i));

                    var button = new Button {Background = Brushes.Transparent, FontSize = 36, Name = string.Concat((char) (j + 'a'), (char) (7 - i + '1'))};

                    if (piece != null)
                    {
                        button.Content = piece.ToString();
                    }

                    button.Click += this.button_Click;

                    (this.uniformGrid1.Children[i * 8 + j] as Border).Child = button;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (this._srcPosition == null)
            {
                this._srcPosition = new PiecePosition((sender as Button).Name);

                if (this._game.Board.GetPiece(this._srcPosition) == null)
                {
                    this._srcPosition = null;
                }

                return;
            }
            else
            {
                this._game.Play(this._srcPosition, new PiecePosition((sender as Button).Name));

                this._srcPosition = null;

                this.RefreshGame();

                if (this._game.GetPlayer(this._game.CurrentPlayer.Color).IsChess)
                {
                    if (this._game.GetPlayer(this._game.CurrentPlayer.Color).IsMat)
                    {
                        MessageBox.Show("Chess & Mat !");
                    }

                    MessageBox.Show("Chess !");
                }
            }
        }

        private void RefreshGame()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    BasePiece piece = this._game.Board.GetPiece(new PiecePosition(j, 7 - i));

                    var button = (this.uniformGrid1.Children[i * 8 + j] as Border).Child as Button;

                    if (piece != null)
                    {
                        button.Content = piece.ToString();
                    }
                    else
                    {
                        button.Content = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this._game.Undo();

            RefreshGame();
        }
    }
}