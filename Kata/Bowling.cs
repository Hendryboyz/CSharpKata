using System;

namespace Kata
{
    public class Bowling
    {
        private readonly int NUM_OF_PINS = 10;
        private readonly int NUM_OF_FRAME = 10;
        private int[] scoreBoard = new int[22];
        private int rollTimes;
        private int frameStart;
        private int frame = 1;

        public void Roll(int pins)
        {
            PinValidation(pins);
            scoreBoard[rollTimes++] = pins;
            SummaryFrame(pins);
        }

        private void PinValidation(int pins)
        {
            if (pins > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
        }

        private void SummaryFrame(int pins)
        {
            if (frame < NUM_OF_FRAME)
            {
                NormalSummary(pins);
            }
            else
            {
                if (!IsValidRollInLastFrame())
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void NormalSummary(int pins)
        {
            if (GetNormalScores(frameStart) > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
            if (pins == 10 || rollTimes > frameStart + 1)
            {
                frameStart = rollTimes;
                frame++;
            }
        }

        private bool IsValidRollInLastFrame()
        {
            if (IsStrike(frameStart) && rollTimes <= frameStart + 3)
            {
                return true;
            }
            else if (IsSpare(frameStart) && rollTimes <= frameStart + 3)
            {
                return true;
            }
            else if (rollTimes <= frameStart + 2)
            {
                return true;
            }
            return false;
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
                    scores += NUM_OF_PINS + bonus;
                    rollInFrame = 1;
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
                boardIndex += rollInFrame;
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
