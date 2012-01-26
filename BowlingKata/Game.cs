namespace BowlingKata {
	public class Game {
		private int[] rolls = new int[21];
		private int currentRoll = 0;

		public void Roll(int pins) {
			rolls[currentRoll++] = pins;
		}

		public int Score() {
			int score = 0;
			int frameIndex = 0;
			for (int frame = 0; frame < 10; frame++) {
				if (IsStrike(frameIndex))
				{
					score += 10 + strikeBonus(frameIndex);
					frameIndex++;
				}
				else if (IsSpare(frameIndex)) {
					score += 10 + spareBonus(frameIndex);
					frameIndex += 2;
				}
				else {
					score += sumOfBallsInFrame(frameIndex);
					frameIndex += 2;
				}
			}
			return score;
		}

		private bool IsStrike(int frameIndex) {
			return rolls[frameIndex] == 10;
		}

		private int sumOfBallsInFrame(int frameIndex) {
			return rolls[frameIndex] + rolls[frameIndex + 1];
		}

		private int spareBonus(int frameIndex) {
			return rolls[frameIndex + 2];
		}

		private int strikeBonus(int frameIndex) {
			return rolls[frameIndex + 1] + rolls[frameIndex + 2];
		}

		private bool IsSpare(int frameIndex) {
			return rolls[frameIndex] +
						 rolls[frameIndex + 1] == 10;
		}
	}
}
