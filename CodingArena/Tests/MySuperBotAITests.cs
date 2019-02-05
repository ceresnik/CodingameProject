using System.Collections.Generic;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.TurnActions;
using Moq;
using NUnit.Framework;

namespace CodingArena.Tests
{
    [TestFixture]
    public class MySuperBotAITests
    {
        private MySuperBotAI sut;
        private IOwnBot ownBotMock;
        private IEnemy enemyMock;
        private IBattlefieldView battleFieldMock;
        private IReadOnlyCollection<IEnemy> enemiesCollection;

        [SetUp]
        public void SetUp()
        {
            sut = new MySuperBotAI();
            ownBotMock = new Mock<IOwnBot>().Object;
            enemyMock = new Mock<IEnemy>().Object;
            battleFieldMock = new Mock<IBattlefieldView>().Object;
            enemiesCollection = new List<IEnemy> {enemyMock};
        }

        [TearDown]
        public void TearDown()
        {
            ownBotMock = null;
            enemyMock = null;
            battleFieldMock = null;
            enemiesCollection = null;
            sut = null;
        }

        [Test]
        public void ReturnsTurnActionObject()
        {
            //act
            var result = sut.GetTurnAction(ownBotMock, enemiesCollection, battleFieldMock);
            //verify
            Assert.That(result, Is.Not.Null, "Calling the GetTurnAction() method must return not null object.");
        }

        [Test]
        public void WhenNoEnemy_ReturnsIdle()
        {
            var result = sut.GetTurnAction(ownBotMock, new List<IEnemy>(), battleFieldMock);
            Assert.IsInstanceOf(TurnAction.Idle().GetType(), result, 
                "When the list of enemies is empty, Idle action must be returned.");
        }

        [Test]
        public void WhenEnemysDistanceIsMoreThan9_MyBotMoves()
        {
            var battlefieldPlaceOfOwnBot = new Mock<IBattlefieldPlace>().Object;
            Mock.Get(battlefieldPlaceOfOwnBot).Setup(x => x.X).Returns(0);
            Mock.Get(battlefieldPlaceOfOwnBot).Setup(x => x.Y).Returns(0);
            Mock.Get(battleFieldMock).Setup(x => x[ownBotMock]).Returns(battlefieldPlaceOfOwnBot);
            var battlefieldPlaceOfEnemyBot = new Mock<IBattlefieldPlace>().Object;
            Mock.Get(battlefieldPlaceOfEnemyBot).Setup(x => x.X).Returns(10);
            Mock.Get(battlefieldPlaceOfEnemyBot).Setup(x => x.Y).Returns(0);
            Mock.Get(battleFieldMock).Setup(x => x[enemyMock]).Returns(battlefieldPlaceOfEnemyBot);
            var result = sut.GetTurnAction(ownBotMock, enemiesCollection, battleFieldMock);
            Assert.IsInstanceOf(TurnAction.Move.Towards(battlefieldPlaceOfOwnBot, battlefieldPlaceOfEnemyBot).GetType(), result,
                "When the distance to the enemy is 10, Move Towards action must be returned.");
        }
    }
}