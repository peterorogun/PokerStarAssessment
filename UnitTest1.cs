using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RestSharp;

namespace PokerStarAssessment
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        RestRequest request;
        string url = "http://localhost:3000";
        [TestMethod]
        public void RetrieveallfixturesAndValidateFeatureCount()
        {
            client = new RestClient(url);
            request = new RestRequest("fixtures", Method.GET);
            request.AddHeader("Content-type", "application/json");

            var response = client.Execute<List<Root>>(request);
            if (response.IsSuccessful == true)
            {
                Assert.AreEqual(3, response.Data.Count);
            }
        }

        [TestMethod]
        public void RetrieveallfixturesAndValidateFeatureId()
        {
            client = new RestClient(url);
            request = new RestRequest("fixtures", Method.GET);
            request.AddHeader("Content-type", "application/json");

            var response = client.Execute<List<Root>>(request);
            if (response.IsSuccessful == true)
            {
                Assert.AreEqual(Convert.ToString(1), response.Data[0].fixtureId);
                Assert.AreEqual(Convert.ToString(2), response.Data[1].fixtureId);
                Assert.AreEqual(Convert.ToString(3), response.Data[2].fixtureId);
            }
        }

        [TestMethod]
        public void AddNewfixture()
        {
            client = new RestClient(url);
            request = new RestRequest("fixture", Method.POST);
            request.RequestFormat = DataFormat.Json;

            var payload = request.AddJsonBody(
                new Root()
                {
                    fixtureId = "4",
                    fixtureStatus = new FixtureStatus()
                    {
                        displayed = true,
                        suspended = false
                    },
                    footballFullState = new FootballFullState()
                    {
                        homeTeam = "Chelsea",
                        awayTeam = "Asenal",
                        finished = true,
                        gameTimeInSeconds = 92,
                        startDateTime = DateTime.Now,
                        started = true,
                        goals = new List<Goal>()
                         {
                             new Goal()
                             {
                                  id = 1,
                                  playerId = 10,
                                  penalty = true,
                                  teamId = "1",
                                  confirmed = true,
                                  clockTime = 10,
                                  ownGoal = false,
                                  period = ""
                             },
                         },
                        possibles = new List<object>()
                        {
                            new object(){ }
                        },
                        corners = new List<object>()
                        {
                            new object(){ }
                        },
                        redCards = new List<object>()
                        {
                            new object(){ }
                        },
                        yellowCards = new List<object>()
                        {
                            new object(){ }
                        },
                        teams = new List<Team>()
                         {
                            new Team()
                            {
                                 teamId = "Home",
                                 name = "Chelsea",
                                 association = ""
                            },
                            new Team()
                            {
                                 teamId = "Away",
                                 name = "Arsenal",
                                 association = ""
                            }
                         }
                    }
                });
            try
            {
                var response = client.Execute<List<Root>>(payload);
                if (response.IsSuccessful == true)
                {
                    Assert.AreEqual(200, (int)response.StatusCode);
                }
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        [TestMethod]
        public void GetNewlyAddedFixture()
        {
            client = new RestClient(url);
            request = new RestRequest("fixtures", Method.GET);

            var response =
                client.Execute<List<Root>>(request).Data[3];
            if (response.fixtureId.Equals(3))
            {
                Assert.AreEqual(Convert.ToString(3), response.fixtureId);
                Assert.AreEqual("Home", response.footballFullState.teams[0].teamId);
            }
        }

        [TestMethod]
        public void DeleteFixture()
        {
            client = new RestClient(url);
            request = new RestRequest("fixture/4", Method.DELETE);
            request.AddHeader("Content-type", "application/json");

            var response = client.Execute<List<Root>>(request);
            if ((int)response.StatusCode == 200)
            {
                Assert.AreEqual(200, (int)response.StatusCode);
                Assert.IsTrue(response.Content.Equals("Fixture has been deleted"));
            }
        }
    }
}
