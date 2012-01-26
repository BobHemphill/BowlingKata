using NUnit.Framework;

namespace BowlingKata {
	[NUnit.Framework.TestFixture]
	public class GameTest {
		private Game g;

		[SetUp]
		public void SetupGame() {
			g = new Game();
		}

		[Test]
		public void GutterGame() {
			RollGame(20, 0);
			Assert.AreEqual(0, g.Score());
		}

		[Test]
		public void TestAllOnes() {
			RollGame(20, 1);
			Assert.AreEqual(20, g.Score());
		}

		[Test]
		public void TestSpare() {
			RollSpare();
			g.Roll(3);	
			RollGame(17, 0);
			Assert.AreEqual(16, g.Score());
		}

		[Test]
		public void TestStrike() {
			RollStrike();
			g.Roll(3);
			g.Roll(4);
			RollGame(16, 0);
			Assert.AreEqual(24, g.Score());
		}

		[Test]
		public void TestPerfectGame() {
			RollGame(12, 10);
			Assert.AreEqual(300, g.Score());
		}

		private void RollStrike() {
			g.Roll(10);
		}

		private void RollSpare() {
			g.Roll(5);
			g.Roll(5);
		}

		private void RollGame(int rolls, int pins) {
			for (int i = 0; i < rolls; i++) {
				g.Roll(pins);
			}
		}
	}
}
