namespace WordAnalyzer
{
    internal class WordList
    {
        private List<Word> words = new List<Word>();
        public List<Word> Words { get { return words; } }
        public WordList() { }
        public void addWord(String word)
        {
            words.Add(new Word(word.ToLower()));
        }
        public bool Contains(String wordIn)
        {
            foreach (Word word in words)
            {
                if (word.getWord.Equals(wordIn))
                {
                    word.Amount++;
                    return true;
                }
            }
            return false;
        }
        //bubble sort for sorting algo cuz I'm lazy
        public void sortWordsByAmount() 
        {
            for (int i = 0; i < words.Count; i++) 
            {
                for(int j = i; j < words.Count; j++) 
                {
                    if (words[i].Amount < words[j].Amount)
                    { 
                        Word tempWord = words[i];
                        words[i] = words[j];
                        words[j] = tempWord;    
                    }
                }
            }
        }
        public List<Word> getFiveMostCommon() 
        {
            List<Word> list = new List<Word>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(words[i]); 
            }
            return list;
        }
        public List<Word> getFiveLeastCommon()
        {
            List<Word> list = new List<Word>();
            for (int i = words.Count - 1; i > words.Count - 6; i--)
            {
                list.Add(words[i]);
            }
            return list;
        }
        public Word getLongestWord()
        {
            Word word = new Word();
            int lenght = words[0].getWord.Length;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].getWord.Length > lenght)
                {
                    word = words[i];
                    lenght = words[i].getWord.Length;
                }
            }
            return word;
        }
        //There will awlays be more than one word that is 4 characters so I CHOOSE to return only one of them, same goes for the maximum amount
        public Word getShortestWord() 
        {
            Word word = new Word();
            int lenght = words[0].getWord.Length;
            for (int i = 0; i < words.Count; i++) 
            {
                if (words[i].getWord.Length < lenght)
                { 
                    word = words[i];
                    lenght = words[i].getWord.Length;
                }
            }
            return word;
        }
    }
}
