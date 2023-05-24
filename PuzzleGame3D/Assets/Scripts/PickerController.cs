using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        [SerializeField]
        private Unimgpicker imagePicker;

        [SerializeField]
        private MeshRenderer imageRenderer;

        public GameObject MenuPanel;

        private int[] sizes = {1024, 256, 16};

        public Texture Pic;
        public static PickerController pc;

        void Awake()
        {
            pc=this;
            imagePicker.Completed += (string path) =>
            {
                StartCoroutine(LoadImage(path, imageRenderer));
            };
        }

        public void OnPressShowPicker()
        {
            imagePicker.Show("Select Image", "unimgpicker");
        }

        private IEnumerator LoadImage(string path, MeshRenderer output)
        {
            var url = "file://" + path;
            var unityWebRequestTexture = UnityWebRequestTexture.GetTexture(url);
            yield return unityWebRequestTexture.SendWebRequest();

            var texture = ((DownloadHandlerTexture)unityWebRequestTexture.downloadHandler).texture;
            if (texture == null)
            {
                Debug.LogError("Failed to load texture url:" + url);
            }

            //output.material.mainTexture = texture;
            Pic=texture;
            CloseMenu();
            
          
        }

        public  void CloseMenu()
        {
            MenuPanel.SetActive(false);

        }

        public void QuitGame()
        {

            Application.Quit();
        }

       


    }
}