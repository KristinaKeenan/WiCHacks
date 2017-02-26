using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Battle: MonoBehaviour {

	int cHP;
	//int special = 3;

	int mHP;

	bool battleStart;

	bool cTurn = true;
	bool mTurn = false;


	GameObject cHealth;
	GameObject mHealth;

	Text cText;
	Text mText;

	Text dialogueText;
	Text pressP;
	Text NumPress;

	Text Feminisa;
	Text Patriarchy;



	string[,] dialogueString = new string[,]{{ "It's so cute that you think you can be a hero like the guys can.", "It's not cute, I'm fighting for what I believe in! I'm just as capable as men are!" }, { "Yeah, sure. Just sit there and look pretty while we go and take over the town.", "It's patronising to tell a woman to look pretty- we are so much more than our appearances!",},{ "Keep telling yourself that. I don't know why you're even here, we don't need feminism.", "What?! Of course we do! Not all women are in situations where they're treated equally as men.",},{ "What do you mean? The women I see are fine with how things are.", "Every women faces the world differently based on her own personal experiences.",} };

	int dialogueNum;
	int dialogueRound;
	int dialogueChar;


	Canvas Win;
	Canvas Lose;

	bool playerWin;
	bool playerLost;

	// Use this for initialization
	void Start() {

	

		cHealth = GameObject.Find("cHealth");
		mHealth = GameObject.Find("mHealth");

		cText = GameObject.Find("cText").GetComponent<Text>();
		mText = GameObject.Find("mText").GetComponent<Text>();

		NumPress = GameObject.Find ("NumPress").GetComponent<Text> ();
		dialogueText = GameObject.Find ("dialogue").GetComponent<Text> ();
		dialogueText.text = dialogueString[dialogueRound,dialogueChar];

		NumPress.enabled = true;

		pressP = GameObject.Find ("PressP").GetComponent<Text> ();

		pressP.enabled = false;


		Feminisa = GameObject.Find ("Feminisa").GetComponent<Text> ();
		Patriarchy = GameObject.Find ("Patriarchy").GetComponent<Text> ();

		Feminisa.enabled = false;
		Patriarchy.enabled = true;


		battleStart = true;


		cHP = 200;
		mHP = 200;


		Win = GameObject.Find ("Win").GetComponent<Canvas> ();
		Lose = GameObject.Find ("Lose").GetComponent<Canvas> ();

		Win.enabled = false;
		Lose.enabled = false;

		playerWin = false;
		playerLost = false;


	}
		
	//player attack
	void playerAttack(GameObject mHealth) {
		float attackNum = Random.Range(0.0f, 1.0f);

		if (attackNum >= 0.5f) {
			print("cAttack True");
			mHP -= 10;
			if (mHP < 0) {
				mHP = 0;
			}
			mHealth.transform.localScale += new Vector3(-0.05f, 0, 0);



		} 



	}

	//special attack
	void specialAttack(GameObject mHealth) {
		float attackNum = Random.Range(0.0f, 1.0f);

		if (attackNum >= 0.3f) {
			print("sAttack True");
			mHP -= 15;
		//	special--;
			if (mHP < 0) {
				mHP = 0;
			}
			mHealth.transform.localScale += new Vector3(-0.075f, 0, 0);

		} 
	}



	//monster attack
	void monsterAttack(GameObject cHealth) {

		float attackNum = Random.Range(0.0f, 1.0f);

		if (attackNum >= 0.5f) {
			print("mAttack True");
			cHP -= 10;

			if (cHP < 0) {
				cHP = 0;
			}
			cHealth.transform.localScale += new Vector3(-0.05f, 0, 0);


		}


	}
		


	// Update is called once per frame
	void Update() {

		if (battleStart) {



			cText.text = cHP + "/200 HP";
			mText.text = mHP + "/200 HP";


			if (dialogueChar > 1) {

				dialogueChar = 0;
				dialogueRound++;

			}
			if (dialogueRound > 3) {

				dialogueRound = 0;

			}

			if (dialogueChar == 0) {
				Patriarchy.enabled = true;
				Feminisa.enabled = false;
				NumPress.enabled = true;

				
			} else {
				Patriarchy.enabled = false;
				Feminisa.enabled = true;
				NumPress.enabled = false;

			}

			dialogueText.text = dialogueString [dialogueRound, dialogueChar];



			if (mHP > 0 && cHP > 0) {



				if (cTurn && !mTurn) {


					if (Input.GetKeyUp ("1")) {
						print ("attack");
						playerAttack (mHealth);
						cTurn = false;
						mTurn = true;
						print ("mHP: " + mHP + ", cHP: " + cHP);
						dialogueChar++;
						pressP.enabled = true;


					}
					if (Input.GetKeyUp ("2")) {
						print ("special");
						//if (special > 0) {
						specialAttack (mHealth);
						//} else {
						//	print("no more special left");
						//}
						cTurn = false;
						mTurn = true;
						print ("mHP: " + mHP + ", cHP: " + cHP);
						dialogueChar++;
						pressP.enabled = true;


					}
				} 
				if (mTurn && !cTurn && Input.GetKeyUp ("p")) {
					monsterAttack (cHealth);
					cTurn = true;
					mTurn = false;
					print ("mHP: " + mHP + ", cHP: " + cHP);
					dialogueChar++;
					pressP.enabled = false;


				} 
			} else {

				if (mHP > cHP) {

					playerLost = true;
					Lose.enabled = true;

				
				}
				if (cHP > mHP) {
				
					playerWin = true;
					Win.enabled = true;
				
				} 


				battleStart = false;
			}
		} else {
		
			if (Input.GetKeyDown ("p")) {
			
				Application.LoadLevel(Application.loadedLevel);


			
			}
				

		}



	}
}