using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Midterms_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //battle info
            Random rnd = new Random();
            int level = 1, round = 0, dmg, restore;
            double buff = 0, mpRestore = 0;
            bool endGame = false, battle = true;
            bool playerTurn = true, enemyTurn = false;

            //general info
            int chance, totalDMG = 0;
            string input, role = "", info = "";
            bool classSelect = false, confirm = false, tutorial = true;
            List<string> weapon = new List<string> { "sword", "dagger", "grimoire", "holy staff" };


            //player stats
            string playerName, title = "";
            Dictionary<string, int> stats = new Dictionary<string, int>();
            Dictionary<string, int[]> moveset = new Dictionary<string, int[]>();
            string[] move = new string[3];
            int currentHP, currentMP, baseStat;

            //enemy info 
            string[] enemyName = new string[3] { "GRUNT", "AIDE", "EVIL WARLORD" };
            Dictionary<string, int> enemy = new Dictionary<string, int>();
            Dictionary<int, int[]> enemyMove = new Dictionary<int, int[]>();
            int enemyCurrentHP = 0, lowestChance = 0, highestChance = 0;

            //open menu
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t   _                                                     _       ___ " +
                    "\r\n\t\t\t  /_\\  _ __ ___   _   _  ___  _   _   _ __ ___  __ _  __| |_   _/ _ \\" +
                    "\r\n\t\t\t //_\\\\| '__/ _ \\ | | | |/ _ \\| | | | | '__/ _ \\/ _` |/ _` | | | \\// /" +
                    "\r\n\t\t\t/  _  \\ | |  __/ | |_| | (_) | |_| | | | |  __/ (_| | (_| | |_| | \\/ " +
                    "\r\n\t\t\t\\_/ \\_/_|  \\___|  \\__, |\\___/ \\__,_| |_|  \\___|\\__,_|\\__,_|\\__, | () " +
                    "\r\n\t\t\t                  |___/                                    |___/     ");

                Console.WriteLine("\t\t\t\t\t\t      ______" +
                    "\r\n\t\t\t\t\t\t   ,-' ;  ! `-." +
                    "\r\n\t\t\t\t\t\t  / :  !  :  . \\" +
                    "\r\n\t\t\t\t\t\t |_ ;   __:  ;  |" +
                    "\r\n\t\t\t\t\t\t )| .  :)(.  !  |" +
                    "\r\n\t\t\t\t\t\t |\"    (##)  _  |" +
                    "\r\n\t\t\t\t\t\t |  :  ;`'  (_) (" +
                    "\r\n\t\t\t\t\t\t |  :  :  .     |" +
                    "\r\n\t\t\t\t\t\t )_ !  ,  ;  ;  |" +
                    "\r\n\t\t\t\t\t\t || .  .  :  :  |" +
                    "\r\n\t\t\t\t\t\t |\" .  |  :  .  |" +
                    "\r\n\t\t\t\t\t\t |mt-2_;----.___|");

                Console.Write("\n\n\n\t\t\t\t\t      Press [Enter] to Start ");

            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            Console.Clear();

            //story
            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t    H...hey... ");
            Console.ReadKey();
            Console.Clear();

            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t    HEEEEEEEYYYYY!!!!");
            Console.ReadKey();
            Console.Clear();

            Console.Write("\n\n\n\n\n\n\t\t\t[???]: Oh, thank goodness! You're alive! I thought you died.");
            Console.Write("\n\t\t\t       You would've been pathetic if you did before we even slew the boss.");
            Console.Write("\n\n\t\t\t[You]: ...");
            Console.Write("\n\n\t\t\t[???]: Wait a minute. Why are you acting like that- Don't tell me...");
            Console.Write("\n\n\t\t\t[You]: ...");
            Console.Write("\n\n\t\t\t[???]: Do you remember anything that happened before entering?");
            Console.Write("\n\n\t\t\tYOU SHOOK YOUR HEAD AT THE STRANGER");
            Console.Write("\n\n\t\t\t[???]: You DIMWIT!!! Just before we're about to fight the boss.");
            Console.Write("\n\t\t\t       *Ughhhhh* That's why I told you to check for traps before" +
                "\n\t\t\t       doing anything!");
            Console.ReadKey();
            Console.Clear();


            //main menu
            while (true)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\t\t\t             [???]: Well, do you at least remember your name?");
                Console.Write("\n\t\t\t\t             (Please input your name below)\n\n");
                Console.Write("\t\t\t\t             Response: ");
                playerName = Console.ReadLine().ToUpper();

                if (playerName.Length > 0)
                {
                    Console.Clear();
                    break;
                }

                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t      Your mind is still hazy from what happened");
                Console.Write("\t\t\t\t           Then, something comes into mind");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Write("\n\n\n\n\n\n\n\n\t\t\t[Clara]: Good. At least you remembered. I'm Clara Fey by the way.");
            Console.Write("\n\t\t\t          Since you obviously forgot about.");
            Console.Write("\n\n\t\t\t[Clara]: *Sigh* I can't believe we are in this predicament.");
            Console.Write("\n\n\t\t\t[Clara]: Anyways, let's go to the next floor. We're close to fighting");
            Console.Write("\n\t\t\t         the Evil Warlord that's been causing havoc to the kingdom. ");
            Console.Write("\n\t\t\t         Once everything is over, I'm going on vacation.");
            Console.Write("\n\n\t\t\t\t JUST AS YOU STOOD UP, CLARA HANDED YOU YOUR WEAPON");
            Console.ReadKey();
            Console.Clear();

            //getting the stats of the player

            while (confirm == false)
            {
                classSelect = false;

                Console.Write("\n\n\n\n\n\n\n\n\t\t\t\t\t\t       It was a....");
                Console.WriteLine("\n\n\t\t\t\t       [Sword]  [Dagger]  [Grimoire]  [Holy Staff]");
                Console.WriteLine("\n\n\t\t\t\t*Keep in mind that each weapon will yield different stats*");
                Console.WriteLine("\t\t\t\t   *RECOMMENDED TO USE SWORD FOR BEGINNER's EXPERIENCE*");
                Console.WriteLine("\n\t\t\t\t  (Please type the weapon name below to view the details)");
                Console.Write("\n\n\t\t\t\t\t\t     Response: ");
                input = Console.ReadLine().ToLower();

                if (weapon.Contains(input))
                {
                    while (classSelect == false)
                    {
                        Console.Clear();

                        switch (input)
                        {
                            case "sword":

                                title = "SWORDMASTER";
                                move[0] = ("SLASH");
                                move[1] = ("CHARGE");
                                move[2] = ("GUILLOTINE");
                                buff = 0;
                                mpRestore = 0;

                                //moveset
                                moveset[move[0]] = new int[3];
                                moveset[move[0]][0] = 90;
                                moveset[move[0]][1] = 0;
                                moveset[move[0]][2] = 95;

                                moveset[move[1]] = new int[3];
                                moveset[move[1]][0] = 100;
                                moveset[move[1]][1] = 8;
                                moveset[move[1]][2] = 90;

                                moveset[move[2]] = new int[3];
                                moveset[move[2]][0] = 110;
                                moveset[move[2]][1] = 15;
                                moveset[move[2]][2] = 75;

                                info = "\t\tUses a sword to slay the enemies. Has high HP and DEF but low SPD" +
                                    "\n\t\t\t\tand ACCURACY in comparison to other classes. " +
                                    "\n\t\t\t\tRECOMMENDED FOR BEGINNERS" +
                                    "\n\n\t\tSPECIAL\t\tLOWER MP COST" +
                                    "\n\t\tSKILL:";

                                break;

                            case "dagger":

                                title = "ASSASSIN";
                                move[0] = "STAB";
                                move[1] = "THRUST";
                                move[2] = "SHADOW STRIKE";
                                buff = 0;
                                mpRestore = 0;

                                //moveset
                                moveset[move[0]] = new int[3];
                                moveset[move[0]][0] = 90;
                                moveset[move[0]][1] = 0;
                                moveset[move[0]][2] = 100;

                                moveset[move[1]] = new int[3];
                                moveset[move[1]][0] = 100;
                                moveset[move[1]][1] = 20;
                                moveset[move[1]][2] = 95;

                                moveset[move[2]] = new int[3];
                                moveset[move[2]][0] = 115;
                                moveset[move[2]][1] = 40;
                                moveset[move[2]][2] = 90;

                                info = "\t\tUses a dagger to slay the enemies. Has high SPD and ACCURACY" +
                                    "\n\t\t\t\tbut low ATK and DEF in comparison to other classes. " +
                                    "\n\n\t\tSPECIAL\t\tHIGH CHANCE TO LAND A CRITICAL HIT" +
                                    "\n\t\tSKILL:";

                                break;

                            case "grimoire":

                                title = "ARCHMAGE";
                                move[0] = ("THROW");
                                move[1] = ("ENCHANT");
                                move[2] = ("DARK MAGIC");
                                buff = 0;
                                mpRestore = .2;

                                //moveset
                                moveset[move[0]] = new int[3];
                                moveset[move[0]][0] = 85;
                                moveset[move[0]][1] = 0;
                                moveset[move[0]][2] = 95;

                                moveset[move[1]] = new int[3];
                                moveset[move[1]][0] = 100;
                                moveset[move[1]][1] = 35;
                                moveset[move[1]][2] = 70;

                                moveset[move[2]] = new int[3];
                                moveset[move[2]][0] = 145;
                                moveset[move[2]][1] = 55;
                                moveset[move[2]][2] = 65;

                                info = "\t\tConjures powerful spells to attack the enemies. Has high ATK and MP" +
                                    "\n\t\t\t\tbut low HP and DEF in comparison to other classes" +
                                    "\n\n\t\tSPECIAL\t\tHIGH MP REGENERATION" +
                                    "\n\t\tSKILL:";

                                break;

                            case "holy staff":

                                title = "HOLY SAINT";
                                move[0] = "PRAY";
                                move[1] = "CHANT";
                                move[2] = "DIVINE WRATH";
                                buff = .2;
                                mpRestore = 0;

                                //moveset
                                moveset[move[0]] = new int[3];
                                moveset[move[0]][0] = 95;
                                moveset[move[0]][1] = 0;
                                moveset[move[0]][2] = 100;

                                moveset[move[1]] = new int[3];
                                moveset[move[1]][0] = 100;
                                moveset[move[1]][1] = 30;
                                moveset[move[1]][2] = 95;

                                moveset[move[2]] = new int[3];
                                moveset[move[2]][0] = 140;
                                moveset[move[2]][1] = 50;
                                moveset[move[2]][2] = 75;

                                info = "\t\tUses the staff to channel holy powers. Has high MP" +
                                    "\n\t\t\t\tbut low HP and ATK in comparison to other classes" +
                                    "\n\n\t\tSPECIAL\t\tHIGH HP HEALS" +
                                    "\n\t\tSKILL:";

                                break;
                        }

                        Console.WriteLine($"\n\n\t\t\t\t\t\tCLASS: [{title}]\t\t\t\t");
                        Console.WriteLine("\n\t\t----------------------------------------------------------------------------------");
                        Console.WriteLine($"\t\t||\t\t\t\t\t\t\t\t\t\t||");
                        Console.WriteLine($"\t\t||\t\t\t\t       MOVE LIST\t\t\t\t||");
                        Console.WriteLine($"\t\t||\t\t\t\t\t\t\t\t\t\t||");
                        Console.WriteLine($"\t\t||\tMOVE\t\t\tPOWER\t\tMP COST\t\tACC.\t\t||");
                        Console.WriteLine($"\t\t||\t{move[0]}\t\t\t{moveset[move[0]][0]}\t\t{moveset[move[0]][1]}\t\t{moveset[move[0]][2]}\t\t||");
                        Console.WriteLine($"\t\t||\t{move[1]}\t\t\t{moveset[move[1]][0]}\t\t{moveset[move[1]][1]}\t\t{moveset[move[1]][2]}\t\t||");
                        Console.WriteLine($"\t\t||\t{move[2]}\t\t{moveset[move[2]][0]}\t\t{moveset[move[2]][1]}\t\t{moveset[move[2]][2]}\t\t||");
                        Console.WriteLine($"\t\t||\t\t\t\t\t\t\t\t\t\t||");
                        Console.WriteLine("\t\t----------------------------------------------------------------------------------");
                        Console.WriteLine($"\n\t\tINFO:{info}");

                        role = title.ToUpper();

                        Console.WriteLine("\n\n\t\t\t\t\t      Are you sure about this choice?");
                        Console.WriteLine("\t\t\t\t\t(Type [Yes] to proceed or [No] to go back)");
                        Console.Write("\n\t\t\t\t\t\t\tRespond: ");
                        input = Console.ReadLine().ToLower();

                        if (input == "yes")
                        {
                            confirm = true;
                            Console.Clear();
                            break;
                        }
                        else if (input == "no")
                        {
                            classSelect = true;
                            break;

                        }

                    }
                }

                if (confirm != true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\tYour mind is still hazy from what happened...");
                    Console.Write("\n\t\t\t              [Clara]: Hello??? Are you goin' to get it or what?");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            switch (role)
            {
                case "SWORDMASTER": //swordmaster

                    //stats
                    baseStat = (rnd.Next(32, 37) * 10);
                    stats["HP"] = baseStat + (int)(baseStat * .10);

                    stats["ATK"] = (rnd.Next(9, 16) * 10);

                    baseStat = (rnd.Next(11, 18) * 10);
                    stats["DEF"] = baseStat + (int)(baseStat * .10);

                    stats["MP"] = (rnd.Next(9, 16) * 10);
                    stats["SPD"] = (rnd.Next(6, 11) * 10);

                    break;

                case "ASSASSIN": //assassin

                    //stats
                    stats["HP"] = (rnd.Next(30, 35) * 10);

                    baseStat = (rnd.Next(7, 14) * 10);
                    stats["ATK"] = baseStat - (int)(baseStat * .10);

                    baseStat = (rnd.Next(7, 14) * 10);
                    stats["DEF"] = baseStat - (int)(baseStat * .10);

                    stats["MP"] = (rnd.Next(9, 16) * 10);

                    baseStat = (rnd.Next(8, 12) * 10);
                    stats["SPD"] = baseStat + (int)(baseStat * .10);

                    break;

                case "ARCHMAGE": //grandmaster

                    //stats
                    baseStat = (rnd.Next(28, 33) * 10);
                    stats["HP"] = baseStat - (int)(baseStat * .10);

                    baseStat = (rnd.Next(11, 18) * 10);
                    stats["ATK"] = baseStat + (int)(baseStat * .10);

                    baseStat = (rnd.Next(7, 14) * 10);
                    stats["DEF"] = baseStat - (int)(baseStat * .10);

                    baseStat = (rnd.Next(11, 18) * 10);
                    stats["MP"] = baseStat + (int)(baseStat * .10);

                    stats["SPD"] = (rnd.Next(6, 11) * 10);

                    break;


                case "HOLY SAINT": //saint

                    //stats
                    baseStat = (rnd.Next(28, 33) * 10);
                    stats["HP"] = baseStat - (int)(baseStat * .10);

                    baseStat = (rnd.Next(7, 14) * 10);
                    stats["ATK"] = baseStat - (int)(baseStat * .10);

                    stats["DEF"] = (rnd.Next(9, 16) * 10);

                    baseStat = (rnd.Next(11, 18) * 10);
                    stats["MP"] = baseStat + (int)(baseStat * .10);

                    stats["SPD"] = (rnd.Next(6, 11) * 10);

                    break;

            }

            currentHP = stats["HP"];
            currentMP = stats["MP"];

            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t                [Clara]: Ah right, before I forget...");
            Console.ReadKey();
            Console.Clear();

            //tutorial
            do
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t                [Clara]: Do you at least remember how to fight?");
                Console.WriteLine("\t\t\t\t\t   (Type [Yes] to skip or [No] start tutorial)");
                Console.Write("\n\t\t\t\t\t\t\t  Respond: ");
                input = Console.ReadLine().ToLower();

                if (input == "yes" || input == "no")
                {
                    switch (input)
                    {
                        case "yes":

                            Console.Clear();
                            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t[Clara]: Thank goodness!!! At least you remember the most important thing!");
                            Console.Write("\n\t\t\t         Well, let's do our best to defeat that baddie!");
                            tutorial = false;
                            Console.ReadKey();

                            break;

                        case "no":

                            Console.Clear();
                            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t[Clara]: #$%#$%#$%# I CAN'T BELIEVE THIS!!!" +
                                "\n\t\t\t\t         *Sigh* Fine. I'll give you a quick rundown on how it works." +
                                "\n\t\t\t\t          You better pay attention...");
                            Console.ReadKey();

                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\tAt the start of each round, there are two status windows: one for you and the enemy");
                            Console.WriteLine("\t\twith each displaying your respective stats.");

                            Console.WriteLine($"\n\n\t\t\t\t\t\t[???] {playerName}'s Stats\t");
                            Console.WriteLine("\t\t\t\t----------------------------------------------------------");
                            Console.Write($"\n\t\t\t\t HP: ???/??? ██████████████████████████████████ ");
                            Console.Write($"\n\t\t\t\t MP: ???/??? ██████████████████████████████████ ");
                            Console.ResetColor();
                            Console.WriteLine($"\n\n\t\t\t\t\t     ATK: ???       DEF:???       SPD: ???");
                            Console.WriteLine("\t\t\t\t----------------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine($"\t\t\t\t\t\t[ENEMY] ????'s Stats\t");
                            Console.WriteLine("\t\t\t\t----------------------------------------------------------");
                            Console.Write($"\n\t\t\t\t HP: ???/??? ███████████████████████████████████ ");
                            Console.ResetColor();
                            Console.WriteLine($"\n\n\t\t\t\t    ATK: ???     DEF: ???     SPD: ???     ACC.: ???%-???%");
                            Console.Write("\t\t\t\t----------------------------------------------------------");
                            Console.ReadKey();

                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\tAt the start of your turn, you have the option to type down one of the three choices:");
                            Console.Write("\n\t\t[Attack]: Will lead you to your list of moves, alongside their corresponding stats.");

                            Console.WriteLine("\n\t\t           Type in the correct attack name while making sure that you have enough MP to be able " +
                                "\n\t\t           to attack the opponents. MP will regenerate but only after you defeat " +
                                "\n\t\t           the enemy.");

                            Console.WriteLine("\n\t\t           Keep in mind that having high ACCURACY will land you a hit and having " +
                                "\n\t\t           high SPD will make it easier to land a CRIT HIT and doubles the damage " +
                                "\n\t\t           to the enemy.");

                            Console.WriteLine("\n\t\t[Heal]: Will randomly regenerate your lost HP, but will make you lose a turn.");
                            Console.Write("\n\t\t[Flee]:  Will just make you leave the dungeon. But by doing so, you'll end up" +
                                "\n\t\t        leaving as a loser and let's say, caused hundreds of millions of people to die.");

                            Console.ReadKey();
                            Console.Clear();
                            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t   [Clara]: Well, you got that? Good. Now go on and fight the big baddie!!");

                            tutorial = false;
                            Console.ReadKey();

                            break;

                    }
                }

                if (tutorial)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t        Your mind is still hazy from what happened");
                    Console.Write("\t\t\t\t[Clara]: OMG, I'm getting sick of this! Will you just answer?");
                    Console.ReadKey();
                }

                Console.Clear();

            } while (tutorial);


            while (endGame == false)
            {
                Console.WriteLine($"\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t LEVEL {level}");
                Console.Write($"\n\t\t\t\t\t\t\t  START!");

                //generate enemy stats
                //Basic ATK base
                enemyMove[0] = new int[2]; enemyMove[0][0] = (rnd.Next(6, 10)) * 10;
                //SP ATK Base
                enemyMove[1] = new int[2]; enemyMove[1][0] = (rnd.Next(8, 11)) * 10;
                //ULT ATK Base
                enemyMove[2] = new int[2]; enemyMove[2][0] = (rnd.Next(10, 14)) * 10;

                //HP
                baseStat = rnd.Next(28, 36) * 10;

                if (currentHP % 10 >= 7)
                {
                    enemy["HP"] = baseStat - (int)(baseStat * (level / 100));
                }
                else if (currentHP % 10 <= 3)
                {
                    enemy["HP"] = baseStat + (int)(baseStat * (level / 100));
                }
                else
                {
                    enemy["HP"] = baseStat;
                }

                enemyCurrentHP = enemy["HP"];

                //ATK
                chance = (currentHP + stats["ATK"]) / 10;
                baseStat = rnd.Next(7, 16) * 10;

                if (chance % 10 >= 7)
                {
                    enemy["ATK"] = baseStat - (int)(baseStat * (level / 100));
                }
                else if (chance % 10 <= 3)
                {
                    enemy["ATK"] = baseStat + (int)(baseStat * (level / 100));
                }
                else
                {
                    enemy["ATK"] = baseStat;
                }

                //DEF
                chance = (currentHP + stats["DEF"]) / 10;
                baseStat = rnd.Next(7, 16) * 10;

                if (chance % 10 >= 7)
                {
                    enemy["DEF"] = baseStat - (int)(baseStat * (level / 100));
                }
                else if (chance % 10 <= 3)
                {
                    enemy["DEF"] = baseStat + (int)(baseStat * (level / 100));
                }
                else
                {
                    enemy["DEF"] = baseStat;
                }

                //SPD
                chance = (currentHP + stats["SPD"]) / 10;
                baseStat = rnd.Next(6, 9) * 10;

                if (chance % 10 >= 7)
                {
                    enemy["SPD"] = baseStat - (int)(baseStat * (level / 100));
                }
                else if (chance % 10 <= 3)
                {
                    enemy["SPD"] = baseStat + (int)(baseStat * (level / 100));
                }
                else
                {
                    enemy["SPD"] = baseStat;
                }

                enemy["SPD"] = (int)(enemy["SPD"] - (stats["SPD"] * .3));

                //ACCURACY
                for (int i = 0; i < 3; i++)
                {
                    chance = rnd.Next(1, 10);

                    if (chance >= 7)
                    {
                        enemyMove[i][1] = (rnd.Next(6, 7) * 10) + 5;
                    }
                    else if (chance <= 3)
                    {
                        enemyMove[i][1] = (rnd.Next(8, 10) * 10) + 5;
                    }
                    else
                    {
                        enemyMove[i][1] = rnd.Next(8, 10) * 10;
                    }

                }

                for (int x = 0; x < 3; x++)
                {
                    for (int y = x; y < 3 - 1; y++)
                    {
                        if (enemyMove[y][1] > lowestChance)
                        {
                            lowestChance = enemyMove[x][1];
                        }

                        if (highestChance < lowestChance)
                        {
                            int temp = lowestChance;
                            lowestChance = highestChance;
                            highestChance = temp;
                        }
                    }
                }

                Console.ReadKey();
                Console.Clear();


                while (battle == true && level < 4)
                {
                    Console.ReadKey();
                    Console.WriteLine($"\n\n\t\t\t\t\t\t         Level  [{level}]\n\n");
                    Console.WriteLine($"\t\t\t\t\t\t[{title}] {playerName}'s Stats\t");
                    Console.WriteLine("\t\t\t\t----------------------------------------------------------");
                    Console.Write($"\n\t\t\t\t HP: {currentHP}/{stats["HP"]}  ");

                    for (int i = 0; i < (currentHP / 5); i++)
                    {
                        if (currentHP < stats["HP"] / 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("█");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("█");
                        }

                        if (i > 37)
                        {
                            break;
                        }

                    }

                    Console.ResetColor();
                    Console.Write($"\n\t\t\t\t MP: {currentMP}/{stats["MP"]}  ");

                    for (int i = 0; i < (currentMP / 5); i++)
                    {
                        if (currentMP < stats["MP"] / 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("█");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("█");
                        }
                    }

                    Console.ResetColor();
                    Console.WriteLine($"\n\n\t\t\t\t\t     ATK: {stats["ATK"]}       DEF:{stats["DEF"]}       SPD: {stats["SPD"]}\t");
                    Console.WriteLine("\t\t\t\t----------------------------------------------------------");

                    Console.WriteLine();

                    Console.WriteLine($"\t\t\t\t\t\t[ENEMY] {enemyName[level - 1]}'s Stats\t");
                    Console.WriteLine("\t\t\t\t----------------------------------------------------------");
                    Console.Write($"\n\t\t\t\t HP: {enemyCurrentHP}/{enemy["HP"]}  ");

                    for (int i = 0; i < (enemyCurrentHP / 5); i++)
                    {
                        if (enemyCurrentHP < enemy["HP"] / 7)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("█");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("█");
                        }

                        if (i > 37)
                        {
                            break;
                        }

                    }

                    Console.ResetColor();
                    Console.WriteLine($"\n\n\t\t\t\t    ATK: {enemy["ATK"]}     DEF:{enemy["DEF"]}     SPD: {enemy["SPD"]}     ACC.: {lowestChance}%-{highestChance}%");
                    Console.Write("\t\t\t\t----------------------------------------------------------");

                    if (playerTurn == true)
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\tWhat would you like to do?");
                        Console.WriteLine("\n\t\t\t\t\t        [Attack]   [Heal]   [Flee]");
                        Console.Write("\n\t\t\t\t\t\tResponse:\t");
                        input = Console.ReadLine().ToLower();

                        switch (input)
                        {
                            case "attack":

                                Console.Clear();

                                while (true)
                                {
                                    chance = rnd.Next(1, 101);

                                    Console.WriteLine($"\n\n\n\n\t\t[{title}] {playerName}'s MOVE SET");
                                    Console.Write($"\n\t\tMP:\t{currentMP}/{stats["MP"]}  ");

                                    for (int i = 0; i < (currentMP / 5); i++)
                                    {
                                        if (currentMP < stats["MP"] / 7)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.Write("█");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("█");
                                        }
                                    }

                                    Console.ResetColor();
                                    Console.WriteLine("\n\n\t\t----------------------------------------------------------------------------------");
                                    Console.WriteLine($"\t\t||\t\t\t\t\t\t\t\t\t\t||");
                                    Console.WriteLine($"\t\t||\tMOVE\t\t\tPOWER\t\tMP COST\t\tACC.\t\t||");
                                    Console.WriteLine($"\t\t||\t{move[0]}\t\t\t{moveset[move[0]][0]}\t\t{moveset[move[0]][1]}\t\t{moveset[move[0]][2]}\t\t||");
                                    Console.WriteLine($"\t\t||\t{move[1]}\t\t\t{moveset[move[1]][0]}\t\t{moveset[move[1]][1]}\t\t{moveset[move[1]][2]}\t\t||");
                                    Console.WriteLine($"\t\t||\t{move[2]}\t\t{moveset[move[2]][0]}\t\t{moveset[move[2]][1]}\t\t{moveset[move[2]][2]}\t\t||");
                                    Console.WriteLine($"\t\t||\t\t\t\t\t\t\t\t\t\t||");
                                    Console.WriteLine("\t\t----------------------------------------------------------------------------------");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write("\n\t\tYou try to attack using\t");
                                    input = Console.ReadLine().ToUpper();

                                    if (moveset.ContainsKey(input))
                                    {
                                        if (currentMP < moveset[input][1])
                                        {
                                            Console.WriteLine($"\n\t\tYou have insufficient MP to use this attack.");
                                            Console.ReadKey();

                                        }
                                        else if (currentMP > moveset[input][1])
                                        {
                                            Console.WriteLine($"\n\t\tYou used {moveset[input][1]} MP to attack.");
                                            currentMP -= moveset[input][1];

                                            if (currentMP <= 0)
                                            {
                                                currentMP = 0;
                                            }

                                            //result of the attack
                                            if (moveset[input][2] >= chance)
                                            {
                                                chance = rnd.Next(6, 15) * 10;

                                                if (stats["SPD"] > chance && round < 2)
                                                {
                                                    Console.WriteLine($"\n\t\tYou landed a critical hit!");
                                                    dmg = ((moveset[input][0] + stats["ATK"]) * 2) - enemy["DEF"];
                                                    round++;
                                                }
                                                else
                                                {
                                                    dmg = (moveset[input][0] + stats["ATK"]) - enemy["DEF"];
                                                    round = 0;
                                                }

                                                if (dmg < 0)
                                                {
                                                    dmg = 0;
                                                }

                                                Console.Write($"\n\t\tYou managed to deal {dmg} DMG on the enemy");
                                                enemyCurrentHP -= dmg;


                                            }
                                            else if (moveset[input][2] < chance)
                                            {
                                                Console.Write("\n\t\tHowever, you MISSED!");
                                            }

                                            break;
                                        }

                                    }
                                    else
                                    {
                                        Console.Write("\n\t\tYour brain is feeling fuzzy. You need to concentrate.");
                                        Console.ReadKey();
                                    }

                                    Console.Clear();
                                }

                                Console.ReadKey();
                                playerTurn = false;
                                enemyTurn = true;

                                break;

                            case "heal":

                                restore = (int)(rnd.Next(stats["HP"] - currentHP) * (.5 + buff));

                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t        _____" +
                                    "\r\n\t\t\t\t\t\t        `.___,'" +
                                    "\r\n\t\t\t\t\t\t         (___)" +
                                    "\r\n\t\t\t\t\t\t         <   >" +
                                    "\r\n\t\t\t\t\t\t          ) (" +
                                    "\r\n\t\t\t\t\t\t         /`-.\\" +
                                    "\r\n\t\t\t\t\t\t        /     \\" +
                                    "\r\n\t\t\t\t\t\t       / _    _\\" +
                                    "\r\n\t\t\t\t\t\t      :,' `-.' `:" +
                                    "\r\n\t\t\t\t\t\t      |         |" +
                                    "\r\n\t\t\t\t\t\t      :         ;" +
                                    "\r\n\t\t\t\t\t\t       \\       /" +
                                    "\r\n\t\t\t\t\t\t        `.___.'");
                                Console.Write($"\n\n\t\t\t\t    You drank the potion and RESTORED {restore} of your HP");
                                Console.ReadKey();

                                currentHP += restore;

                                if (currentHP > stats["HP"])
                                {
                                    currentHP = stats["HP"];
                                }

                                playerTurn = false;
                                enemyTurn = true;

                                break;

                            case "flee":

                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\t                _" +
                                    "\r\n\t\t\t\t\t\t              _( }" +
                                    "\r\n\t\t\t\t\t\t    -=   _  <<  \\" +
                                    "\r\n\t\t\t\t\t\t        `.\\__/`/\\\\" +
                                    "\r\n\t\t\t\t\t\t  -=      '--'\\\\  `" +
                                    "\r\n\t\t\t\t\t\t       -=     //" +
                                    "\r\n\t\t\t\t\t\t   jgs        \\)");
                                Console.Write($"\n\n\t\t\t\t\t  Like a COWARD, you FLED the battlefield");
                                Console.ReadKey();

                                currentHP = 0;
                                battle = false;
                                endGame = true;

                                break;

                            default:

                                Console.Write("\n\t\t\t\t   Your brain is feeling fuzzy. You need to concentrate.");
                                Console.ReadKey();

                                break;

                        }

                        Console.Clear();
                    }

                    if (enemyTurn == true)
                    {
                        Console.Clear();
                        //enemy turn
                        if (enemyCurrentHP < 0)
                        {
                            level++;

                            //end conditions
                            if (level > 3)
                            {
                                battle = false;
                                endGame = true;
                                break;
                            }

                            playerTurn = true;
                            enemyTurn = false;

                            Console.WriteLine("\n\n\t\t\t\t   _________________________________________________________" +
                            "\r\n\t\t\t\t /|     -_-                                             _-  |\\" +
                            "\r\n\t\t\t\t/ |_-_- _                                         -_- _-   -| \\   " +
                            "\r\n\t\t\t\t  |                            _-  _--                      | " +
                            "\r\n\t\t\t\t  |                            ,                            |" +
                            "\r\n\t\t\t\t  |      .-'````````'.        '(`        .-'```````'-.      |" +
                            "\r\n\t\t\t\t  |    .` |           `.      `)'      .` |           `.    |          " +
                            "\r\n\t\t\t\t  |   /   |   ()        \\      U      /   |    ()       \\   |" +
                            "\r\n\t\t\t\t  |  |    |    ;         | o   T   o |    |    ;         |  |" +
                            "\r\n\t\t\t\t  |  |    |     ;        |  .  |  .  |    |    ;         |  |" +
                            "\r\n\t\t\t\t  |  |    |     ;        |   . | .   |    |    ;         |  |" +
                            "\r\n\t\t\t\t  |  |    |     ;        |    .|.    |    |    ;         |  |" +
                            "\r\n\t\t\t\t  |  |    |____;_________|     |     |    |____;_________|  |  " +
                            "\r\n\t\t\t\t  |  |   /  __ ;   -     |     !     |   /     `'() _ -  |  |" +
                            "\r\n\t\t\t\t  |  |  / __  ()        -|        -  |  /  __--      -   |  |" +
                            "\r\n\t\t\t\t  |  | /        __-- _   |   _- _ -  | /        __--_    |  |" +
                            "\r\n\t\t\t\t  |__|/__________________|___________|/__________________|__|" +
                            "\r\n\t\t\t\t /                                             _ -        lc \\" +
                            "\r\n\t\t\t\t/   -_- _ -             _- _---                       -_-  -_ \\");
                            Console.Write("\n\n\t\t\t\t    You have eliminated the enemy. Press any key to continue!");


                            enemyCurrentHP = enemy["HP"];
                            currentMP += (int)((stats["MP"] - currentMP) * (.2 + mpRestore));

                            if (currentMP > stats["MP"])
                            {
                                currentMP = stats["MP"];
                            }

                            Console.ReadKey();
                            break;
                        }
                        else if (enemyCurrentHP > 0)
                        {
                            Console.WriteLine("\n\n\t\t\t\t            _.------.                        .----.__" +
                                "\r\n\t\t\t\t           /         \\_.       ._           /---.__  \\" +
                                "\r\n\t\t\t\t          |  O    O   |\\\\___  //|          /       `\\ |" +
                                "\r\n\t\t\t\t          |  .vvvvv.  | )   `(/ |         | o     o  \\|" +
                                "\r\n\t\t\t\t          /  |     |  |/      \\ |  /|   ./| .vvvvv.  |\\" +
                                "\r\n\t\t\t\t         /   `^^^^^'  / _   _  `|_ ||  / /| |     |  | \\" +
                                "\r\n\t\t\t\t       ./  /|         | O)  O   ) \\|| //' | `^vvvv'  |/\\\\" +
                                "\r\n\t\t\t\t      /   / |         \\        /  | | ~   \\          |  \\\\" +
                                "\r\n\t\t\t\t      \\  /  |        / \\ Y   /'   | \\     |          |   ~" +
                                "\r\n\t\t\t\t       `'   |  _     |  `._/' |   |  \\     7        /" +
                                "\r\n\t\t\t\t         _.-'-' `-'-'|  |`-._/   /    \\ _ /    .    |" +
                                "\r\n\t\t\t\t    __.-'            \\  \\   .   / \\_.  \\ -|_/\\/ `--.|_" +
                                "\r\n\t\t\t\t --'                  \\  \\ |   /    |  |              `-" +
                                "\r\n\t\t\t\t                       \\uU \\UU/     |  /   :F_P:");

                            Console.WriteLine("\n\n\t\t\t\t\t            It's the enemy's turn.");
                            chance = rnd.Next(1, 101);
                            int index = rnd.Next(0, 3);

                            if (enemyMove[index][1] > chance)
                            {
                                chance = rnd.Next(6, 15) * 10;

                                if (stats["SPD"] > chance)
                                {
                                    Console.Write($"\n\t\t\t\t\t            They landed a CRITICAL HIT!");
                                    dmg = ((enemyMove[index][0] + enemy["ATK"]) * 2) - stats["DEF"];
                                }
                                else
                                {
                                    dmg = (enemyMove[index][0] + enemy["ATK"]) - stats["DEF"];
                                }

                                if (dmg < 0)
                                {
                                    dmg = 0;
                                }

                                Console.Write($"\n\n\t\t\t\t           The enemy managed to deal {dmg} DMG on you");
                                currentHP -= dmg;

                            }
                            else
                            {
                                Console.Write("\n\n\t\t\t\t                      The enemy MISSED!");
                            }

                            enemyTurn = false;
                            playerTurn = true;
                            int hits = enemy["HP"] - enemyCurrentHP;
                            totalDMG += hits;

                            Console.ReadKey();
                        }

                    }

                    //if it happened during turn
                    if (currentHP < 0)
                    {
                        endGame = true;
                        break;
                    }

                    Console.Clear();
                }

                Console.Clear();
            }

            if (level > 3 && enemyCurrentHP < 0)
            {
                Console.WriteLine("\n\n\t\t\t\t       /\\         /\\                    .           /\\" +
                    "\r\n\t\t\t\t      /  \\       /  \\                   |@>        /  \\" +
                    "\r\n\t\t\t\t     /    \\     / .  \\                  |         /    \\" +
                    "\r\n\t\t\t\t    /      \\   /  |@> \\       /\\       / \\       /      \\" +
                    "\r\n\t\t\t\t   /     /\\ \\ /   |    \\     /  \\     /   \\     /        \\" +
                    "\r\n\t\t\t\t  /     /  \\ /  _ | _   \\   /    \\    | O |    /          _   _   _" +
                    "\r\n\t\t\t\t /     /    \\  |_|_|_|   \\ /      \\   |___|   /          | |_| |_| |" +
                    "\r\n\t\t\t\t/     /      \\  | O |     /        \\  | |_|  /      /\\   |         |" +
                    "\r\n\t\t\t\t    _   _   _ \\ |___|    /          \\ |__|| /      /  \\  |  O   O  |" +
                    "\r\n\t\t\t\t   | |_| |_| |  | |_|   /             | |_|       /    \\ |   __ _  |" +
                    "\r\n\t\t\t\t   |         |  |__||  /              |_| |      /       |     |   |" +
                    "\r\n\t\t\t\t   | O  O  O |  | |_| /               |__ |     /        | O  O  O |" +
                    "\r\n\t\t\t\t   |  _      |  _   _   _        ______   |   _   _   _  |  _      |" +
                    "\r\n\t\t\t\t   | |__|_ | |_| |_| |_| |______|      |_____| |_| |_| |_| |__|_ |_|" +
                    "\r\n\t\t\t\t   |  |   _| |        _  |  | _|  ____     _||        _  |  |    | |" +
                    "\r\n\t\t\t\t   |   _| _  ||_|   _|_  | _|_   |||||| |_| _||_|   _|_  |   _| _| |" +
                    "\r\n\t\t\t\t   |  __|  |_|  |_       | | |__ |++++|   |_||  |_      ||  __|  |_|" +
                    "\r\n\t\t\t\t   |_________|___________|-------------------|___________|_________|");
                Console.WriteLine("\n\t\t\t\t\t     Congratulations! You have defeated the Evil Warlord! " +
                    "\n\t\t\t\t\t              Now, everyone can live peacefully.\n\n");

            }
            else if (currentHP < 0)
            {
                Console.WriteLine("\n\n\n\t\t\t\t\t\t             ___          " +
                    "\r\n\t\t\t\t\t\t            /   \\\\        " +
                    "\r\n\t\t\t\t\t\t       /\\\\ | . . \\\\       " +
                    "\r\n\t\t\t\t\t\t     ////\\\\|     ||       " +
                    "\r\n\t\t\t\t\t\t   ////   \\\\ ___//\\       " +
                    "\r\n\t\t\t\t\t\t  ///      \\\\      \\      " +
                    "\r\n\t\t\t\t\t\t ///       |\\\\      |     " +
                    "\r\n\t\t\t\t\t\t//         | \\\\  \\   \\    " +
                    "\r\n\t\t\t\t\t\t/          |  \\\\  \\   \\   " +
                    "\r\n\t\t\t\t\t\t           |   \\\\ /   /   " +
                    "\r\n\t\t\t\t\t\t           |    \\/   /    " +
                    "\r\n\t\t\t\t\t\t           |     \\\\/|     " +
                    "\r\n\t\t\t\t\t\t           |      \\\\|     " +
                    "\r\n\t\t\t\t\t\t           |       \\\\     " +
                    "\r\n\t\t\t\t\t\t           |        |     " +
                    "\r\n\t\t\t\t\t\t           |_________\\    ");
                Console.Write("\n\n\t\t\t\t\t\t             YOU DIED!!!\n\n");
            }
            else if (currentHP == 0)
            {
                Console.WriteLine("\n\n\n\n\n\t\t\t\t                     __,-~~/~    `---." +
                    "\r\n\t\t\t\t                   _/_,---(      ,    )" +
                    "\r\n\t\t\t\t               __ /        <    /   )  \\___" +
                    "\r\n\t\t\t\t- ------===;;;'====------------------===;;;===----- -  -" +
                    "\r\n\t\t\t\t                  \\/  ~\"~\"~\"~\"~\"~\\~\"~)~\"/" +
                    "\r\n\t\t\t\t                  (_ (   \\  (     >    \\)" +
                    "\r\n\t\t\t\t                   \\_( _ <         >_>'" +
                    "\r\n\t\t\t\t                      ~ `-i' ::>|--\"" +
                    "\r\n\t\t\t\t                          I;|.|.|" +
                    "\r\n\t\t\t\t                         <|i::|i|`." +
                    "\r\n\t\t\t\t                        (` ^'\"`-' \")");
                Console.Write("\n\n\t\t                Your cowardiness led to the destructionn of the kingdom...\n\n");

            }

            Console.ReadKey();
            Console.Clear();

            //stores the score
            List <string> score = new List<string>();

            //reads the record from the file
            using (StreamReader sr = new StreamReader("scoreboard.txt"))
            {
                string player = "";

                while ((player = sr.ReadLine()) != null)
                {
                    score.Add(player);  
                }
            }

            //displays the scores
            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\tSCOREBOARD");

            for (int x = 0; x < score.Count; x++)
            {
                Console.WriteLine($"\n\n\t\t\t\t\t\t\t{x+1}. {score[x]}");
            }

            //adds in the latest score
            using (StreamWriter sw = new StreamWriter("scoreboard.txt", true))
            {
                //computation of the score
                int num = ((currentHP) * (round)) + totalDMG;

                if (totalDMG == 0 && input == "flee")
                {
                    num = 0;
                }

                sw.WriteLine($"{playerName} - {num}");

                Console.WriteLine($"\n\n\n\t\t\t\t\t\tLatest Score: {playerName} - {num}");
            }

            Console.Write("\t\t\t\t\t\t");
            Console.ReadKey();
        }
    }
}
