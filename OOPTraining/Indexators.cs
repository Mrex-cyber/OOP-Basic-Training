namespace OOPTraining
{
    class Footballer
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Footballer() { }
        public Footballer(string name, int num)
        {
            Name = name;
            Number = num;
        }
    }

    class FootballTeam
    {
        Footballer[] team = new Footballer[11];
        public FootballTeam() { }
        public FootballTeam(Footballer[] team)
        {
            this.team = team;
        }

        public Footballer this [int i]
        {
            get 
            {
                if (i >= 0 && i < team.Length) return team[i];
                else return null;
            }
            set
            {
                if (i >= 0 && i < team.Length) team[i] = value;
            }
        }
    }

    class Word
    {
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }
    class Dictionary
    {
        Word[] words;
        public Dictionary()
        {
            words = new Word[]
            {
            new Word("red", "Червоний"),
            new Word("blue", "Синiй"),
            new Word("green", "Зелений")
            };
        }

        public string this[string source]
        {            
            get
            {
                Word target = null;
                foreach (Word word in words)
                {
                    if (word.Source == source)
                    {
                        target = word;
                        break;
                    }
                }
                return target?.Target;
            }
            set
            {
                foreach (Word word in words)
                {
                    if (word.Source == source)
                    {
                        word.Target = value;
                        break;
                    }
                }
            }
        }
    }
}
