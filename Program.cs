using System.Diagnostics;

namespace WordAnalyzer
{
    internal static class Program
    {
        //Изводи:
        //Когато всяка отделна задача бъде изпълнена поотделно нещата се случват по бързо, дори и линейния алгоритъм за
        //изпълнение да бъде максимално оптимизиран.




        private static WordList words = new WordList();
        private static String specialSymbols = "_-<>,:;{}[]#@.!?$\"'\\|abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMOPQRSTUVXYZ";
        static void Main()
        {
            //create and record words
            int charsInWords = 0;
            String book = File.ReadAllText("C:\\Users\\User\\source\\repos\\WordAnalyzer\\WordAnalyzer\\Lynn-Flewelling_-_Skritijat_voin_-_11895-b.txt");
            List<char> chars = new List<char>();
            String word = "";
            for (int i = 0; i < book.Length; i++) 
            {
                if (specialSymbols.Contains(book[i])) continue;
                if (Char.IsWhiteSpace(book[i])) 
                {
                    if (word.Length > 3 && !words.Contains(word.ToLower()))
                    {
                        words.addWord(word);
                        charsInWords += word.Length;
                    }
                    word = "";
                }
                else word += book[i];
                if (!chars.Contains(book[i]))
                {
                    chars.Add(book[i]);
                }
            }
            var watch = new Stopwatch();
            //Threaded version

            //1.The number of words
            Thread wordCount = new Thread(() =>
            {
                Console.WriteLine("Word count: " + words.Words.Count);
            });

            //2.The shortest word
            Thread shortestWord = new Thread(() => 
            {
                var watch = new Stopwatch();
                watch.Start();
                String word = words.Words[0].getWord;
                int lenght = words.Words[0].getWord.Length;
                Console.WriteLine();
                foreach (Word word1 in words.Words)
                {
                    if (word1.getWord.Length < lenght)
                    {
                        lenght = word1.getWord.Length;
                        word = word1.getWord;
                    }
                }
                Console.WriteLine("Shortest word: " + word);
                watch.Stop();
                Console.WriteLine("Execuution time: " + watch.Elapsed);
            });

            //3.The longest word
            Thread longestWord = new Thread(() =>
            {
                var watch = new Stopwatch();
                watch.Start();
                String word = "";
                int lenght = words.Words[0].getWord.Length;
                foreach (Word word1 in words.Words)
                {
                    if (word1.getWord.Length > lenght)
                    {
                        lenght = word1.getWord.Length;
                        word = word1.getWord;
                    }
                }
                Console.WriteLine("Longest word: " + word);
                watch.Stop();
                Console.WriteLine("Execuution time: " + watch.Elapsed);
            });

            //4.Average word length
            Thread averageLetters = new Thread(() =>
            {
                Console.WriteLine("Average word lenght: " + (float)charsInWords / words.Words.Count);
            });

            //5.Five most common words
            Thread fiveMostCommon = new Thread(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Word[] fiveMostCommon = { new Word(""), new Word(""), new Word(""), new Word(""), new Word("") };
                foreach (Word word1 in words.Words)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (word1.Amount > fiveMostCommon[i].Amount)
                        {
                            for (int j = i; j < 4; j++) 
                            {
                                fiveMostCommon[j+1] = fiveMostCommon[j];
                            }
                            fiveMostCommon[i] = word1;
                            break;
                        }
                    }
                }

                foreach (Word word2 in fiveMostCommon)
                {
                    Console.WriteLine(word2.getWord);
                }

                watch.Stop();
                Console.WriteLine("Execuution time: " + watch.Elapsed);
            });

            //6.Five most common words
            Thread fiveLeastCommon = new Thread(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Word[] fiveLeastCommon = { new Word(""), new Word(""), new Word(""), new Word(""), new Word("") };
                foreach (Word word1 in words.Words)
                {
                    for (int i = 4; i > 0; i--)
                    {
                        if (word1.Amount <= fiveLeastCommon[i].Amount)
                        {
                            if (i == 4)
                                fiveLeastCommon[i] = word1;
                            else
                            {
                                try
                                {
                                    Word temp = fiveLeastCommon[i + 1];
                                    fiveLeastCommon[i + 1] = fiveLeastCommon[i];
                                    fiveLeastCommon[i] = temp;
                                }
                                catch (IndexOutOfRangeException) { continue; }
                            }
                        }
                    }
                }

                foreach (Word word2 in fiveLeastCommon)
                {
                    Console.WriteLine(word2.getWord);
                }

                watch.Stop();
                Console.WriteLine("Execuution time: " + watch.Elapsed);
            });

            wordCount.Start();
            shortestWord.Start();
            longestWord.Start();
            averageLetters.Start();
            fiveMostCommon.Start();
            fiveLeastCommon.Start();

            Console.WriteLine("Press enter to continue to the non threaded execution.");
            Console.ReadLine();

            //Non threaded version
            watch.Start();
            words.sortWordsByAmount();
            //1.The number of words
            Console.WriteLine("Word count: " + words.Words.Count);
            //2.The shortest word
            Console.WriteLine("Shortest word: " + words.getShortestWord().getWord);
            //3.The longest word
            Console.WriteLine("Longest word: " + words.getLongestWord().getWord);
            //4.Average word length
            Console.WriteLine("Average word lenght: " + (float)charsInWords/words.Words.Count);
            //5.Five most common words
            Console.WriteLine("Five most common words are: ");
            foreach (Word wordInBook in words.getFiveMostCommon())
            {
                Console.WriteLine("     " + wordInBook.getWord + " " + wordInBook.Amount);
            }
            //6.Five most common words
            Console.WriteLine("Five least common words are: ");
            foreach (Word wordInBook in words.getFiveLeastCommon())
            {
                Console.WriteLine("     " + wordInBook.getWord + " " + wordInBook.Amount);
            }
            watch.Stop();
            Console.WriteLine("Elapsed time without threading: " + watch.Elapsed);
        }
    }

   /* $id = 11895
	$source = Моята библиотека

    __Издание:__
    Автор: Лин Флюълинг

    Заглавие: Скритият воин

    Преводач: Радин Григоров

    Година на превод: 2014
	Език, от който е преведено: английски(не е указано)

    Издание: първо(не е указано)

    Издател: MBG Books; Ем Би Джи Тойс ЕООД
    Град на издателя: София
    Година на издаване: 2014
	Тип: роман
    Националност: американска
    Печатница: „Мултипринт“ ООД
    Редактор: Елиза Чернева

    Коректор: Катрин Якимова

    ISBN: 978-954-2989-47-9
	Адрес в Библиоман: https://biblioman.chitanka.info/books/6562*/
}