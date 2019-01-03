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
            RollValidation(pins);
            scoreBoard[rollIndex++] = pins;
            SummarizeFrame(pins);
        }

        private void RollValidation(int pins)
        {
            if (pins > NUM_OF_PINS)
            {
                throw new InvalidOperationException();
            }
        }

        private void SummarizeFrame(int pins)
        {
            if (frame < NUM_OF_FRAME)
            {
                SummarizeNormalFrame(pins);
            }
            else
            {
                if (!IsValidLastFrameRoll())
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void SummarizeNormalFrame(int pins)
        {
            if (scoreBoard[frameStart] + scoreBoard[frameStart + 1] > 10)
            {
                throw new InvalidOperationException();
            }
            if (pins == 10 || rollIndex > frameStart + 1)
            {
                frameStart = rollIndex;
                frame++;
            }
        }

        private bool IsValidLastFrameRoll()
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
            else
            {
                return false;
            }
        }

        public int GetScores()
        {
            int scores = 0;
            for (int boardIndex = 0, frame = 1; frame <= NUM_OF_FRAME; frame++)
            {
                int rollTimes = 2;
                if (IsStrike(boardIndex))
                {
                    scores += GetStrikeScores(boardIndex);
                    rollTimes = 1;
                }
                else if (IsSpare(boardIndex))
                {
                    scores += GetSpareScores(boardIndex);
                }
                else
                {
                    scores += GetFrameScores(boardIndex);
                }
                boardIndex += rollTimes;
            }
            return scores;
        }


        private bool IsStrike(int boardIndex)
        {
            return scoreBoard[boardIndex] == NUM_OF_PINS;
        }

        private int GetStrikeScores(int boardIndex)
        {
            int bonus = scoreBoard[boardIndex + 1] + scoreBoard[boardIndex + 2];
            return NUM_OF_PINS + bonus;
        }

        private bool IsSpare(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1] == NUM_OF_PINS;
        }

        private int GetSpareScores(int boardIndex)
        {
            int bonus = scoreBoard[boardIndex + 2];
            return GetFrameScores(boardIndex) + bonus;
        }

        private int GetFrameScores(int boardIndex)
        {
            return scoreBoard[boardIndex] + scoreBoard[boardIndex + 1];
        }
    }
}
