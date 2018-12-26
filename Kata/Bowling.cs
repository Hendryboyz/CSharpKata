using System;

namespace Kata
{
    public class Bowling
    {
        private readonly int NUM_OF_FRAME = 10;
        private int[] scoreBoard = new int[22];
        private int rollTimes = 0;
        private int frameStart = 0;
        private int frame = 1;

        public void Roll(int pins)
        {
            if (pins > 10)
            {
                throw new InvalidOperationException();
            }

            scoreBoard[rollTimes] = pins;

            if (frame < 10)
            {
                rollTimes++;
                if (scoreBoard[frameStart] + scoreBoard[frameStart + 1] > 10)
                {
                    throw new InvalidOperationException();
                }
                if (IsStrike(frameStart) || rollTimes > frameStart + 1)
                {
                    frameStart = rollTimes;
                    frame++;
                }
            }
            else
            {
                if (IsStrike(frameStart) && rollTimes <= frameStart + 2)
                {
                    rollTimes++;
                }
                else if (IsSpare(frameStart) && rollTimes <= frameStart + 2)
                {
                    rollTimes++;
                }
                else if (rollTimes <= frameStart + 1)
                {
                    rollTimes++;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int GetScores()
        {
            int scores = 0;
            for (int boardIndex = 0, frame = 1; frame <= NUM_OF_FRAME; frame++)
            {
                int rollInFrame = 2;
                if (IsStrike(boardIndex))
                {
                    int bonus = scoreBoard[boardIndex + 1] + scoreBoard[boardIndex + 2];
                    scores += scoreBoard[boardIndex] + bonus;
                    rollInFrame = 1;
                }
                else if (IsSpare(boardIndex))
                {
                    int bonus = scoreBoard[boardIndex + 2];
                    scores += GetStandardScores(boardIndex) + scoreBoard[boardIndex + 2];
                }
                else
                {
                    scores += GetStandardScores(boardIndex);
                }
                boardIndex += rollInFrame;
            }
            return scores;
        }

        private int GetStandardScores(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1];
        }

        private bool IsSpare(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1] == 10;
        }

        private bool IsStrike(int boardIndex)
        {
            return scoreBoard[boardIndex] == 10;
        }
    }
}
