using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;

    public int life;
    int score;

    Text textLife;
    Text textScore;

    GameObject panelSelesai;

    AudioSource audio;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        score = 0;

        textLife = GameObject.Find("TextLife").GetComponent<Text>();
        textScore = GameObject.Find("TextScore").GetComponent<Text>();

        TampilkanScore();

        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TepiKanan")
        {
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
            life -= 1;
            TampilkanScore();
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
            life -= 1;
            TampilkanScore();
        }
        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            score += 1;
            TampilkanScore();
        }
        if (life <= 0)
        {
            panelSelesai.SetActive(true);

            Text txPemenang;
            txPemenang = GameObject.Find("TextScoreFin").GetComponent<Text>();
            txPemenang.text = "Score: " + score;
            Destroy(gameObject);
            return;
        }

        audio.PlayOneShot(hitSound);

    }
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + life + " Score P2: " + score);
        textLife.text = "Life: " + life;
        textScore.text = "Score: " + score;
    }
}
