using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceData
{
    private int row;
    private int col;
    private Quaternion rotation;
    private GameObject pieceObj;

    public int Row { get => row; set => row = value; }
    public int Col { get => col; set => col = value; }
    public Quaternion Rotation { get => rotation; set => rotation = value; }
    public GameObject PieceObj { get => pieceObj; set => pieceObj = value; }

    public PieceData(int row, int col, Quaternion rotation, GameObject pieceObj)
    {
        this.row = row;
        this.col = col;
        this.rotation = rotation;
        this.pieceObj = pieceObj;
    }

}