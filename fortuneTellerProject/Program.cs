using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fortuneTellerProject {
    class Program {
        static bool continueFlag = true;
        static bool eventFlag = true;
        static bool tryAgain = true;
        static string userInput;
        static string firstName;
        static string lastName;
        static string fullName;
        static int age;
        static string birthMonth;
        static string color;
        static int siblings;
        static string retireYears;
        static string moneyBank;
        static string location;
        static string transport;
        static string[] roygbiv = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

        static string UppercaseFirst(string s) { //changes first character in input to upercase
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void beginning(bool beginningFlag) {
            if (beginningFlag) { //the beginning of the encounter. Will not repeat
                Console.WriteLine("You walk up to a machine. It reads in bold and eye-catching letters \"ZOLTAR SPEAKS\". A fortune teller arcade machine.");
                Console.ReadKey();
                Console.WriteLine("You stare at the fortune teller machine. It suddenly shouts \a \"ENTER A COIN TO BE WORTHY TO SPEAK TO ME! ZOLTAR!\"");
                Console.WriteLine("Do you enter a coin? y/n");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "y") {
                    Console.WriteLine("Zoltar shouts \"AT ANYTIME, YOU MAY SAY \"Restart\" TO BEGIN YOUR FORTUNE AGAIN. YOU MAY ALSO \"Quit\" AS WELL!\"");
                    continueFlag = true;
                } else {
                    Console.WriteLine("Zoltar shouts \"YOU ARE NOT WORTHY! LEAVE MY PRESENCE!\"");
                    continueFlag = false;
                    eventFlag = false;
                }
            }
        }

        static void leaveRestart(string leaveRestartInput) { //checks if the user wants to leave or restart
            if (leaveRestartInput == "quit") {
                Console.WriteLine("You turn to leave. As you are walking away, you hear zoltar murmur \"No one likes a quitter\".");
                continueFlag = false;
                eventFlag = false;
            } else if (leaveRestartInput == "restart") {
                startFortune();
            }
        }

        static void startFortune() { //The body of the fortune
            while (true) {
                eventFlag = true;
                continueFlag = true;

                Console.WriteLine("After a brief pause... \nZoltar: \"WHAT IS YOUR FIRST NAME?\"");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                string firstName = UppercaseFirst(userInput);

                Console.WriteLine("Zoltar shouts \"WHAT IS YOUR LAST NAME?\"");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                string lastName = UppercaseFirst(userInput);

                Console.WriteLine("Zoltar shouts \"WHAT IS YOUR AGE?\"");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                bool isNumeric = int.TryParse(userInput, out age);
                if (isNumeric) {
                    if (age % 2 == 0) {
                        retireYears = "retire in 40 years";
                    } else {
                        retireYears = "retire in 32 years";
                    }
                } else {
                    retireYears = "never retire";
                }

                Console.WriteLine("Zoltar shouts \"WHAT MONTH WERE YOU BORN IN?\"");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                string birthMonth = UppercaseFirst(userInput);
                string birthMonthCompare = birthMonth.ToLower();
                string birthMonthFirstLetter = birthMonthCompare.Substring(0, 1);
                string birthMonthSecondLetter = birthMonthCompare.Substring(1, 1);
                string birthMonthThirdLetter = birthMonthCompare.Substring(2, 1);
                fullName = firstName + " " + lastName;
                string fullNameLowercase = fullName.ToLower();
                switch (birthMonth) { //catch if the user didn't input a month correctly
                    case "January":
                    case "February":
                    case "March":
                    case "April":
                    case "May":
                    case "June":
                    case "July":
                    case "August":
                    case "September":
                    case "October":
                    case "November":
                    case "December":
                        if (fullNameLowercase.IndexOf(birthMonthFirstLetter) != -1)  {
                            moneyBank = "$10,000,000";
                        } else if (fullNameLowercase.IndexOf(birthMonthSecondLetter) != -1) {
                            moneyBank = "$2,000,000";
                        } else if (fullNameLowercase.IndexOf(birthMonthThirdLetter) != -1) {
                            moneyBank = "$800,000";
                        } else {
                            moneyBank = "$500,000";
                        }
                        break;
                    default:
                        moneyBank = "nothing";
                        break;
                }

                Console.WriteLine("Zoltar shouts \"WHAT IS YOUR FAVORITE ROYGBIV COLOR?\nIF YOU DON'T KNOW WHAT ROYGBIV IS, SAY \"Help\"\".");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                if (userInput == "help") { //help text
                    Console.WriteLine("ROYGBIV ARE COLORS OF THE RAINBOW! HERE IS A LIST!");
                    foreach (string rainbow in roygbiv)
                        Console.WriteLine(rainbow.ToUpper());

                    Console.WriteLine("I ASK AGAIN! WHAT IS YOUR FAVORITE COLOR?");
                    userInput = Console.ReadLine().ToLower();
                    leaveRestart(userInput);
                    if (continueFlag == false)
                        break;
                }
                string color = userInput;
                switch (color) {
                    case "r":
                    case "red":
                        transport = "a Bugatti";
                        break;

                    case "o":
                    case "orange":
                        transport = "a Tesla";
                        break;
                    
                    case "y":
                    case "yellow":
                        transport = "a Geoprism";
                        break;

                    case "g":
                    case "green":
                        transport = "a Yacht";
                        break;

                    case "b":
                    case "blue":
                        transport = "a Lamborgini";
                        break;

                    case "i":
                    case "indigo":
                        transport = "a Suzuki";
                        break;

                    case "v":
                    case "violet":
                        transport = "a private jet";
                        break;

                    default:
                        transport = "you will walk or swim to where ever you need to go";
                        break;
                }

                Console.WriteLine("Zoltar shouts \"HOW MANY SIBLINGS DO YOU HAVE?\".");
                userInput = Console.ReadLine().ToLower();
                leaveRestart(userInput);
                if (continueFlag == false)
                    break;
                isNumeric = int.TryParse(userInput, out siblings);
                if (isNumeric) {
                    switch (siblings) {
                        case 0:
                            location = "LA";
                            break;

                        case 1:
                            location = "Paris";
                            break;

                        case 2:
                            location = "Shanghai";
                            break;

                        case 3:
                            location = "New York City";
                            break;

                        default:
                            location = "Dubai";
                            break;
                    }
                } else {
                    location = "a garbage dump";
                }

                eventFlag = true;
                break;
            }
        }
        static void Main(string[] args) {
            beginning(tryAgain);
            if (continueFlag) {
                startFortune();
            }
            if (eventFlag) {
                Console.WriteLine("{0} will {1} with {2} in the bank, a vacation home in {3} and {4}.", fullName, retireYears, moneyBank, location, transport);
                Console.WriteLine("Zoltar shouts \"FOR ANOTHER FORTUNE, ENTER AN ADDITIONAL COIN!\"");
                Console.WriteLine("Do you enter a coin? y/n");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "y")  {
                    startFortune();
                } else {
                    Console.WriteLine("Zoltar shouts \"COME BACK TO ZOLTAR AGAIN IF YOU ARE UNSURE OF YOUR FUTURE!\"");
                    continueFlag = false;
                }
            }
            Console.ReadKey();
        }
    }
}