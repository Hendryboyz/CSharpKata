using System;

namespace Kata
{
    public class Bowling
    {
        private readonly int NUM_OF_FRAME = 10;
        private readonly int NUM_OF_PINS = 10;
        private int[] scoreBoard = new int[22];
        private int rollIndex;
        private int frameStart;
        private int frame = 1;

        public void Roll(int pins)
        {
            ArgumentValidation(pins);
            scoreBoard[rollIndex++] = pins;
            SummarizeFrame(pins);
        }

        private void ArgumentValidation(int pins)
        {
            if (pins > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
        }

        private void SummarizeFrame(int pins)
        {
            bool isLastFrame = frame == NUM_OF_FRAME;
            if (!isLastFrame)
            {
                SummarizeNormalFrame(pins);
            }
            else
            {
                if (!IsValidRollInLastFrame())
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void SummarizeNormalFrame(int pins)
        {
            if (GetNormalScores(frameStart) > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
            bool isFrameFinished = pins == 10 || rollIndex > frameStart + 1;
            if (isFrameFinished)
            {
                frameStart = rollIndex;
                frame++;
            }
        }

        private bool IsValidRollInLastFrame()
        {
            return (IsStrike(frameStart) && rollIndex <= frameStart + 3) ||
                   (IsSpare(frameStart) && rollIndex <= frameStart + 3) ||
                   rollIndex <= frameStart + 2;
        }

        public int GetScores()
        {
            int scores = 0;
            for (int boardIndex = 0, frame = 1; frame <= NUM_OF_FRAME; frame++)
            {
                int rollTimes = 2;
                if (IsStrike(boardIndex))
                {
                    int bonus = scoreBoard[boardIndex + 1] + scoreBoard[boardIndex + 2];
                    scores += NUM_OF_PINS + bonus;
                    rollTimes = 1;
                }
                else if (IsSpare(boardIndex))
                {
                    int bonus = scoreBoard[boardIndex + 2];
                    scores += NUM_OF_PINS + bonus;
                }
                else
                {
                    scores += GetNormalScores(boardIndex);
                }
                boardIndex += rollTimes;
            }
            return scores;
        }

        private bool IsStrike(int boardIndex)
        {
            return scoreBoard[boardIndex] == NUM_OF_PINS;
        }

        private bool IsSpare(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1] == NUM_OF_PINS;
        }

        private int GetNormalScores(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1];
        }
    }
}
