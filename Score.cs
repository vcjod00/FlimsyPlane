using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform plane;
    public Text scoreText;

    // Updates score the longer you survive
    void Update()
    {
        scoreText.text = plane.position.x.ToString("0");
    }
}
