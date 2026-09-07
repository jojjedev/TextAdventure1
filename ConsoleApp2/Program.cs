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
            else if (hero.Location == "barn")
            {
                Barn(hero);
            }
            else if (hero.Location == "barnfight")
            {
                BarnFight(hero);
            }
            else if (hero.Location == "backroom")
            {
                BackRoom(hero);
            }
            else if (hero.Location == "church")
            {
                Church(hero);
            }
            else if (hero.Location == "vault")
            {
                Vault(hero);
            }
            else if (hero.Location == "basement")
            {
                Basement(hero);
            }
            else if (hero.Location == "gameover")
            {
                GameOver(hero);
            }
            else
            {
                Console.Error.WriteLine($"You forgot to implement '{hero.Location}'!");
            }
        }
        
        Console.WriteLine("\nThank you for playing!");
    }

    static string Ask(string question)
    {
        string response;
        do
        {
            Console.Write(question);
            response = Console.ReadLine().Trim().ToLower();
            
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
            string response = Ask("What item to do prefer? ");
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
        Console.WriteLine("The courtyard is dark and path is leading away from the house. Up ahead it splits in two directions," +
                          "one path towards the church and another path towards the barn.");
        while (true)
        {
            string response = Ask("Do you walk towards the CHURCH or the BARN?");
            if (response == "church")
            {
                Console.WriteLine("You get a strange feeling as you aproach the chruch." +
                                  "There is candle light glowing in the windows, even though it's long since abandoned." +
                                  "As you get close, you realise that the door looks even bigger than you thought. You decide" +
                                  "to investigate and open the door.");
                hero.Location = "church";
                break;
            }
            else if (response == "barn")
            {
                Console.WriteLine("You head towards the barn.");
                hero.Location = "barn";
                break;
            }

            Console.Read(); // Fråga om varför denna read metoden skippades utan if satsen över.
        }
    }

    static void Barn(Hero hero)
    {
        Console.WriteLine("You enter into the barn. It is dark and there seems to be a room at the end.");
        string response = Ask("Do you want to explore the ROOM in the barn or turn back towards the CHURCH?");
        if (response == "room")
        {
            hero.Location = "barnfight";
        }
        else if (response == "church")
        {
            hero.Location = "church";

        }
        
    }

    static void BarnFight(Hero hero)
    {
        Hero.SetDmg(hero);
        List <Enemy> enemies = new List<Enemy>();
        for (int i = 0; i < 3; i++)
        {
            Enemy enemy = new Enemy();
            enemy.Name = $"Minion{i+1}";
            enemy.SetDmg(enemy);
            enemies.Add(enemy);
        }
        
        for(; enemies.Count() > 0; )
        {
            while (enemies[0].Health > 0)
            {
                EnemyTurn(hero, enemies[0]);
                PlayerTurn(hero, enemies[0]);
                if (hero.Health <= 0)
                {
                    Console.WriteLine("The final hit brings you to a knee, and you fall unconscious");
                    Console.ReadLine();
                    hero.Location = "gameover";
                }
            }

            enemies.Remove(enemies[0]);
        }
        Console.WriteLine("You manage take down the animals! You decide to investigate the room in the back of the barn.");
        Console.ReadLine();
        hero.Location = "backroom";
    }

    static void BackRoom(Hero hero)
    {
        Console.WriteLine("You are in the backroom");
        Console.ReadLine();
        
        Console.WriteLine("You see a shiny set of armor");
        if (AskYesOrNo("Do you wish to equip it?"))
        {
            hero.Health += 50;
            hero.Items.Add("Shiny Armor");
        }
        Console.WriteLine("You also see a potion with a red liquid in it");
        if (AskYesOrNo("Do you drink the potion?"))
        {
            int result = RollD6();
            if (hero.Health == 150)
            {
                Console.WriteLine("You have not recieved any damage so the potion has no effect");
            }
            else if (result <= 2)
            {
                Console.WriteLine("The potion tastes good but has clearly been here for awhile and the effect i greatly reduced");
                hero.Health += 10;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
            else if (result > 2 && result <= 4)
            {
                Console.WriteLine("The potion creates a warm feeling inside you, but does not feel fully potent");
                hero.Health += 20;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
            else
            {
                Console.WriteLine("The potion fills you with warmth and a surge of energy ");
                hero.Health += 30;
                if (hero.Health >= 150)
                {
                    hero.Health = 150;
                    Console.WriteLine("You are now at full HP!");
                }
                else
                {
                    Console.WriteLine($"You have {hero.Health} HP!");
                }
            }
        }
        Console.WriteLine("After gathering your things, you decide to head towards the church.");
        hero.Location = "church";
    }
    static void Vault(Hero hero)
    {
        Console.WriteLine("As you enter the room you find riches beyond your imagination. \nYou go to grab a goblet of pure gold, but as soon as you touch it everything goes black");
        hero.Location = "gameover";
        Console.ReadLine();
    }

    static void Basement(Hero hero)
    {
        Console.WriteLine("The minotaur drags your lifeless body down the stairs into the basement, as you are being dragged, everything starts to fade");
        hero.Location = "gameover";
    }

    static void GameOver(Hero hero)
    {
        Console.Clear();
        Console.WriteLine("You wake up in a bed at the inn and the inkeeper asks \n");
        string response = Ask("Do you want to go AGAIN or are you heading HOME?");
        if (response == "home")
        {
            
            hero.Location = "quit";
        }
        else if (response == "again")
        {
            hero.Items.Clear();
            hero.Health = 100;
            hero.Location = "newgame";
        }

    }
    static void Church(Hero hero)
    {
        Console.WriteLine("You enter the church, and the door slams shut behind you." +
                          "At the altar, you see a towering figure covered in robes." +
                          "The figure turns towards you with a huge axe and starts to charge towards you.");
        bool winner;
        Enemy boss = new Enemy();
        boss.Name = "Minotaur";
        Hero.SetDmg(hero);
        boss.SetDmg(boss);
        
        while(true)
        {
            if (hero.Health <= 0)
            {
                hero.Location = "basement";
                break;
            }

            if (boss.Health <= 0)
            {
                Console.WriteLine("The minotaur falls backwards and into a gate you did not see before, \nYou enter the room");
                hero.Location = "vault";
                break;
            }
            EnemyTurn(hero, boss);
            PlayerTurn(hero, boss);
            
        }
        
    }
    // Lägg till flavour

    static void EnemyTurn(Hero hero, Enemy enemy)
    {
        int roll = RollD6();
        
        if (roll <= 2)
            {
                enemy.AttackSwipe(enemy);
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    hero.Health -= enemy.swipeDmg / 2;
                    Console.WriteLine($"You attempt to parry the swipe, but you still take {enemy.swipeDmg / 2} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= enemy.swipeDmg;
                    Console.WriteLine($"You attempt to dodge backwards, but not far enough! You take {enemy.swipeDmg} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    Console.WriteLine("You manage to jump over the attack and avoid all damage.");
                    Console.WriteLine(hero.Health);
                }

            }
            else if (roll > 2 && roll <= 4) //varför får vi varning här?
            {
                enemy.AttackKick(enemy); 
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    hero.Health -= enemy.kickDmg;
                    Console.WriteLine($"You attempt to parry the kick, but you are unsuccessful. You take {enemy.kickDmg} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    Console.WriteLine("You dodge to the side of the kick and avoid all damage!");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= enemy.kickDmg / 2;
                    Console.WriteLine($"You try to jump over the kick but it catches your legs mid jump. You land awkwardly and take {enemy.kickDmg / 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
            }
            else if (roll >= 5)
            {
                enemy.AttackStrike(enemy);
                string response = Ask("What do you want to do? Jump, parry or dodge? ");
                if (response == "parry")
                {
                    Console.WriteLine($"You parry the attack and deflect it away from you. You avoid all damage!");
                    Console.WriteLine(hero.Health);
                }

                if (response == "dodge")
                {
                    hero.Health -= enemy.strikeDmg / 2;
                    Console.WriteLine($"The attack graces your arm while trying to dodge to the side. You take {enemy.strikeDmg / 2} damage.");
                    Console.WriteLine(hero.Health);
                }

                if (response == "jump")
                {
                    hero.Health -= enemy.strikeDmg * 2;
                    Console.WriteLine($"You jump straight into the attack and suffer a grievous wound. You take {enemy.strikeDmg * 2} damage. ");
                    Console.WriteLine(hero.Health);
                }
                
            }
            
    }

    // Lägg till flavour
    static void PlayerTurn(Hero hero, Enemy enemy)
    {
        string response = Ask("It's your turn to attack. \nDo you play it safe and SLASH in a big arch \nor try for a more risky and precise STAB? ");
        if (response == "slash")
        {
            enemy.Health -= hero.currentDmg;
            Console.WriteLine($"{enemy.Health} Boss HP");
        }
        else if (response == "stab")
        {
            if (RollD6() >= 4)
            {
                enemy.Health -= hero.currentDmg * 2;
                Console.WriteLine("You hit your mark!");
                Console.WriteLine(hero.currentDmg);
                Console.WriteLine($" {enemy.Health} {enemy.Name} HP");
            }
            else
            {
                Console.WriteLine("The enemy dodges to the side and you miss.");
                Console.WriteLine(hero.currentDmg);
                Console.WriteLine($" {enemy.Health} {enemy.Name} HP");
            }
        }
        
    }
    
    
}