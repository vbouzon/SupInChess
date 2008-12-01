namespace ChessLib.Actions
{
    ///<summary>
    ///
    ///</summary>
    public abstract class MoveAction : Action
    {
        ///<summary>
        ///
        ///</summary>
        public abstract PiecePosition StartingPosition { get; }

        ///<summary>
        ///
        ///</summary>
        public abstract PiecePosition ArrivalPosition { get; }
    }
}