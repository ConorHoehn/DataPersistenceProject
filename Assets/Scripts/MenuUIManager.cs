
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{

    [SerializeField] private TMPro.TextMeshProUGUI highScoreMesh;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreName;
    

    // Start is called before the first frame update
    void Start()
    {
        SetHighScoreText(MainManager.Instance.highScore);
    }

    private void SetHighScoreText(MainManager.HighScoreData highScore)
    {
        if (highScore != null)
        {
            highScoreMesh.text = highScore.points.ToString();
            highScoreName.text = $"Set by {highScore.playerName}!!!";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
