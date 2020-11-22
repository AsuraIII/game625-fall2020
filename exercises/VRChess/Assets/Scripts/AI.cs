using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    private Piece selectedPiece;
    private Square selectedSquare;

    private float waitTime = 3.0f;
    private float timeCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BoardManager._instance.IsPlayerTurn == false)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter > waitTime)
            {
                if (HasValidMove())
                {
                    MakeRandomMove();
                    timeCounter = 0.0f;
                }
            }
        }
    }

    private bool HasValidMove()
    {
        SelectPiece();
        SelectSquare();
        if (selectedPiece && selectedSquare)
        {
            return true;
        }
        return false;
    }

    private void MakeRandomMove()
    {
        BoardManager._instance.MovePiece(selectedPiece, selectedSquare);

        BoardManager._instance.IsPlayerTurn = true;

        DeselectPiece();

        selectedSquare = null;
    }
    private void SelectSquare()
    {
        if (selectedPiece)
        {
            int possibleMovCount = BoardManager._instance.possibleMovList.Count;
            //Debug.Log(possibleMovCount);
            if (possibleMovCount > 0)
            {
                int randomIndex = Random.Range(0, possibleMovCount);

                Square s = BoardManager._instance.possibleMovList[randomIndex];

                //If possibleMoveList's square has piece assign s = the square
                foreach (Square square in BoardManager._instance.possibleMovList)
                {
                    if (square.Piece)
                    {
                        s = square;
                        break;
                    }
                }

                selectedSquare = s;
            }
        }
    }

    private void SelectPiece()
    {
        DeselectPiece();

        Piece piece = CanEatPiece();
        if (!piece)
        {
            ColorType AIColorType = BoardManager.AIColorType;
            int randomIndex = Random.Range(0, BoardManager._instance.allPieces[AIColorType].Count);

            piece = BoardManager._instance.allPieces[AIColorType][randomIndex];
            BoardManager._instance.GetPossibleMov(piece);
        }


        if (piece.colorType == BoardManager._instance.TypeCanMove())
        {
            selectedPiece = piece;

            //BoardManager._instance.HLPiece(selectedPiece);
            //BoardManager._instance.HLPossibleMov();
        }
    }

    private void DeselectPiece()
    {
        //if (selectedPiece)
        //{
        //    BoardManager._instance.UnHLPiece(selectedPiece);
        //    BoardManager._instance.UnHLBoardSquares();
        //}
        selectedPiece = null;
    }



    private void SelectCanEatSquare()
    {

    }

    private Piece CanEatPiece()
    {
        ColorType AIColorType = BoardManager.AIColorType;
        foreach (Piece piece in BoardManager._instance.allPieces[AIColorType])
        {
            BoardManager._instance.GetPossibleMov(piece);
            foreach (Square s in BoardManager._instance.possibleMovList)
            {
                if (s.Piece && s.Piece.colorType != AIColorType)
                {
                    return piece;
                }
            }
        }
        return null;
    }
}
