using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Paragraph_Counter
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a paragraph you would like to work with");
            var input = Console.ReadLine();
            input = input.ToLower();
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

        //Checks to see if string is Palindrome - Currently will fall if there is a special character in a word IE: racecar!
        public static void CheckPalindromeWord(String input)
        {
            int palindromeCount = 0;

            //Remove special characters from paragraph - Regex replace with negated set of characters to only replace character outside of what is listed.
            input = Regex.Replace(input, "[^a-zA-Z ]+", "");

            //Count the ammount of Palindromes - See CheckPalindromeCount method
            palindromeCount = CheckPalindromeCount(input, ' ');
    
            Console.WriteLine("This Paragraph has "+ palindromeCount + " palindromes in it.");
        }

        public static void CheckPalindromeSentance(String input)
        {
            int palindromeCount = 0;
            
            input = input.Replace(" ", "");
            Console.WriteLine(input);
            palindromeCount = CheckPalindromeCount(input, '.');
            Console.WriteLine("This Paragraph has "+ palindromeCount + " palindromes in it.");
        }

        public static void CheckUniqueWords(String input)
        {
               //Map may be best for this one 
        }

        public static void CheckWordsWithLetter(String input)
        {
            bool shouldLoop = true;
            
            while(shouldLoop)
            {
                Console.WriteLine("Please enter a letter - then I will list all the words that contain it: ");
                String letterInput = Console.ReadLine();
                letterInput = letterInput.ToLower();
                var isCharacter = (letterInput.Length == 1);
                
                if(isCharacter)
                {
                    Console.WriteLine("Here is a list of words that contain the letter " + letterInput + ": ");
                    foreach(string word in input.Split(' '))
                    {
                        if(word.Contains(letterInput))
                        {
                            //wordList.Add(word);
                            Console.Write(word + " - "); //<---- Fix here so a '-' doesn't always apear at the end
                        }
                    }
                    shouldLoop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a single character.");
                } 
            }
        }


        public static int CheckPalindromeCount(String input, char split)
        {

            int count = 0;
            foreach(string word in input.Split(split))
            {
                bool isPalindrome = false;
                String reversedString = ReverseString(word);
                if(!string.IsNullOrWhiteSpace(word))
                {
                    isPalindrome = string.Equals(word, reversedString);
                }
                //If the word is a palindrome add to the palindrome count
                if(isPalindrome)
                {
                    count++;
                }
            }
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
                Console.WriteLine("1. Check if word is a palindrome.");
                Console.WriteLine("2. Check if a sentance is a palindrome.");
                Console.WriteLine("3. List count of unique words in a paragraph.");
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

