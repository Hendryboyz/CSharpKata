using System;

namespace Kata
{
    public class Bowling
    {
        private int[] scoreBoard = new int[22];
        private int rollIndex;
        private int frameStart;
        private int frame = 1;
        private readonly int NUM_OF_PINS = 10;
        private readonly int NUM_OF_FRAMES = 10;

        public void Roll(int pins)
        {
            PinValidation(pins);
            scoreBoard[rollIndex++] = pins;
            SummarizeFrame(pins);
        }

        private void SummarizeFrame(int pins)
        {
            if (frame < NUM_OF_FRAMES)
            {
                SummarizeNomarlFrame(pins);
            }
            else
            {
                if (!IsLastFrameValidRoll())
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void PinValidation(int pins)
        {
            if (pins > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
        }

        private void SummarizeNomarlFrame(int pins)
        {
            if (GetNormalScores(frameStart) > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
            if (pins == 10 || rollIndex > frameStart + 1)
            {
                frameStart = rollIndex;
                frame++;
            }
        }

        private bool IsLastFrameValidRoll()
        {
            if (IsStrike(frameStart) && rollIndex <= frameStart + 3)
            {
                return true;
            }
            else if (IsSpare(frameStart) && rollIndex <= frameStart + 3)
            {
                return true;
            }
            else if (rollIndex <= frameStart + 2)
            {
                return true;
            }
            return false;
        }

        public int GetScores()
        {
            int scores = 0;
            for (int boardIndex = 0, frame = 1; frame <= 10; frame++)
            {
                scores += CalculateScores(boardIndex);
                boardIndex += GetRollInFrame(boardIndex);
            }
            return scores;
        }

        private int CalculateScores(int boardIndex)
        {
            if (IsStrike(boardIndex))
            {
                int bonus = scoreBoard[boardIndex + 1] + scoreBoard[boardIndex + 2];
                return 10 + bonus;
            }
            else if (IsSpare(boardIndex))
            {
                int bonus = scoreBoard[boardIndex + 2];
                return 10 + bonus;
            }
            else
            {
                return GetNormalScores(boardIndex);
            }
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

        private int GetRollInFrame(int boardIndex)
        {
            if (IsStrike(boardIndex))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
