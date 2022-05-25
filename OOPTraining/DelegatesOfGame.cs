namespace OOPTraining
{
    class DelegatesOfGame
    {
        
        public void HealingFromFriend<H>(ref double currentHealth, H healing)
        {
            try
            {
                currentHealth += Convert.ToDouble(healing);
            }
            catch (Exception)
            {
                Console.WriteLine("Friend can not healing!");
            }
            Console.WriteLine($"HEALTH after friend healing: {currentHealth}.");
        }
        public void HittingFromEnemy<H>(ref double currentHealth, H hit)
        {
            try
            {
                currentHealth -= Convert.ToDouble(hit);
            }
            catch (Exception)
            {
                Console.WriteLine("Enemy can not hit!");
            }
            Console.WriteLine($"HEALTH after hitting from enemy: {currentHealth}.");
        }
        public void HittingFromBoss<H>(ref double currentHealth, H hit)
        {
            try
            {
                currentHealth -= Convert.ToDouble(hit);
            }
            catch (Exception)
            {
                Console.WriteLine("Boss can not hit!");
            }
            Console.WriteLine($"HEALTH after hitting from Boss: {currentHealth}.");
        }        
    }    
    
}
