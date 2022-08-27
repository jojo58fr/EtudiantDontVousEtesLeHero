using Godot;
using System;

public class TestButton: Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Button talkButton;	
    private Button interactButton;	
    private Button useButton;	
    private Button inventoryButton;	
    private Button mapButton;

    private Sprite mcTalk;
    private Sprite otherTalk;

    private TextEdit textbox;

    private TextureButton people1;
    private TextureButton people2;
    private TextureButton banane1;
    private TextureButton garbage1;

    private bool getBanane = false;
    private bool bananeInTrash = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //GD.Print();
        
        //buttonTest      = GetTree().GetRoot().GetNode<Button>("Control/Button");	
        //buttonTest.Connect("button_down", this, nameof(_on_AnimationPlayer_animation_finished) );
        mcTalk = GetTree().GetRoot().GetNode<Sprite>("Control/MCTalk");
        otherTalk = GetTree().GetRoot().GetNode<Sprite>("Control/OtherTalk");
        textbox = GetTree().GetRoot().GetNode<TextEdit>("Control/TextEdit");
    
        people1 = GetTree().GetRoot().GetNode<TextureButton>("Control/Background/People1");
        people2 = GetTree().GetRoot().GetNode<TextureButton>("Control/Background/People2");
        banane1 = GetTree().GetRoot().GetNode<TextureButton>("Control/Background/Banana1");
        garbage1 = GetTree().GetRoot().GetNode<TextureButton>("Control/Background/Garbage1");

        talkButton      = GetTree().GetRoot().GetNode<Button>("Control/TalkButton");
        interactButton  = GetTree().GetRoot().GetNode<Button>("Control/InteractButton");
        useButton       = GetTree().GetRoot().GetNode<Button>("Control/UseButton");
        inventoryButton = GetTree().GetRoot().GetNode<Button>("Control/InventoryButton");
        mapButton = GetTree().GetRoot().GetNode<Button>("Control/MapButton");

        mapButton.Disabled = true;
    
        people1.Connect("button_down", this, nameof(_on_TextureButton_people1_buttondown));
        people2.Connect("button_down", this, nameof(_on_TextureButton_people2_buttondown));
        banane1.Connect("button_down", this, nameof(_on_TextureButton_banane1_buttondown));
        garbage1.Connect("button_down", this, nameof(_on_TextureButton_garbage1_buttondown));


        mapButton.Connect("button_down", this, nameof(_on_TextureButton_mapButton_buttondown));

    }

    public void _on_TextureButton_mapButton_buttondown() {
        GetTree().ChangeScene("res://src/Scenes/MapTwo.tscn");
    }

    public void _on_TextureButton_people1_buttondown() {
        
        textbox.Text = "- Hé bonjour, je recherche la faculté d’arts plastique, vous savez où elle est ?";
        textbox.Text += "\n - Oula, nous on vient d’arriver à Montpellier, on connaît pas du tout la zone, on sait juste que vous n’êtes pas aux bon endroits.";
        textbox.Text += "\n - Merci beaucoup, je vais demander à d’autres personnes. ";
        
        //Oula, nous on vient d’arriver à Montpellier, on connaît pas du tout la zone, on sait juste que vous n’êtes pas aux bon endroits.
        
        GD.Print("Prout2");
    }

    public void _on_TextureButton_people2_buttondown() {
        if(!bananeInTrash) {
            textbox.Text = "- Salut; tu sais où est la faculté d’art ?";
            textbox.Text += "\n - Ah, encore un de ces crasseux d’étudiant de Paul Va, j’imagine que c’est toi qui à laisser tes déchets par terre ?";
            textbox.Text += "\n - Mais non…";
            textbox.Text += "\n - Oui, c’est cela …";
        }
        else {
            textbox.Text = "- Regarde, j’ai nettoyé les déchets, est ce que tu pourrais répondre à ma question ?";
            textbox.Text += "\n - Hmm, vous voyez quand vous voulez… Enfin bon, vous avez pas un téléphone avec un gps ? ";
            textbox.Text += "\n - Euh non, j’ai qu’un vieux téléphone à clapet, mais j’ai une carte  ";
            textbox.Text += "\n - Quel horreur…";
            textbox.Text += "\n - Bon, je vais vous l’indiquer sur votre carte";
            textbox.Text += "\n - Merci, bien";
            textbox.Text += "\n **Nouveau lieu débloqué**";

            mapButton.Disabled = false;
        }
    }

    public void _on_TextureButton_banane1_buttondown() {
        if(!getBanane) {
            getBanane = true;

            //CanvasItem item = GetTree().GetRoot().GetNode<CanvasItem>("Control/Background/Banana1");
            banane1.QueueFree();

            textbox.Text = "**Vous récupérez la banane**";

        }
    }

    public void _on_TextureButton_garbage1_buttondown() {
        if(getBanane) {
            textbox.Text = "**Vous jetez la banane dans la poubelle**";
            getBanane = false;
            bananeInTrash = true;
        }
        else {
            textbox.Text = "Oh, une poubelle, c'est très cossus";
        }

    }

	public void _on_AnimationPlayer_animation_finished()
	{
		GD.Print("Prout");
        //GD.Print("Enemy: " + animatedSprite.Animation);
		/*if(animatedSprite.Animation == "Attack")
		{

			IsAttacking = false;
		}*/

	}




//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
