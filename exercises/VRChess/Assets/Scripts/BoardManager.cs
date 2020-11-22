using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager _instance;

    public GameObject White_Pawn;
    public GameObject White_Rook;
    public GameObject White_Horse;
    public GameObject White_Bishop;
    public GameObject White_Queen;
    public GameObject White_King;
    public GameObject Black_Pawn;
    public GameObject Black_Rook;
    public GameObject Black_Horse;
    public GameObject Black_Bishop;
    public GameObject Black_Queen;
    public GameObject Black_King;

    public Transform pieceParent;
    public Transform squareParent;

    public GameObject squareObj;
    public Square[,] boardSquare = new Square[8, 8];

    public List<PieceData> pieceData;

    public bool IsPlayerTurn = true;
    public static ColorType PlayerColorType = ColorType.White;
    public static ColorType AIColorType = ColorType.Black;

    public static bool randomPieceType = false;

    public List<Square> possibleMovList = new List<Square>();

    public List<Piece> whitePieces = new List<Piece>();
    public List<Piece> blackPieces = new List<Piece>();
    public Dictionary<ColorType, List<Piece>> allPieces = new Dictionary<ColorType, List<Piece>>();

    private void Awake()
    {
        _instance = this;

    }
    private void Start()
    {
        InitBoard();
        InitAddSquare();
        InitAddPiece();
        InitAllPieces();
        if (randomPieceType)
        {
            RandomizePieces();
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    RandomizePieces();
        //}
    }

    //Initial Board data
    private void InitBoard()
    {
        pieceData = new List<PieceData>() {

                new PieceData(0,0,Quaternion.Euler(0,0,0),White_Rook),
                new PieceData(0,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(1,0,Quaternion.Euler(0,0,0),White_Horse),
                new PieceData(1,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(2,0,Quaternion.Euler(0,0,0),White_Bishop),
                new PieceData(2,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(3,0,Quaternion.Euler(0,0,0),White_Queen),
                new PieceData(3,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(4,0,Quaternion.Euler(0,0,0),White_King),
                new PieceData(4,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(5,0,Quaternion.Euler(0,0,0),White_Bishop),
                new PieceData(5,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(6,0,Quaternion.Euler(0,0,0),White_Horse),
                new PieceData(6,1,Quaternion.Euler(0,0,0),White_Pawn),
                new PieceData(7,0,Quaternion.Euler(0,0,0),White_Rook),
                new PieceData(7,1,Quaternion.Euler(0,0,0),White_Pawn),

                new PieceData(0,7,Quaternion.Euler(0,180,0),Black_Rook),
                new PieceData(0,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(1,7,Quaternion.Euler(0,180,0),Black_Horse),
                new PieceData(1,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(2,7,Quaternion.Euler(0,180,0),Black_Bishop),
                new PieceData(2,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(3,7,Quaternion.Euler(0,180,0),Black_Queen),
                new PieceData(3,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(4,7,Quaternion.Euler(0,180,0),Black_King),
                new PieceData(4,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(5,7,Quaternion.Euler(0,180,0),Black_Bishop),
                new PieceData(5,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(6,7,Quaternion.Euler(0,180,0),Black_Horse),
                new PieceData(6,6,Quaternion.Euler(0,180,0),Black_Pawn),
                new PieceData(7,7,Quaternion.Euler(0,180,0),Black_Rook),
                new PieceData(7,6,Quaternion.Euler(0,180,0),Black_Pawn)
        };



    }



    //Initial and instantiate all squares
    private void InitAddSquare()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject square = Instantiate(squareObj, transform);

                square.transform.position = new Vector3(2 * i - 7, 1.8f, 2 * j - 7);
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0);

                Square s = square.GetComponent<Square>() as Square;
                s.InitSquareData(i, j, square.transform.position, null);
                boardSquare[i, j] = s;
            }
        }
    }

    //Initial and instantiate all pieces
    private void InitAddPiece()
    {
        if (pieceData.Count > 0)
        {
            foreach (PieceData p in pieceData)
            {
                GameObject pieceObj = Instantiate(p.PieceObj, boardSquare[p.Row, p.Col].Position, p.Rotation, pieceParent);
                Piece piece = pieceObj.GetComponent<Piece>() as Piece;
                piece.UpdatePieceData(p.Row, p.Col);
                if (piece.colorType == ColorType.White)
                {
                    whitePieces.Add(piece);
                }
                else if (piece.colorType == ColorType.Black)
                {
                    blackPieces.Add(piece);
                }
                AddPieceToBoard(piece);
            }
        }
    }

    private void InitAllPieces()
    {
        allPieces[ColorType.White] = whitePieces;
        allPieces[ColorType.Black] = blackPieces;
    }


    //Check the type that can move in this turn
    public ColorType TypeCanMove()
    {
        if (IsPlayerTurn)
        {
            return PlayerColorType == ColorType.White ? ColorType.White : ColorType.Black;
        }
        else
        {
            return PlayerColorType == ColorType.White ? ColorType.Black : ColorType.White;
        }
    }

    public ColorType TypeCannotMove()
    {
        if (IsPlayerTurn)
        {
            return PlayerColorType == ColorType.White ? ColorType.Black : ColorType.White;
        }
        else
        {
            return PlayerColorType == ColorType.White ? ColorType.White : ColorType.Black;
        }
    }

    public void AddPieceToBoard(Piece p)
    {
        boardSquare[p.Row, p.Col].Piece = p;
    }

    public void DeletePieceFromBoard(Piece p)
    {
        boardSquare[p.Row, p.Col].Piece = null;
    }

    public void UpdatePieceDataToBoard(Piece p, Square s)
    {
        DeletePieceFromBoard(p);
        p.UpdatePieceData(s.Row, s.Col);
        AddPieceToBoard(p);
        allPieces[TypeCanMove()].Find(x => x == p).UpdatePieceData(s.Row, s.Col);
    }

    public void MovePiece(Piece piece, Square square)
    {
        if (piece && square)
        {
            if (CanMoveTo(piece, square))
            {
                piece.GetComponent<NavMeshAgent>().SetDestination(square.Position);
                //piece.transform.position = square.Position;
                if (square.Piece)
                {
                    piece.GetComponent<PieceBehaviour>().enemy = square.Piece;
                    allPieces[TypeCannotMove()].Remove(piece);
                }
                SoundManager._instance.audio_Walk.Play();
                UpdatePieceDataToBoard(piece, square);
            }
        }
    }

    public void EliminatePiece(Piece piece)
    {
        Destroy(piece.gameObject, 2f);
    }

    //Hight light possible movement for one piece
    public void HLPossibleMov()
    {
        foreach (var s in possibleMovList)
        {
            HLSquare(s);
        }
    }

    public void GetPossibleMov(Piece p)
    {
        PossibleMovList(p);
    }

    //return one list that contain all possible move for a piece
    public List<Square> PossibleMovList(Piece p)
    {
        if (possibleMovList.Count > 0)
        {
        }
        possibleMovList.Clear();

        switch (p.pieceType)
        {
            case PieceType.Pawn:
                possibleMovList = PawnPossibleMov(p);
                break;
            case PieceType.Rook:
                possibleMovList = RookPossibleMov(p);
                break;
            case PieceType.Bishop:
                possibleMovList = BishopPossibleMov(p);
                break;
            case PieceType.Queen:
                possibleMovList = QueenPossibleMov(p);
                break;
            case PieceType.Horse:
                possibleMovList = HorsePossibleMov(p);
                break;
            case PieceType.King:
                possibleMovList = KingPossibleMov(p);
                break;
        }
        return possibleMovList;
    }

    //PawnMovement
    private List<Square> PawnPossibleMov(Piece p)
    {
        int intSwitch = 1;
        if (p.colorType == ColorType.White)
        {
            intSwitch = 1;
        }
        else if (p.colorType == ColorType.Black)
        {
            intSwitch = -1;
        }

        Piece enmyOrBlockPiece;
        if ((p.colorType == ColorType.White && p.Col == 1) || (p.colorType == ColorType.Black && p.Col == 6))
        {
            //Front 2
            for (int i = 1; i < 3; i++)
            {
                if (CheckIsInBoundary(p.Row, p.Col + i * intSwitch))
                {
                    if ((enmyOrBlockPiece = GetPieceFromBoard(p.Row, p.Col + i * intSwitch)) != null)
                    {
                        break;
                    }
                    Square s = boardSquare[p.Row, p.Col + i * intSwitch];
                    possibleMovList.Add(s);
                }
            }
        }
        else
        {
            if (CheckIsInBoundary(p.Row, p.Col + 1 * intSwitch))
            {
                //Front 1
                if ((enmyOrBlockPiece = GetPieceFromBoard(p.Row, p.Col + 1 * intSwitch)) == null)
                {
                    Square s = boardSquare[p.Row, p.Col + 1 * intSwitch];
                    possibleMovList.Add(s);
                }
            }
        }


        //UpRight
        if (CheckIsInBoundary(p.Row + 1 * intSwitch, p.Col + 1 * intSwitch) && (enmyOrBlockPiece = GetPieceFromBoard(p.Row + 1 * intSwitch, p.Col + 1 * intSwitch)) != null
            && enmyOrBlockPiece.colorType != p.colorType)
        {
            Square s = boardSquare[p.Row + 1 * intSwitch, p.Col + 1 * intSwitch];
            possibleMovList.Add(s);
        }

        //UpLeft
        if (CheckIsInBoundary(p.Row - 1 * intSwitch, p.Col + 1 * intSwitch) && (enmyOrBlockPiece = GetPieceFromBoard(p.Row - 1 * intSwitch, p.Col + 1 * intSwitch)) != null
            && enmyOrBlockPiece.colorType != p.colorType)
        {
            Square s = boardSquare[p.Row - 1 * intSwitch, p.Col + 1 * intSwitch];
            possibleMovList.Add(s);
        }

        return possibleMovList;
    }

    private List<Square> RookPossibleMov(Piece p)
    {
        return HVMoveCheck(p);
    }

    private List<Square> BishopPossibleMov(Piece p)
    {
        return DiagonalMoveCheck(p);
    }

    private List<Square> QueenPossibleMov(Piece p)
    {
        List<Square> possibleMovList;
        possibleMovList = HVMoveCheck(p);
        possibleMovList.AddRange(DiagonalMoveCheck(p));
        return possibleMovList;
    }

    private List<Square> HorsePossibleMov(Piece p)
    {
        List<Square> possibleMovList = new List<Square>();
        AddOnePossibleMovToList(possibleMovList, p, -1, +2);
        AddOnePossibleMovToList(possibleMovList, p, +1, +2);
        AddOnePossibleMovToList(possibleMovList, p, -2, +1);
        AddOnePossibleMovToList(possibleMovList, p, +2, +1);
        AddOnePossibleMovToList(possibleMovList, p, -1, -2);
        AddOnePossibleMovToList(possibleMovList, p, +1, -2);
        AddOnePossibleMovToList(possibleMovList, p, -2, -1);
        AddOnePossibleMovToList(possibleMovList, p, +2, -1);
        return possibleMovList;
    }

    private List<Square> KingPossibleMov(Piece p)
    {
        List<Square> possibleMovList = new List<Square>();
        AddOnePossibleMovToList(possibleMovList, p, -1, +1);
        AddOnePossibleMovToList(possibleMovList, p, 0, +1);
        AddOnePossibleMovToList(possibleMovList, p, 1, +1);
        AddOnePossibleMovToList(possibleMovList, p, 1, 0);
        AddOnePossibleMovToList(possibleMovList, p, 1, -1);
        AddOnePossibleMovToList(possibleMovList, p, 0, -1);
        AddOnePossibleMovToList(possibleMovList, p, -1, -1);
        AddOnePossibleMovToList(possibleMovList, p, -1, 0);
        return possibleMovList;
    }


    //Check Horizontal and Vertical possible move, return list of all possible move
    private List<Square> HVMoveCheck(Piece p)
    {
        List<Square> possibleMovList = new List<Square>();

        //Up
        AddHVDMoveToList(possibleMovList, p, 0, 1);

        //Down
        AddHVDMoveToList(possibleMovList, p, 0, -1);

        //Left
        AddHVDMoveToList(possibleMovList, p, -1, 0);

        //Right
        AddHVDMoveToList(possibleMovList, p, 1, 0);
        //possibleMovList.AddRange(possibleMovList);

        return possibleMovList;
    }

    //Check Diagonal possible move, return list of all possible move
    private List<Square> DiagonalMoveCheck(Piece p)
    {
        List<Square> possibleMovList = new List<Square>();

        //UpLeft diagonal
        AddHVDMoveToList(possibleMovList, p, -1, 1);
        //UpRight diagonal
        AddHVDMoveToList(possibleMovList, p, 1, 1);
        //DownLeft diagonal
        AddHVDMoveToList(possibleMovList, p, -1, -1);
        //DownRight diagonal
        AddHVDMoveToList(possibleMovList, p, 1, -1);


        return possibleMovList;
    }

    //Add one Piece to list
    private void AddOnePossibleMovToList(List<Square> list, Piece p, int rowMov, int colMov)
    {
        Piece enmyOrBlockPiece;
        if (CheckIsInBoundary(p.Row + rowMov, p.Col + colMov))
        {
            enmyOrBlockPiece = GetPieceFromBoard(p.Row + rowMov, p.Col + colMov);
            if (enmyOrBlockPiece == null || enmyOrBlockPiece.colorType != p.colorType)
            {
                Square s = boardSquare[p.Row + rowMov, p.Col + colMov];
                list.Add(s);
            }
            else
            {
                return;
            }
        }
    }

    //Basic function for check horizontal, vertical, diagonal, and add to list
    private void AddHVDMoveToList(List<Square> list, Piece p, int onOffRow, int onOffCol)
    {
        Piece enmyOrBlockPiece;
        for (int i = 1; i < 8; ++i)
        {
            if (CheckIsInBoundary(p.Row + i * onOffRow, p.Col + i * onOffCol))
            {
                enmyOrBlockPiece = GetPieceFromBoard(p.Row + i * onOffRow, p.Col + i * onOffCol);

                if (enmyOrBlockPiece == null || enmyOrBlockPiece.colorType != p.colorType)
                {
                    Square s = boardSquare[p.Row + i * onOffRow, p.Col + i * onOffCol];
                    list.Add(s);
                }
                if (enmyOrBlockPiece)
                {
                    break;
                }
            }
        }
    }


    //Get Piece from 2D array boardSquare
    private Piece GetPieceFromBoard(int row, int col)
    {
        Piece p = boardSquare[row, col].Piece;
        return p;
    }

    //Check if the row and col are in the range of the board
    private bool CheckIsInBoundary(int row, int col)
    {
        if (0 <= row && row < boardSquare.GetLength(0) && 0 <= col && col < boardSquare.GetLength(1))
        {
            return true;
        }
        return false;
    }

    //Highlight one square
    private void HLSquare(Square s)
    {
        s.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 0.3f);
    }


    //Highlight Piece
    public void HLPiece(Piece p)
    {
        Renderer[] renderers = p.gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", new Color(0, 0.3f, 0));
        }
    }

    //UnHighlight Piece
    public void UnHLPiece(Piece p)
    {
        Renderer[] renderers = p.gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.EnableKeyword("_EMISSION");
            r.material.SetColor("_EmissionColor", Color.black);
        }
    }

    //Unhightlight one square
    private void UnHlSquare(int row, int col)
    {
        boardSquare[row, col].transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0);
    }

    //Unhightlight all square in the board
    public void UnHLBoardSquares()
    {
        for (int i = 0; i < boardSquare.GetLength(0); ++i)
        {
            for (int j = 0; j < boardSquare.GetLength(1); ++j)
            {
                UnHlSquare(i, j);
            }
        }

    }

    //Check if the input row and col is contain in the all possible movement in the list.
    public bool CanMoveTo(Piece p, Square s)
    {
        if (possibleMovList.Count > 0 && possibleMovList.Contains(s))
        {
            return true;
        }
        return false;
    }

    private void RandomizePieces()
    {
        List<PieceType> whitePieceTypes = new List<PieceType>();
        List<PieceType> blackPieceTypes = new List<PieceType>();

        foreach (Square s in boardSquare)
        {
            if (s.Piece && s.Piece.gameObject.layer == LayerMask.NameToLayer("WhitePiece"))
            {
                whitePieceTypes.Add(s.Piece.pieceType);
            }
            else if (s.Piece && s.Piece.gameObject.layer == LayerMask.NameToLayer("BlackPiece"))
            {
                blackPieceTypes.Add(s.Piece.pieceType);
            }
        }

        foreach (Square s in boardSquare)
        {
            if (s.Piece && s.Piece.gameObject.layer == LayerMask.NameToLayer("WhitePiece"))
            {
                int randomIndex = Random.Range(0, whitePieceTypes.Count);
                s.Piece.pieceType = whitePieceTypes[randomIndex];
                whitePieceTypes.RemoveAt(randomIndex);
            }
            else if (s.Piece && s.Piece.gameObject.layer == LayerMask.NameToLayer("BlackPiece"))
            {
                int randomIndex = Random.Range(0, blackPieceTypes.Count);
                s.Piece.pieceType = blackPieceTypes[randomIndex];
                blackPieceTypes.RemoveAt(randomIndex);
            }
        }
    }
}






