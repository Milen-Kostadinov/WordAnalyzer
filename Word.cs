namespace WordAnalyzer
{
    internal class Word
    {
        private int amount;
        private String word;
        public String getWord { get { return word; } }
        public int Amount 
        { 
            get { return amount; }
            set { amount = value; } 
        }
        public Word() { }
        public Word(String word) 
        {
            amount = 1;
            this.word = word;
        }
    }
}
