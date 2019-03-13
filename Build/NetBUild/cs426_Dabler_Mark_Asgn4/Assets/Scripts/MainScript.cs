using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject acamera;
    public GameObject ccamera;
    public GameObject tvcamera;

    public GameObject start;
    public GameObject bottom;
    public GameObject middle;
    public GameObject top;

    public GameObject player;
    public GameObject cat;

    public GameObject aintro;
    public GameObject pintro1;
    public GameObject pintro2;

    public int choice = 0;
    private int points = 0;

    public GameObject q1;
    public GameObject q1a1;
    public GameObject q1a2;
    public GameObject q1a3;
    public GameObject q1a4;

    public int answer1 = 1;

    public GameObject aint1;
    public GameObject pint1;
    public GameObject pint2;

    public GameObject a1;
    public GameObject tvint1;

    public GameObject q2;
    public GameObject q2a1;
    public GameObject q2a2;
    public GameObject q2a3;
    public GameObject q2a4;

    public int answer2 = 2;

    public GameObject pint22;

    public GameObject a2;

    public GameObject tvint2;

    public GameObject q3;
    public GameObject q3a1;
    public GameObject q3a2;
    public GameObject q3a3;
    public GameObject q3a4;

    public int answer3 = 3;

    public GameObject pint32;

    public GameObject a3;

    public GameObject afinale;

    public GameObject fish;

    public ScoreTracker scoreTracker;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = acamera.transform.position;
        Camera.main.transform.rotation = acamera.transform.rotation;
        StartCoroutine(intro());
    }


    IEnumerator intro()
    {
        yield return new WaitForSeconds(1);
        aintro.SetActive(true);
        yield return new WaitForSeconds(5);
        aintro.SetActive(false);
        Camera.main.transform.position = ccamera.transform.position;
        Camera.main.transform.rotation = ccamera.transform.rotation;
        Instantiate(player, start.transform.position, start.transform.rotation);
        pintro1.SetActive(true);
        yield return new WaitForSeconds(3);
        pintro1.SetActive(false);
        yield return new WaitForSeconds(3);
        pintro2.SetActive(true);
        yield return new WaitForSeconds(3);
        pintro2.SetActive(false);
        Camera.main.transform.position = tvcamera.transform.position;
        Camera.main.transform.rotation = tvcamera.transform.rotation;
        q1.SetActive(true);
        q1a1.SetActive(true);
        q1a2.SetActive(true);
        q1a3.SetActive(true);
        q1a4.SetActive(true);
        yield return new WaitForSeconds(10);
        q1.SetActive(false);
        q1a1.SetActive(false);
        q1a2.SetActive(false);
        q1a3.SetActive(false);
        q1a4.SetActive(false);
        Camera.main.transform.position = acamera.transform.position;
        Camera.main.transform.rotation = acamera.transform.rotation;
        aint1.SetActive(true);
        yield return new WaitForSeconds(3);
        aint1.SetActive(false);
        Camera.main.transform.position = ccamera.transform.position;
        Camera.main.transform.rotation = ccamera.transform.rotation;
        pint1.SetActive(true);
        yield return new WaitForSeconds(3);
        if (choice == answer1)
        {
            player.transform.position = bottom.transform.position;
            points++;
            scoreTracker.AddPoint(1);

        }
        choice = 0;
        pint1.SetActive(false);
        yield return new WaitForSeconds(3);
        pint2.SetActive(true);
        yield return new WaitForSeconds(3);
        pint2.SetActive(false);
        Camera.main.transform.position = tvcamera.transform.position;
        Camera.main.transform.rotation = tvcamera.transform.rotation;
        a1.SetActive(true);
        yield return new WaitForSeconds(3);
        a1.SetActive(false);
        tvint1.SetActive(true);
        yield return new WaitForSeconds(3);
        tvint1.SetActive(false);
        q2.SetActive(true);
        q2a1.SetActive(true);
        q2a2.SetActive(true);
        q2a3.SetActive(true);
        q2a4.SetActive(true);
        yield return new WaitForSeconds(10);
        q2a1.SetActive(false);
        q2a2.SetActive(false);
        q2a3.SetActive(false);
        q2a4.SetActive(false);
        q2.SetActive(false);
        Camera.main.transform.position = acamera.transform.position;
        Camera.main.transform.rotation = acamera.transform.rotation;
        aint1.SetActive(true);
        yield return new WaitForSeconds(3);
        aint1.SetActive(false);
        Camera.main.transform.position = ccamera.transform.position;
        Camera.main.transform.rotation = ccamera.transform.rotation;
        pint1.SetActive(true);
        yield return new WaitForSeconds(3);
        pint1.SetActive(false);
        if (choice == answer2)
        {
            if (points == 0)
                player.transform.position = bottom.transform.position;
            else if (points == 1)
                player.transform.position = middle.transform.position;
            points++;
            scoreTracker.AddPoint(1);
        }
        choice = 0;
        yield return new WaitForSeconds(3);
        pint22.SetActive(true);
        yield return new WaitForSeconds(3);
        pint22.SetActive(false);
        Camera.main.transform.position = tvcamera.transform.position;
        Camera.main.transform.rotation = tvcamera.transform.rotation;
        a2.SetActive(true);
        yield return new WaitForSeconds(3);
        a2.SetActive(false);
        tvint2.SetActive(true);
        yield return new WaitForSeconds(3);
        tvint2.SetActive(false);
        q3.SetActive(true);
        q3a1.SetActive(true);
        q3a2.SetActive(true);
        q3a3.SetActive(true);
        q3a4.SetActive(true);
        yield return new WaitForSeconds(10);
        q3a1.SetActive(false);
        q3a2.SetActive(false);
        q3a3.SetActive(false);
        q3a4.SetActive(false);
        q3.SetActive(false);
        Camera.main.transform.position = acamera.transform.position;
        Camera.main.transform.rotation = acamera.transform.rotation;
        aint1.SetActive(true);
        yield return new WaitForSeconds(3);
        aint1.SetActive(false);
        Camera.main.transform.position = ccamera.transform.position;
        Camera.main.transform.rotation = ccamera.transform.rotation;
        pint1.SetActive(true);
        yield return new WaitForSeconds(3);
        pint1.SetActive(false);
        if (choice == answer3)
        {
            if (points == 0)
                player.transform.position = bottom.transform.position;
            else if (points == 1)
                player.transform.position = middle.transform.position;
            else if (points == 2)
            {
                Destroy(fish);
                player.transform.position = top.transform.position;
            }
            points++;
            scoreTracker.AddPoint(1);
        }
        choice = 0;
        yield return new WaitForSeconds(3);
        pint32.SetActive(true);
        yield return new WaitForSeconds(3);
        pint32.SetActive(false);
        a3.SetActive(true);
        Camera.main.transform.position = tvcamera.transform.position;
        Camera.main.transform.rotation = tvcamera.transform.rotation;
        yield return new WaitForSeconds(3);
        a3.SetActive(false);
        Camera.main.transform.position = acamera.transform.position;
        Camera.main.transform.rotation = acamera.transform.rotation;
        afinale.SetActive(true);
        yield return new WaitForSeconds(3);
        afinale.SetActive(false);
        Camera.main.transform.position = ccamera.transform.position;
        Camera.main.transform.rotation = ccamera.transform.rotation;
    }

    public void setChoice(int ch)
    {
        choice = ch;
    }

}
