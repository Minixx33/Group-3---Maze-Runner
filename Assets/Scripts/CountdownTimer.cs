using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    // 2 minutes = 120 seconds
    // 5 minutes = 300 seconds
    public float startTime = 300f;
    public int countdownSpeed = 2;
    float currentTime = 300f;
    public TextMeshProUGUI timeText;
    private bool mazeEntered = false;
    private bool gameEnded = false;
	// Start is called before the first frame update
	void Start() {
        currentTime = startTime;
    }

    private void OnTriggerEnter(Collider other){
		if(!other.CompareTag("MainCamera"))
			mazeEntered = true;
	}

        private void Update() {
            if (mazeEntered){
                if(currentTime <= 0) {
                    if(!gameEnded)
				        EndGame();
            }
                else{
				    currentTime -= Time.deltaTime * countdownSpeed;
				    timeText.text = (currentTime / 60f).ToString("0.00");
			    }
            }
        }

        void EndGame(){
                 Debug.Log("Game Over!!");
                
                gameEnded = true;
        }
    }
