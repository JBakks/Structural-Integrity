using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TMP_Text spallText;
    public TMP_Text crackText;
    public TMP_Text pittingText;
    public TMP_Text concreteJointText;
    public GameObject player;

    //private Damage[] damages;
    // Start is called before the first frame update
    void Start()
    {
        /*
        gameOverCanvas.transform.LookAt(player.transform);
        gameOverCanvas.transform.Rotate(Vector3.up, -180);
        gameOverCanvas.transform.position = player.transform.position - player.transform.forward * 5f;
        */
        /*
        damages = Resources.LoadAll<Damage>("Damage");
        foreach (Damage damage in damages)
        {
            Score.instance.SetScore(damage, PlayerPrefs.GetInt(damage.name));
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

        spallText.text = PlayerPrefs.GetInt("Spall") + "/" + PlayerPrefs.GetInt("CSpalls");
        crackText.text = PlayerPrefs.GetInt("Crack") + "/" + PlayerPrefs.GetInt("CCracks");
        pittingText.text = PlayerPrefs.GetInt("Pitting") + "/" + PlayerPrefs.GetInt("CPittings");
        concreteJointText.text = PlayerPrefs.GetInt("Concrete Joint") + "/" + PlayerPrefs.GetInt("CConcrete Joints");
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
