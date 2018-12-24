using System;

namespace Kata
{
    public class Bowling
    {
        private readonly int NUM_OF_FRAME = 10;
        private int[] scoreBoard = new int[21];
        private int throwIndex = 0;
        private int frameStart = 0;
        private int currentFrame = 1;

        public int GetScores()
        {
            int scores = 0;
            for (int scoreIndex = 0, frame = 0; frame < NUM_OF_FRAME; frame++)
            {
                int rollInFrame = 2;
                if (IsStrike(scoreIndex))
                {
                    int bonus = scoreBoard[scoreIndex + 1] + scoreBoard[scoreIndex + 2];
                    scores += scoreBoard[scoreIndex] + bonus;
                    rollInFrame = 1;
                }
                else if (IsSpare(scoreIndex))
                {
                    int bonus = scoreBoard[scoreIndex + 2];
                    scores += GetNormalScores(scoreIndex) + bonus;
                }
                else
                {
                    scores += GetNormalScores(scoreIndex);
                }
                scoreIndex += rollInFrame;
            }
            return scores;
        }

        private int GetNormalScores(int scoreIndex)
        {
            return scoreBoard[scoreIndex] + scoreBoard[scoreIndex + 1];
        }

        private bool IsStrike(int scoreIndex)
        {
            return scoreBoard[scoreIndex] == 10;
        }

        private bool IsSpare(int scoreIndex)
        {
            return scoreBoard[scoreIndex] + scoreBoard[scoreIndex + 1] == 10;
        }

        public void Roll(int pins)
        {
            if (pins > 10)
            {
                throw new InvalidOperationException();
            }
            scoreBoard[throwIndex++] = pins;

            if (scoreBoard[frameStart] + scoreBoard[frameStart + 1] > 10)
            {
                throw new InvalidOperationException();
            }

            if (pins == 10  || throwIndex > frameStart + 1)
            {
                if (currentFrame < 10)
                {
                    currentFrame++;
                    frameStart = throwIndex;
                }
            }
        }
    }
}
