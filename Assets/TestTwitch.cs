using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwitchChatConnect.Client
{


    public class TestTwitch : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
        public void SendMessage()
        {
            bool red = TwitchChatClient.instance.SendChatMessage("prova");
            if (!red)
            {
                Debug.Log("porcodioo");
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("ciao");
                SendMessage();
            }
        }
    }
}
