using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BowlingBDD.Specs
{
    [Binding]
    public class ScoringSteps
    {
        private BowlingGame _bowlingGame;

        [Given(@"A bowling game")]
        public void GivenABowlingGame()
        {
            _bowlingGame = new BowlingGame();
            Assert.IsNotNull(_bowlingGame);
        }

//        [When(@"The bonus ball is a (.)")]
//        public void WhenTheBonusBallIsA(char p0)
//        {
//            _bowlingGame.AddBonusBall(p0);
//            Assert.AreEqual(p0, _bowlingGame.Frames.Last().BonusBall);
//        }

        [When(@"The bonus roll is (.)")]
        public void WhenTheBonusRollIs(char p0)
        {
            _bowlingGame.Roll(p0);
        }

        [When(@"The frame series is: X,X,X,X,X,X,X,X,X,X,X,X")]
        public void WhenTheFrameSeriesIsXXXXXXXXXXXX()
        {
            for (var i = 0; i < 12; i++ )
            {
                _bowlingGame.Roll('X');
            }
        }

        [When(@"All the frame scores are (.) and (.)")]
        public void WhenAllTheFrameScoresAreAnd(char p0, char p1)
        {
            for (var i = 0; i < 10; i++)
            {
                _bowlingGame.Roll(p0);
                _bowlingGame.Roll(p1);
            }
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            var score = _bowlingGame.GetScore();
            Assert.AreEqual(p0, score);
        }
    }

//    [Binding]
//    public class CustomTransforms
//    {
//        [StepArgumentTransformation(@"'(.*?)'")]
//        public char CharConvert(object someVal)
//    }
}
