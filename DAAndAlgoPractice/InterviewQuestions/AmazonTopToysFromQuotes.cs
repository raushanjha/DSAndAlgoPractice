using System;
using System.Collections.Generic;
using System.Linq;

//You work on a team whose job is to understand the most sought after toys for the holiday season.
// A teammate of yours has built a webcrawler that extracts a list of quotes about toys from different articles.
//You need to take these quotes and identify which toys are mentioned most frequently.
//Write an algorithm that identifies the top N toys out of a list of quotes and list of toys.
//Your algorithm should output the top N toys mentioned most frequently in the quotes.

//Input:
//The input to the function/method consists of five arguments:

//numToys, an integer representing the number of toys
//topToys, an integer representing the number of top toys your algorithm needs to return;
//toys, a list of strings representing the toys,
//numQuotes, an integer representing the number of quotes about toys;
//quotes, a list of strings that consists of space-sperated words representing articles about toys

//Output:
//Return a list of strings of the most popular N toys in order of most to least frequently mentioned

//Note:
//The comparison of strings is case-insensitive.If the value of topToys is more than the number of toys, 
//return the names of only the toys mentioned in the quotes.If toys are mentioned an equal number of times in quotes, sort alphabetically.
namespace DAAndAlgoPractice.DALogic
{
    public class AmazonTopToysFromQuotes
    {
        class ToyWordStats
        {
            public string toyWord;
            public int toyWordCount;
            public HashSet<int> quoteIds;

            public ToyWordStats(string inToyWord, int inToyWordCount)
            {
                this.toyWord = inToyWord;
                this.toyWordCount = inToyWordCount;
                this.quoteIds = new HashSet<int>(); // hashSet is required to have unique QuoteId 
            }
        }


        public static void Processor()
        {
            int numToys = 6;
            int topToys = 2;
            List<string> toys = new List<string>() { "elmo", "elsa", "legos", "drone", "tablet", "warcraft" };
            int numQuotes = 6;
            List<string> quotes = new List<string>() {
            "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
            "The new Elmo dolls are super high quality",
            "Expect the Elsa dolls to be very popular this year, Elsa!",
            "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
            "For parents of older kids, look into buying them a drone",
            "Warcraft is slowly rising in popularity ahead of the holiday season"
            };

            var returnValue = PopularNToys(numToys, topToys, toys, numQuotes, quotes);
        }


        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        private static List<string> PopularNToys(int numToys,
                                         int topToys,
                                         List<string> toys,
                                         int numQuotes, List<string> quotes)
        {
            // WRITE YOUR CODE HERE
            HashSet<string> setToys = new HashSet<string>();
            IDictionary<string, ToyWordStats> toyWordDict = new Dictionary<string, ToyWordStats>();

            for (int i = 0; i < numToys; i++)
            {
                setToys.Add(toys[i]);
            }

            string[] specialChars = { "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "[", "]", "\\", "\\\\", ".", ",", "~", "?", "!", ";", ":" }; // we have to ignore these from the list

            // let's create the map words to put the word occurance
            for (int i = 0; i < numQuotes; i++) // forloop: BEGINS outer
            { 

                String q = quotes[i];

                // let's remove the special characters which doesn't count in word
                for (int cIn = 0; cIn < specialChars.Length; cIn++)
                {
                    q = q.Replace(specialChars[cIn], "");
                }

                q = q.ToLower();

                string[] toyWordsArray = q.Split(' ');
                // now let's split the words in quote and check for toys count
                for (int w = 0; w < toyWordsArray.Length; w++)
                {  // forloop BEGING

                    string toyWord = toyWordsArray[w];

                    // if in toys' list this contains then & only then process further // it will be case insensitive
                    if (setToys.Contains(toyWord, StringComparer.InvariantCultureIgnoreCase))
                    {
                        ToyWordStats stats;

                        if (toyWordDict.ContainsKey(toyWord))
                        {
                            stats = toyWordDict[toyWord];
                        }
                        else
                        {
                            stats = new ToyWordStats(toyWord, 0);
                        }

                        stats.toyWordCount++;
                        stats.quoteIds.Add(i);

                        // let's update the toyWord's status
                        toyWordDict[toyWord] = stats;
                    }
                }  // forloop ENDS

            } // // forloop: ENDS outer

            // now process for output
            string[] outputString = new string[toyWordDict.Count];

            int index = 0;
            foreach (var wouter in toyWordDict)
            {
                var maxCount = wouter.Value.toyWordCount;
                outputString[index] = wouter.Key;

                foreach (var w in toyWordDict)
                {
                    if (maxCount < w.Value.toyWordCount && !outputString.Contains(w.Key))
                    {
                        outputString[index] = w.Key;
                    }
                }

                //
                index++;
            }


            List<string> res = new List<string>(); // it will be used to return result
            // let's fill the result
            if (topToys > toyWordDict.Count)
            {
                foreach (var str in outputString)
                {
                    res.Add(str);
                }
            }
            else
            {
                for (int i1 = 0; i1 < topToys; i1++)
                {
                    res.Add(outputString[i1]);
                }
            }

            //
            return res;
        }
        // METHOD SIGNATURE ENDS
    }

}
