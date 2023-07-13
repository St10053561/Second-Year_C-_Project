using System;

namespace POE_Project
{
    public class Project
    {
        public static void Main(string[] args)
        {
            //I link the here in this program to run
            Recipe show = new Recipe();

            string text = @"
                         __          __  _                            _______          
                         \ \        / / | |                          |__   __|         
                          \ \  /\  / /__| | ___ ___  _ __ ___   ___     | | ___        
                           \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \    | |/ _ \       
                            \  /\  /  __/ | (_| (_) | | | | | |  __/    | | (_) |      
                             \/  \/_\___|_|\___\___/|_| |_| |_|\___|    |_|\___/       

                                  |  __ \         (_)                /\                
                                  | |__) |___  ___ _ _ __   ___     /  \   _ __  _ __  
                                  |  _  // _ \/ __| | '_ \ / _ \   / /\ \ | '_ \| '_ \ 
                                  | | \ \  __/ (__| | |_) |  __/  / ____ \| |_) | |_) |
                                  |_|  \_\___|\___|_| .__/ \___| /_/    \_\ .__/| .__/ 
                                                    | |                   | |   | |    
                                                    |_|                   |_|   |_|    
";
            Console.ForegroundColor = ConsoleColor.Blue; // Set the console text color to green
            Console.WriteLine(text);
            
            Console.ResetColor();
            Console.WriteLine("*".PadLeft(120, '*'));
            // Welcome message to the user
            show.Menu();
            Console.ReadKey();


        }
    }
}
