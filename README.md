# Palindrome-Word-Counter

<h2>How it works</h2>
  This program runs as a terminal application.
  
  Once the program is started, the user will be prompted to enter a paragraph that they would like to work with. 
  After giving input the user will then be prompted to select one of four menu options.
  
  Each menu option corrisponds with the following task:
  
  <ul>
  <li>Give the number of palindrome words</li>
  <li>Give the number of palindrome sentences</li>
  <li>List the unique words of a paragraph with the count of the word instance</li>
  <li>Let the user also input a letter and list all words containing that letter</li>
  </ul>

<h2>Methods</h2>
  The following section will give a brief description of the methods and how they are used within this program.
  
  <h3>CheckPalindromeWord</h3>
    Accepts string input and formats to remove any special characters IE: periods, commas. It then sends the input string to a method for palindrome checking.
    Also specifies what character to split at for the CheckPalindromeCount method.
  
  <h3>CheckPalindromeSetnance</h3>
    Accepts string input and calls the CheckPalindromeCount method, specifying that it splits the string on every period.
  
  <h3>CheckUniqueWord</h3>
    Accepts string input and formats the string to remove any special characters. Uses a dictionary to keep track of unique words and the amount of times they occur in a key-value pair.
  
  <h3>CheckWordsWithLetter</h3>
    Accepts string input, then allows the user to input a letter to check how many words occur in the paragraph with the specified letter.
    
  <h3>CheckPalindromeCount</h3>
    Accepts string and character parameters. The character parameter is used to split the input string into sections that can be used for palindrome checking. In the case of a space, individual words will be checked. In the case of a period full sentances will be checked.
  
  <h3>ReverseString</h3>
    Accepts string input and returns a reversed version of that string.
    
  <h3>PrintMenu</h3>
    Prints out menu selection options and returns the options to the calling method. Utilizes Tryparse to convert the input to a string and prevent format and overflow exceptions.

<h2>How to run</h2>

Download and unzip the repository. 

You can run a .exe file from the Paragraph Counter/bin/Debug/netcoreapp3.1 folder called Paragraph Counter.exe

OR

Open the folder in VScode or alternativly you can open a command prompt within the folder. Bring up the terminal within VSCode - or in Windows command prompt while in the programs directory, type: <strong>dotnet run</strong>

This method requires the .NET Core SDK which can be downloaded here if needed: https://dotnet.microsoft.com/download
