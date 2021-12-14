using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ProblemConfig[] problemConfigs;
    private Vector3 playerSpawn = Vector3.zero;
    private int prevButtonIndex = 0;

    private ScoreController scoreController;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    public void Problem1()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(0));
    }

    public void Problem2()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(1));
    }

    public void Problem3()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(2));
    }

    public void Problem4()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(3));
    }

    public void Problem5()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(4));
    }

    public void Problem6()
    {
        destroyOtherInstance();
        StartCoroutine(startProblem(5));
    }

    public void Problem7()
    {
        scoreController.resetScore();
        destroyOtherInstance();
        StartCoroutine(startProblem(6));
    }

    public void Problem8()
    {
        scoreController.resetScore();
        destroyOtherInstance();
        StartCoroutine(startProblem(7));
    }

    public void Problem9()
    {
        scoreController.resetScore();
        destroyOtherInstance();
        StartCoroutine(startProblem(8));
    }

    private IEnumerator startProblem(int index)
    {
        // reset score setiap transisi problem
        scoreController.resetScore();
        // set button yang ditekan sebelumnya agar bisa ditekan lagi
        problemConfigs[prevButtonIndex].button.interactable = true;
        // set button yang ditekan sekarang agar tidak bisa ditekan (menghindari spam)
        problemConfigs[index].button.interactable = false;

        yield return new WaitForSeconds(1f);
        
        // Instansiasi player dan spawner
        Instantiate(problemConfigs[index].player, playerSpawn, Quaternion.identity);
        
        // Beberapa problemConfig tidak menggunakan spawner, handler untuk menghindari null reference
        if (problemConfigs[index].spawner != null)
        {
            GameObject crystalSpawner = Instantiate(problemConfigs[index].spawner);
        }
        // set button ini menjadi prevButtonIndex agar bisa ditekan kembali ketika button lain ditekan
        prevButtonIndex = index;
    }

    private void destroyOtherInstance()
    {
        // Destroy Instance player dan spawner setiap transisi problem
        GameObject playerInstance = GameObject.FindGameObjectWithTag("Player");
        if (playerInstance != null) Destroy(playerInstance);
        GameObject crystalSpawnerInstance = GameObject.FindGameObjectWithTag("Spawner");
        if (crystalSpawnerInstance != null) Destroy(crystalSpawnerInstance);
    }
}
