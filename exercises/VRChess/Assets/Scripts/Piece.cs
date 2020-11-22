using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private int row;
    [SerializeField]
    private int col;
    private Quaternion rotation;


    public PieceType pieceType = PieceType.Empty;
    public ColorType colorType = ColorType.Black;

    public int Row { get => row; set => row = value; }
    public int Col { get => col; set => col = value; }
    public Quaternion Rotation { get => rotation; set => rotation = value; }

    //private bool isMove = false;
    //private Vector3 destPos;
    //private NavMeshAgent agent;

    private void Start()
    {
        //destPos = transform.position;
        //agent = GetComponent<NavMeshAgent>();
    }

    public void UpdatePieceData(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    ////Move piece to position
    //public void MoveTo(Vector3 position)
    //{
    //    this.destPos = position;
    //    isMove = true;
    //}

    //private void Update()
    //{
    //    if (isMove)
    //    {
    //        Debug.Log(transform.position + ":" + destPos);
    //        GetComponent<NavMeshAgent>().SetDestination(destPos);
    //        if (agent.velocity == Vector3.zero)
    //        {
    //            isMove = false;
    //        }
    //    }
    //}
}
public enum PieceType
{
    Empty,
    Pawn,
    Rook,
    Horse,
    Bishop,
    Queen,
    King
}

public enum ColorType
{
    Black,
    White
}