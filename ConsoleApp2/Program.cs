namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Weclome to Text Adventure!");
        string name = "";
        Hero hero = new Hero();
        while (hero.Location != "quit")
        {
            if (hero.Location == "newgame")
            {
                NewGame(hero);
            }
            else if (hero.Location == "tableroom")
            {
                TableRoom(hero);
            }
            else if (hero.Location == "corridor")
            {
                Corridor(hero);
            }
            else if (hero.Location == "kitchen")
            {
                Kitchen(hero);
            }
            else if (hero.Location == "lockedroom")
            {
                LockedRoom(hero);
            }
            else if (hero.Location == "courtyard")
            {
                Courtyard(hero);
            }
            else if (hero.Location == "church")
            {
                Church(hero);
            }
            else
            {
                Console.Error.WriteLine($"You forgot to implement '{hero.Location}'!");
            }
        }
        /*
        do
        {
            Console.Write("What is your name, adventurer? ");
            name = Console.ReadLine();
            
            Console.Write($"So, {name} it is? ");
            string yesOrNo = Console.ReadLine().Trim().ToLower();

            if (yesOrNo != "yes" && yesOrNo != "ok")
            {
                name = "";
            }
        } while (name == "");
        
        do
        {
            name = Ask("What is your name, adventurer? ");
        } while (!AskYesOrNo($"So, {name} it is? "));
        */

    }

    static string Ask(string question)
    {
        string response;
        do
        {
            Console.Write(question);
            response = Console.ReadLine().Trim();
            
        } while (response == "");

        return response;
    }

    static bool AskYesOrNo(string question)
    {
        while (true)
        {
            string response = Ask(question).ToLower();
            switch (response)
            {
                case "yes":
                    case "ok":
                        return true;
                case "no":
                    return false;
            }
        }
    }

    static int RollD6()
    {
        Random random = new Random();
        int roll = random.Next(1, 7);
        return roll;
    }

    static void NewGame(Hero hero)
    {
        Console.Clear();
        string name = "";
        do
        {
            name = Ask("What is your name, adventurer? ");
        } while (!AskYesOrNo($"So, {name} it is? "));

        hero.Name = name;
        hero.Location = "tableroom";
    }
    static void TableRoom(Hero hero)
    {
        Console.Clear();
        hero.Items.Add("Wooden Sword");
        Console.WriteLine("You are equipped with one wooden sword, and your task " +
                          "is to slay the monster at the end of the adventure. " +
                          "" +
                          "In front of you is a stone table with two items on it, " +
                          "a knife and a key." +
                          "" +
                          "You can only pick up one of these items.");
        while(true) {
            string response = Ask("What item to do prefer? ").ToLower().Trim();
            if (response == "knife")
            {
                hero.Items.Add("Knife");
                Console.WriteLine("You have picked up the Knife! ");
                Console.WriteLine("It has been added to your inventory! ");
                break;
            }
            else if (response == "key")
            {
                hero.Items.Add("key");
                Console.WriteLine("You have picked up the Key! ");
                Console.WriteLine("It has been added to your inventory! ");
                break;
            }
            else if (response == "none")
            {
                Console.WriteLine("Alright, you leave empty handed");
                break;
            }
            else
            {
                Console.WriteLine("I didn't understand? ");
            }
            
            
        }
        Console.WriteLine("You leave the room and enter the corridor.");
        hero.Location = "corridor";
    }

    static void Corridor(Hero hero)
    {
        Console.WriteLine("You exit the room and find yourself standing in a dark " + "hallway. " +
                          "You can either enter another room on your right " + "side, " +
                          "or continue down the hallway on your left.");
        string response = Ask("Which door do you want to enter? ");
        if (response == "left")
        {
            if (hero.Items.Contains("key"))
            {
                Console.WriteLine("The door seems to be locked. You try the key you found in the tableroom and it works!" +
                                  "You open the door and enter the room.");
                Console.Read();
                hero.Location = "lockedroom";
                hero.Items.Remove("key");
                
            }
            else
            {
                Console.WriteLine("The door seems to be locked.");
                Console.WriteLine("You proceed to the room on the right.");
                Console.Read();
                hero.Location = "kitchen";
            }

        }
        else if (response == "right")
        {
            Console.WriteLine("You enter into the kitchen.");
            hero.Location = "kitchen";
        }
        
    }

    static void LockedRoom(Hero hero)
    {
        Console.Clear();
        Console.WriteLine("Inside the locked room... " +
                          "you find a shiny sword! ");
        if (AskYesOrNo("Do you want to swap your wooden sword? "))
        {
            hero.Items.Remove("Wooden Sword");
            hero.Items.Add("Shiny Sword");
        }
        Console.WriteLine("You exit out into the corridor and enter the last door at the end ");
        Console.Read();
        hero.Location = "kitchen";

    }

    static void Kitchen(Hero hero)
    {
        Console.WriteLine("In the kitchen you see a closed chest, it does not seem to be looked.");
        if (AskYesOrNo("Do you want to open the chest?"))
        {
            Console.WriteLine("You see a chef's hat with a strange symbol of what looks like a spatula ");
            if (AskYesOrNo("Do you grab the chef's hat? "))
            {
                if (RollD6() >= 3)
                {
                    Console.WriteLine("The chef's hat is indeed magical, you feel inspired");
                    hero.Items.Add("Magical chef's hat");
                }
                else
                {
                    Console.WriteLine("You get a wierd feeling from touching the hat");
                    hero.Items.Add("Cursed chef's hat");
                }
            }
            else
            {
                Console.WriteLine("Something about the hat doesn't feel right, you decide to ignore it");
            }
        }

        Console.WriteLine("You exit the kitchen and you enter into a massive courtyard");
        Console.Read();
        hero.Location = "courtyard";
    }

    static void Courtyard(Hero hero)
    {
        Console.WriteLine("The courtyard is dark and path is leading away from the house towards a huge church." +
                          "Something feels off though. There seems to be candle light glowing in the windows of the church," +
                          "even though it's long since abandoned. You decide to go and investigate it.");
        if (AskYesOrNo("Do you walk towards the door? "))
        {
            Console.WriteLine("The door looks even bigger when you get closer");
            hero.Location = "church";
        }
        else
        {
            hero.Location = "corridor";
        }

        Console.Read(); // Fråga om varför denna read metoden skippades utan if satsen över.
    }

    static void Church(Hero hero)
    {
        Console.WriteLine("You enter the church, and the door slams shut behind you." +
                          "At the altar, you see a towering figure covered in robes." +
                          "The figure turns towards you with a huge axe and starts to charge towards you.");
        bool winner;
        Enemy boss = new Enemy();
        
        
        
        while(true)
        {
            
            if (hero.Health <= 0)
            {
                hero.Location = "basement";
                break;
            }

            if (boss.Health <= 0)
            {
                hero.Location = "vault";
                break;
            }
            //EnemyTurn(hero);
            PlayerTurn(hero, boss);
            
        }
        
    }

    static void EnemyTurn(Hero hero)
    {
        int swipeDmg = 10;
        int strikeDmg = 25;
        int kickDmg = 15;
        int roll = RollD6();
        
        if (roll <= 2)
            {
                Console.WriteLine("The minotaur swipes his axe at you");
                string response = Ask("What do you want to do? Jump, parry or dodge? ").ToLower().Trim();
                if (response == "parry")
                {
                    hero.Health -= swipeDmg / 2;
                    Console.WriteLine($"You attempt to parry his swipe, but he is too strong. You take {swipeDmg / 2} damage ");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= swipeDmg;
                    Console.WriteLine("You attempt to dodge backwards, but his reach is too far and his axe hits you ");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    Console.WriteLine("He is not used to fighting someone small, you manage to jump over his swipe and take no damage. ");
                    Console.WriteLine(hero.Health);
                }

            }
            else if (roll > 2 && roll <= 4) //varför får vi varning här?
            {
                Console.WriteLine("The minotaur attemps to kick you ");
                string response = Ask("What do you want to do? Jump, parry or dodge? ").ToLower().Trim();
                if (response == "parry")
                {
                    hero.Health -= kickDmg;
                    Console.WriteLine($"You attempt to parry his kick, but he is too strong. You take {kickDmg} damage ");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    Console.WriteLine("You dodge to the side and his kick misses you. You take no damage. ");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= kickDmg / 2;
                    Console.WriteLine($"You try to jump over his kick but he catches your legs mid jump. You land awkwardly and take {kickDmg / 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
            }
            else if (roll >= 5)
            {
                Console.WriteLine("The minotaur uses his axe to strike you from above ");
                string response = Ask("What do you want to do? Jump, parry or dodge? ").ToLower().Trim();
                if (response == "parry")
                {
                    Console.WriteLine($"You parry his attack and deflect it towards the ground. You take no damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= strikeDmg / 2;
                    Console.WriteLine($"His attack graces your arm while trying to dodge to the side. You take {strikeDmg / 2} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= strikeDmg * 2;
                    Console.WriteLine($"You jump straight into the axe and take a grievous wound. You take {strikeDmg * 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
                
            }
            
    }

    static void PlayerTurn(Hero hero, Enemy boss)
    {
        Hero.SetDmg(hero);
        Console.WriteLine(hero.currentDmg);
    }
}