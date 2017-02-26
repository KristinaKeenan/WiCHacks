#pragma strict


    var y = 0;
    var x = 0;

    var player: GameObject;

    var boxCol : BoxCollider;


    function Start () {

        player = GameObject.Find("Player1");

        var self = this;

    }



    function Update () {

        if (Input.GetKeyDown(KeyCode.W)) {
            player.transform.position.y+=1;
            player.transform.Translate(x,y,0);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            player.transform.position.x-=1;
            player.transform.Translate(x,y,0);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            player.transform.position.y-=1;
            player.transform.Translate(x,y,0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.transform.position.x+=1;
            player.transform.Translate(x,y,0);
        }
        
    };
