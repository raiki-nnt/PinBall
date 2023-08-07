using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるZ軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    public int point = 0;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextp部ジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //gameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
        
    }
        private void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.tag == "SmallStarTag")
    {
        point += 10;
    }
    else if (other.gameObject.tag == "LargeStarTag")
    {
        point += 15;
    }
    else if (other.gameObject.tag == "SmallCloudTag")
    {
        point += 30;
    }
    else if (other.gameObject.tag == "LargeCloudTag")
    {
        point += 50;
    }
    this.scoreText = GameObject.Find("scoreText");
    this.scoreText.GetComponent<Text> ().text = point.ToString();

    }
}
