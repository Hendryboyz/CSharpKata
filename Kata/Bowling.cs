using System;

namespace Kata
{
    public class Bowling
    {
        private int[] scoreBoard = new int[21];
        private int rollIndex;
        private int frameStart = 0;
        private int currentFrame = 1;
        private readonly int NUM_OF_FRAME = 10;

        public int Scores()
        {
            int scores = 0;
            for (int boardIndex = 0, frame = 1; frame <= NUM_OF_FRAME; frame++)
            {
                int rollInFrame = 2;
                if (scoreBoard[boardIndex] == 10)
                {
                    int bonus = scoreBoard[boardIndex + 1] + scoreBoard[boardIndex + 2];
                    scores += scoreBoard[boardIndex] + bonus;
                    rollInFrame = 1;
                }
                else if (scoreBoard[boardIndex] + scoreBoard[boardIndex + 1] == 10)
                {
                    int bonus = scoreBoard[boardIndex + 2];
                    scores += scoreBoard[boardIndex] + scoreBoard[boardIndex + 1] + bonus;
                }
                else
                {
                    scores += GetNormalScores(boardIndex);
                }
                boardIndex += rollInFrame;
            }
            return scores;
        }

        private int GetNormalScores(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1];
        }

        public void Roll(int pins)
        {
            if (pins > 10)
            {
                throw new InvalidOperationException();
            }
            scoreBoard[rollIndex] = pins;

            if (scoreBoard[frameStart] + scoreBoard[frameStart+1] > 10)
            {
                throw new InvalidOperationException();
            }

            if (currentFrame < 10)
            {
                rollIndex++;
                if (pins == 10 || rollIndex > frameStart + 1)
                {
                    frameStart = rollIndex;
                    currentFrame += 1;
                }
            }
            else
            {
                if (scoreBoard[frameStart] == 10 && rollIndex < frameStart + 3)
                {
                    rollIndex++;
                }
                else if(scoreBoard[frameStart] + scoreBoard[frameStart + 1] == 10 && rollIndex < frameStart + 3)
                {
                    rollIndex++;
                }
                else if (rollIndex < frameStart + 2)
                {
                    rollIndex++;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
