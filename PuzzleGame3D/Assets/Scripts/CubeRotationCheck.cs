using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeRotationCheck : MonoBehaviour
{
    public List<Vector3> targetRotations = new List<Vector3>(); // hedef vektörlerin listesi
    public List<GameObject> cubes = new List<GameObject>(); // vektörleri kontroledilecek küplerin listesi
    public List<bool> allcubesinrotation= new List<bool>(); // bool listesi küpler doğru yerindeyse diye
    private int cn;

    void Start()
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cubes.Add(cube);        //sahnedeki küleri bulur ve listeye ekler
        }
    }

    void Update()
    {
        
        if (CubeTextureSplitter.instance.CubeNumber==2)  // eğer küp sayısı 4 ise 4 küpünde yerinde olup olmadığını kontrol eder
        {
            cn=4;
        }
        else if (CubeTextureSplitter.instance.CubeNumber==3)    // eğer küp sayısı 9 ise 9 küpünde yerinde olup olmadığını kontrol eder
        {
            cn=9;
        }
        else if (CubeTextureSplitter.instance.CubeNumber==4)    // eğer küp sayısı 12 ise 12 küpünde yerinde olup olmadığını kontrol eder
        {
            cn=16;
        }
      for (int i = 0; i <cn; i++)
           {
            for (int x = 0; x < targetRotations.Count; x++)
                {
                    if (cubes[i].transform.eulerAngles == targetRotations[x]    )
                    {
                       allcubesinrotation[i]=true;   //eğer küpler doğru pozisyonda ise allcubes listesindeki elemanları true yapar
                    }
                }    
           }      
            for (int i = 0; i < allcubesinrotation.Count; i++)
            {
                if (allcubesinrotation[0]==true&&allcubesinrotation[1]==true&&allcubesinrotation[2]==true&&allcubesinrotation[3]==true) //eğer bütün küpler doğru pozisyonda ise bir sonraki levela geçer
                {
                   if (SceneManager.GetActiveScene().buildIndex==3)
                   {
                    SceneManager.LoadScene(0);
                   } 
                   else
                   {
                    SceneManager.LoadScene(0);
                   }
                
            
                }
            }
        }   
}
