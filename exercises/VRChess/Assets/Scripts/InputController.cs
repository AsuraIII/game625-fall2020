using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.XR;
public class InputController : MonoBehaviour
{

    //private Transform selectedPiece;
    private Piece selectedPiece;

    public GameObject rightHandControllerPrefab;

    private string rayCastLayer = "";

    // Start is called before the first frame update
    void Start()
    {
        rayCastLayer = BoardManager.PlayerColorType == ColorType.White ? "BlackPiece" : "WhitePiece";
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        //{
        //    Debug.Log("1");
        //}
        //if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch)>0.0f)
        //{
        //    Debug.Log("1");
        //}
        //if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("1");
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(rightHandControllerPrefab.transform.position, rightHandControllerPrefab.transform.forward);
            RaycastHit hit;
            if (BoardManager._instance.IsPlayerTurn == true && Physics.Raycast(ray, out hit, 100, ~(1 << LayerMask.NameToLayer(rayCastLayer))))
            {
                //Debug.Log(hit.transform.position);
                if (hit.transform.tag == "Square")
                {
                    if (selectedPiece)
                    {
                        Square s = hit.transform.GetComponent<Square>() as Square;
                        SelectSquare(s);
                    }
                }

                if (hit.transform.tag == "Piece")
                {
                    // SelectPiece(hit.transform);
                    Piece piece = hit.transform.GetComponent<Piece>() as Piece;
                    SelectPiece(piece);
                }
            }
        }
    }

    public void SelectSquareOrPiece(GameObject obj)
    {
        if (BoardManager._instance.IsPlayerTurn == true)
        {
            //Debug.Log(hit.transform.position);
            if (obj.tag == "Square")
            {
                if (selectedPiece)
                {
                    Square s = obj.transform.GetComponent<Square>() as Square;
                    SelectSquare(s);
                }
            }

            if (obj.transform.tag == "Piece")
            {
                // SelectPiece(hit.transform);
                Piece piece = obj.transform.GetComponent<Piece>() as Piece;
                SelectPiece(piece);
            }
        }
    }


    private void SelectSquare(Square s)
    {
        if (BoardManager._instance.CanMoveTo(selectedPiece, s))
        {
            BoardManager._instance.MovePiece(selectedPiece, s);
            BoardManager._instance.IsPlayerTurn = false;
        }
        DeselectPiece();
    }

    private void SelectPiece(Piece piece)
    {
        DeselectPiece();

        if (piece.colorType == BoardManager._instance.TypeCanMove())
        {
            selectedPiece = piece;
            BoardManager._instance.HLPiece(selectedPiece);
            BoardManager._instance.GetPossibleMov(piece);
            BoardManager._instance.HLPossibleMov();
        }

    }
    private void DeselectPiece()
    {
        if (selectedPiece != null)
        {
            BoardManager._instance.UnHLPiece(selectedPiece);
            BoardManager._instance.UnHLBoardSquares();
        }
        selectedPiece = null;
    }
}