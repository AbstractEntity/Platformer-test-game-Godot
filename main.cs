using Godot;
using System;


public unsafe partial class main : Node2D
{

    struct Person
    {
        public string name;
        public int age;
    };

    Person[] people = new Person[50];
    public unsafe override void _Ready()
    {
        int[] arr = new int[50];
        fixed (Person* pPerson = people)
        {
            initialize(pPerson);
        }
        //Util.SaveGame();
        //Util.LoadGame();
    }

    unsafe void initialize(Person* pPerson)
    {
        for (int i = 0; i < people.Length; i++)
        {
            (pPerson + i)->age = i;
            (pPerson + i)->name = (i / 2).ToString();

            GD.Print((pPerson + i)->age, " ", people[i].age, " ", (pPerson + i)->name, " ", people[i].name);
        }
    }
    void _on_exit_pressed()
	{
		GetTree().Quit();
	}
    void _on_play_pressed()
    {
        GetTree().ChangeSceneToFile("res://world.tscn");
    }

}






