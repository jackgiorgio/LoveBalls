using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public LevelPreset levelPreset;
    public bool isLevelPassed = false;
    public bool isLose = false;
    public bool gameStarted = false;
    public StarDisapper star1, star2, star3;
    public Percentage bar;
    public PercentageText percentageText;


    private bool captureScreenShot= false;
    private MaleBall maleBall;
    private FemaleBall femaleBall;
    private GameObject winPanel;
    private GameObject goldPanel;
    private ResultDisplay resultDisplay;
    private GoldDisplay goldDisplay;
    private LineCreator lineCreator;
    private int star;
    public int Star
    {
        get
        {
            return star;
        }
        set
        {
            star = value;
        }
    }
    private int previousStar;
    private RenderTextToPNG renderTextToPNG;
    public void GetPreviousStar()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 4;
        previousStar = PlayerPrefsManager.GetLevelStar(currentLevel);
        Debug.Log("previous star of level " + currentLevel.ToString() + " is " + previousStar.ToString() + "stars");
    }

    public float previousDistance = 0;
    private float totalDistance;
    public float TotalDistance
    {
        get
        {
            return totalDistance;
        }
        set
        {
            totalDistance = value;
            CountPercentageAndDisplayUI();
        }
    }
    
    // Use this for initialization
	void Start () {
        GetPreviousStar();
        renderTextToPNG = FindObjectOfType<RenderTextToPNG>();
        if (!renderTextToPNG)
        {
            Debug.LogError("cannot find rendertexttopng!");
        }
        FindWinPanel();
        FindGoldPanel();
        maleBall = GameObject.FindObjectOfType<MaleBall>();
        maleBall.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        femaleBall = GameObject.FindObjectOfType<FemaleBall>();
        femaleBall.transform.GetComponent<Rigidbody2D>().isKinematic = true;       
        winPanel.SetActive(false);
        goldPanel.SetActive(false);
        CountPercentageAndDisplayUI();
        lineCreator = GameObject.FindObjectOfType<LineCreator>();

    }

	
	// Update is called once per frame
	void Update () {
        HandleWinCondition();
        HandleLoseCondition();
	}

    void HandleWinCondition()
    {
        if (isLevelPassed)
        {
            Debug.Log("LevelPassed!");
            maleBall.ChangeFace(MaleBall.Face.smile);
            femaleBall.ChangeFace(FemaleBall.Face.smile);
            CompareStarAndDisplayUI();
            lineCreator.Disable();
        }
    }

    void HandleLoseCondition()
    {
        if (isLose)
        {
            Debug.Log("You Lose!");
            maleBall.ChangeFace(MaleBall.Face.cry);
            femaleBall.ChangeFace(FemaleBall.Face.cry);
            winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
            resultDisplay.DisplayLosePanel();
            isLose = false;
            lineCreator.Disable();
        }
    }

    void FindWinPanel()
    {
        winPanel = GameObject.Find("WinPanel");
        resultDisplay = GameObject.FindObjectOfType<ResultDisplay>();
        if (!winPanel)
        {
            Debug.LogError("Please create you win object");
        }
    }

    public void SetFreeBalls()
    {
        maleBall.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        femaleBall.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        gameStarted = true;
    }

    void UnblockedLevelIfNeeded() //update the unblocked levels of all scenes
    {
        PlayerPrefsManager.SetTotalStars();
        PlayerPrefsManager.UpdateUnblockedLevels();
    }

    void SetLevelStar()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 4;
        if (CountPercentage() > levelPreset.threeStarsThreshold)
        {
            PlayerPrefsManager.SetUnblockStar(currentLevel, 3);
            return;
        }
        if (CountPercentage() > levelPreset.twoStarThreshold)
        {
            PlayerPrefsManager.SetUnblockStar(currentLevel, 2);
            return;
        }
        else
        {
            PlayerPrefsManager.SetUnblockStar(currentLevel, 1);
        }
        
    }


    void CompareStarAndDisplayUI()
    {
        isLevelPassed = false;
        int currentStar = StarOfThisLevel();
        if (currentStar <= previousStar)
        {
            //show winPanel directly;
            DisplayWinPanel();
        }
        if (currentStar > previousStar)
        {
            if (currentStar ==3 && previousStar ==0)
            {
                int money = PlayerPrefsManager.GetMoney() + 75;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(75);
            }

            if (currentStar == 3 && previousStar == 1)
            {
                int money = PlayerPrefsManager.GetMoney() + 55;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(55);
            }
            if (currentStar == 3 && previousStar == 2)
            {
                int money = PlayerPrefsManager.GetMoney() + 30;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(30);
            }
            if (currentStar == 2 && previousStar == 0)
            {
                int money = PlayerPrefsManager.GetMoney() + 45;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(45);
            }
            if (currentStar == 2 && previousStar == 1)
            {
                int money = PlayerPrefsManager.GetMoney() + 25;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(25);
            }
            if (currentStar == 1 && previousStar == 0)
            {
                int money = PlayerPrefsManager.GetMoney() + 20;
                PlayerPrefsManager.SetMoney(money);
                goldPanel.SetActive(true);
                goldDisplay.Display(20);
            }
        }

    }


    private float CountPercentage() 
    {
        float restLength = levelPreset.levelLength - totalDistance;  //计算剩余的长度
        if (restLength <= 0)
        {
            return 0f;
        }
        return (levelPreset.levelLength - totalDistance) / levelPreset.levelLength;  //返回剩余的长度占总长度之比
    }

    void CountPercentageAndDisplayUI()
    {
        float percentage = CountPercentage();
        percentageText.ShowPercentage(percentage);
        bar.FillWithPersentage(percentage);
        if (percentage < levelPreset.threeStarsThreshold)
        {
            star3.Disapplear();
        }
        if (percentage < levelPreset.twoStarThreshold)
        {
            star2.Disapplear();
        }
    }

    private int StarOfThisLevel()
    {
        if (CountPercentage() > levelPreset.threeStarsThreshold)
        {
            return 3;
        }
        if (CountPercentage() > levelPreset.twoStarThreshold)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    void FindGoldPanel()
    {
        goldPanel = GameObject.Find("GoldPanel");
        goldDisplay = GameObject.FindObjectOfType<GoldDisplay>();
        if (!goldDisplay)
        {
            Debug.LogError("Please create you gold Panel object");
        }
    }

    public void DisplayWinPanel()
    {
        isLevelPassed = false;
        winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
        resultDisplay.DisplayWinPanel(levelPreset,CountPercentage());
        SetLevelStar();
        UnblockedLevelIfNeeded();
        goldPanel.SetActive(false);
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 4;
        renderTextToPNG.SaveToPNG(currentLevel);
    }

    public void CaptureDefaultScreenShot()
    {
        if (!captureScreenShot)
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 4;
           renderTextToPNG.SaveToDefaultPNG(currentLevel);
           captureScreenShot = true; 
        }
    }




}
