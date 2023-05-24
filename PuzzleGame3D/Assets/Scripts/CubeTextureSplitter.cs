using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTextureSplitter : MonoBehaviour
{
    [SerializeField]
    private Texture image;
    private Texture2D newImage;
    public int CubeNumber;
    [SerializeField]
    private List<Texture2D> textureList = new List<Texture2D>(); //resimlerin atanacağı texture listesi
    public List<MeshRenderer> Cubelist = new List<MeshRenderer>(); // küplerin üzerine atamak için mesh listesi
    private bool isSliceDone=false;
    public static CubeTextureSplitter instance;



    private void Update()
    {
        image = Kakera.PickerController.pc.Pic;  //Kakera namespaceinden picker controller classından oluşturduğumuz nesne  
                                                //kullandığımız kod ile seçtiğimiz resmi image nesnesine atıyoruz


        if (Kakera.PickerController.pc.Pic&&isSliceDone==false)
        {
            SliceImage();   //eğer seçtiysek resmi parçalara ayırıyoruz
        }
    }



    private void SliceImage()       //resim parçalama kodumuz
    {
        

        newImage = new Texture2D(image.width, image.height);    //aldığımız fotoğrafı dönüştürme işlemimiz
        newImage.SetPixels((image as Texture2D).GetPixels());
        newImage.Apply();

        int width = image.width / CubeNumber;
        int height = image.height / CubeNumber;
        

        for (int y = 0; y < CubeNumber; y++)
        {
            for (int x = 0; x < CubeNumber; x++)
            {
                Texture2D tile = new Texture2D(width, height);
                tile.SetPixels(newImage.GetPixels(x * width, y * height, width, height));
                tile.Apply();
                textureList.Add(tile);  //fotoğrafın parçalarını tek tek listeye sırayla ekliyoruz
                
            }
        }

       
        
        for (int i = 0; i < Cubelist.Count; i++)
        {
            // Küpün materyali üzerindeki texture'i güncelleme kodumuz
            Cubelist[i].material.mainTexture = textureList[i % textureList.Count];
        }
        isSliceDone=true;
    }

     private void Start() {
            instance = this;
        }

}
