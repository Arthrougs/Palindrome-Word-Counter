using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Paragraph_Counter
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.Clear();
            bool shouldLoop = true;
            while(shouldLoop)
            {
                Console.WriteLine("Please enter a paragraph you would like to work with");
                var input = Console.ReadLine();
                input = input.ToLower();
                Console.Clear();

                int menuSelection = PrintMenu();
                Console.Clear();   

                switch(menuSelection)
                {
                    case 1:
                        CheckPalindromeWord(input);
                        break;
                    case 2:
                        CheckPalindromeSentance(input);
                        break;
                    case 3:
                        CheckUniqueWords(input);
                        break;
                    case 4:
                        CheckWordsWithLetter(input);
                        break;
                    default:
                        break;
                } 
            }  
        }

        //Checks to see what words are a palindrome within the given string type input.
        public static void CheckPalindromeWord(String input)
        {
            int palindromeCount = 0;

            //Remove special characters from paragraph - Regex replace with negated set of characters to only replace character outside of what is listed.
            input = Regex.Replace(input, "[^a-zA-Z ]+", "");

            //Count the ammount of Palindromes. Split at spaces to get individual words - See CheckPalindromeCount method
            palindromeCount = CheckPalindromeCount(input, ' ');
    
            Console.WriteLine("This Paragraph has "+ palindromeCount + " palindromes in it.");
        }

        //Checks to see what sentances are a palindrome within the given string type input.
        public static void CheckPalindromeSentance(String input)
        {
            int palindromeCount = 0;
            
            input = Regex.Replace(input, "[^a-zA-Z.]+", "");

            //Remove all spaces from the paragraph.
            input = input.Replace(" ", "");

            //Check Palindrome Count by splitting at periods to get full sentances.
            palindromeCount = CheckPalindromeCount(input, '.');
            Console.WriteLine("This Paragraph has "+ palindromeCount + " palindromes in it.");
        }

        //Finds all words within a paragraph and counts the occurance of each. Then list out each unique word found along with the amount of occurances.
        public static void CheckUniqueWords(String input)
        {
            //Key = indivudal word Value = the number of occurances of that word.
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            //Remove all non alphabetical characters
            input = Regex.Replace(input, "[^a-zA-Z ]+", "");

            //Loop through the input, splitting at spaces to get individual words.
            //If the words already exists add 1 to the value - if it does not, add a new key with a value of 1.
            foreach(String word in input.Split(" "))
            {
                if(!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 1);
                }
                else
                {
                    wordCount[word]++;
                }
            }
            printDictionary(wordCount);
        }

        //Prints out the key value pairing of the given dictionary.
        public static void printDictionary(Dictionary<string, int> d)
        {
            foreach(KeyValuePair<string, int> pair in d)
            {
                Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
            }
        }

        //Allows user to input a character - then it will return all the words that contain that letter.
        public static void CheckWordsWithLetter(String input)
        {
            bool shouldLoop = true;
            
            while(shouldLoop)
            {
                //Input handeling 
                Console.WriteLine("Please enter a letter - then I will list all the words that contain it: ");
                String letterInput = Console.ReadLine();
                letterInput = letterInput.ToLower();

                //Bool for checking that the input is a single character.
                var isCharacter = (letterInput.Length == 1);
                
                if(isCharacter)
                {
                    Console.WriteLine("Here is a list of words that contain the letter " + letterInput + ": ");
                    //Loop through paragraph splitting at spaces to get each word. If the word contains the letter list it.
                    foreach(string word in input.Split(' '))
                    {
                        if(word.Contains(letterInput))
                        {
                            //wordList.Add(word);
                            Console.Write(word + " ");
                        }
                    }
                    shouldLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a single character.");
                } 
                Console.WriteLine("");
            }
        }

        //Method for checking if the given input is a palindrome. Takes a char param to signify where it should cut off the input before checking.
        public static int CheckPalindromeCount(String input, char split)
        {

            int count = 0;
            //For each word in the input, split at the given split character.
            foreach(string word in input.Split(split))
            {
                bool isPalindrome = false;
                //Reverse the sttring - See Reverse String method
                String reversedString = ReverseString(word);

                //Makes sure the returned output isn't null or white space - and greater than 1. Then check if the word and reversedString are equal.
                if(!string.IsNullOrWhiteSpace(word) && word.Length > 1)
                {
                    isPalindrome = string.Equals(word, reversedString);
                }
                //If the word is a palindrome add to the palindrome count
                if(isPalindrome)
                {
                    count++;
                    //Console.Write(word + " ");
                }
            }
            Console.WriteLine("");
            return count;
        }

        //Take a given string then convert to an array of characters - Reverse the order of characters with Array.Reverse then create a new string out of it and return.
        public static String ReverseString(String s)
        {
            char[] letters = s.ToCharArray();
            Array.Reverse(letters);
            String reversedWord = new String(letters);

            return reversedWord;
        }

        //Print Menu and return the option selected.
        public static int PrintMenu()
        {
           var printMenu = true;
           var selection = 0;

           while(printMenu)
           {   
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check how many words are a palindrome in the paragraph.");
                Console.WriteLine("2. Check how many sentances are a palindrome in the paragraph.");
                Console.WriteLine("3. List a count of unique words in a paragraph.");
                Console.WriteLine("4. List all words in a paragraph that contain a specific letter.");

                
                var isInt = int.TryParse(Console.ReadLine(), out selection);

                if(isInt)
                {
                    if((selection >= 1) && (selection <= 4))
                    {
                        printMenu = false;
                    }
                    else
                    {
                    Console.WriteLine("Please enter a number 1-4."); 
                    }
                }
                else
                {
                    Console.WriteLine("Please enter and Interger between 1 and 4");
                }        
            } 
            return selection; 
        }      
    }
}

