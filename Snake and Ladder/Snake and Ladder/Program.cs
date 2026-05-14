using System;

class SnakeLadderFull
{
    static void Main()
    {
        // UC1: Start position
        int player1 = 0;
        int player2 = 0;

        int currentPlayer = 1;

        // UC6: Dice count
        int diceCount = 0;

        Random random = new Random();

        Console.WriteLine("Snake and Ladder - 2 Player Game Started!");

        // UC4: Repeat till someone reaches 100
        while (player1 < 100 && player2 < 100)
        {
            // UC2: Roll dice
            int dice = random.Next(1, 7);

            // UC3: Option
            int option = random.Next(0, 3); // 0=NoPlay,1=Ladder,2=Snake

            diceCount++;

            Console.WriteLine("\nPlayer " + currentPlayer + " rolled: " + dice);

            int tempPosition;

            if (currentPlayer == 1)
                tempPosition = player1;
            else
                tempPosition = player2;

            // UC3: switch-case logic
            switch (option)
            {
                case 0:
                    Console.WriteLine("No Play");
                    break;

                case 1:
                    Console.WriteLine("Ladder");
                    tempPosition += dice;
                    break;

                case 2:
                    Console.WriteLine("Snake");
                    tempPosition -= dice;
                    break;
            }

            // UC4: Reset if < 0
            if (tempPosition < 0)
                tempPosition = 0;

            // UC5: Exact 100 rule
            if (tempPosition <= 100)
            {
                if (currentPlayer == 1)
                    player1 = tempPosition;
                else
                    player2 = tempPosition;
            }

            // UC6: Display positions
            Console.WriteLine("P1: " + player1 + " | P2: " + player2);

            // UC7: If Ladder → same player plays again
            if (option != 1)
            {
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
        }

        // UC7: Winner
        if (player1 == 100)
            Console.WriteLine("\n Player 1 Wins!");
        else
            Console.WriteLine("\n Player 2 Wins!");

        Console.WriteLine("Total Dice Rolls: " + diceCount);
    }
}