#region usings

using ChessLib.Pieces;

#endregion

namespace ChessLib.Actions
{
    ///<summary>
    ///
    ///</summary>
    public class SimpleMoveAction : MoveAction
    {
        private readonly PiecePosition _arrivalPosition;
        private readonly Game _game;
        private readonly PiecePosition _startingPosition;
        private bool _verifyMovement;

        ///<summary>
        ///Constructeur 
        ///</summary>
        ///<param name="game"></param>
        ///<param name="piecePosition"></param>
        ///<param name="newPosition"></param>
        ///<param name="verifyMovement"></param>
        public SimpleMoveAction(Game game, PiecePosition piecePosition, PiecePosition newPosition, bool verifyMovement)
        {
            this._game = game;
            this._startingPosition = piecePosition;
            this._arrivalPosition = newPosition;
            this.VerifyMovement = verifyMovement;
        }

        ///<summary>
        ///Position d'arrivée du mouvement
        ///</summary>
        public override PiecePosition ArrivalPosition
        {
            get { return this._arrivalPosition; }
        }

        ///<summary>
        ///Position de départ du mouvement
        ///</summary>
        public override PiecePosition StartingPosition
        {
            get { return this._startingPosition; }
        }

        ///<summary>
        ///
        ///</summary>
        public bool VerifyMovement
        {
            get { return this._verifyMovement; }
            set { this._verifyMovement = value; }
        }

        ///<summary>
        ///Effectue l'action de mouvement.
        ///</summary>
        ///<returns></returns>
        public override bool Do()
        {
            BasePiece basePiece = this._game.Board.GetPiece(this.StartingPosition);

            if (basePiece == null)
            {
                return false;
            }

            if (basePiece.Move(this.ArrivalPosition, this.VerifyMovement) == false)
            {
                return false;
            }

            basePiece.MovementCount++;

            return true;
        }

        ///<summary>
        ///Annule l'action de mouvement.
        ///</summary>
        ///<returns></returns>
        public override bool UnDo()
        {
            BasePiece basePiece = this._game.Board.GetPiece(this.ArrivalPosition);

            if (basePiece == null)
            {
                return false;
            }

            if (basePiece.Move(this.StartingPosition, false) == false)
            {
                return false;
            }

            basePiece.MovementCount--;

            return true;
        }
    }
}