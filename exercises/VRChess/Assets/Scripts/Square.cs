using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private int row;
    private int col;
    private Vector3 position;
    private Piece piece;

    public int Row { get => row; set => row = value; }
    public int Col { get => col; set => col = value; }
    public Vector3 Position { get => position; set => position = value; }
    public Piece Piece { get => piece; set => piece = value; }

    public void InitSquareData(int row, int col, Vector3 position, Piece piece)
    {
        this.row = row;
        this.col = col;
        this.position = position;
        this.piece = piece;
    }

    public void AddPiece(Piece piece)
    {
        piece.Row = this.row;
        piece.Col = this.col;
        this.piece = piece;
    }

    public void RemovePiece()
    {
        this.piece = null;
    }
}