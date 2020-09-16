using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public List<Cube> cubelist = new List<Cube>();

    public int score = 0;

    public int goalScore = 17;

    public float TimeLimit = 12.0f;

    private float timer = 12.0f;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Cube.OnCubeCollectedRepository += AddCube;
    }
    public void Timer() {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UIManager._instance.SetTime(timer);
        }
        else
        {
            UIManager._instance.ShowLoseMsg();
            Time.timeScale = 0f;
        }
    }

    public void CheckWinStat()
    {
        if(score>= goalScore)
        {
            UIManager._instance.ShowWinMsg();
            Time.timeScale = 0f;
        }
    }

    public void AddPoint(int num) {
        score += num;
        CheckWinStat();
        UIManager._instance.SetScoreNum(score);
    }

    public void AddCube(Cube cube)
    {
        cubelist.Add(cube);
        //string cubeContent = "<color=" + cube.cubeColor + ">" + cube.cubeName + "</color>";
        UIManager._instance.SetRepositoryContent(CubeListContent());
    }

    public string CubeListContent()
    {
        string cubeListContent = "";
        foreach (Cube cube in cubelist)
        {
            cubeListContent += "\n"+ "<color=" + cube.cubeColor + ">" + cube.cubeName + "</color>";
        }
        return cubeListContent;
    }

    public void DelLastEle()
    {
        if (cubelist.Count > 0)
        {
            cubelist.RemoveAt(cubelist.Count - 1);
            UIManager._instance.SetRepositoryContent(CubeListContent());
        }
    }


    private void Update()
    {
        //Timer
        Timer();
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            DelLastEle();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log(Score);
            Debug.Log(cubelist.Count);
            foreach (Cube cube in cubelist)
            {
                Debug.Log(cube.cubeName);

            }

        }
    }

}
