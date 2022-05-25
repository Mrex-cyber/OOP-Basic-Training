namespace OOPTraining
{
    class Bread
    {
        public int Weight { get; set; } // масса
        
    }  
    class Butter
    {
        public int Weight { get; set; } // масса
        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich { Weight = bread.Weight + butter.Weight };
        }
    }   
    class Sandwich
    {
        public int Weight { get; set; } // масса             
    }

}
