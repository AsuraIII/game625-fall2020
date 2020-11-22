using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWhite()
    {
        BoardManager.PlayerColorType = ColorType.White;
        BoardManager.AIColorType = ColorType.Black;
        LoadMainGame();
    }

    public void PlayBlack()
    {
        BoardManager.PlayerColorType = ColorType.Black;
        BoardManager.AIColorType = ColorType.White;
        LoadMainGame();
    }

    public void AcessRandomPiece()
    {
        BoardManager.randomPieceType = true;
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("Main");
    }
}
