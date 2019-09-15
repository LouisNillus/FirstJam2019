using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject biteButton;
    public List<ParticleSystem> cumList = new List<ParticleSystem>();
    public List<ParticleSystem> bloodList = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 10 meters in front of the camera:

        foreach(ParticleSystem ps in cumList)
        {
            ps.transform.position = ray.GetPoint(0);
        }
        foreach(ParticleSystem ps in bloodList)
        {
            ps.transform.position = ray.GetPoint(0);
        }

        if(Input.GetMouseButtonDown(0))
        {
            cumList[Random.Range(0, cumList.Count)].Emit(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            bloodList[Random.Range(0, bloodList.Count)].Emit(1);
        }
    }


    public void SceneLoader(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Exit()
    {
        StartCoroutine(PetiteBite());
    }

    public IEnumerator PetiteBite()
    {
        biteButton.SetActive(true);
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
